
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/22/2010 16:19:02
-- Generated from EDMX file: C:\Users\Kim\Desktop\SVN\sw3-s305a\projekt\code\HoplaHelpdesk\HoplaHelpdesk\Controllers\Model.edmx
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
    [ProblemID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Added_date] datetime  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Deadline] datetime  NOT NULL,
    [IsDeadlineApproved] bit  NOT NULL,
    [AssignedTo] nvarchar(max)  NOT NULL,
    [Reassignable] bit  NOT NULL,
    [SolvedAtTime] datetime  NOT NULL
);
GO

-- Creating table 'TagSet'
CREATE TABLE [dbo].[TagSet] (
    [TagID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Priority] smallint  NOT NULL,
    [Category_CategoryID] int  NOT NULL
);
GO

-- Creating table 'DepartmentSet'
CREATE TABLE [dbo].[DepartmentSet] (
    [DeptID] int IDENTITY(1,1) NOT NULL,
    [DepartmentName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategorySet'
CREATE TABLE [dbo].[CategorySet] (
    [CategoryID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Department_DeptID] int  NOT NULL
);
GO

-- Creating table 'SolutionSet'
CREATE TABLE [dbo].[SolutionSet] (
    [SolutionID] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CommentSet'
CREATE TABLE [dbo].[CommentSet] (
    [CommentID] int IDENTITY(1,1) NOT NULL,
    [time] datetime  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [Problem_ProblemID] int  NOT NULL
);
GO

-- Creating table 'ProblemTag'
CREATE TABLE [dbo].[ProblemTag] (
    [Problem_ProblemID] int  NOT NULL,
    [Tag_TagID] int  NOT NULL
);
GO

-- Creating table 'ProblemSolution'
CREATE TABLE [dbo].[ProblemSolution] (
    [Problem_ProblemID] int  NOT NULL,
    [Solution_SolutionID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ProblemID] in table 'ProblemSet'
ALTER TABLE [dbo].[ProblemSet]
ADD CONSTRAINT [PK_ProblemSet]
    PRIMARY KEY CLUSTERED ([ProblemID] ASC);
GO

-- Creating primary key on [TagID] in table 'TagSet'
ALTER TABLE [dbo].[TagSet]
ADD CONSTRAINT [PK_TagSet]
    PRIMARY KEY CLUSTERED ([TagID] ASC);
GO

-- Creating primary key on [DeptID] in table 'DepartmentSet'
ALTER TABLE [dbo].[DepartmentSet]
ADD CONSTRAINT [PK_DepartmentSet]
    PRIMARY KEY CLUSTERED ([DeptID] ASC);
GO

-- Creating primary key on [CategoryID] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [PK_CategorySet]
    PRIMARY KEY CLUSTERED ([CategoryID] ASC);
GO

-- Creating primary key on [SolutionID] in table 'SolutionSet'
ALTER TABLE [dbo].[SolutionSet]
ADD CONSTRAINT [PK_SolutionSet]
    PRIMARY KEY CLUSTERED ([SolutionID] ASC);
GO

-- Creating primary key on [CommentID] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [PK_CommentSet]
    PRIMARY KEY CLUSTERED ([CommentID] ASC);
GO

-- Creating primary key on [Problem_ProblemID], [Tag_TagID] in table 'ProblemTag'
ALTER TABLE [dbo].[ProblemTag]
ADD CONSTRAINT [PK_ProblemTag]
    PRIMARY KEY NONCLUSTERED ([Problem_ProblemID], [Tag_TagID] ASC);
GO

-- Creating primary key on [Problem_ProblemID], [Solution_SolutionID] in table 'ProblemSolution'
ALTER TABLE [dbo].[ProblemSolution]
ADD CONSTRAINT [PK_ProblemSolution]
    PRIMARY KEY NONCLUSTERED ([Problem_ProblemID], [Solution_SolutionID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Problem_ProblemID] in table 'ProblemTag'
ALTER TABLE [dbo].[ProblemTag]
ADD CONSTRAINT [FK_ProblemTag_Problem]
    FOREIGN KEY ([Problem_ProblemID])
    REFERENCES [dbo].[ProblemSet]
        ([ProblemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tag_TagID] in table 'ProblemTag'
ALTER TABLE [dbo].[ProblemTag]
ADD CONSTRAINT [FK_ProblemTag_Tag]
    FOREIGN KEY ([Tag_TagID])
    REFERENCES [dbo].[TagSet]
        ([TagID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProblemTag_Tag'
CREATE INDEX [IX_FK_ProblemTag_Tag]
ON [dbo].[ProblemTag]
    ([Tag_TagID]);
GO

-- Creating foreign key on [Department_DeptID] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [FK_DepartmentCategory]
    FOREIGN KEY ([Department_DeptID])
    REFERENCES [dbo].[DepartmentSet]
        ([DeptID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentCategory'
CREATE INDEX [IX_FK_DepartmentCategory]
ON [dbo].[CategorySet]
    ([Department_DeptID]);
GO

-- Creating foreign key on [Problem_ProblemID] in table 'ProblemSolution'
ALTER TABLE [dbo].[ProblemSolution]
ADD CONSTRAINT [FK_ProblemSolution_Problem]
    FOREIGN KEY ([Problem_ProblemID])
    REFERENCES [dbo].[ProblemSet]
        ([ProblemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Solution_SolutionID] in table 'ProblemSolution'
ALTER TABLE [dbo].[ProblemSolution]
ADD CONSTRAINT [FK_ProblemSolution_Solution]
    FOREIGN KEY ([Solution_SolutionID])
    REFERENCES [dbo].[SolutionSet]
        ([SolutionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProblemSolution_Solution'
CREATE INDEX [IX_FK_ProblemSolution_Solution]
ON [dbo].[ProblemSolution]
    ([Solution_SolutionID]);
GO

-- Creating foreign key on [Problem_ProblemID] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [FK_CommentProblem]
    FOREIGN KEY ([Problem_ProblemID])
    REFERENCES [dbo].[ProblemSet]
        ([ProblemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CommentProblem'
CREATE INDEX [IX_FK_CommentProblem]
ON [dbo].[CommentSet]
    ([Problem_ProblemID]);
GO

-- Creating foreign key on [Category_CategoryID] in table 'TagSet'
ALTER TABLE [dbo].[TagSet]
ADD CONSTRAINT [FK_TagCategory]
    FOREIGN KEY ([Category_CategoryID])
    REFERENCES [dbo].[CategorySet]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TagCategory'
CREATE INDEX [IX_FK_TagCategory]
ON [dbo].[TagSet]
    ([Category_CategoryID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------