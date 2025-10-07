<?php
require_once 'includes/db_connect.php';
session_start();

if (isset($_SESSION['user_id'])) {
    header("Location: dashboard.php");
    exit();
}

$token = $_GET['token'] ?? '';
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Reset Password - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <div class="container my-5">
        <div class="modern-card" style="max-width: 500px; margin: auto;">
            <div class="card-content">
                <div class="text-center mb-4">
                    <h2 class="fw-bold">Reset Your Password</h2>
                    <p class="text-muted">Enter and confirm your new password below.</p>
                </div>
                <div id="message"></div>
                <form id="resetPasswordForm">
                    <input type="hidden" name="token" value="<?php echo htmlspecialchars($token); ?>">
                    <div class="mb-3">
                        <label for="password" class="form-label">New Password</label>
                        <div class="input-group">
                            <span class="input-group-text"><i data-lucide="lock"></i></span>
                            <input type="password" class="form-control" id="password" name="password" placeholder="New password" required
                                   pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).{8,}"
                                   title="Must contain at least one number, one uppercase and lowercase letter, one special character, and at least 8 or more characters">
                        </div>
                    </div>
                    <div class="mb-4">
                        <label for="confirm_password" class="form-label">Confirm New Password</label>
                         <div class="input-group">
                            <span class="input-group-text"><i data-lucide="lock"></i></span>
                            <input type="password" class="form-control" id="confirm_password" name="confirm_password" placeholder="Confirm new password" required>
                        </div>
                    </div>
                    <div class="d-grid">
                        <button type="submit" class="btn-primary-modern">
                            <i data-lucide="save" class="me-2"></i>Reset Password
                        </button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <script>
        lucide.createIcons();

        document.getElementById('resetPasswordForm').addEventListener('submit', function(e) {
            e.preventDefault();
            const form = e.target;
            const formData = new FormData(form);
            const messageDiv = document.getElementById('message');
            const password = formData.get('password');
            const confirm_password = formData.get('confirm_password');

            if (password !== confirm_password) {
                messageDiv.innerHTML = `<div class="alert alert-warning">Passwords do not match.</div>`;
                return;
            }

            fetch('api/password_reset.php', {
                method: 'POST',
                body: formData
            })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    messageDiv.innerHTML = `<div class="alert alert-success">${data.message} You can now <a href="login.php">login</a>.</div>`;
                    form.reset();
                } else {
                    messageDiv.innerHTML = `<div class="alert alert-danger">${data.message}</div>`;
                }
            })
            .catch(error => {
                console.error('Error:', error);
                messageDiv.innerHTML = `<div class="alert alert-danger">An unexpected network error occurred.</div>`;
            });
        });
    </script>
</body>
</html>