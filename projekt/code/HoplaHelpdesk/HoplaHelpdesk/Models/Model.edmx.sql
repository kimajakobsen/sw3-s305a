
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/23/2010 13:46:52
-- Generated from EDMX file: C:\Documents and Settings\aba\My Documents\3.SW\P3\projekt\code\HoplaHelpdesk\HoplaHelpdesk\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [hopla];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProblemTag_Problem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProblemTag] DROP CONSTRAINT [FK_ProblemTag_Problem];
GO
IF OBJECT_ID(N'[dbo].[FK_ProblemTag_Tag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProblemTag] DROP CONSTRAINT [FK_ProblemTag_Tag];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartmentCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategorySet] DROP CONSTRAINT [FK_DepartmentCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_ProblemSolution_Problem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProblemSolution] DROP CONSTRAINT [FK_ProblemSolution_Problem];
GO
IF OBJECT_ID(N'[dbo].[FK_ProblemSolution_Solution]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProblemSolution] DROP CONSTRAINT [FK_ProblemSolution_Solution];
GO
IF OBJECT_ID(N'[dbo].[FK_CommentProblem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentSet] DROP CONSTRAINT [FK_CommentProblem];
GO
IF OBJECT_ID(N'[dbo].[FK_TagCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TagSet] DROP CONSTRAINT [FK_TagCategory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProblemSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProblemSet];
GO
IF OBJECT_ID(N'[dbo].[TagSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TagSet];
GO
IF OBJECT_ID(N'[dbo].[DepartmentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DepartmentSet];
GO
IF OBJECT_ID(N'[dbo].[CategorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategorySet];
GO
IF OBJECT_ID(N'[dbo].[SolutionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SolutionSet];
GO
IF OBJECT_ID(N'[dbo].[CommentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommentSet];
GO
IF OBJECT_ID(N'[dbo].[ProblemTag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProblemTag];
GO
IF OBJECT_ID(N'[dbo].[ProblemSolution]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProblemSolution];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProblemSet'
CREATE TABLE [dbo].[ProblemSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Added_date] datetime  NOT NULL,
    [Deadline] datetime  NOT NULL,
    [IsDeadlineApproved] bit  NOT NULL,
    [AssignedTo] nvarchar(max)  NOT NULL,
    [Reassignable] bit  NOT NULL,
    [SolvedAtTime] datetime  NOT NULL
);
GO

-- Creating table 'TagSet'
CREATE TABLE [dbo].[TagSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Priority] smallint  NOT NULL,
    [Category_Id] int  NOT NULL
);
GO

-- Creating table 'DepartmentSet'
CREATE TABLE [dbo].[DepartmentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DepartmentName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategorySet'
CREATE TABLE [dbo].[CategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Department_Id] int  NOT NULL
);
GO

-- Creating table 'SolutionSet'
CREATE TABLE [dbo].[SolutionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CommentSet'
CREATE TABLE [dbo].[CommentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [time] datetime  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [Problem_Id] int  NOT NULL
);
GO

-- Creating table 'ProblemTag'
CREATE TABLE [dbo].[ProblemTag] (
    [Problems_Id] int  NOT NULL,
    [Tags_Id] int  NOT NULL
);
GO

-- Creating table 'ProblemSolution'
CREATE TABLE [dbo].[ProblemSolution] (
    [Problems_Id] int  NOT NULL,
    [Solutions_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ProblemSet'
ALTER TABLE [dbo].[ProblemSet]
ADD CONSTRAINT [PK_ProblemSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TagSet'
ALTER TABLE [dbo].[TagSet]
ADD CONSTRAINT [PK_TagSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DepartmentSet'
ALTER TABLE [dbo].[DepartmentSet]
ADD CONSTRAINT [PK_DepartmentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [PK_CategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SolutionSet'
ALTER TABLE [dbo].[SolutionSet]
ADD CONSTRAINT [PK_SolutionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [PK_CommentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Problems_Id], [Tags_Id] in table 'ProblemTag'
ALTER TABLE [dbo].[ProblemTag]
ADD CONSTRAINT [PK_ProblemTag]
    PRIMARY KEY NONCLUSTERED ([Problems_Id], [Tags_Id] ASC);
GO

-- Creating primary key on [Problems_Id], [Solutions_Id] in table 'ProblemSolution'
ALTER TABLE [dbo].[ProblemSolution]
ADD CONSTRAINT [PK_ProblemSolution]
    PRIMARY KEY NONCLUSTERED ([Problems_Id], [Solutions_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Problems_Id] in table 'ProblemTag'
ALTER TABLE [dbo].[ProblemTag]
ADD CONSTRAINT [FK_ProblemTag_Problem]
    FOREIGN KEY ([Problems_Id])
    REFERENCES [dbo].[ProblemSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tags_Id] in table 'ProblemTag'
ALTER TABLE [dbo].[ProblemTag]
ADD CONSTRAINT [FK_ProblemTag_Tag]
    FOREIGN KEY ([Tags_Id])
    REFERENCES [dbo].[TagSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProblemTag_Tag'
CREATE INDEX [IX_FK_ProblemTag_Tag]
ON [dbo].[ProblemTag]
    ([Tags_Id]);
GO

-- Creating foreign key on [Department_Id] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [FK_DepartmentCategory]
    FOREIGN KEY ([Department_Id])
    REFERENCES [dbo].[DepartmentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentCategory'
CREATE INDEX [IX_FK_DepartmentCategory]
ON [dbo].[CategorySet]
    ([Department_Id]);
GO

-- Creating foreign key on [Problems_Id] in table 'ProblemSolution'
ALTER TABLE [dbo].[ProblemSolution]
ADD CONSTRAINT [FK_ProblemSolution_Problem]
    FOREIGN KEY ([Problems_Id])
    REFERENCES [dbo].[ProblemSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Solutions_Id] in table 'ProblemSolution'
ALTER TABLE [dbo].[ProblemSolution]
ADD CONSTRAINT [FK_ProblemSolution_Solution]
    FOREIGN KEY ([Solutions_Id])
    REFERENCES [dbo].[SolutionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProblemSolution_Solution'
CREATE INDEX [IX_FK_ProblemSolution_Solution]
ON [dbo].[ProblemSolution]
    ([Solutions_Id]);
GO

-- Creating foreign key on [Problem_Id] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [FK_CommentProblem]
    FOREIGN KEY ([Problem_Id])
    REFERENCES [dbo].[ProblemSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CommentProblem'
CREATE INDEX [IX_FK_CommentProblem]
ON [dbo].[CommentSet]
    ([Problem_Id]);
GO

-- Creating foreign key on [Category_Id] in table 'TagSet'
ALTER TABLE [dbo].[TagSet]
ADD CONSTRAINT [FK_TagCategory]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[CategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TagCategory'
CREATE INDEX [IX_FK_TagCategory]
ON [dbo].[TagSet]
    ([Category_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------