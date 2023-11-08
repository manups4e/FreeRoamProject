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

-- Dump dei dati della tabella new_gamemode.users: ~4 rows (circa)
INSERT INTO `users` (`ID`, `UserID`, `discord`, `license`, `Name`, `group`, `group_level`, `playTime`, `last_connection`) VALUES
	(1, 6779795704521957376, '306134422434873346', '5a20e55a8cfdb8efeaa50ed048f7e92ae3ccc7ef', 'manups4e', 'dev', 5, 1275480, '2023-11-07 12:13:15'),

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

CREATE DEFINER=`root`@`localhost` PROCEDURE `IngressoPlayer`(
	IN `inDisc` BIGINT,
	IN `inLice` VARCHAR(75),
	IN `inName` VARCHAR(50),
	IN `inToken` BIGINT
)

LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT 'On join selects or create a new user'
BEGIN
	if (select exists(SELECT * FROM users WHERE discord = inDisc AND license = inLice) IS false) then
		INSERT INTO users (`UserID`, `discord`, `license`, `name`) VALUES (inToken, inDisc, `inLice`, `inName`);      
	END if;
	
	SELECT * FROM users where discord = inDisc AND license = inLice LIMIT 1;
END