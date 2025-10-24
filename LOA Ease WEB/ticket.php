<?php
require_once 'includes/db_connect.php';
session_start();
if (!isset($_SESSION['student_id'])) {
    header('Location: login.php');
    exit();
}

$student_id = $_SESSION['student_id'];
// This query now ONLY gets the active queue number.
// All other details will be fetched by the JavaScript to ensure consistency.
$stmt = $conn->prepare("
    SELECT q.queue_number
    FROM queues q
    WHERE q.student_id = ? AND q.status IN ('waiting', 'serving', 'scheduled')
    ORDER BY q.created_at DESC LIMIT 1
");
$stmt->bind_param("i", $student_id);
$stmt->execute();
$ticket = $stmt->get_result()->fetch_assoc();
$stmt->close();
$conn->close();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Your Ticket - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/fetch/3.6.2/fetch.min.js"></script>
    <style>
        :root {
            --loa-blue: #003366; --loa-yellow: #FFC72C; --loa-blue-light: #0055a4;
            --light-bg: #eef2f7; --dark-text: #212529; --card-bg: rgba(255, 255, 255, 0.7);
            --card-shadow: 0 8px 32px 0 rgba(0, 51, 102, 0.2); --font-family: 'Poppins', sans-serif;
        }
        body {
            font-family: var(--font-family); background: linear-gradient(-45deg, var(--light-bg), var(--loa-blue-light), var(--light-bg), var(--loa-blue));
            background-size: 400% 400%; animation: gradientBG 15s ease infinite; display: flex;
            justify-content: center; align-items: center; min-height: 100vh; padding: 2rem;
        }
        @keyframes gradientBG { 0% { background-position: 0% 50%; } 50% { background-position: 100% 50%; } 100% { background-position: 0% 50%; } }
        .styled-card {
            background: var(--card-bg); border-radius: 1.5rem; border: 1px solid rgba(255, 255, 255, 0.2);
            box-shadow: var(--card-shadow); backdrop-filter: blur(25px); -webkit-backdrop-filter: blur(25px);
            width: 100%; overflow: hidden; animation: fadeInFromBottom 1s ease-out;
        }
        @keyframes fadeInFromBottom { from { opacity: 0; transform: translateY(40px) scale(0.95); } to { opacity: 1; transform: translateY(0) scale(1); } }
        .card-content { padding: 2.5rem; }
        .purpose-item-container { padding-bottom: 0.75rem; margin-bottom: 0.75rem; border-bottom: 1px dotted #aab8c2; }
        .purpose-item-container:last-child { border-bottom: none; margin-bottom: 0; padding-bottom: 0; }
        .purpose-main-title { font-size: 1rem; font-weight: 500; display: block; color: var(--dark-text); }
        .purpose-sub-list { padding-left: 0.5rem; margin-top: 0.25rem; }
        .purpose-sub-item { display: block; color: #495057; font-size: 0.9rem; }
    </style>
</head>
<body>
    <div class="styled-card text-center" style="max-width: 500px;">
        <div class="card-content">
            <?php if ($ticket): ?>
                <div id="ticket-view-container">
                    <div class="text-center p-5">
                        <div class="spinner-border text-primary" role="status"></div>
                        <p class="mt-3 text-muted">Loading your ticket...</p>
                    </div>
                </div>
            <?php else: ?>
                <div class="text-center p-5">
                    <i data-lucide="ticket-x" class="text-muted" style="width: 80px; height: 80px;"></i>
                    <h3 class="mt-3">No Active Ticket</h3>
                    <p class="text-muted">You don't have a ticket yet. Get one from the dashboard.</p>
                    <a href="dashboard.php" class="btn btn-primary mt-3 d-inline-flex align-items-center"><i data-lucide="plus-circle" class="me-2"></i>Get a Ticket Now</a>
                </div>
            <?php endif; ?>
        </div>
    </div>

    <audio id="notification-sound" src="/Music/NotificationKiosk.mp3" preload="auto"></audio>

    <script>
        lucide.createIcons();

        if ('Notification' in window && Notification.permission !== "granted" && Notification.permission !== "denied") {
            Notification.requestPermission();
        }

        function showNotification(title, body) {
            if ('Notification' in window && Notification.permission === "granted") {
                new Notification(title, { body: body });
            }
        }

        <?php if ($ticket): ?>
        var queueNumber = "<?php echo $ticket['queue_number']; ?>";
        var viewContainer = document.getElementById('ticket-view-container');
        var notificationSound = document.getElementById('notification-sound');
        
        var currentTicketStatus = null;

        function updateTicketView(ticketData) {
            if (!ticketData) {
                viewContainer.innerHTML = '<div class="text-center p-5">' +
                    '<i data-lucide="ticket-check" class="text-success" style="width: 80px; height: 80px;"></i>' +
                    '<h3 class="mt-3">Ticket Processed</h3>' +
                    '<p class="text-muted">Your transaction is complete or has been cancelled.</p>' +
                    '<a href="dashboard.php" class="btn btn-primary mt-3 d-inline-flex align-items-center">Back to Dashboard</a>' +
                    '</div>';
                lucide.createIcons();
                return;
            }

            var status = ticketData.status;
            var queue_number = ticketData.queue_number;
            var counter_name = ticketData.counter_name;
            var schedule_datetime = ticketData.schedule_datetime;
            var purpose = ticketData.purpose;
            var created_at = ticketData.created_at;
            
            var badgeClass = '', badgeText = '', alertHTML = '', showEditButton = false;
            switch(status) {
                case 'scheduled':
                    badgeClass = 'bg-info'; badgeText = 'Scheduled';
                    alertHTML = '<div class="alert alert-warning mt-4"><strong>On your scheduled date,</strong> please check in at a kiosk to enter the queue.</div>';
                    showEditButton = true;
                    break;
                case 'waiting':
                    badgeClass = 'bg-primary'; badgeText = 'Waiting in Queue';
                    alertHTML = '<div class="alert alert-success mt-4"><strong>You are now in the queue!</strong> Please wait for your number to be called.</div>';
                    break;
                case 'serving':
                    badgeClass = 'bg-success'; badgeText = 'Now Serving';
                    alertHTML = '<div class="alert alert-success mt-4"><strong>Your number has been called!</strong> Please proceed to the counter.</div>';
                    break;
                default:
                    updateTicketView(null); 
                    return;
            }

            // Format Purposes
            var purposeHTML = '';
            var all_purposes = purpose.split(', ');
            var doc_requests = [];
            var other_purposes = [];
            
            for (var i = 0; i < all_purposes.length; i++) {
                if (all_purposes[i].indexOf('doc_req:') === 0) {
                    doc_requests.push(all_purposes[i].replace('doc_req:', ''));
                } else {
                    other_purposes.push(all_purposes[i]);
                }
            }

            if (doc_requests.length > 0) {
                purposeHTML += '<div class="purpose-item-container"><strong class="purpose-main-title">Document Request</strong><div class="purpose-sub-list">';
                for (var i = 0; i < doc_requests.length; i++) {
                    purposeHTML += '<span class="purpose-sub-item">- ' + doc_requests[i] + '</span>';
                }
                purposeHTML += '</div></div>';
            }
            
            for (var i = 0; i < other_purposes.length; i++) {
                purposeHTML += '<div class="purpose-item-container"><strong class="purpose-main-title">' + other_purposes[i] + '</strong></div>';
            }
            
            var scheduleDate = new Date(schedule_datetime).toLocaleDateString('en-US', { year: 'numeric', month: 'long', day: 'numeric' });

            viewContainer.innerHTML = 
                '<div class="mb-3"><span class="badge rounded-pill fs-6 ' + badgeClass + '">' + badgeText + '</span></div>' +
                '<h2 class="fw-bold mb-3">Your Queue Ticket</h2>' +
                '<div class="bg-light p-4 rounded-3 mb-4 border">' +
                    '<h1 class="display-1 fw-bolder text-primary mb-0">' + queue_number + '</h1>' +
                    '<p class="text-muted mb-0">Present this number or the QR code</p>' +
                '</div>' +
                '<img src="https://api.qrserver.com/v1/create-qr-code/?size=180x180&data=' + encodeURIComponent(queue_number) + '&qzone=1" alt="QR Code" class="img-fluid rounded-3">' +
                '<hr class="my-4">' +
                '<div class="text-start">' +
                    '<h5 class="fw-bold mb-3 text-center">Appointment Details</h5>' +
                    '<ul class="list-group list-group-flush">' +
                        '<li class="list-group-item d-flex align-items-center bg-transparent"><i data-lucide="landmark" class="me-3"></i><div><strong class="d-block">Counter/Office</strong>' + counter_name + '</div></li>' +
                        '<li class="list-group-item d-flex align-items-center bg-transparent"><i data-lucide="calendar-check" class="me-3"></i><div><strong class="d-block">Scheduled Date</strong>' + scheduleDate + '</div></li>' +
                        '<li class="list-group-item bg-transparent">' +
                            '<div class="d-flex align-items-center"><i data-lucide="edit" class="me-3"></i><strong class="d-block">Purpose(s)</strong></div>' +
                            '<div class="ps-4 ms-3 mt-2">' + purposeHTML + '</div>' +
                        '</li>' +
                    '</ul>' +
                '</div>' +
                alertHTML +
                '<div class="text-center mt-4">' +
                    (showEditButton ? '<a href="dashboard.php" class="btn btn-outline-secondary btn-sm"><i data-lucide="edit-3" style="width:14px; height:14px;"></i> Edit Ticket</a>' : '') +
                '</div>';
            
            lucide.createIcons();
        }

        function fetchTicketDetails() {
            fetch('api/get_ticket_details.php?queue_number=' + queueNumber)
               .then(function(res) {
                   if (!res.ok) {
                       throw new Error('Network response was not ok');
                   }
                   return res.json();
               })
               .then(function(data) {
                   if (data.success && ['scheduled', 'waiting', 'serving'].indexOf(data.ticket.status) !== -1) {
                       var newStatus = data.ticket.status;
                       if (currentTicketStatus === 'waiting' && newStatus === 'serving') {
                           if (notificationSound) {
                               notificationSound.play().catch(function(e) { console.error("Audio play failed", e); });
                           }
                           showNotification("It's your turn!", 'Your ticket ' + data.ticket.queue_number + ' is now being served.');
                       }
                       currentTicketStatus = newStatus; 

                       updateTicketView(data.ticket);
                   } else {
                       currentTicketStatus = null; 
                       updateTicketView(null);
                   }
               })
               .catch(function(error) {
                    console.error('Error fetching ticket details:', error);
                    currentTicketStatus = null;
                    updateTicketView(null);
               });
        }

        document.addEventListener('DOMContentLoaded', function() {
            if (notificationSound) {
                notificationSound.play().catch(function(e) { console.error("Audio play failed. User may need to interact with the page first."); });
            }

            fetchTicketDetails();
            setInterval(fetchTicketDetails, 5000);
        });
        <?php endif; ?>
    </script>
</body>
</html>