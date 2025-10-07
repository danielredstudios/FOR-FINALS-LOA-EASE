<?php
require_once '../includes/db_connect.php';
session_start();
header('Content-Type: application/json');

if (!isset($_SESSION['student_id'])) {
    http_response_code(401);
    echo json_encode(['success' => false, 'message' => 'Not authenticated.']);
    exit();
}

$queue_number = $_GET['queue_number'] ?? '';

if (empty($queue_number)) {
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => 'Queue number is required.']);
    exit();
}

$stmt = $conn->prepare("SELECT status FROM queues WHERE queue_number = ? AND student_id = ?");
$stmt->bind_param("si", $queue_number, $_SESSION['student_id']);
$stmt->execute();
$result = $stmt->get_result();

if ($ticket = $result->fetch_assoc()) {
    echo json_encode(['success' => true, 'status' => $ticket['status']]);
} else {
    // If the ticket is completed or cancelled, it might not be found by the active ticket query.
    // We can send a generic 'inactive' status to tell the page to update.
    echo json_encode(['success' => false, 'status' => 'inactive']);
}

$stmt->close();
$conn->close();
?>