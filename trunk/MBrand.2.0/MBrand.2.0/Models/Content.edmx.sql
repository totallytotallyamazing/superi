



-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 02/16/2012 22:29:22
-- Generated from EDMX file: D:\Work\MBrand\v2\MBrand.2.0\Models\Content.edmx
-- Target version: 2.0.0.0
-- --------------------------------------------------

DROP DATABASE IF EXISTS `gbua_mbrandnew`;
CREATE DATABASE `gbua_mbrandnew`;
USE `gbua_mbrandnew`;

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------

--    ALTER TABLE `Contents_Work` DROP CONSTRAINT `FK_Work_inherits_Content`;
--    ALTER TABLE `Contents_WorkGroup` DROP CONSTRAINT `FK_WorkGroup_inherits_Content`;
--    ALTER TABLE `Contents_Work` DROP CONSTRAINT `FK_WorkGroupWork`;

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;
    DROP TABLE IF EXISTS `Contents`;
    DROP TABLE IF EXISTS `Contents_Work`;
    DROP TABLE IF EXISTS `Contents_WorkGroup`;
    DROP TABLE IF EXISTS `Statements`;
SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Statements'

CREATE TABLE `Statements` (
    `Id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Text` longtext  NOT NULL
);

-- Creating table 'Contents'

CREATE TABLE `Contents` (
    `Id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Text` longtext  NULL,
    `Name` longtext  NOT NULL,
    `Title` longtext  NOT NULL,
    `SeoDescription` longtext  NULL,
    `SeoKeywords` longtext  NULL,
    `Description` longtext  NULL
);

-- Creating table 'Contents_WorkGroup'

CREATE TABLE `Contents_WorkGroup` (
    `Id` int  NOT NULL
);

-- Creating table 'Contents_Work'

CREATE TABLE `Contents_Work` (
    `Image` longtext  NULL,
    `Id` int  NOT NULL,
    `WorkGroup_Id` int  NOT NULL
);

-- Creating table 'Contents_TextContent'

CREATE TABLE `Contents_TextContent` (
    `Id` int  NOT NULL
);



-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on `Id` in table 'Contents_WorkGroup'

ALTER TABLE `Contents_WorkGroup`
ADD CONSTRAINT `PK_Contents_WorkGroup`
    PRIMARY KEY (`Id` );

-- Creating primary key on `Id` in table 'Contents_Work'

ALTER TABLE `Contents_Work`
ADD CONSTRAINT `PK_Contents_Work`
    PRIMARY KEY (`Id` );

-- Creating primary key on `Id` in table 'Contents_TextContent'

ALTER TABLE `Contents_TextContent`
ADD CONSTRAINT `PK_Contents_TextContent`
    PRIMARY KEY (`Id` );



-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on `WorkGroup_Id` in table 'Contents_Work'

ALTER TABLE `Contents_Work`
ADD CONSTRAINT `FK_WorkGroupWork`
    FOREIGN KEY (`WorkGroup_Id`)
    REFERENCES `Contents_WorkGroup`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkGroupWork'

CREATE INDEX `IX_FK_WorkGroupWork` 
    ON `Contents_Work`
    (`WorkGroup_Id`);

-- Creating foreign key on `Id` in table 'Contents_WorkGroup'

ALTER TABLE `Contents_WorkGroup`
ADD CONSTRAINT `FK_WorkGroup_inherits_Content`
    FOREIGN KEY (`Id`)
    REFERENCES `Contents`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating foreign key on `Id` in table 'Contents_Work'

ALTER TABLE `Contents_Work`
ADD CONSTRAINT `FK_Work_inherits_Content`
    FOREIGN KEY (`Id`)
    REFERENCES `Contents`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating foreign key on `Id` in table 'Contents_TextContent'

ALTER TABLE `Contents_TextContent`
ADD CONSTRAINT `FK_TextContent_inherits_Content`
    FOREIGN KEY (`Id`)
    REFERENCES `Contents`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
