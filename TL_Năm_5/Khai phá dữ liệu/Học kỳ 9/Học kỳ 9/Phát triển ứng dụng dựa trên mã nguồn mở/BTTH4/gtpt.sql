-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th10 17, 2021 lúc 10:44 AM
-- Phiên bản máy phục vụ: 10.4.21-MariaDB
-- Phiên bản PHP: 7.4.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `gtpt`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `user`
--

CREATE TABLE `user` (
  `ID` int(10) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Role` varchar(11) NOT NULL,
  `Phone` varchar(255) NOT NULL,
  `Avatar` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `user`
--

INSERT INTO `user` (`ID`, `Name`, `Username`, `Email`, `Password`, `Role`, `Phone`, `Avatar`) VALUES
(6, 'hai yen', 'haiyen', 'yen@gmail.com', '9MRx65bdBalyjtvFhqanWSeo0t+BPDy1LZ5NElqUHjE=', '1', '0967239798', 'ảnh 2.jpg'),
(12, 'hoaithanh', 'hoaithanh', 'hoaithanh@gmail.com', 'thanh99', '0', '0978897679', 'ảnh 3.jfif'),
(20, 'thaovy', 'Thaovy', 'thaovy@gmail.com', '827ccb0eea8a706c4c34a16891f84e7b', '', '0967239725', 'ảnh 4.png'),
(21, 'hieu', 'Hieu', 'hieu@gmail.com', '202cb962ac59075b964b07152d234b70', '', '037564289', 'ảnh 2.jpg'),
(22, 'hung', 'hung', 'hung@gmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '', '0966446332', 'ảnh 1.jpg');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `user`
--
ALTER TABLE `user`
  MODIFY `ID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
