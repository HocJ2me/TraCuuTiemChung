-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 09, 2022 at 02:22 AM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ql_vaccin`
--

-- --------------------------------------------------------

--
-- Table structure for table `area`
--

CREATE TABLE `area` (
  `ID` int(11) NOT NULL,
  `name` text NOT NULL,
  `idvaccin` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `area`
--

INSERT INTO `area` (`ID`, `name`, `idvaccin`) VALUES
(1, 'Bạch Đằng', 1),
(2, 'Bạch Đằng', 2),
(3, 'Hai Bà Trưng', 1),
(4, 'Đống Đa', 2);

-- --------------------------------------------------------

--
-- Table structure for table `declaration`
--

CREATE TABLE `declaration` (
  `ID` int(11) NOT NULL,
  `healthy` text NOT NULL,
  `sick` int(11) NOT NULL,
  `cough` int(11) NOT NULL,
  `fever` int(11) NOT NULL,
  `f` int(11) NOT NULL,
  `userid` int(11) NOT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `declaration`
--

INSERT INTO `declaration` (`ID`, `healthy`, `sick`, `cough`, `fever`, `f`, `userid`, `date`) VALUES
(1, 'GOOD', 0, 0, 0, -1, 1, '2022-01-08');

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `id` int(11) NOT NULL,
  `username` text NOT NULL,
  `password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`id`, `username`, `password`) VALUES
(1, '20193191', '1'),
(2, '20193011', '1'),
(3, '20192991', '1'),
(4, '20192860', '1');

-- --------------------------------------------------------

--
-- Table structure for table `signupvaccin`
--

CREATE TABLE `signupvaccin` (
  `ID` int(11) NOT NULL,
  `userid` int(11) NOT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `ID` int(11) NOT NULL,
  `name` text NOT NULL,
  `address` text NOT NULL,
  `class` text NOT NULL,
  `level` int(11) NOT NULL,
  `healthy` text NOT NULL,
  `vaccin` int(11) NOT NULL,
  `BHYT` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`ID`, `name`, `address`, `class`, `level`, `healthy`, `vaccin`, `BHYT`) VALUES
(1, 'Lê Chí Tuyền', '20B7 Đầm Trấu, Bạch Đằng, Hai Bà Trưng', 'ET1 07', 6, 'GOOD', 2, ''),
(2, 'Lê Duy Hoàng Minh', '20B7 Đầm Trấu, Bạch Đằng, Hai Bà Trưng', 'ET1 07', 6, 'GOOD', 2, ''),
(3, 'Trương Phi Long', '20B7 Đầm Trấu, Bạch Đằng, Hai Bà Trưng', 'ET1 07', 6, 'GOOD', 0, ''),
(4, 'Nguyễn Đình Hòa', '20B7 Đầm Trấu, Bạch Đằng, Hai Bà Trưng', 'ET1 07', 6, 'GOOD', 1, '');

-- --------------------------------------------------------

--
-- Table structure for table `vaccin`
--

CREATE TABLE `vaccin` (
  `id` int(11) NOT NULL,
  `userid` int(11) NOT NULL,
  `type` int(11) NOT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `vaccin`
--

INSERT INTO `vaccin` (`id`, `userid`, `type`, `date`) VALUES
(3, 1, 1, '2021-09-29');

-- --------------------------------------------------------

--
-- Table structure for table `vaccinontime`
--

CREATE TABLE `vaccinontime` (
  `ID` int(11) NOT NULL,
  `name` int(11) NOT NULL,
  `owner` int(11) NOT NULL,
  `fromdate` date NOT NULL,
  `enddate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `vaccintype`
--

CREATE TABLE `vaccintype` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `vaccintype`
--

INSERT INTO `vaccintype` (`id`, `name`) VALUES
(1, 'Vero Cell'),
(2, 'Astra'),
(3, 'Pfizer'),
(4, 'SinoPharm');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `area`
--
ALTER TABLE `area`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `declaration`
--
ALTER TABLE `declaration`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `userid` (`userid`);

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `signupvaccin`
--
ALTER TABLE `signupvaccin`
  ADD PRIMARY KEY (`userid`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `vaccin`
--
ALTER TABLE `vaccin`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `userid` (`userid`),
  ADD UNIQUE KEY `type` (`type`),
  ADD UNIQUE KEY `userid_2` (`userid`,`type`);

--
-- Indexes for table `vaccinontime`
--
ALTER TABLE `vaccinontime`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indexes for table `vaccintype`
--
ALTER TABLE `vaccintype`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `area`
--
ALTER TABLE `area`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `declaration`
--
ALTER TABLE `declaration`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `vaccin`
--
ALTER TABLE `vaccin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `vaccinontime`
--
ALTER TABLE `vaccinontime`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `vaccintype`
--
ALTER TABLE `vaccintype`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `declaration`
--
ALTER TABLE `declaration`
  ADD CONSTRAINT `declaration_ibfk_1` FOREIGN KEY (`userid`) REFERENCES `user` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `signupvaccin`
--
ALTER TABLE `signupvaccin`
  ADD CONSTRAINT `signupvaccin_ibfk_1` FOREIGN KEY (`userid`) REFERENCES `user` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `login` (`id`);

--
-- Constraints for table `vaccin`
--
ALTER TABLE `vaccin`
  ADD CONSTRAINT `vaccin_ibfk_1` FOREIGN KEY (`type`) REFERENCES `vaccintype` (`id`),
  ADD CONSTRAINT `vaccin_ibfk_2` FOREIGN KEY (`userid`) REFERENCES `user` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `vaccinontime`
--
ALTER TABLE `vaccinontime`
  ADD CONSTRAINT `vaccinontime_ibfk_1` FOREIGN KEY (`name`) REFERENCES `area` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
