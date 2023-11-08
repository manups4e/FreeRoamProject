-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versione server:              10.4.28-MariaDB - mariadb.org binary distribution
-- S.O. server:                  Win64
-- HeidiSQL Versione:            12.5.0.6677
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dump della struttura del database new_gamemode
CREATE DATABASE IF NOT EXISTS `new_gamemode` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `new_gamemode`;

-- Dump della struttura di procedura new_gamemode.IngressoPlayer
DELIMITER //
CREATE PROCEDURE `IngressoPlayer`(
	IN `inDisc` BIGINT,
	IN `inLice` VARCHAR(75),
	IN `inName` VARCHAR(50),
	IN `inToken` BIGINT
)
    COMMENT 'All''ingresso seleziona o crea un nuovo User'
BEGIN
	if (select exists(SELECT * FROM users WHERE discord = inDisc AND license = inLice) IS false) then
		INSERT INTO users (`UserID`, `discord`, `license`, `name`) VALUES (inToken, inDisc, `inLice`, `inName`);      
	END if;
	
	SELECT * FROM users where discord = inDisc AND license = inLice LIMIT 1;
END//
DELIMITER ;

-- Dump della struttura di tabella new_gamemode.users
CREATE TABLE IF NOT EXISTS `users` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` bigint(20) DEFAULT NULL,
  `discord` varchar(75) DEFAULT NULL,
  `license` varchar(75) DEFAULT NULL,
  `Name` varchar(75) DEFAULT NULL,
  `group` char(10) DEFAULT 'user',
  `group_level` int(1) NOT NULL DEFAULT 0,
  `playTime` int(12) NOT NULL DEFAULT 0,
  `last_connection` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`ID`) USING BTREE,
  UNIQUE KEY `Unique_Discord` (`discord`) USING BTREE,
  UNIQUE KEY `Unique_License` (`license`),
  UNIQUE KEY `Snowflake` (`UserID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=185 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dump dei dati della tabella new_gamemode.users: ~4 rows (circa)
INSERT INTO `users` (`ID`, `UserID`, `discord`, `license`, `Name`, `group`, `group_level`, `playTime`, `last_connection`) VALUES
	(1, 6779795704521957376, '306134422434873346', '5a20e55a8cfdb8efeaa50ed048f7e92ae3ccc7ef', 'manups4e', 'dev', 5, 1275480, '2023-11-08 11:26:36');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
