-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 26, 2025 at 02:26 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `learnvaluate_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `certificates`
--

CREATE TABLE `certificates` (
  `id` int(11) NOT NULL,
  `user_name` varchar(100) DEFAULT NULL,
  `date_issued` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `certificates`
--

INSERT INTO `certificates` (`id`, `user_name`, `date_issued`) VALUES
(1, 'Shammi', '2025-05-22'),
(2, 'Najia', '2025-05-22'),
(3, 'Homayra', '2025-05-22'),
(4, 'Nahid', '2025-05-22'),
(5, 'Borshon', '2025-05-24');

-- --------------------------------------------------------

--
-- Table structure for table `courses`
--

CREATE TABLE `courses` (
  `id` int(11) NOT NULL,
  `tutor_name` varchar(255) NOT NULL,
  `logo_file` varchar(255) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `courses`
--

INSERT INTO `courses` (`id`, `tutor_name`, `logo_file`, `description`) VALUES
(1, 'Tutor_A', 'html-logo.png', 'Complete HTML tutorial'),
(2, 'Tutor_B', 'css-logo.png', 'Complete CSS tutorial'),
(3, 'Tutor_C', 'js-logo.png', 'Complete JS tutorial'),
(4, 'Tutor_D', 'react-logo.png', 'Complete React.js tutorial'),
(5, 'Tutor_F', 'CreativeSkill.png', 'Complete CreativeSkill tutorial');

-- --------------------------------------------------------

--
-- Table structure for table `payments`
--

CREATE TABLE `payments` (
  `id` int(11) NOT NULL,
  `method` varchar(50) DEFAULT NULL,
  `card_number` varchar(30) DEFAULT NULL,
  `expiry` varchar(10) DEFAULT NULL,
  `cvv` varchar(10) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `transaction_id` varchar(50) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `submitted_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `course` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `payments`
--

INSERT INTO `payments` (`id`, `method`, `card_number`, `expiry`, `cvv`, `phone`, `transaction_id`, `email`, `submitted_at`, `course`) VALUES
(1, 'card', '24567789876653', '03/30', 'HBRDE34556', '', '', 'test@example.com', '2025-05-25 17:06:01', 1),
(2, 'Bkash', '', '', '', '01617413582', 'CNX2BO0LS', 'atho24@gmail.com', '2025-05-25 17:07:02', 1),
(3, 'Bkash', '', '', '', '01617413582', 'CNX2BO0MS', 'atho24@gmail.com', '2025-05-25 17:07:27', 2),
(6, 'Nagad', '', '', '', '01617413592', 'CNX2BO0NS', 'borshon123@gmail.com', '2025-05-25 17:09:47', 4),
(7, 'Rocket', '', '', '', '01617413592', 'CNX2BO0ES', 'nahid@gmail.com', '2025-05-25 17:12:36', 3),
(9, 'card', '23235698654321', '04/30', 'SGH345JHFD', '', '', 'mim123@gmail.com', '2025-05-26 01:50:00', 2),
(10, 'Rocket', '', '', '', '01617413572', 'CNX2BO0NS', 'homayra123@gmail.com', '2025-05-26 04:23:50', 1),
(11, 'Bkash', '', '', '', '01617413513', 'CNX2BO0ES', 'borshon123@gmail.com', '2025-05-26 08:03:06', 1),
(12, 'Bkash', '', '', '', '01617413513', 'CNX2BO0ES', 'borshon123@gmail.com', '2025-05-26 08:03:41', 1),
(13, 'Rocket', '', '', '', '01617413553', 'CNX2BO0NS', 'mim123@gmail.com', '2025-05-26 08:09:42', 1),
(14, 'card', '77554234789', '04/30', 'D32HKJJHG7', '', '', 'test@example.com', '2025-05-26 08:24:23', 1);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `email`, `password`) VALUES
(1, 'Test', 'test@example.com', '$2y$10$MK6chJgGExI/VZ.5xB1LUuRZ5fn2ENtQGvoS76TVX3Z3FRFhJCM4.'),
(2, 'homyra12', 'homayra@gmail.com', '\'$2y$10$MK6chJgGExI/VZ.5xB1LUuRZ5fn2ENtQGvoS76TVX3Z3FRFhJCM4.\''),
(3, 'Athocho12', 'athocho@example.com', '$2y$10$MK6chJgGExI/VZ.5xB1LUuRZ5fn2ENtQGvoS76TVX3Z3FRFhJCM4.'),
(4, 'Najia12', 'najia@example.com', '$2y$10$MK6chJgGExI/VZ.5xB1LUuRZ5fn2ENtQGvoS76TVX3Z3FRFhJCM4.'),
(5, 'Nahid12', 'nahid@example.com', '$2y$10$MK6chJgGExI/VZ.5xB1LUuRZ5fn2ENtQGvoS76TVX3Z3FRFhJCM4.'),
(6, 'Borshon12', 'borshon@example.com', '$2y$10$MK6chJgGExI/VZ.5xB1LUuRZ5fn2ENtQGvoS76TVX3Z3FRFhJCM4.');

-- --------------------------------------------------------

--
-- Table structure for table `videos`
--

CREATE TABLE `videos` (
  `id` int(11) NOT NULL,
  `title` varchar(255) DEFAULT NULL,
  `video_url` text DEFAULT NULL,
  `course_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `videos`
--

INSERT INTO `videos` (`id`, `title`, `video_url`, `course_id`) VALUES
(1, 'HTML Part 1', 'https://www.youtube.com/embed/UB1O30fR-EE', 1),
(2, 'CSS Part 1', 'https://www.youtube.com/embed/yfoY53QXEnI', 2),
(3, 'JS Part 1', 'https://www.youtube.com/embed/W6NZfCO5SIk', 3),
(7, 'CSS Tutorial Part-1', 'https://www.youtube.com/embed/yfoY53QXEn', 2);

-- --------------------------------------------------------

--
-- Table structure for table `video_feedback`
--

CREATE TABLE `video_feedback` (
  `id` int(11) NOT NULL,
  `video_id` int(11) NOT NULL,
  `is_liked` tinyint(1) DEFAULT 0,
  `comment` text DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `video_feedback`
--

INSERT INTO `video_feedback` (`id`, `video_id`, `is_liked`, `comment`, `created_at`) VALUES
(1, 1, 0, 'done', '2025-05-24 03:02:10'),
(2, 1, 1, 'Alhamdulillah', '2025-05-24 03:02:44'),
(3, 2, 1, 'Alhamdulillah Done.', '2025-05-24 03:21:33'),
(4, 4, 1, 'Good.', '2025-05-24 15:30:06'),
(5, 1, 1, 'Alhamdulillah', '2025-05-24 15:31:34');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `certificates`
--
ALTER TABLE `certificates`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `courses`
--
ALTER TABLE `courses`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `payments`
--
ALTER TABLE `payments`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_course` (`course`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indexes for table `videos`
--
ALTER TABLE `videos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `course_id` (`course_id`);

--
-- Indexes for table `video_feedback`
--
ALTER TABLE `video_feedback`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `certificates`
--
ALTER TABLE `certificates`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `courses`
--
ALTER TABLE `courses`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `payments`
--
ALTER TABLE `payments`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `videos`
--
ALTER TABLE `videos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `video_feedback`
--
ALTER TABLE `video_feedback`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `payments`
--
ALTER TABLE `payments`
  ADD CONSTRAINT `fk_course` FOREIGN KEY (`course`) REFERENCES `courses` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `videos`
--
ALTER TABLE `videos`
  ADD CONSTRAINT `videos_ibfk_1` FOREIGN KEY (`course_id`) REFERENCES `courses` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
