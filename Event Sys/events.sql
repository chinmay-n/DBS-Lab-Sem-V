-- MySQL dump 10.16  Distrib 10.1.18-MariaDB, for Linux (x86_64)
--
-- Host: localhost    Database: events
-- ------------------------------------------------------
-- Server version	10.1.18-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `category` (
  `cname` varchar(6) DEFAULT NULL,
  `eid` int(11) NOT NULL,
  `cid` int(11) NOT NULL AUTO_INCREMENT,
  `max_p` int(11) DEFAULT NULL,
  `prize` int(11) DEFAULT NULL,
  PRIMARY KEY (`cid`,`eid`),
  KEY `eid` (`eid`),
  CONSTRAINT `category_ibfk_1` FOREIGN KEY (`eid`) REFERENCES `event` (`evid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `etype`
--

DROP TABLE IF EXISTS `etype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `etype` (
  `typeid` varchar(4) NOT NULL,
  `tname` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`typeid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `etype`
--

LOCK TABLES `etype` WRITE;
/*!40000 ALTER TABLE `etype` DISABLE KEYS */;
/*!40000 ALTER TABLE `etype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event`
--

DROP TABLE IF EXISTS `event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event` (
  `evid` int(11) NOT NULL AUTO_INCREMENT,
  `ename` varchar(10) NOT NULL,
  `typeid` varchar(4) DEFAULT NULL,
  `address` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`evid`),
  KEY `typeid` (`typeid`),
  CONSTRAINT `event_ibfk_1` FOREIGN KEY (`typeid`) REFERENCES `etype` (`typeid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event`
--

LOCK TABLES `event` WRITE;
/*!40000 ALTER TABLE `event` DISABLE KEYS */;
/*!40000 ALTER TABLE `event` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reg`
--

DROP TABLE IF EXISTS `reg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reg` (
  `regid` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(10) DEFAULT NULL,
  `eid` int(11) NOT NULL,
  `uname` varchar(6) DEFAULT NULL,
  `amt` int(11) DEFAULT NULL,
  PRIMARY KEY (`regid`,`eid`),
  KEY `eid` (`eid`),
  KEY `uname` (`uname`),
  CONSTRAINT `reg_ibfk_1` FOREIGN KEY (`eid`) REFERENCES `event` (`evid`),
  CONSTRAINT `reg_ibfk_2` FOREIGN KEY (`uname`) REFERENCES `reg_user` (`uname`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reg`
--

LOCK TABLES `reg` WRITE;
/*!40000 ALTER TABLE `reg` DISABLE KEYS */;
/*!40000 ALTER TABLE `reg` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reg_user`
--

DROP TABLE IF EXISTS `reg_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reg_user` (
  `uname` varchar(6) NOT NULL,
  `name` varchar(10) DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `email` varchar(10) DEFAULT NULL,
  `password` varchar(32) DEFAULT NULL,
  `phone` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`uname`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reg_user`
--

LOCK TABLES `reg_user` WRITE;
/*!40000 ALTER TABLE `reg_user` DISABLE KEYS */;
/*!40000 ALTER TABLE `reg_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teams`
--

DROP TABLE IF EXISTS `teams`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `teams` (
  `regid` int(11) NOT NULL,
  `cid` int(11) NOT NULL,
  `eid` int(11) NOT NULL,
  `tid` int(11) DEFAULT NULL,
  PRIMARY KEY (`regid`,`eid`,`cid`),
  UNIQUE KEY `tid` (`tid`),
  KEY `eid` (`eid`),
  KEY `cid` (`cid`),
  CONSTRAINT `teams_ibfk_1` FOREIGN KEY (`regid`) REFERENCES `reg` (`regid`),
  CONSTRAINT `teams_ibfk_2` FOREIGN KEY (`eid`) REFERENCES `event` (`evid`),
  CONSTRAINT `teams_ibfk_3` FOREIGN KEY (`cid`) REFERENCES `category` (`cid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teams`
--

LOCK TABLES `teams` WRITE;
/*!40000 ALTER TABLE `teams` DISABLE KEYS */;
/*!40000 ALTER TABLE `teams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `name` varchar(10) DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `tuname` varchar(6) DEFAULT NULL,
  `aadhar` varchar(8) NOT NULL,
  `email` varchar(10) DEFAULT NULL,
  `phone` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`aadhar`),
  UNIQUE KEY `phone` (`phone`),
  UNIQUE KEY `tuname` (`tuname`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-11-16 20:35:53
