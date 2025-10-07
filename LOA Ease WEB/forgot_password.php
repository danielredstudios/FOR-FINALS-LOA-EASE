<?php
session_start();
if (!isset($_SESSION['user_id'])) {
    header("Location: login.php");
    exit();
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dashboard - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <link rel="stylesheet" href="styles.css">
    <style>
        .status-badge {
            font-size: 0.9rem;
            padding: 0.5em 0.8em;
        }
        .welcome-banner {
            background: linear-gradient(135deg, var(--loa-blue), var(--loa-blue-light));
            color: white;
            border-radius: 1rem;
            padding: 2rem;
            margin-bottom: 2rem;
        }
        @media (max-width: 768px) {
            .welcome-banner {
                padding: 1.5rem;
                text-align: center;
            }
            .display-4 {
                font-size: 2.5rem;
            }
        }
    </style>
</head>
<body>
    <?php include 'includes/header.php'; ?>

    <div class="container my-4">
        <div class="welcome-banner">
            <h1 class="display-4">Welcome, <?php echo htmlspecialchars($_SESSION['full_name']); ?>!</h1>
            <p class="lead">Here's a quick overview of your queuing status.</p>
        </div>

        <div class="row">
            <div class="col-lg-8 mb-4">
                <div class="modern-card h-100">
                    <div class="card-content">
                        <h3 class="mb-4">Live Queue Status</h3>
                        <div id="live-status-container"></div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 mb-4">
                <div class="modern-card h-100">
                    <div class="card-content">
                        <h3 class="mb-4">My Ticket</h3>
                        <div id="my-ticket-container"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <?php include 'includes/footer.php'; ?>

    <script>
        lucide.createIcons();

        function fetchLiveStatus() {
            fetch('api/get_live_status.php')
                .then(response => response.text())
                .then(data => {
                    document.getElementById('live-status-container').innerHTML = data;
                    lucide.createIcons();
                })
                .catch(error => console.error('Error fetching live status:', error));
        }

        function fetchMyTicketStatus() {
            fetch('api/get_my_ticket_status.php')
                .then(response => response.text())
                .then(data => {
                    document.getElementById('my-ticket-container').innerHTML = data;
                    lucide.createIcons();
                })
                .catch(error => console.error('Error fetching my ticket status:', error));
        }

        document.addEventListener('DOMContentLoaded', function() {
            fetchLiveStatus();
            fetchMyTicketStatus();
            setInterval(fetchLiveStatus, 5000); 
            setInterval(fetchMyTicketStatus, 5000);
        });
    </script>
</body>
</html>