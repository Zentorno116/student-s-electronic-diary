-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: University
-- ------------------------------------------------------
-- Server version	8.0.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `accounts`
--

DROP TABLE IF EXISTS `accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `accounts` (
  `login` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `is_admin` tinyint(1) DEFAULT NULL,
  `first_name` varchar(20) DEFAULT NULL,
  `surname` varchar(20) DEFAULT NULL,
  `last_name` varchar(20) DEFAULT NULL,
  `groupname` varchar(10) DEFAULT NULL,
  `birthday` date DEFAULT NULL,
  `path_to_picture` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accounts`
--

LOCK TABLES `accounts` WRITE;
/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
INSERT INTO `accounts` VALUES ('admin','qwerty',1,' ',' ',' ',' ','2012-08-20',' '),('login','parol',0,'Имя','Фамилия','Отчество','09-321(1)','2009-11-20',' '),('sdf','sdf',0,'fasd','sdf','fsd','09-322(2)','2009-11-20',' '),('Логин','Пароль',0,'Имя','Фамилия','Отчество','09-321(2)','2009-11-20',' '),('Логин','Пароль',0,'Мурад','Быданов','Эдвардович','09-321(2)','2009-11-20',' '),('kriper2004','2004',0,'Idiot','Familnyi','NotStated','09-322(2)','2009-11-20','C:/Users/Тимур/OneDrive/Pictures/Screenshots/Снимок экрана 2024-03-29 165920.png'),('klara','aralk',0,'Клара','Исхакова','Валидоловна','09-321(1)','2009-11-20',' ');
/*!40000 ALTER TABLE `accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lessons`
--

DROP TABLE IF EXISTS `lessons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lessons` (
  `lesson_id` int NOT NULL AUTO_INCREMENT,
  `group_name` varchar(20) NOT NULL,
  `day_of_the_week` varchar(20) NOT NULL,
  `lesson_number` int DEFAULT NULL,
  PRIMARY KEY (`lesson_id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lessons`
--

LOCK TABLES `lessons` WRITE;
/*!40000 ALTER TABLE `lessons` DISABLE KEYS */;
INSERT INTO `lessons` VALUES (1,'09-321(1)','Monday',0),(2,'09-321(2)','Monday',0),(3,'09-322(1)','Monday',0),(4,'09-322(2)','Monday',0),(5,'09-321(1)','Monday',1),(6,'09-321(2)','Monday',1),(7,'09-322(1)','Monday',1),(8,'09-322(2)','Monday',1),(10,'09-321(1)','Вторник',3),(11,'09-321(1)','Вторник',1),(16,'09-321(1)','Понедельник',1),(18,'09-321(1)','Вторник',2);
/*!40000 ALTER TABLE `lessons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `points`
--

DROP TABLE IF EXISTS `points`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `points` (
  `student_login` varchar(30) DEFAULT NULL,
  `subject` varchar(50) DEFAULT NULL,
  `point1` int DEFAULT NULL,
  `point2` int DEFAULT NULL,
  `point3` int DEFAULT NULL,
  `point4` int DEFAULT NULL,
  `point5` int DEFAULT NULL,
  `point6` int DEFAULT NULL,
  `point7` int DEFAULT NULL,
  `point8` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `points`
--

LOCK TABLES `points` WRITE;
/*!40000 ALTER TABLE `points` DISABLE KEYS */;
INSERT INTO `points` VALUES ('login','математический анализ',4,10,0,0,0,0,0,0),('login','алгебра и геометрия',0,0,6,0,0,0,0,0),('sdf','математический анализ',67,13,0,0,0,0,0,0),('sdf','алгебра и геометрия',0,3,0,0,0,0,0,0),('Логин','математический анализ',0,0,0,0,0,0,0,0),('Логин','алгебра и геометрия',0,0,0,0,0,0,0,0),('Логин','математический анализ',0,0,0,0,0,0,0,0),('Логин','алгебра и геометрия',0,0,0,0,0,0,0,0),('Логин','математический анализ',0,0,0,0,0,0,0,0),('Логин','алгебра и геометрия',0,0,0,0,0,0,0,0),('Логин','технологии программирования',0,0,0,0,0,0,0,0),('Логин','история',0,0,0,0,0,0,0,0),('kriper2004','математический анализ',0,0,0,0,0,0,0,0),('kriper2004','алгебра и геометрия',0,0,0,0,0,0,0,0),('kriper2004','технологии программирования',0,0,0,0,0,0,0,0),('kriper2004','история',0,0,0,0,0,0,0,0),('klara','математический анализ',0,0,0,0,0,0,0,0),('klara','алгебра и геометрия',0,0,0,0,0,0,0,0),('klara','технологии программирования',0,0,0,0,0,0,0,0),('klara','история',0,0,0,0,0,0,0,0);
/*!40000 ALTER TABLE `points` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `schedule`
--

DROP TABLE IF EXISTS `schedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `schedule` (
  `parity` tinyint(1) DEFAULT NULL,
  `lesson_id` int DEFAULT NULL,
  `teacher_id` int DEFAULT NULL,
  `room` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedule`
--

LOCK TABLES `schedule` WRITE;
/*!40000 ALTER TABLE `schedule` DISABLE KEYS */;
INSERT INTO `schedule` VALUES (0,9,3,''),(1,10,1,''),(0,11,2,''),(0,12,3,''),(1,14,4,''),(1,15,1,''),(0,16,1,''),(0,17,3,''),(0,18,1,'');
/*!40000 ALTER TABLE `schedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teachers`
--

DROP TABLE IF EXISTS `teachers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teachers` (
  `ID` int DEFAULT NULL,
  `first_name` varchar(50) DEFAULT NULL,
  `surname` varchar(50) DEFAULT NULL,
  `last_name` varchar(50) DEFAULT NULL,
  `subject` varchar(50) DEFAULT NULL,
  `group_name` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teachers`
--

LOCK TABLES `teachers` WRITE;
/*!40000 ALTER TABLE `teachers` DISABLE KEYS */;
INSERT INTO `teachers` VALUES (1,'Anatoly','Sidorov','Mihailovich','математический анализ','09-321(1)'),(2,'Dinara','Ginyatova','Halilovna','алгебра и геометрия','09-321(1)'),(3,'Дина','Лапыпова','Сергеевна','технологии программирования','09-321(1)'),(4,'Людмила','Бродовская','Николаевна','история','09-321(1)');
/*!40000 ALTER TABLE `teachers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-03-31  4:39:21
