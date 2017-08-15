
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/09/2017 13:44:01
-- Generated from EDMX file: C:\Users\agustin.binci\Documents\Proyectos\FakeAPI\DataAccess\SqlServerDao\EntityModel\EntitiesModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Obras];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Item_Requirement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Item] DROP CONSTRAINT [FK_Item_Requirement];
GO
IF OBJECT_ID(N'[dbo].[FK_RequirementUser_Requirement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequirementUser] DROP CONSTRAINT [FK_RequirementUser_Requirement];
GO
IF OBJECT_ID(N'[dbo].[FK_RequirementUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequirementUser] DROP CONSTRAINT [FK_RequirementUser_User];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleAction_Action]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleAction] DROP CONSTRAINT [FK_RoleAction_Action];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleAction_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleAction] DROP CONSTRAINT [FK_RoleAction_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_Sheet_Requirement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sheet] DROP CONSTRAINT [FK_Sheet_Requirement];
GO
IF OBJECT_ID(N'[dbo].[FK_Sheet_SheetState]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sheet] DROP CONSTRAINT [FK_Sheet_SheetState];
GO
IF OBJECT_ID(N'[dbo].[FK_SheetItem_Sheet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SheetItem] DROP CONSTRAINT [FK_SheetItem_Sheet];
GO
IF OBJECT_ID(N'[dbo].[FK_SheetItem_SubItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SheetItem] DROP CONSTRAINT [FK_SheetItem_SubItem];
GO
IF OBJECT_ID(N'[dbo].[FK_SubItem_Item]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubItem] DROP CONSTRAINT [FK_SubItem_Item];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Role];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Action]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Action];
GO
IF OBJECT_ID(N'[dbo].[ExpirationState]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExpirationState];
GO
IF OBJECT_ID(N'[dbo].[Item]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Item];
GO
IF OBJECT_ID(N'[dbo].[Message]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Message];
GO
IF OBJECT_ID(N'[dbo].[Parameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Parameter];
GO
IF OBJECT_ID(N'[dbo].[Requirement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Requirement];
GO
IF OBJECT_ID(N'[dbo].[RequirementUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RequirementUser];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[RoleAction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleAction];
GO
IF OBJECT_ID(N'[dbo].[Sheet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sheet];
GO
IF OBJECT_ID(N'[dbo].[SheetItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SheetItem];
GO
IF OBJECT_ID(N'[dbo].[SheetState]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SheetState];
GO
IF OBJECT_ID(N'[dbo].[SubItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubItem];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Action'
CREATE TABLE [dbo].[Action] (
    [actionId] int  NOT NULL,
    [description] varchar(99)  NOT NULL
);
GO

-- Creating table 'ExpirationState'
CREATE TABLE [dbo].[ExpirationState] (
    [expirationStateId] int  NOT NULL,
    [description] varchar(50)  NOT NULL
);
GO

-- Creating table 'Item'
CREATE TABLE [dbo].[Item] (
    [requirementNumber] int  NOT NULL,
    [itemNumber] int  NOT NULL,
    [description] varchar(500)  NOT NULL
);
GO

-- Creating table 'Message'
CREATE TABLE [dbo].[Message] (
    [id] varchar(50)  NOT NULL,
    [message1] varchar(99)  NOT NULL
);
GO

-- Creating table 'Parameter'
CREATE TABLE [dbo].[Parameter] (
    [id] varchar(50)  NOT NULL,
    [value] varchar(50)  NOT NULL
);
GO

-- Creating table 'Requirement'
CREATE TABLE [dbo].[Requirement] (
    [requirementNumber] int  NOT NULL,
    [purchaseOrderNumber] int  NOT NULL,
    [purchaseOrderExcercise] int  NOT NULL,
    [certificationDays] int  NOT NULL,
    [provider] varchar(500)  NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [roleId] int IDENTITY(1,1) NOT NULL,
    [description] varchar(50)  NOT NULL
);
GO

-- Creating table 'Sheet'
CREATE TABLE [dbo].[Sheet] (
    [requirementNumber] int  NOT NULL,
    [sheetNumber] int  NOT NULL,
    [sheetStateId] int  NOT NULL,
    [fromDate] datetime  NOT NULL,
    [untilDate] datetime  NOT NULL
);
GO

-- Creating table 'SheetItem'
CREATE TABLE [dbo].[SheetItem] (
    [requirementNumber] int  NOT NULL,
    [itemNumber] int  NOT NULL,
    [subItemNumber] int  NOT NULL,
    [sheetNumber] int  NOT NULL,
    [partialQuantity] decimal(18,2)  NOT NULL,
    [percentQuantity] int  NOT NULL
);
GO

-- Creating table 'SheetState'
CREATE TABLE [dbo].[SheetState] (
    [sheetStateId] int IDENTITY(1,1) NOT NULL,
    [description] varchar(50)  NOT NULL
);
GO

-- Creating table 'SubItem'
CREATE TABLE [dbo].[SubItem] (
    [requirementNumber] int  NOT NULL,
    [itemNumber] int  NOT NULL,
    [subItemNumber] int  NOT NULL,
    [description] varchar(500)  NOT NULL,
    [sis] varchar(50)  NULL,
    [unitPrice] decimal(18,2)  NOT NULL,
    [unitOfMeasurement] varchar(50)  NOT NULL,
    [totalQuantity] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [cuit] varchar(20)  NOT NULL,
    [name] varchar(50)  NOT NULL,
    [lastname] varchar(50)  NOT NULL,
    [roleId] int  NOT NULL,
    [password] varchar(99)  NOT NULL
);
GO

-- Creating table 'RequirementUser'
CREATE TABLE [dbo].[RequirementUser] (
    [Requirement_requirementNumber] int  NOT NULL,
    [User_cuit] varchar(20)  NOT NULL
);
GO

-- Creating table 'RoleAction'
CREATE TABLE [dbo].[RoleAction] (
    [Action_actionId] int  NOT NULL,
    [Role_roleId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [actionId] in table 'Action'
ALTER TABLE [dbo].[Action]
ADD CONSTRAINT [PK_Action]
    PRIMARY KEY CLUSTERED ([actionId] ASC);
GO

-- Creating primary key on [expirationStateId] in table 'ExpirationState'
ALTER TABLE [dbo].[ExpirationState]
ADD CONSTRAINT [PK_ExpirationState]
    PRIMARY KEY CLUSTERED ([expirationStateId] ASC);
GO

-- Creating primary key on [requirementNumber], [itemNumber] in table 'Item'
ALTER TABLE [dbo].[Item]
ADD CONSTRAINT [PK_Item]
    PRIMARY KEY CLUSTERED ([requirementNumber], [itemNumber] ASC);
GO

-- Creating primary key on [id] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [PK_Message]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Parameter'
ALTER TABLE [dbo].[Parameter]
ADD CONSTRAINT [PK_Parameter]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [requirementNumber] in table 'Requirement'
ALTER TABLE [dbo].[Requirement]
ADD CONSTRAINT [PK_Requirement]
    PRIMARY KEY CLUSTERED ([requirementNumber] ASC);
GO

-- Creating primary key on [roleId] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([roleId] ASC);
GO

-- Creating primary key on [requirementNumber], [sheetNumber] in table 'Sheet'
ALTER TABLE [dbo].[Sheet]
ADD CONSTRAINT [PK_Sheet]
    PRIMARY KEY CLUSTERED ([requirementNumber], [sheetNumber] ASC);
GO

-- Creating primary key on [requirementNumber], [itemNumber], [subItemNumber], [sheetNumber] in table 'SheetItem'
ALTER TABLE [dbo].[SheetItem]
ADD CONSTRAINT [PK_SheetItem]
    PRIMARY KEY CLUSTERED ([requirementNumber], [itemNumber], [subItemNumber], [sheetNumber] ASC);
GO

-- Creating primary key on [sheetStateId] in table 'SheetState'
ALTER TABLE [dbo].[SheetState]
ADD CONSTRAINT [PK_SheetState]
    PRIMARY KEY CLUSTERED ([sheetStateId] ASC);
GO

-- Creating primary key on [requirementNumber], [itemNumber], [subItemNumber] in table 'SubItem'
ALTER TABLE [dbo].[SubItem]
ADD CONSTRAINT [PK_SubItem]
    PRIMARY KEY CLUSTERED ([requirementNumber], [itemNumber], [subItemNumber] ASC);
GO

-- Creating primary key on [cuit] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([cuit] ASC);
GO

-- Creating primary key on [Requirement_requirementNumber], [User_cuit] in table 'RequirementUser'
ALTER TABLE [dbo].[RequirementUser]
ADD CONSTRAINT [PK_RequirementUser]
    PRIMARY KEY CLUSTERED ([Requirement_requirementNumber], [User_cuit] ASC);
GO

-- Creating primary key on [Action_actionId], [Role_roleId] in table 'RoleAction'
ALTER TABLE [dbo].[RoleAction]
ADD CONSTRAINT [PK_RoleAction]
    PRIMARY KEY CLUSTERED ([Action_actionId], [Role_roleId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [requirementNumber] in table 'Item'
ALTER TABLE [dbo].[Item]
ADD CONSTRAINT [FK_Item_Requirement]
    FOREIGN KEY ([requirementNumber])
    REFERENCES [dbo].[Requirement]
        ([requirementNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [requirementNumber], [itemNumber] in table 'SubItem'
ALTER TABLE [dbo].[SubItem]
ADD CONSTRAINT [FK_SubItem_Item]
    FOREIGN KEY ([requirementNumber], [itemNumber])
    REFERENCES [dbo].[Item]
        ([requirementNumber], [itemNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [requirementNumber] in table 'Sheet'
ALTER TABLE [dbo].[Sheet]
ADD CONSTRAINT [FK_Sheet_Requirement]
    FOREIGN KEY ([requirementNumber])
    REFERENCES [dbo].[Requirement]
        ([requirementNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [roleId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_Role]
    FOREIGN KEY ([roleId])
    REFERENCES [dbo].[Role]
        ([roleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Role'
CREATE INDEX [IX_FK_User_Role]
ON [dbo].[User]
    ([roleId]);
GO

-- Creating foreign key on [sheetStateId] in table 'Sheet'
ALTER TABLE [dbo].[Sheet]
ADD CONSTRAINT [FK_Sheet_SheetState]
    FOREIGN KEY ([sheetStateId])
    REFERENCES [dbo].[SheetState]
        ([sheetStateId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Sheet_SheetState'
CREATE INDEX [IX_FK_Sheet_SheetState]
ON [dbo].[Sheet]
    ([sheetStateId]);
GO

-- Creating foreign key on [requirementNumber], [sheetNumber] in table 'SheetItem'
ALTER TABLE [dbo].[SheetItem]
ADD CONSTRAINT [FK_SheetItem_Sheet]
    FOREIGN KEY ([requirementNumber], [sheetNumber])
    REFERENCES [dbo].[Sheet]
        ([requirementNumber], [sheetNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SheetItem_Sheet'
CREATE INDEX [IX_FK_SheetItem_Sheet]
ON [dbo].[SheetItem]
    ([requirementNumber], [sheetNumber]);
GO

-- Creating foreign key on [requirementNumber], [itemNumber], [subItemNumber] in table 'SheetItem'
ALTER TABLE [dbo].[SheetItem]
ADD CONSTRAINT [FK_SheetItem_SubItem]
    FOREIGN KEY ([requirementNumber], [itemNumber], [subItemNumber])
    REFERENCES [dbo].[SubItem]
        ([requirementNumber], [itemNumber], [subItemNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Requirement_requirementNumber] in table 'RequirementUser'
ALTER TABLE [dbo].[RequirementUser]
ADD CONSTRAINT [FK_RequirementUser_Requirement]
    FOREIGN KEY ([Requirement_requirementNumber])
    REFERENCES [dbo].[Requirement]
        ([requirementNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [User_cuit] in table 'RequirementUser'
ALTER TABLE [dbo].[RequirementUser]
ADD CONSTRAINT [FK_RequirementUser_User]
    FOREIGN KEY ([User_cuit])
    REFERENCES [dbo].[User]
        ([cuit])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RequirementUser_User'
CREATE INDEX [IX_FK_RequirementUser_User]
ON [dbo].[RequirementUser]
    ([User_cuit]);
GO

-- Creating foreign key on [Action_actionId] in table 'RoleAction'
ALTER TABLE [dbo].[RoleAction]
ADD CONSTRAINT [FK_RoleAction_Action]
    FOREIGN KEY ([Action_actionId])
    REFERENCES [dbo].[Action]
        ([actionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role_roleId] in table 'RoleAction'
ALTER TABLE [dbo].[RoleAction]
ADD CONSTRAINT [FK_RoleAction_Role]
    FOREIGN KEY ([Role_roleId])
    REFERENCES [dbo].[Role]
        ([roleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleAction_Role'
CREATE INDEX [IX_FK_RoleAction_Role]
ON [dbo].[RoleAction]
    ([Role_roleId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------