--CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
--    `MigrationId` varchar(150) NOT NULL,
--    `ProductVersion` varchar(32) NOT NULL,
--    PRIMARY KEY (`MigrationId`)
--);

--START TRANSACTION;

--CREATE TABLE `Heroes` (
--    `HeroId` int NOT NULL AUTO_INCREMENT,
--    `Name` longtext NULL,
--    `Active` tinyint(1) NOT NULL,
--    `UpdateDate` datetime(6) NOT NULL,
--    PRIMARY KEY (`HeroId`)
--);

--CREATE TABLE `Movies` (
--    `MovieId` int NOT NULL AUTO_INCREMENT,
--    `Name` longtext NULL,
--    `Rate` int NOT NULL,
--    PRIMARY KEY (`MovieId`)
--);

--CREATE TABLE `Secrets` (
--    `SecretId` int NOT NULL AUTO_INCREMENT,
--    `Name` longtext NULL,
--    `HeroId` int NOT NULL,
--    PRIMARY KEY (`SecretId`),
--    CONSTRAINT `FK_Secrets_Heroes_HeroId` FOREIGN KEY (`HeroId`) REFERENCES `Heroes` (`HeroId`) ON DELETE CASCADE
--);

--CREATE TABLE `Weapons` (
--    `WeaponId` int NOT NULL AUTO_INCREMENT,
--    `Name` longtext NULL,
--    `HeroId` int NOT NULL,
--    PRIMARY KEY (`WeaponId`),
--    CONSTRAINT `FK_Weapons_Heroes_HeroId` FOREIGN KEY (`HeroId`) REFERENCES `Heroes` (`HeroId`) ON DELETE CASCADE
--);

--CREATE TABLE `HeroesMovies` (
--    `HeroId` int NOT NULL,
--    `MovieId` int NOT NULL,
--    PRIMARY KEY (`HeroId`, `MovieId`),
--    CONSTRAINT `FK_HeroesMovies_Heroes_HeroId` FOREIGN KEY (`HeroId`) REFERENCES `Heroes` (`HeroId`) ON DELETE CASCADE,
--    CONSTRAINT `FK_HeroesMovies_Movies_MovieId` FOREIGN KEY (`MovieId`) REFERENCES `Movies` (`MovieId`) ON DELETE CASCADE
--);

--CREATE INDEX `IX_HeroesMovies_MovieId` ON `HeroesMovies` (`MovieId`);

--CREATE UNIQUE INDEX `IX_Secrets_HeroId` ON `Secrets` (`HeroId`);

--CREATE INDEX `IX_Weapons_HeroId` ON `Weapons` (`HeroId`);

--INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
--VALUES ('20230916232706_Create_Databse_And_Tables', '7.0.11');

--COMMIT;

