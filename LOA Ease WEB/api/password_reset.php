<?php
require_once '../includes/db_connect.php';

header('Content-Type: application/json');

if ($_SERVER['REQUEST_METHOD'] != 'POST') {
    http_response_code(405);
    echo json_encode(['success' => false, 'message' => 'Invalid request method.']);
    exit();
}

// Handle password reset request
if (isset($_POST['email'])) {
    $email = $_POST['email'];

    $stmt = $conn->prepare("SELECT student_id FROM students WHERE email = ?");
    $stmt->bind_param("s", $email);
    $stmt->execute();
    $result = $stmt->get_result();

    if ($result->num_rows > 0) {
        $token = bin2hex(random_bytes(50));
        $expires = time() + 1800; // 30 minutes from now

        // Ensure no old tokens exist for this email
        $delete_stmt = $conn->prepare("DELETE FROM password_resets WHERE email = ?");
        $delete_stmt->bind_param("s", $email);
        $delete_stmt->execute();
        $delete_stmt->close();

        // Insert the new token with an integer timestamp
        $insert_stmt = $conn->prepare("INSERT INTO password_resets (email, token, expires) VALUES (?, ?, ?)");
        $insert_stmt->bind_param("ssi", $email, $token, $expires);
        $insert_stmt->execute();
        $insert_stmt->close();

        // In a real application, you would send an email here.
        // For this example, we will just return the link.
        $reset_link = "https://loaease.tech/experimental%20LOA-EASE/LOA%20Ease/reset_password.php?token=" . $token;
        
        echo json_encode(['success' => true, 'message' => 'Password reset link for testing: ' . $reset_link]);
    } else {
        // We send a generic message for security to not reveal if an email exists or not.
        echo json_encode(['success' => true, 'message' => 'If a user with that email exists, a password reset link has been sent.']);
    }
    $stmt->close();
    $conn->close();
    exit();
}

// Handle the actual password update
if (isset($_POST['token']) && isset($_POST['password'])) {
    $token = $_POST['token'];
    $password = $_POST['password'];

    $stmt = $conn->prepare("SELECT email, expires FROM password_resets WHERE token = ?");
    $stmt->bind_param("s", $token);
    $stmt->execute();
    $result = $stmt->get_result();

    if ($row = $result->fetch_assoc()) {
        // The check is now a clean integer comparison
        if ($row['expires'] >= time()) {
            $password_hash = password_hash($password, PASSWORD_BCRYPT);
            $email = $row['email'];

            // Get the student_id associated with the email
            $student_stmt = $conn->prepare("SELECT student_id FROM students WHERE email = ?");
            $student_stmt->bind_param("s", $email);
            $student_stmt->execute();
            $student_result = $student_stmt->get_result();
            
            if ($student = $student_result->fetch_assoc()) {
                $student_id = $student['student_id'];

                // Update the user's password
                $update_stmt = $conn->prepare("UPDATE users SET password_hash = ? WHERE student_id = ?");
                $update_stmt->bind_param("si", $password_hash, $student_id);
                $update_stmt->execute();
                $update_stmt->close();

                // Delete the token now that it has been used
                $delete_stmt = $conn->prepare("DELETE FROM password_resets WHERE email = ?");
                $delete_stmt->bind_param("s", $email);
                $delete_stmt->execute();
                $delete_stmt->close();

                echo json_encode(['success' => true, 'message' => 'Your password has been updated successfully.']);
            } else {
                echo json_encode(['success' => false, 'message' => 'Could not find a user associated with this email.']);
            }
            $student_stmt->close();
        } else {
            echo json_encode(['success' => false, 'message' => 'The password reset link has expired.']);
        }
    } else {
        echo json_encode(['success' => false, 'message' => 'Invalid password reset token.']);
    }
    $stmt->close();
    $conn->close();
    exit();
}

echo json_encode(['success' => false, 'message' => 'Invalid request.']);
?>