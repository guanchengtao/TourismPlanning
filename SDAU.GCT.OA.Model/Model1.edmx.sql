
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/19/2019 16:35:15
-- Generated from EDMX file: D:\MyProject\SDAU.GCT.OA.Model\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyProject];
GO
--IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
--GO






-- Creating table 'PlantInfo'
CREATE TABLE [dbo].[PlantInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PlantName] nvarchar(20)  NOT NULL,
    [PlantDetail] nvarchar(2000)  NOT NULL,
    [JingDu] nvarchar(10)  NOT NULL,
    [WeiDu] nvarchar(10)  NOT NULL,
    [Xiaoqu] nvarchar(max)  NOT NULL,
    [SubTime] datetime  NOT NULL
);
GO

-- Creating table 'PlantImage'
CREATE TABLE [dbo].[PlantImage] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Url] nvarchar(1000)  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [SubTime] datetime  NOT NULL,
    [PlantInfoId] int  NOT NULL
);
GO

-- Creating table 'UserComment'
CREATE TABLE [dbo].[UserComment] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(300)  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [PlantInfoId] int  NOT NULL
);
GO





-- Creating primary key on [Id] in table 'PlantInfo'
ALTER TABLE [dbo].[PlantInfo]
ADD CONSTRAINT [PK_PlantInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlantImage'
ALTER TABLE [dbo].[PlantImage]
ADD CONSTRAINT [PK_PlantImage]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserComment'
ALTER TABLE [dbo].[UserComment]
ADD CONSTRAINT [PK_UserComment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO





-- --------------------------------------------------





-- Creating foreign key on [PlantInfoId] in table 'PlantImage'
ALTER TABLE [dbo].[PlantImage]
ADD CONSTRAINT [FK_PlantInfoPlantImage]
    FOREIGN KEY ([PlantInfoId])
    REFERENCES [dbo].[PlantInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlantInfoPlantImage'
CREATE INDEX [IX_FK_PlantInfoPlantImage]
ON [dbo].[PlantImage]
    ([PlantInfoId]);
GO

-- Creating foreign key on [PlantInfoId] in table 'UserComment'
ALTER TABLE [dbo].[UserComment]
ADD CONSTRAINT [FK_PlantInfoUserComment]
    FOREIGN KEY ([PlantInfoId])
    REFERENCES [dbo].[PlantInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlantInfoUserComment'
CREATE INDEX [IX_FK_PlantInfoUserComment]
ON [dbo].[UserComment]
    ([PlantInfoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------