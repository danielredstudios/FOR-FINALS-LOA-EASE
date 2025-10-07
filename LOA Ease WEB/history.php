<?php
session_start();
if (!isset($_SESSION['user_id'])) {
    header('Location: login.php');
    exit();
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Transaction History - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <style>
       .styled-card {
            background: rgba(255, 255, 255, 0.7); border-radius: 1.5rem; border: 1px solid rgba(255, 255, 255, 0.2);
            box-shadow: 0 8px 32px 0 rgba(0, 51, 102, 0.2); backdrop-filter: blur(25px); -webkit-backdrop-filter: blur(25px);
            animation: fadeInFromBottom 1s ease-out;
       }
       @keyframes fadeInFromBottom { from { opacity: 0; transform: translateY(40px) scale(0.95); } to { opacity: 1; transform: translateY(0) scale(1); } }
       body {
            font-family: 'Poppins', sans-serif;
            background: linear-gradient(-45deg, #eef2f7, #0055a4, #eef2f7, #003366);
            background-size: 400% 400%;
            animation: gradientBG 15s ease infinite;
       }
       @keyframes gradientBG { 0% { background-position: 0% 50%; } 50% { background-position: 100% 50%; } 100% { background-position: 0% 50%; } }
       .card-content { padding: 2.5rem; }
       .history-item { border-bottom: 1px solid #dee2e6; }
       .history-item:last-child { border-bottom: none; }

       @media (max-width: 768px) {
            .card-content {
                padding: 1.5rem;
            }
            .fw-bold {
                font-size: 1.25rem;
            }
            .history-item h5 {
                font-size: 1rem;
            }
            .history-item p, .history-item small {
                font-size: 0.9rem;
            }
       }
    </style>
</head>
<body>
    <div class="container py-5">
    <div class="styled-card" style="max-width: 800px; margin: auto;">
        <div class="card-content">
            <div class="d-flex justify-content-between align-items-center mb-4">
                <h3 class="mb-0 fw-bold">Transaction History</h3>
                <a href="dashboard.php" class="btn btn-outline-secondary btn-sm">
                    <i data-lucide="arrow-left" style="width:16px; height:16px;"></i> Back to Dashboard
                </a>
            </div>
            
            <div id="history-list" class="list-group">
                <div class="text-center p-5">
                    <div class="spinner-border text-primary" role="status"></div>
                    <p class="mt-3">Loading your history...</p>
                </div>
            </div>
        </div>
    </div>
    </div>

    <script>
        document.addEventListener('DOMContentLoaded', function() {
            const historyList = document.getElementById('history-list');

            fetch('api/get_history.php')
                .then(response => response.json())
                .then(data => {
                    historyList.innerHTML = '';
                    if (data.success && data.history.length > 0) {
                        data.history.forEach(ticket => {
                            const statusBadges = {
                                'waiting': { bg: 'secondary', text: 'Waiting' },
                                'scheduled': { bg: 'info', text: 'Scheduled' },
                                'serving': { bg: 'primary', text: 'Serving' },
                                'completed': { bg: 'success', text: 'Completed' },
                                'cancelled': { bg: 'danger', text: 'Cancelled' },
                                'no-show': { bg: 'warning', text: 'No-Show' }
                            };  
                            const statusInfo = statusBadges[ticket.status] || { bg: 'dark', text: 'Unknown' };

                            const item = document.createElement('div');
                            item.className = 'list-group-item list-group-item-action flex-column align-items-start p-3 history-item';
                            
                            const schedule = new Date(ticket.schedule_datetime);
                            const formattedSchedule = schedule.toLocaleString('en-US', { month: 'long', day: 'numeric', year: 'numeric', hour: 'numeric', minute: '2-digit', hour12: true });

                            item.innerHTML = `
                                <div class="d-flex w-100 justify-content-between">
                                    <h5 class="mb-1 fw-bold text-primary">${ticket.queue_number}</h5>
                                    <span class="badge bg-${statusInfo.bg}">${statusInfo.text}</span>
                                </div>
                                <p class="mb-1"><strong>Counter:</strong> ${ticket.counter_name}</p>
                                <p class="mb-1"><strong>Purpose:</strong> ${ticket.purpose}</p>
                                <small class="text-muted"><strong>Scheduled for:</strong> ${formattedSchedule}</small>
                            `;
                            historyList.appendChild(item);
                        });
                    } else {
                        historyList.innerHTML = `
                            <div class="text-center p-5">
                                <i data-lucide="folder-x" class="text-muted" style="width:64px; height:64px;"></i>
                                <h4 class="mt-3">No History Found</h4>
                                <p class="text-muted">You haven't created any queue tickets yet.</p>
                            </div>
                        `;
                    }
                    lucide.createIcons();
                })
                .catch(error => {
                    console.error('Error fetching history:', error);
                    historyList.innerHTML = '<div class="alert alert-danger">Could not load your transaction history.</div>';
                });
        });
        lucide.createIcons();
    </script>
</body>
</html>