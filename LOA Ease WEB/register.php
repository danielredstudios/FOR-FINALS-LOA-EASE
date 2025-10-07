<?php
require_once 'includes/db_connect.php';

$message = '';
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $student_number = trim($_POST['student_number']);
    $last_name = trim($_POST['last_name']);
    $first_name = trim($_POST['first_name']);
    $middle_initial = trim($_POST['middle_initial']);
    $course = trim($_POST['course']);
    $email = trim($_POST['email']);
    $username = trim($_POST['username']);
    $password = $_POST['password'];
    $visitor_queue_number = trim($_POST['visitor_queue_number']);

    if (empty($student_number) || empty($last_name) || empty($first_name) || empty($course) || empty($email) || empty($username) || empty($password)) {
        $message = '<div class="alert alert-warning d-flex align-items-center"><i data-lucide="alert-triangle" class="me-2"></i>All fields are required.</div>';
    } else {
        $password_hash = password_hash($password, PASSWORD_BCRYPT);
        
        $number_with_c = $student_number;
        $number_without_c = $student_number;

        if (strtoupper(substr($student_number, 0, 1)) === 'C') {
            $number_without_c = substr($student_number, 1);
        } else {
            $number_with_c = 'C' . $student_number;
        }

        $student_stmt = $conn->prepare("SELECT student_id FROM students WHERE student_number = ? OR student_number = ?");
        $student_stmt->bind_param("ss", $number_with_c, $number_without_c);
        $student_stmt->execute();
        $student_result = $student_stmt->get_result();

        if ($student_result->num_rows === 1) {
            $student_data = $student_result->fetch_assoc();
            $student_id = $student_data['student_id'];

            if (!empty($visitor_queue_number)) {
                $visitor_stmt = $conn->prepare("SELECT visitor_id FROM queues WHERE queue_number = ? AND visitor_id IS NOT NULL LIMIT 1");
                $visitor_stmt->bind_param("s", $visitor_queue_number);
                $visitor_stmt->execute();
                $visitor_result = $visitor_stmt->get_result();
                if($visitor_data = $visitor_result->fetch_assoc()){
                    $visitor_id = $visitor_data['visitor_id'];
                    $link_stmt = $conn->prepare("UPDATE students SET visitor_id = ? WHERE student_id = ?");
                    $link_stmt->bind_param("ii", $visitor_id, $student_id);
                    $link_stmt->execute();
                    $link_stmt->close();
                }
                $visitor_stmt->close();
            }

            $stmt = $conn->prepare("INSERT INTO users (student_id, username, password_hash) VALUES (?, ?, ?)");
            $stmt->bind_param("iss", $student_id, $username, $password_hash);

            try {
                if ($stmt->execute()) {
                    $message = '<div class="alert alert-success d-flex align-items-center"><i data-lucide="check-circle" class="me-2"></i>Registration successful! You can now <a href="login.php" class="alert-link">log in</a>.</div>';
                }
            } catch (mysqli_sql_exception $exception) {
                 if ($conn->errno === 1062) {
                    $message = '<div class="alert alert-danger d-flex align-items-center"><i data-lucide="x-circle" class="me-2"></i>This Username is already taken.</div>';
                 } else {
                    $message = '<div class="alert alert-danger d-flex align-items-center"><i data-lucide="server-crash" class="me-2"></i>An unexpected error occurred. Please try again.</div>';
                 }
            }
            $stmt->close();

        } else {
             $message = '<div class="alert alert-danger d-flex align-items-center"><i data-lucide="user-x" class="me-2"></i>Could not verify student number.</div>';
        }
        $student_stmt->close();
    }
}
$conn->close();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Register - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <style>
         :root {
            --loa-blue: #003366; --loa-yellow: #FFC72C; --loa-blue-light: #0055a4;
            --light-bg: #eef2f7; --dark-text: #212529; --card-bg: rgba(255, 255, 255, 0.7);
            --card-shadow: 0 8px 32px 0 rgba(0, 51, 102, 0.2); --font-family: 'Poppins', sans-serif;
        }
        body {
            font-family: var(--font-family); background: linear-gradient(-45deg, var(--light-bg), var(--loa-blue-light), var(--light-bg), var(--loa-blue));
            background-size: 400% 400%; animation: gradientBG 15s ease infinite; display: flex;
            justify-content: center; align-items: center; min-height: 100vh; padding: 1rem; perspective: 1000px;
        }
        @keyframes gradientBG { 0% { background-position: 0% 50%; } 50% { background-position: 100% 50%; } 100% { background-position: 0% 50%; } }
        .styled-card {
            background: var(--card-bg); border-radius: 1.5rem; border: 1px solid rgba(255, 255, 255, 0.2);
            box-shadow: var(--card-shadow); backdrop-filter: blur(25px); -webkit-backdrop-filter: blur(25px);
            width: 100%; max-width: 700px; overflow: hidden; animation: fadeInFromBottom 1s ease-out; transition: transform 0.1s ease;
        }
        @keyframes fadeInFromBottom { from { opacity: 0; transform: translateY(40px) scale(0.95); } to { opacity: 1; transform: translateY(0) scale(1); } }
        .card-content { padding: 2.5rem; }
        .btn-primary-modern {
            background: var(--loa-blue); border: none; border-radius: 50px; padding: 0.8rem 2rem;
            font-size: 1.1rem; font-weight: 600; color: white; transition: all 0.3s ease;
            box-shadow: 0 4px 15px rgba(0, 51, 102, 0.3);
        }
        .btn-primary-modern:hover {
            background-color: var(--loa-yellow); color: var(--loa-blue); transform: translateY(-4px) scale(1.05);
            box-shadow: 0 8px 25px rgba(255, 199, 44, 0.5);
        }
        .form-control[readonly] {
            background-color: #e9ecef;
            cursor: not-allowed;
        }
        @media (max-width: 768px) {
            .card-content {
                padding: 1.5rem;
            }
        }
    </style>
</head>
<body>
   <div class="styled-card">
        <div class="card-content">
            <div class="text-center mb-4">
                <h2 class="fw-bold">Create Your Account</h2>
                <p class="text-muted">Join the LOA-EASE system today.</p>
            </div>
            <?php if($message) echo $message; ?>
            <div id="api-message"></div>
            <form action="register.php" method="POST">
                <div class="mb-3">
                    <label for="student_number" class="form-label">Student Number</label>
                    <div class="input-group">
                         <input type="text" class="form-control" id="student_number" name="student_number" required>
                         <span class="input-group-text" id="student_number_status"></span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-5 mb-3">
                        <label for="last_name" class="form-label">Last Name</label>
                        <input type="text" class="form-control" id="last_name" name="last_name" required readonly>
                    </div>
                    <div class="col-md-5 mb-3">
                        <label for="first_name" class="form-label">First Name</label>
                        <input type="text" class="form-control" id="first_name" name="first_name" required readonly>
                    </div>
                    <div class="col-md-2 mb-3">
                        <label for="middle_initial" class="form-label">M.I.</label>
                        <input type="text" class="form-control" id="middle_initial" name="middle_initial" maxlength="5" readonly>
                    </div>
                </div>

                <div class="mb-3">
                    <label for="course" class="form-label">Course</label>
                    <input type="text" class="form-control" id="course" name="course" required readonly>
                </div>

                <div class="mb-3">
                    <label for="email" class="form-label">Email</label>
                    <input type="email" class="form-control" id="email" name="email" required readonly>
                </div>

                <div class="mb-3">
                    <label for="visitor_queue_number" class="form-label">Temporary Visitor ID (Optional)</label>
                    <input type="text" class="form-control" id="visitor_queue_number" name="visitor_queue_number" placeholder="Enter if you have a VISITOR-XXXX number">
                </div>
                
                <hr>

                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label for="username" class="form-label">Username</label>
                        <input type="text" class="form-control" id="username" name="username" required readonly>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="password" class="form-label">Password</label>
                        <input type="password" class="form-control" id="password" name="password" required
                               pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).{8,}"
                               title="Must contain at least one number, one uppercase and lowercase letter, one special character, and at least 8 or more characters">
                    </div>
                </div>

                <div class="d-grid mt-3">
                    <button type="submit" class="btn-primary-modern" id="registerButton"><i data-lucide="user-plus" class="me-2"></i>Register</button>
                </div>
            </form>
             <hr class="my-4">
            <p class="text-center text-muted">Already have an account? <a href="login.php">Login here</a></p>
        </div>
    </div>
    
    <script>
        lucide.createIcons();

        document.addEventListener('DOMContentLoaded', function() {
            const studentNumberInput = document.getElementById('student_number');
            const lastNameInput = document.getElementById('last_name');
            const firstNameInput = document.getElementById('first_name');
            const middleInitialInput = document.getElementById('middle_initial');
            const courseInput = document.getElementById('course');
            const emailInput = document.getElementById('email');
            const usernameInput = document.getElementById('username'); 
            const apiMessageDiv = document.getElementById('api-message');
            const statusIndicator = document.getElementById('student_number_status');
            const registerButton = document.getElementById('registerButton');

            let debounceTimer;

            studentNumberInput.addEventListener('input', function() {
                clearTimeout(debounceTimer);
                const studentNumber = this.value.trim();

                resetFields();
                if (studentNumber) {
                    statusIndicator.innerHTML = '<div class="spinner-border spinner-border-sm" role="status"></div>';
                } else {
                    statusIndicator.innerHTML = '';
                }
                
                debounceTimer = setTimeout(() => {
                    if (studentNumber) {
                        fetch(`api/get_student_details.php?student_number=${studentNumber}`)
                            .then(response => response.json())
                            .then(result => {
                                if (result.success) {
                                    const data = result.data;
                                    lastNameInput.value = data.last_name || '';
                                    firstNameInput.value = data.first_name || '';
                                    middleInitialInput.value = data.middle_initial || '';
                                    courseInput.value = data.course || '';
                                    emailInput.value = data.email || '';
                                    
                                    if (data.first_name && data.last_name) {
                                        const firstName = data.first_name.split(' ')[0].toLowerCase();
                                        const lastName = data.last_name.toLowerCase();
                                        usernameInput.value = `${firstName}.${lastName}`;
                                    }

                                    apiMessageDiv.innerHTML = '';
                                    statusIndicator.innerHTML = '<i data-lucide="check" class="text-success"></i>';
                                    registerButton.disabled = false;
                                } else {
                                    apiMessageDiv.innerHTML = `<div class="alert alert-danger py-2">${result.message}</div>`;
                                    statusIndicator.innerHTML = '<i data-lucide="x" class="text-danger"></i>';
                                    registerButton.disabled = true;
                                }
                                lucide.createIcons();
                            })
                            .catch(error => {
                                console.error('Error:', error);
                                apiMessageDiv.innerHTML = `<div class="alert alert-danger py-2">Network error. Please try again.</div>`;
                                statusIndicator.innerHTML = '<i data-lucide="alert-triangle" class="text-warning"></i>';
                                lucide.createIcons();
                            });
                    } else {
                        resetFields();
                    }
                }, 500);
            });

            function resetFields() {
                lastNameInput.value = '';
                firstNameInput.value = '';
                middleInitialInput.value = '';
                courseInput.value = '';
                emailInput.value = '';
                usernameInput.value = '';
                apiMessageDiv.innerHTML = '';
                statusIndicator.innerHTML = '';
                registerButton.disabled = false;
            }
        });
    </script>
</body>
</html>