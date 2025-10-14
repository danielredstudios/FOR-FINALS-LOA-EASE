-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 09, 2025 at 08:46 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `loa_ease_queuing_experiemental`
--

-- --------------------------------------------------------

--
-- Table structure for table `admins`
--

CREATE TABLE `admins` (
  `admin_id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `full_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `cashiers`
--

CREATE TABLE `cashiers` (
  `cashier_id` int(11) NOT NULL,
  `counter_id` int(11) DEFAULT NULL,
  `username` varchar(100) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `role` enum('admin','cashier') NOT NULL DEFAULT 'cashier',
  `full_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cashiers`
--

INSERT INTO `cashiers` (`cashier_id`, `counter_id`, `username`, `password_hash`, `role`, `full_name`) VALUES
(1, 1, 'cashier1', '$2y$10$sDWBtkmB.FPx/1490owM8.NSX9C.IVynpFyKPI67wLyyysnlVBXOW', 'cashier', 'Daniel Red - Cashier 1'),
(2, 2, 'cashier2', '$2y$10$sDWBtkmB.FPx/1490owM8.NSX9C.IVynpFyKPI67wLyyysnlVBXOW', 'cashier', 'GAVIN PEÑARANDA - Cashier 2'),
(3, 3, 'cashier3', '$2y$10$sDWBtkmB.FPx/1490owM8.NSX9C.IVynpFyKPI67wLyyysnlVBXOW', 'cashier', 'JEANROMUALD DELA CRUZ -  Cashier 3'),
(4, 4, 'cashier4', '$2y$10$sDWBtkmB.FPx/1490owM8.NSX9C.IVynpFyKPI67wLyyysnlVBXOW', 'cashier', 'Cashier 4 - Sean Yzer'),
(7, 5, 'admin', '$2y$10$sDWBtkmB.FPx/1490owM8.NSX9C.IVynpFyKPI67wLyyysnlVBXOW', 'admin', 'Daniel Red - Admin');

-- --------------------------------------------------------

--
-- Table structure for table `counters`
--

CREATE TABLE `counters` (
  `counter_id` int(11) NOT NULL,
  `counter_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `counters`
--

INSERT INTO `counters` (`counter_id`, `counter_name`) VALUES
(1, 'Cashier 1'),
(2, 'Cashier 2'),
(3, 'Cashier 3'),
(4, 'Cashier 4'),
(5, 'Admin');

-- --------------------------------------------------------

--
-- Table structure for table `counter_schedules`
--

CREATE TABLE `counter_schedules` (
  `schedule_id` int(11) NOT NULL,
  `counter_id` int(11) NOT NULL,
  `is_open` tinyint(1) NOT NULL DEFAULT 1,
  `status` enum('open','break') NOT NULL DEFAULT 'open',
  `start_time` time DEFAULT '08:00:00',
  `end_time` time DEFAULT '17:00:00'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `counter_schedules`
--

INSERT INTO `counter_schedules` (`schedule_id`, `counter_id`, `is_open`, `status`, `start_time`, `end_time`) VALUES
(1, 1, 0, 'open', '08:00:00', '22:19:06'),
(2, 2, 0, 'open', '08:00:00', '17:00:00'),
(3, 3, 0, 'open', '08:00:00', '17:00:00'),
(4, 4, 0, 'open', '08:00:00', '17:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `guardians`
--

CREATE TABLE `guardians` (
  `guardian_id` int(11) NOT NULL,
  `full_name` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `phone_number` varchar(20) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `password_resets`
--

CREATE TABLE `password_resets` (
  `id` int(11) NOT NULL,
  `email` varchar(255) NOT NULL,
  `token` varchar(255) NOT NULL,
  `expires` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `password_resets`
--

INSERT INTO `password_resets` (`id`, `email`, `token`, `expires`) VALUES
(3, 'C1118-23@itmlyceumalabang.onmicrosoft.com', '3ec93673da9ea94cd3a874d14d8d19cbabcb8451b5519ed17b732bb8c178c77edf1ade81ff83283bd09467b40f2877145c68', 1758008521),
(7, 'c1030-23@itmlyceumalabang.onmicrosoft.com', 'b7054ddc8631ad6f8176bd2f58e6fe40c51f677ecde4f507ea142670bc45357ea2bfb73aa474b3bc3bb6e61fb6cc6b40727a', 1758953852);

-- --------------------------------------------------------

--
-- Table structure for table `queues`
--

CREATE TABLE `queues` (
  `queue_id` int(11) NOT NULL,
  `student_id` int(11) DEFAULT NULL,
  `visitor_id` int(11) DEFAULT NULL,
  `counter_id` int(11) NOT NULL,
  `queue_number` varchar(20) NOT NULL,
  `purpose` text DEFAULT NULL,
  `schedule_datetime` datetime NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `called_at` timestamp NULL DEFAULT NULL,
  `status` enum('waiting','serving','completed','cancelled','no-show','scheduled','expired') NOT NULL DEFAULT 'waiting',
  `is_priority` tinyint(1) NOT NULL DEFAULT 0
) ;

--
-- Dumping data for table `queues`
--

INSERT INTO `queues` (`queue_id`, `student_id`, `visitor_id`, `counter_id`, `queue_number`, `purpose`, `schedule_datetime`, `created_at`, `called_at`, `status`, `is_priority`) VALUES
(51, 21, NULL, 2, 'CCS-0926-001', 'Tuition Payment', '2025-09-26 08:00:00', '2025-09-26 00:45:19', '2025-09-26 00:51:07', 'completed', 0),
(53, 21, NULL, 2, 'CCS-0926-002', 'Tuition Payment', '2025-09-26 08:30:00', '2025-09-26 00:50:24', '2025-09-26 00:51:14', 'completed', 0),
(55, 45, NULL, 2, 'CCS-0926-006', 'Tuition Payment', '2025-09-26 09:00:00', '2025-09-26 00:54:41', '2025-09-26 00:56:45', 'completed', 0),
(57, 45, NULL, 2, 'CCS-0926-008', 'Tuition Payment', '2025-09-26 09:30:00', '2025-09-26 01:36:48', '2025-09-26 01:36:59', 'completed', 0),
(58, 21, NULL, 2, 'CCS-0926-009', 'Tuition Payment, Enrollment Concern, Promissory Note, Document Request, doc_req:Transcript of Records (TOR)', '2025-09-26 10:00:00', '2025-09-26 01:37:35', '2025-09-26 01:37:47', 'completed', 0),
(67, 45, NULL, 2, 'CCS-0926-018', 'Tuition Payment, Enrollment Concern', '2025-09-26 10:30:00', '2025-09-26 02:14:39', '2025-09-26 02:15:30', 'completed', 0),
(68, 36, NULL, 2, 'CCS-0926-019', 'Tuition Payment, Enrollment Concern', '2025-09-26 11:00:00', '2025-09-26 02:15:09', '2025-09-26 02:17:02', 'completed', 0),
(69, 45, NULL, 2, 'CCS-0926-020', 'Tuition Payment', '2025-09-26 11:30:00', '2025-09-26 02:21:42', '2025-09-26 02:23:48', 'completed', 0),
(70, 38, NULL, 2, 'CCS-0926-021', 'Tuition Payment, Enrollment Concern', '2025-09-26 12:00:00', '2025-09-26 02:22:00', '2025-09-26 02:24:38', 'completed', 0),
(71, 43, NULL, 2, 'CCS-0926-022', 'Tuition Payment', '2025-09-26 12:30:00', '2025-09-26 02:23:39', '2025-09-26 02:26:15', 'completed', 0),
(73, 45, NULL, 2, 'P-CCS-0926-024', 'Document Request, doc_req:Diploma, Transcript of Records (TOR), Good Moral Certificate', '2025-09-26 13:00:00', '2025-09-26 02:42:36', '2025-09-26 02:58:18', 'completed', 1),
(74, 45, NULL, 2, 'P-CCS-0926-025', 'Tuition Payment', '2025-09-26 13:30:00', '2025-09-26 02:58:36', '2025-09-26 02:58:46', 'completed', 1),
(78, 45, NULL, 4, 'CCS-0926-029', 'Document Request, doc_req:Diploma, Transcript of Records (TOR), Good Moral Certificate', '2025-09-26 08:00:00', '2025-09-26 03:11:19', '2025-09-26 03:18:34', 'completed', 0),
(99, 26, NULL, 2, 'CCS-0929-016', 'Tuition Payment', '2025-09-29 15:37:50', '2025-09-29 07:37:50', '2025-09-29 07:38:03', 'completed', 0),
(100, 41, NULL, 2, 'P-CCS-0929-017', 'Enrollment Concern', '2025-09-29 15:39:28', '2025-09-29 07:39:28', '2025-09-29 07:40:09', 'completed', 1),
(102, 45, NULL, 2, 'CCS-0929-019', 'Promissory Note', '2025-09-29 15:41:40', '2025-09-29 07:41:40', NULL, 'completed', 0),
(103, 23, NULL, 4, 'CCS-0929-020', 'Promissory Note', '2025-09-29 15:43:27', '2025-09-29 07:43:27', '2025-09-29 07:46:42', 'completed', 0),
(105, 28, NULL, 2, 'CCS-0929-022', 'Tuition Payment', '2025-09-29 08:00:00', '2025-09-29 07:48:29', NULL, 'completed', 0),
(106, 23, NULL, 4, 'P-CCS-0929-023', 'Document Request, doc_req:Diploma', '2025-09-29 08:00:00', '2025-09-29 07:50:08', '2025-09-29 07:50:24', 'completed', 1),
(107, 21, NULL, 4, 'S NFORMATION ECHNOLO', 'Tuition Payment, Enrollment Concern', '2025-09-30 12:52:48', '2025-09-30 04:52:48', NULL, 'completed', 0),
(108, 46, NULL, 4, 'BSIT-0930-002', 'Tuition Payment', '2025-09-30 12:57:27', '2025-09-30 04:57:27', NULL, 'completed', 0),
(109, 45, NULL, 2, 'GEN-0930-003', 'Tuition Payment, Promissory Note', '2025-10-03 00:00:00', '2025-09-30 05:12:51', NULL, 'completed', 0),
(114, 45, NULL, 4, 'GEN-1002-005', 'Document Request, doc_req:Diploma', '2025-10-02 08:00:00', '2025-10-02 12:51:37', '2025-10-02 12:51:49', 'expired', 0),
(132, 45, NULL, 2, 'BSIT-1009-001', 'Promissory Note', '2025-10-09 13:37:51', '2025-10-09 05:37:51', '2025-10-09 05:38:42', 'completed', 0),
(133, 28, NULL, 2, 'BSIT-1009-002', 'Tuition Payment, Others', '2025-10-09 14:13:53', '2025-10-09 06:13:53', '2025-10-09 06:14:06', 'completed', 0),
(134, 28, NULL, 2, 'BSIT-1009-003', 'Tuition Payment', '2025-10-09 14:16:04', '2025-10-09 06:16:04', NULL, 'waiting', 0);

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `student_id` int(11) NOT NULL,
  `student_number` varchar(50) NOT NULL,
  `last_name` varchar(100) NOT NULL,
  `first_name` varchar(100) NOT NULL,
  `middle_initial` varchar(5) DEFAULT NULL,
  `course` varchar(100) DEFAULT NULL,
  `email` varchar(255) NOT NULL,
  `visitor_id` int(11) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`student_id`, `student_number`, `last_name`, `first_name`, `middle_initial`, `course`, `email`, `visitor_id`, `created_at`) VALUES
(1, '1111-11', 'ESCUDERO', 'ROSALYN', NULL, 'BS Computer Science', 'Rosalyn_Escudero_sh@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:45:57'),
(21, 'C2006-23', 'ABRIO', 'DRIAN EUIJAY', NULL, 'BS Information Technology', 'C2006-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(22, 'C1593-23', 'ANURAN', 'ERICSON', NULL, 'BS Information Technology', 'C1593-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(23, 'C1118-23', 'ATOG', 'SEAN', NULL, 'BS Information Technology', 'C1118-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(24, 'C2202-23', 'BUSTRILLO', 'JASON', NULL, 'BS Information Technology', 'C2202-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(25, 'C1988-23', 'CASAKIT', 'BEATRICE', NULL, 'BS Information Technology', 'C1988-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(26, 'C2008-23', 'CENARDO', 'VERNALYN', NULL, 'BS Information Technology', 'C2008-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(27, 'C1092-23', 'DE CASTRO', 'PIERRE BENEDICT', NULL, 'BS Information Technology', 'C1092-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(28, 'C2027-23', 'DELA CRUZ', 'JEAN ROMUALD', NULL, 'BS Information Technology', 'C2027-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(29, 'C2205-23', 'DIAZ', 'REINZ DEREK', NULL, 'BS Information Technology', 'C2205-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(30, 'C1076-17', 'FLOR', 'PATRICK DAE', NULL, 'BS Information Technology', 'C1076-17@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(31, 'C2040-23', 'GUANZON', 'JOHNLLOYD', NULL, 'BS Information Technology', 'C2040-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(32, 'C2005-23', 'GUARDIAN', 'RYMARK', NULL, 'BS Information Technology', 'C2005-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(33, 'C1944-23', 'JAVIER', 'MARY JHAZMINE', NULL, 'BS Information Technology', 'C1944-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(34, 'C1929-23', 'LIM', 'KIM CARLO', NULL, 'BS Information Technology', 'C1929-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(35, 'C2903-23', 'LOBRICO', 'JB', NULL, 'BS Information Technology', 'C2903-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(36, 'C1822-23', 'LORICO', 'NICK JAMES', NULL, 'BS Information Technology', 'C1822-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(37, '1896-21', 'LUCBAN', 'RACHELLE ANNE', NULL, 'BS Information Technology', '1896-21@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(38, 'C1662-24', 'MADALAG', 'MATTHEW', NULL, 'BS Information Technology', 'C1662-24@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(39, 'C2097-23', 'MATIGA', 'XYRYLLE CLAIRE', NULL, 'BS Information Technology', 'C2097-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(40, 'C1394-23', 'MIRANDA', 'JOHN NINO', NULL, 'BS Information Technology', 'C1394-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(41, 'C1881-23', 'OBIS', 'FRANCINE MEI', NULL, 'BS Information Technology', 'C1881-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(42, '1353-22', 'PAGHARI-ON', 'ANTHONY', NULL, 'BS Information Technology', '1353-22@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(43, 'C1923-23', 'RAMIREZ', 'PRINCE DENZEL', NULL, 'BS Information Technology', 'C1923-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(44, 'C2261-24', 'RAMONES', 'REGINA ANGELA', NULL, 'BS Information Technology', 'C2261-24@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(45, 'C1030-23', 'RED', 'DANIEL RAFAEL', NULL, 'BS Information Technology', 'C1030-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(46, 'C1949-23', 'RODRIGUEZ', 'YUAN JASPER', NULL, 'BS Information Technology', 'C1949-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(47, 'C1878-23', 'SAGUBAN', 'BIANCA JEANELLE', NULL, 'BS Information Technology', 'C1878-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(48, 'C1922-23', 'VICENTE', 'RONNEL JOHN', NULL, 'BS Information Technology', 'C1922-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(49, 'C2057-23', 'YOUNG', 'VYANCE GABRIELLE', NULL, 'BS Information Technology', 'C2057-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-15 23:35:51'),
(50, '2770-22', 'PEÑARANDA', 'NATHAN GAVIN', NULL, 'BS Information Technology', '2770-22@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 00:53:44');

-- --------------------------------------------------------

--
-- Table structure for table `student_guardian_map`
--

CREATE TABLE `student_guardian_map` (
  `map_id` int(11) NOT NULL,
  `student_id` int(11) NOT NULL,
  `guardian_id` int(11) NOT NULL,
  `relationship` varchar(50) DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `student_id` int(11) DEFAULT NULL,
  `guardian_id` int(11) DEFAULT NULL,
  `username` varchar(100) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `last_login` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `student_id`, `guardian_id`, `username`, `password_hash`, `last_login`, `created_at`) VALUES
(13, 48, NULL, 'ronnel.vicente', '$2y$10$GduIvCYvA5BDVHCjqOKbRekrtZQFGn83Tup2bApm3cwh.rdocOI1u', '2025-09-16 05:23:05', '2025-09-16 05:22:49'),
(14, 50, NULL, 'nathan.peñaranda', '$2y$10$LQb8njEYxk9y88WTVoP3e.lM08J4wI3REo9Dx4BzVf3wDIAEv74Eq', '2025-10-09 05:26:36', '2025-09-16 05:33:46'),
(15, 39, NULL, 'xyrylle.matiga', '$2y$10$0jrKbxIsawxKnx69Ay0JTeg.985Q.8rwXgA1U4rpiSGJ55za5RzgW', '2025-09-16 05:45:26', '2025-09-16 05:45:01'),
(18, 23, NULL, 'sean.atog', '$2y$10$28E8rK8ZmaCjZ4fnBvuJD.hG5KTYrjB/0MS2cb3k9PWYh0xpxzuPq', '2025-09-16 07:14:53', '2025-09-16 07:14:44'),
(20, 46, NULL, 'yuan.rodriguez', '$2y$10$Zfw8jsbG.9pNzCXUICnpvO0BmkD6ocwvNYJonyrqrtGpUfK3nUV4y', '2025-09-17 09:37:39', '2025-09-17 09:34:39'),
(24, 21, NULL, 'drian.abrio', '$2y$10$JTMuAL5A4lfJkEAM9A1VfuVMEiJE6FfWt6j2Ej4JpOIINcOY4sbzy', '2025-09-26 00:45:06', '2025-09-26 00:44:56'),
(25, 35, NULL, 'jb.lobrico', '$2y$10$ZlshM.p7C/dGUrG.x6.DSO8jJogmbWpkKeMk54dQAiSZNbAatniF.', '2025-09-29 07:42:44', '2025-09-29 07:41:32'),
(28, 45, NULL, 'daniel.red', '$2y$10$jTwkbY0/432N2Uf729VYbe5/UIPTG6WZ92/t9ARVyzlRY.E8zS1Fq', '2025-10-09 06:10:02', '2025-10-02 09:49:46'),
(29, 28, NULL, 'jean.dela cruz', '$2y$10$uAoTHgN.rA6PNxNg5RUsb.LN9OvYuVP.oF44SZQKzKjNr.Hm2B3pq', '2025-10-09 05:40:05', '2025-10-09 05:39:51');

-- --------------------------------------------------------

--
-- Table structure for table `visitors`
--

CREATE TABLE `visitors` (
  `visitor_id` int(11) NOT NULL,
  `full_name` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `visitors`
--

INSERT INTO `visitors` (`visitor_id`, `full_name`, `email`, `created_at`) VALUES
(1, 'Daniel Red', 'technogaming106@gmail.com', '2025-09-25 01:24:14'),
(2, 'Daniel Red', 'danred106@gmail.com', '2025-09-25 01:30:33'),
(3, 'Jhiro Dela Cruz', 'loa.bsitoutreach.s0015@gmail.com', '2025-09-26 02:25:32'),
(4, 'Daniel Red', 'technogaming106@gmail.com', '2025-09-27 04:30:56'),
(5, 'Daniel Red', 'danred106@gmail.com', '2025-09-27 04:36:28'),
(6, 'Sean Yzer', 'Seanyzer26@gmail.com', '2025-09-29 07:47:44');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admins`
--
ALTER TABLE `admins`
  ADD PRIMARY KEY (`admin_id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Indexes for table `cashiers`
--
ALTER TABLE `cashiers`
  ADD PRIMARY KEY (`cashier_id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD KEY `counter_id` (`counter_id`);

--
-- Indexes for table `counters`
--
ALTER TABLE `counters`
  ADD PRIMARY KEY (`counter_id`);

--
-- Indexes for table `counter_schedules`
--
ALTER TABLE `counter_schedules`
  ADD PRIMARY KEY (`schedule_id`),
  ADD UNIQUE KEY `counter_id` (`counter_id`);

--
-- Indexes for table `guardians`
--
ALTER TABLE `guardians`
  ADD PRIMARY KEY (`guardian_id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indexes for table `password_resets`
--
ALTER TABLE `password_resets`
  ADD PRIMARY KEY (`id`),
  ADD KEY `email` (`email`);

--
-- Indexes for table `queues`
--
ALTER TABLE `queues`
  ADD PRIMARY KEY (`queue_id`),
  ADD KEY `student_id` (`student_id`),
  ADD KEY `counter_id` (`counter_id`),
  ADD KEY `queues_ibfk_3` (`visitor_id`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`student_id`),
  ADD UNIQUE KEY `student_number` (`student_number`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indexes for table `student_guardian_map`
--
ALTER TABLE `student_guardian_map`
  ADD PRIMARY KEY (`map_id`),
  ADD KEY `student_id` (`student_id`),
  ADD KEY `guardian_id` (`guardian_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `student_id` (`student_id`),
  ADD UNIQUE KEY `guardian_id` (`guardian_id`);

--
-- Indexes for table `visitors`
--
ALTER TABLE `visitors`
  ADD PRIMARY KEY (`visitor_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admins`
--
ALTER TABLE `admins`
  MODIFY `admin_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `cashiers`
--
ALTER TABLE `cashiers`
  MODIFY `cashier_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `counters`
--
ALTER TABLE `counters`
  MODIFY `counter_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `counter_schedules`
--
ALTER TABLE `counter_schedules`
  MODIFY `schedule_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `guardians`
--
ALTER TABLE `guardians`
  MODIFY `guardian_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `password_resets`
--
ALTER TABLE `password_resets`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `queues`
--
ALTER TABLE `queues`
  MODIFY `queue_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `students`
--
ALTER TABLE `students`
  MODIFY `student_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

--
-- AUTO_INCREMENT for table `student_guardian_map`
--
ALTER TABLE `student_guardian_map`
  MODIFY `map_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT for table `visitors`
--
ALTER TABLE `visitors`
  MODIFY `visitor_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `cashiers`
--
ALTER TABLE `cashiers`
  ADD CONSTRAINT `cashiers_ibfk_1` FOREIGN KEY (`counter_id`) REFERENCES `counters` (`counter_id`) ON DELETE CASCADE;

--
-- Constraints for table `counter_schedules`
--
ALTER TABLE `counter_schedules`
  ADD CONSTRAINT `counter_schedules_ibfk_1` FOREIGN KEY (`counter_id`) REFERENCES `counters` (`counter_id`) ON DELETE CASCADE;

--
-- Constraints for table `queues`
--
ALTER TABLE `queues`
  ADD CONSTRAINT `queues_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `queues_ibfk_2` FOREIGN KEY (`counter_id`) REFERENCES `counters` (`counter_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `queues_ibfk_3` FOREIGN KEY (`visitor_id`) REFERENCES `visitors` (`visitor_id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `student_guardian_map`
--
ALTER TABLE `student_guardian_map`
  ADD CONSTRAINT `student_guardian_map_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `student_guardian_map_ibfk_2` FOREIGN KEY (`guardian_id`) REFERENCES `guardians` (`guardian_id`) ON DELETE CASCADE;

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `users_ibfk_2` FOREIGN KEY (`guardian_id`) REFERENCES `guardians` (`guardian_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
