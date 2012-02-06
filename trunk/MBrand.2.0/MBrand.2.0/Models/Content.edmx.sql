



-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 02/06/2012 21:20:28
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;
SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Contents'

CREATE TABLE `Contents` (
    `Id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Text` longtext  NOT NULL,
    `Name` longtext  NOT NULL,
    `SeoDescription` longtext  NOT NULL,
    `SeoKeywords` longtext  NOT NULL,
    `Title` longtext  NOT NULL,
    `Desctiption` longtext  NOT NULL
);

-- Creating table 'Statements'

CREATE TABLE `Statements` (
    `Id` int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Text` longtext  NOT NULL
);

-- Creating table 'Contents_WorkGroup'

CREATE TABLE `Contents_WorkGroup` (
    `WorkId` int  NOT NULL,
    `Id` int  NOT NULL
);

-- Creating table 'Contents_Work'

CREATE TABLE `Contents_Work` (
    `WorkGroupId` int  NOT NULL,
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



-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on `WorkGroupId` in table 'Contents_Work'

ALTER TABLE `Contents_Work`
ADD CONSTRAINT `FK_WorkGroupWork`
    FOREIGN KEY (`WorkGroupId`)
    REFERENCES `Contents_WorkGroup`
        (`Id`)
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkGroupWork'

CREATE INDEX `IX_FK_WorkGroupWork` 
    ON `Contents_Work`
    (`WorkGroupId`);

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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
