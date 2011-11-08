
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/08/2011 16:08:12
-- Generated from EDMX file: C:\git\AntiCustomerServiceSystem\AntiCustomerServiceSystem\Models\ServiceSystem.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AntiCustomerService];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CompanyIssue_Company]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompanyIssue] DROP CONSTRAINT [FK_CompanyIssue_Company];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyIssue_Issue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompanyIssue] DROP CONSTRAINT [FK_CompanyIssue_Issue];
GO
IF OBJECT_ID(N'[dbo].[FK_IssueCall]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Calls] DROP CONSTRAINT [FK_IssueCall];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyDocument]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_CompanyDocument];
GO
IF OBJECT_ID(N'[dbo].[FK_CallFollowUp]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FollowUps] DROP CONSTRAINT [FK_CallFollowUp];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Companies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Companies];
GO
IF OBJECT_ID(N'[dbo].[Issues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Issues];
GO
IF OBJECT_ID(N'[dbo].[Calls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Calls];
GO
IF OBJECT_ID(N'[dbo].[Documents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Documents];
GO
IF OBJECT_ID(N'[dbo].[FollowUps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FollowUps];
GO
IF OBJECT_ID(N'[dbo].[CompanyIssue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompanyIssue];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [MainPhone] nvarchar(max)  NULL,
    [Account] nvarchar(max)  NULL
);
GO

-- Creating table 'Issues'
CREATE TABLE [dbo].[Issues] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Opened] datetime  NOT NULL,
    [Closed] datetime  NULL,
    [Modified] datetime  NULL,
    [State] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Details] nvarchar(max)  NULL
);
GO

-- Creating table 'Calls'
CREATE TABLE [dbo].[Calls] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StartTime] datetime  NULL,
    [EndTime] datetime  NULL,
    [ServiceRep] nvarchar(max)  NULL,
    [Reference] nvarchar(max)  NULL,
    [Notes] nvarchar(max)  NULL,
    [Promises] nvarchar(max)  NULL,
    [Resolution] nvarchar(max)  NULL,
    [Issue_Id] int  NOT NULL
);
GO

-- Creating table 'Documents'
CREATE TABLE [dbo].[Documents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [URI] nvarchar(max)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Modified] datetime  NULL,
    [Company_Id] int  NULL,
    [Issue_Id] int  NULL
);
GO

-- Creating table 'FollowUps'
CREATE TABLE [dbo].[FollowUps] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Created] datetime  NOT NULL,
    [ActionTime] datetime  NULL,
    [Action] nvarchar(max)  NULL,
    [Call_Id] int  NOT NULL
);
GO

-- Creating table 'CompanyIssue'
CREATE TABLE [dbo].[CompanyIssue] (
    [Companies_Id] int  NOT NULL,
    [Issues_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Issues'
ALTER TABLE [dbo].[Issues]
ADD CONSTRAINT [PK_Issues]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Calls'
ALTER TABLE [dbo].[Calls]
ADD CONSTRAINT [PK_Calls]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [PK_Documents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FollowUps'
ALTER TABLE [dbo].[FollowUps]
ADD CONSTRAINT [PK_FollowUps]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Companies_Id], [Issues_Id] in table 'CompanyIssue'
ALTER TABLE [dbo].[CompanyIssue]
ADD CONSTRAINT [PK_CompanyIssue]
    PRIMARY KEY NONCLUSTERED ([Companies_Id], [Issues_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Companies_Id] in table 'CompanyIssue'
ALTER TABLE [dbo].[CompanyIssue]
ADD CONSTRAINT [FK_CompanyIssue_Company]
    FOREIGN KEY ([Companies_Id])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Issues_Id] in table 'CompanyIssue'
ALTER TABLE [dbo].[CompanyIssue]
ADD CONSTRAINT [FK_CompanyIssue_Issue]
    FOREIGN KEY ([Issues_Id])
    REFERENCES [dbo].[Issues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyIssue_Issue'
CREATE INDEX [IX_FK_CompanyIssue_Issue]
ON [dbo].[CompanyIssue]
    ([Issues_Id]);
GO

-- Creating foreign key on [Issue_Id] in table 'Calls'
ALTER TABLE [dbo].[Calls]
ADD CONSTRAINT [FK_IssueCall]
    FOREIGN KEY ([Issue_Id])
    REFERENCES [dbo].[Issues]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_IssueCall'
CREATE INDEX [IX_FK_IssueCall]
ON [dbo].[Calls]
    ([Issue_Id]);
GO

-- Creating foreign key on [Company_Id] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [FK_CompanyDocument]
    FOREIGN KEY ([Company_Id])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyDocument'
CREATE INDEX [IX_FK_CompanyDocument]
ON [dbo].[Documents]
    ([Company_Id]);
GO

-- Creating foreign key on [Call_Id] in table 'FollowUps'
ALTER TABLE [dbo].[FollowUps]
ADD CONSTRAINT [FK_CallFollowUp]
    FOREIGN KEY ([Call_Id])
    REFERENCES [dbo].[Calls]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CallFollowUp'
CREATE INDEX [IX_FK_CallFollowUp]
ON [dbo].[FollowUps]
    ([Call_Id]);
GO

-- Creating foreign key on [Issue_Id] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [FK_DocumentIssue]
    FOREIGN KEY ([Issue_Id])
    REFERENCES [dbo].[Issues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentIssue'
CREATE INDEX [IX_FK_DocumentIssue]
ON [dbo].[Documents]
    ([Issue_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------