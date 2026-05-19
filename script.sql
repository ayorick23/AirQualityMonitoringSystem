CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `SensoresCalidadAire` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Ubicacion` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `TipoGas` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `Estado` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_SensoresCalidadAire` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `AlertasAire` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `SensorId` int NOT NULL,
    `Nivel` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `Mensaje` varchar(500) CHARACTER SET utf8mb4 NOT NULL,
    `FechaHora` datetime(6) NOT NULL,
    CONSTRAINT `PK_AlertasAire` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AlertasAire_SensoresCalidadAire_SensorId` FOREIGN KEY (`SensorId`) REFERENCES `SensoresCalidadAire` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `LecturasAire` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `SensorId` int NOT NULL,
    `PM2_5` decimal(65,30) NOT NULL,
    `PM10` decimal(65,30) NOT NULL,
    `CO2` decimal(65,30) NOT NULL,
    `FechaHora` datetime(6) NOT NULL,
    CONSTRAINT `PK_LecturasAire` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_LecturasAire_SensoresCalidadAire_SensorId` FOREIGN KEY (`SensorId`) REFERENCES `SensoresCalidadAire` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_AlertasAire_SensorId` ON `AlertasAire` (`SensorId`);

CREATE INDEX `IX_LecturasAire_SensorId` ON `LecturasAire` (`SensorId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20260519025732_InitialCreate', '8.0.8');

COMMIT;

