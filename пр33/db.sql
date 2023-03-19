-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: mydb
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ap-17-1`
--

DROP TABLE IF EXISTS `ap-17-1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ap-17-1` (
  `id` int NOT NULL,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ap-17-1`
--

LOCK TABLES `ap-17-1` WRITE;
/*!40000 ALTER TABLE `ap-17-1` DISABLE KEYS */;
INSERT INTO `ap-17-1` VALUES (0,'Сафонов Захар Степанович'),(1,'Зыков Рубен Константинович'),(2,'Кабанов Адриан Робертович'),(3,'Киселёв Трофим Геннадиевич'),(4,'Уваров Андрей Мэлсович'),(5,'Осипов Ермолай Германович'),(6,'Романов Яков Тимофеевич'),(7,'Сафонов Леонард Александрович'),(8,'Голубев Михаил Альбертович'),(9,'Зуев Кассиан Геласьевич'),(10,'Кондратьев Мстислав Тимурович'),(11,'Авдеев Сергей Филатович'),(12,'Ефремов Азарий Антонинович'),(13,'Артемьев Ираклий Авксентьевич'),(14,'Осипов Рудольф Борисович');
/*!40000 ALTER TABLE `ap-17-1` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `groups`
--

DROP TABLE IF EXISTS `groups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `groups` (
  `id` int NOT NULL,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `groups`
--

LOCK TABLES `groups` WRITE;
/*!40000 ALTER TABLE `groups` DISABLE KEYS */;
INSERT INTO `groups` VALUES (0,'ЛП-17-1'),(1,'ЛП-17-2'),(2,'ТМ-17-1'),(3,'ТМ-17-1'),(4,'ТО-17-1'),(5,'АД-17-1'),(6,'АД-17-2'),(7,'УК-17-1'),(8,'АП-17-1'),(9,'РП-17-1'),(10,'МХ-17-1'),(11,'КС-17-1'),(12,'ПИ-17-1'),(13,'ИС-17-1'),(14,'ИС-17-2'),(15,'ЭК-17-1');
/*!40000 ALTER TABLE `groups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lp-17-1`
--

DROP TABLE IF EXISTS `lp-17-1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lp-17-1` (
  `id` int NOT NULL,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lp-17-1`
--

LOCK TABLES `lp-17-1` WRITE;
/*!40000 ALTER TABLE `lp-17-1` DISABLE KEYS */;
INSERT INTO `lp-17-1` VALUES (0,'Сафонов Захар Степанович'),(1,'Зыков Рубен Константинович'),(2,'Кабанов Адриан Робертович'),(3,'Киселёв Трофим Геннадиевич'),(4,'Уваров Андрей Мэлсович'),(5,'Осипов Ермолай Германович'),(6,'Романов Яков Тимофеевич'),(7,'Сафонов Леонард Александрович'),(8,'Голубев Михаил Альбертович'),(9,'Зуев Кассиан Геласьевич'),(10,'Кондратьев Мстислав Тимурович'),(11,'Авдеев Сергей Филатович'),(12,'Ефремов Азарий Антонинович'),(13,'Артемьев Ираклий Авксентьевич'),(14,'Осипов Рудольф Борисович');
/*!40000 ALTER TABLE `lp-17-1` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lp-17-2`
--

DROP TABLE IF EXISTS `lp-17-2`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lp-17-2` (
  `id` int NOT NULL,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lp-17-2`
--

LOCK TABLES `lp-17-2` WRITE;
/*!40000 ALTER TABLE `lp-17-2` DISABLE KEYS */;
INSERT INTO `lp-17-2` VALUES (0,'Селезнёв Аввакум Дмитрьевич'),(1,'Попов Адриан Фролович'),(2,'Панфилов Глеб Даниилович'),(3,'Кабанов Назарий Натанович'),(4,'Филиппов Клемент Ильяович'),(5,'Юдин Ипполит Семёнович'),(6,'Елисеев Юлиан Иосифович'),(7,'Гордеев Гордей Протасьевич'),(8,'Исаев Роберт Ярославович'),(9,'Трофимов Любомир Донатович'),(10,'Титов Вальтер Константинович'),(11,'Селиверстов Адам Германнович'),(12,'Тимофеев Рудольф Михайлович'),(13,'Трофимов Степан Тимофеевич'),(14,'Филиппов Макар Филиппович');
/*!40000 ALTER TABLE `lp-17-2` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tm-17-1`
--

DROP TABLE IF EXISTS `tm-17-1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tm-17-1` (
  `id` int NOT NULL,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tm-17-1`
--

LOCK TABLES `tm-17-1` WRITE;
/*!40000 ALTER TABLE `tm-17-1` DISABLE KEYS */;
INSERT INTO `tm-17-1` VALUES (0,'Мартынов Роман Проклович'),(1,'Шестаков Венедикт Наумович'),(2,'Харитонов Ким Владиславович'),(3,'Гуляев Гордей Георгьевич'),(4,'Буров Матвей Васильевич'),(5,'Антонов Герман Тимофеевич'),(6,'Никитин Людвиг Александрович'),(7,'Носков Власий Олегович'),(8,'Рогов Аким Ростиславович'),(9,'Марков Григорий Мэлорович'),(10,'Куликов Рудольф Макарович'),(11,'Лыткин Илларион Альбертович'),(12,'Сазонов Вениамин Еремеевич'),(13,'Стрелков Арсен Степанович'),(14,'Иванов Михаил Геннадиевич');
/*!40000 ALTER TABLE `tm-17-1` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-06 14:22:49
