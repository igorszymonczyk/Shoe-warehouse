CREATE DATABASE  IF NOT EXISTS `magazyn_butow` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `magazyn_butow`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: magazyn_butow
-- ------------------------------------------------------
-- Server version	8.0.36

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
-- Table structure for table `buty`
--

DROP TABLE IF EXISTS `buty`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `buty` (
  `id_buta` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `styl` tinyint unsigned NOT NULL,
  `marka` tinyint unsigned NOT NULL,
  `sku` char(16) COLLATE utf8mb4_unicode_ci NOT NULL,
  `kolorystyka` char(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `model` char(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id_buta`),
  KEY `styl` (`styl`),
  KEY `marka` (`marka`),
  CONSTRAINT `buty_ibfk_1` FOREIGN KEY (`styl`) REFERENCES `style` (`id_stylu`),
  CONSTRAINT `buty_ibfk_2` FOREIGN KEY (`marka`) REFERENCES `marki` (`id_marki`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `buty`
--

LOCK TABLES `buty` WRITE;
/*!40000 ALTER TABLE `buty` DISABLE KEYS */;
INSERT INTO `buty` VALUES (1,3,1,'CN2405-900','Travis Scott Cactus Jack','Nike Air Force 1 Low'),(2,2,2,'555088-610','Bred Toe','Nike Air Jordan 1 Retro High'),(3,4,3,'DC9533-001','Off Noir','Nike Air Jordan 4 Retro Union'),(4,5,4,'FU9006','Black Non-Reflective','Adidas Yeezy Boost 350 V2'),(5,3,5,'M992AG','Grey Blue Red','New Balance 992'),(6,2,6,'VN0A38G1R1Q','Yacht Club','Vans Old Skool'),(7,4,7,'163862C','Off White','Converse Chuck Taylor All Star 70s Hi'),(8,5,1,'FW5191','Yeezreel Non-Reflective','Adidas Yeezy Boost 350 V2'),(9,3,2,'555088-030','Pine Green Black','Nike Air Jordan 1 Retro High'),(10,2,3,'555088-134','University Blue','Air Jordan 1 Retro High OG'),(11,4,5,'875','Charcoal','1906'),(12,1,4,'8953','Flax','Slide'),(14,4,2,'3123','Czerń','Nike Air Max Plus'),(15,3,2,'DD1391-100','Panda','Nike Dunk Low'),(16,4,3,'554724-091','Explore Jordan','Jordan 1 Mid'),(17,4,1,'IE2697','Lucid Blue-Easy Yellow','Harden Volume 8'),(18,4,1,'IF6171','Supplier Colour-White-Core Black','Crazy 1'),(19,3,5,'GC2002BK','Retro Energy','2002R'),(20,3,5,'U9060NRG','Speedy Strides','9060'),(21,3,5,'U9060NRH','Speedy Strides','9060');
/*!40000 ALTER TABLE `buty` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = cp852 */ ;
/*!50003 SET character_set_results = cp852 */ ;
/*!50003 SET collation_connection  = cp852_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `przed_usunieciem_butow` BEFORE DELETE ON `buty` FOR EACH ROW BEGIN
    DELETE FROM cennik WHERE but = OLD.id_buta;
    DELETE FROM kolory_buta WHERE but = OLD.id_buta;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `cennik`
--

DROP TABLE IF EXISTS `cennik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cennik` (
  `but` tinyint unsigned NOT NULL,
  `rozmiar` tinyint unsigned NOT NULL,
  `cena` decimal(10,2) NOT NULL,
  KEY `but` (`but`),
  KEY `rozmiar` (`rozmiar`),
  CONSTRAINT `cennik_ibfk_1` FOREIGN KEY (`but`) REFERENCES `buty` (`id_buta`),
  CONSTRAINT `cennik_ibfk_2` FOREIGN KEY (`rozmiar`) REFERENCES `rozmiary` (`id_rozmiaru`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cennik`
--

LOCK TABLES `cennik` WRITE;
/*!40000 ALTER TABLE `cennik` DISABLE KEYS */;
INSERT INTO `cennik` VALUES (1,10,299.99),(2,11,399.99),(3,12,499.99),(4,13,599.99),(5,14,699.99),(6,15,799.99),(7,16,899.99),(8,17,999.99),(9,18,1099.99),(10,19,1199.99),(18,3,800.00),(17,28,900.00),(16,29,1000.00),(15,29,1200.00),(14,29,600.00),(18,25,800.00),(20,29,1000.00),(21,23,1011.00),(19,26,700.00),(19,23,800.00);
/*!40000 ALTER TABLE `cennik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kolory`
--

DROP TABLE IF EXISTS `kolory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kolory` (
  `id_koloru` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `kolor` char(32) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id_koloru`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kolory`
--

LOCK TABLES `kolory` WRITE;
/*!40000 ALTER TABLE `kolory` DISABLE KEYS */;
INSERT INTO `kolory` VALUES (1,'niebieski'),(2,'czerwony'),(3,'żółty'),(4,'szary'),(5,'biały'),(6,'czarny'),(7,'fioletowy'),(8,'zielony'),(9,'różowy'),(10,'pomarańczowy'),(11,'brązowy');
/*!40000 ALTER TABLE `kolory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kolory_buta`
--

DROP TABLE IF EXISTS `kolory_buta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kolory_buta` (
  `but` tinyint unsigned NOT NULL,
  `kolor` tinyint unsigned NOT NULL,
  KEY `but` (`but`),
  KEY `kolor` (`kolor`),
  CONSTRAINT `kolory_buta_ibfk_1` FOREIGN KEY (`but`) REFERENCES `buty` (`id_buta`),
  CONSTRAINT `kolory_buta_ibfk_2` FOREIGN KEY (`kolor`) REFERENCES `kolory` (`id_koloru`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kolory_buta`
--

LOCK TABLES `kolory_buta` WRITE;
/*!40000 ALTER TABLE `kolory_buta` DISABLE KEYS */;
INSERT INTO `kolory_buta` VALUES (1,1),(1,5),(2,2),(2,6),(3,8),(3,3),(4,6),(4,5),(5,4),(5,1),(6,7),(6,10),(7,11),(7,5),(8,8),(8,2),(9,6),(9,3),(10,1),(10,4),(11,3),(11,5),(11,6),(11,9),(11,10),(11,11),(12,11),(14,6),(15,5),(16,6),(17,7),(17,11),(18,10),(18,5),(18,6),(19,1),(19,5),(20,3),(20,2),(20,6),(21,6),(21,7),(21,4);
/*!40000 ALTER TABLE `kolory_buta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `marki`
--

DROP TABLE IF EXISTS `marki`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `marki` (
  `id_marki` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `marka` char(32) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id_marki`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `marki`
--

LOCK TABLES `marki` WRITE;
/*!40000 ALTER TABLE `marki` DISABLE KEYS */;
INSERT INTO `marki` VALUES (1,'Adidas'),(2,'Nike'),(3,'Jordan'),(4,'Yeezy'),(5,'New Balance'),(6,'Vans'),(7,'Converse');
/*!40000 ALTER TABLE `marki` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rozmiary`
--

DROP TABLE IF EXISTS `rozmiary`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rozmiary` (
  `id_rozmiaru` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `rozmiar_eu` char(10) COLLATE utf8mb4_unicode_ci NOT NULL,
  `rozmiar_us` char(10) COLLATE utf8mb4_unicode_ci NOT NULL,
  `rozmiar_uk` char(10) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id_rozmiaru`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rozmiary`
--

LOCK TABLES `rozmiary` WRITE;
/*!40000 ALTER TABLE `rozmiary` DISABLE KEYS */;
INSERT INTO `rozmiary` VALUES (1,'36','4','3.5'),(2,'36.5','4.5','4'),(3,'36 2/3','4.5','4'),(4,'37 1/3','5','4.5'),(5,'37.5','5','4.5'),(6,'38','5.5','5'),(7,'38.5','6','5.5'),(8,'38 2/3','6','5.5'),(9,'39','6.5','6'),(10,'39 1/3','6.5','6'),(11,'40','7','6'),(12,'40','7','6.5'),(13,'40.5','7.5','6.5'),(14,'40 2/3','7.5','7'),(15,'41','8','7'),(16,'41 1/3','8','7.5'),(17,'42','8.5','7.5'),(18,'42','8.5','8'),(19,'42.5','9','8'),(20,'42 2/3','9','8.5'),(21,'43','9.5','8.5'),(22,'43 1/3','9.5','9'),(23,'44','10','9'),(24,'44','10','9.5'),(25,'44 2/3','10.5','10'),(26,'44.5','10.5','9.5'),(27,'45','11','10'),(28,'45 1/3','11','10.5'),(29,'45.5','11.5','10.5'),(30,'46','12','11'),(31,'46','11.5','11'),(32,'46 2/3','12','11.5'),(33,'47','12.5','11.5'),(34,'47 1/3','12.5','12'),(35,'47.5','13','12'),(36,'48','13','12.5'),(37,'48.5','14','13'),(38,'48 2/3','13.5','13'),(39,'49 1/3','14','13.5'),(40,'49.5','15','14');
/*!40000 ALTER TABLE `rozmiary` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rozmiary_marek`
--

DROP TABLE IF EXISTS `rozmiary_marek`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rozmiary_marek` (
  `marka` tinyint unsigned NOT NULL,
  `rozmiar` tinyint unsigned NOT NULL,
  KEY `marka` (`marka`),
  KEY `rozmiar` (`rozmiar`),
  CONSTRAINT `rozmiary_marek_ibfk_1` FOREIGN KEY (`marka`) REFERENCES `marki` (`id_marki`),
  CONSTRAINT `rozmiary_marek_ibfk_2` FOREIGN KEY (`rozmiar`) REFERENCES `rozmiary` (`id_rozmiaru`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rozmiary_marek`
--

LOCK TABLES `rozmiary_marek` WRITE;
/*!40000 ALTER TABLE `rozmiary_marek` DISABLE KEYS */;
INSERT INTO `rozmiary_marek` VALUES (1,1),(1,3),(1,4),(1,6),(1,8),(1,10),(1,12),(1,14),(1,16),(1,18),(1,20),(1,22),(1,24),(1,25),(1,28),(1,31),(1,32),(1,34),(1,36),(1,38),(1,39),(4,1),(4,3),(4,4),(4,6),(4,8),(4,10),(4,12),(4,14),(4,16),(4,18),(4,20),(4,22),(4,24),(4,25),(4,28),(4,31),(4,32),(4,34),(4,36),(4,38),(4,39),(2,1),(2,2),(2,5),(2,6),(2,7),(2,9),(2,12),(2,13),(2,15),(2,17),(2,19),(2,21),(2,23),(2,26),(2,27),(2,29),(2,30),(2,33),(2,35),(2,36),(2,37),(2,40),(3,1),(3,2),(3,5),(3,6),(3,7),(3,9),(3,12),(3,13),(3,15),(3,17),(3,19),(3,21),(3,23),(3,26),(3,27),(3,29),(3,30),(3,33),(3,35),(3,36),(3,37),(3,40),(5,1),(5,2),(5,5),(5,6),(5,7),(5,9),(5,12),(5,13),(5,15),(5,17),(5,19),(5,21),(5,23),(5,26),(5,27),(5,29),(5,30),(5,33),(5,35),(5,36),(5,37),(5,40),(6,1),(6,2),(6,5),(6,6),(6,7),(6,9),(6,12),(6,13),(6,15),(6,17),(6,19),(6,21),(6,23),(6,26),(6,27),(6,29),(6,30),(6,33),(6,35),(6,36),(6,37),(6,40),(7,1),(7,2),(7,5),(7,6),(7,7),(7,9),(7,12),(7,13),(7,15),(7,17),(7,19),(7,21),(7,23),(7,26),(7,27),(7,29),(7,30),(7,33),(7,35),(7,36),(7,37),(7,40);
/*!40000 ALTER TABLE `rozmiary_marek` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `style`
--

DROP TABLE IF EXISTS `style`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `style` (
  `id_stylu` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `styl` char(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id_stylu`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `style`
--

LOCK TABLES `style` WRITE;
/*!40000 ALTER TABLE `style` DISABLE KEYS */;
INSERT INTO `style` VALUES (1,'Klapki'),(2,'Buty wysokie'),(3,'Buty niskie'),(4,'Buty średnio-wysokie'),(5,'Trampki');
/*!40000 ALTER TABLE `style` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `widokfiltrowaniabutow`
--

DROP TABLE IF EXISTS `widokfiltrowaniabutow`;
/*!50001 DROP VIEW IF EXISTS `widokfiltrowaniabutow`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `widokfiltrowaniabutow` AS SELECT 
 1 AS `model`,
 1 AS `kolorystyka`,
 1 AS `marka`,
 1 AS `styl`,
 1 AS `rozmiar_eu`,
 1 AS `cena`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'magazyn_butow'
--

--
-- Dumping routines for database 'magazyn_butow'
--
/*!50003 DROP PROCEDURE IF EXISTS `FiltrowanieButow` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = cp852 */ ;
/*!50003 SET character_set_results = cp852 */ ;
/*!50003 SET collation_connection  = cp852_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `FiltrowanieButow`(
    IN p_marka VARCHAR(255) CHARACTER SET utf8mb4,
    IN p_styl VARCHAR(255) CHARACTER SET utf8mb4,
    IN p_model VARCHAR(255) CHARACTER SET utf8mb4,
    IN p_kolor VARCHAR(255) CHARACTER SET utf8mb4
)
BEGIN
    SET @sql = 'SELECT DISTINCT buty.model, buty.kolorystyka, marki.marka, style.styl, rozmiary.rozmiar_eu, cennik.cena
		FROM buty 
		JOIN marki ON buty.marka = marki.id_marki
		JOIN style ON buty.styl = style.id_stylu
		JOIN cennik ON buty.id_buta = cennik.but
		JOIN rozmiary ON rozmiary.id_rozmiaru = cennik.rozmiar
		JOIN kolory_buta ON kolory_buta.but = buty.id_buta
		JOIN kolory ON kolory_buta.kolor = kolory.id_koloru
		WHERE 1=1';

    IF p_marka IS NOT NULL THEN
        SET @sql = CONCAT(@sql, ' AND marki.marka = ''', p_marka, '''');
    END IF;

    IF p_styl IS NOT NULL THEN
        SET @sql = CONCAT(@sql, ' AND style.styl = ''', p_styl, '''');
    END IF;

    IF p_model IS NOT NULL THEN
        SET @sql = CONCAT(@sql, ' AND buty.model = ''', p_model, '''');
    END IF;

    IF p_kolor IS NOT NULL THEN
        SET @sql = CONCAT(@sql, ' AND kolory.kolor = ''', p_kolor, '''');
    END IF;

    PREPARE stmt FROM @sql;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `widokfiltrowaniabutow`
--

/*!50001 DROP VIEW IF EXISTS `widokfiltrowaniabutow`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = cp852 */;
/*!50001 SET character_set_results     = cp852 */;
/*!50001 SET collation_connection      = cp852_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `widokfiltrowaniabutow` AS select distinct `buty`.`model` AS `model`,`buty`.`kolorystyka` AS `kolorystyka`,`marki`.`marka` AS `marka`,`style`.`styl` AS `styl`,`rozmiary`.`rozmiar_eu` AS `rozmiar_eu`,`cennik`.`cena` AS `cena` from ((((((`buty` join `marki` on((`buty`.`marka` = `marki`.`id_marki`))) join `style` on((`buty`.`styl` = `style`.`id_stylu`))) join `cennik` on((`buty`.`id_buta` = `cennik`.`but`))) join `rozmiary` on((`rozmiary`.`id_rozmiaru` = `cennik`.`rozmiar`))) join `kolory_buta` on((`kolory_buta`.`but` = `buty`.`id_buta`))) join `kolory` on((`kolory_buta`.`kolor` = `kolory`.`id_koloru`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-13 14:54:32
