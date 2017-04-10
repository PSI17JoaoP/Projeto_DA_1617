
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/10/2017 17:20:54
-- Generated from EDMX file: D:\Desktop\TESP - PSI\S2\PL\DA\Projeto\Etapa 2\Projeto_DA_1617\Projeto\DiagramaArcmage.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BD_DA_Projeto];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GameSet'
CREATE TABLE [dbo].[GameSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Number] int  NOT NULL,
    [RefereeId] int  NULL,
    [DeckId1] int  NULL,
    [DeckId2] int  NULL,
    [Referee_Id] int  NULL
);
GO

-- Creating table 'DeckSet'
CREATE TABLE [dbo].[DeckSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CardSet'
CREATE TABLE [dbo].[CardSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Faction] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Cost] nvarchar(max)  NOT NULL,
    [Loyalty] int  NOT NULL,
    [RuleText] nvarchar(max)  NOT NULL,
    [Attack] int  NOT NULL,
    [Defense] int  NOT NULL
);
GO

-- Creating table 'TeamSet'
CREATE TABLE [dbo].[TeamSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Avatar] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TournamentSet'
CREATE TABLE [dbo].[TournamentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PlayerSet'
CREATE TABLE [dbo].[PlayerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Nickname] nvarchar(max)  NOT NULL,
    [Age] int  NOT NULL,
    [Avatar] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserSet_Referee'
CREATE TABLE [dbo].[UserSet_Referee] (
    [Name] nvarchar(max)  NOT NULL,
    [Avatar] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'GameSet_StandardGame'
CREATE TABLE [dbo].[GameSet_StandardGame] (
    [StandardTournamentId] int  NOT NULL,
    [PlayerId1] int  NULL,
    [PlayerId2] int  NULL,
    [Id] int  NOT NULL,
    [Tournament_Id] int  NOT NULL
);
GO

-- Creating table 'TournamentSet_StandardTournament'
CREATE TABLE [dbo].[TournamentSet_StandardTournament] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'GameSet_TeamGame'
CREATE TABLE [dbo].[GameSet_TeamGame] (
    [TeamTournamentId] int  NOT NULL,
    [TeamId1] int  NULL,
    [TeamId2] int  NULL,
    [Id] int  NOT NULL,
    [Tournament_Id] int  NOT NULL
);
GO

-- Creating table 'TournamentSet_TeamTournament'
CREATE TABLE [dbo].[TournamentSet_TeamTournament] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'UserSet_Administrator'
CREATE TABLE [dbo].[UserSet_Administrator] (
    [Email] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'DeckCard'
CREATE TABLE [dbo].[DeckCard] (
    [Deck_Id] int  NOT NULL,
    [Cards_Id] int  NOT NULL
);
GO

-- Creating table 'TeamPlayer'
CREATE TABLE [dbo].[TeamPlayer] (
    [Teams_Id] int  NOT NULL,
    [Players_Id] int  NOT NULL
);
GO

-- Creating table 'TeamTeamTournament'
CREATE TABLE [dbo].[TeamTeamTournament] (
    [Teams_Id] int  NOT NULL,
    [TeamTournaments_Id] int  NOT NULL
);
GO

-- Creating table 'StandardTournamentPlayer'
CREATE TABLE [dbo].[StandardTournamentPlayer] (
    [StandardTournaments_Id] int  NOT NULL,
    [Players_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GameSet'
ALTER TABLE [dbo].[GameSet]
ADD CONSTRAINT [PK_GameSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DeckSet'
ALTER TABLE [dbo].[DeckSet]
ADD CONSTRAINT [PK_DeckSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CardSet'
ALTER TABLE [dbo].[CardSet]
ADD CONSTRAINT [PK_CardSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeamSet'
ALTER TABLE [dbo].[TeamSet]
ADD CONSTRAINT [PK_TeamSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TournamentSet'
ALTER TABLE [dbo].[TournamentSet]
ADD CONSTRAINT [PK_TournamentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlayerSet'
ALTER TABLE [dbo].[PlayerSet]
ADD CONSTRAINT [PK_PlayerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet_Referee'
ALTER TABLE [dbo].[UserSet_Referee]
ADD CONSTRAINT [PK_UserSet_Referee]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GameSet_StandardGame'
ALTER TABLE [dbo].[GameSet_StandardGame]
ADD CONSTRAINT [PK_GameSet_StandardGame]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TournamentSet_StandardTournament'
ALTER TABLE [dbo].[TournamentSet_StandardTournament]
ADD CONSTRAINT [PK_TournamentSet_StandardTournament]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GameSet_TeamGame'
ALTER TABLE [dbo].[GameSet_TeamGame]
ADD CONSTRAINT [PK_GameSet_TeamGame]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TournamentSet_TeamTournament'
ALTER TABLE [dbo].[TournamentSet_TeamTournament]
ADD CONSTRAINT [PK_TournamentSet_TeamTournament]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet_Administrator'
ALTER TABLE [dbo].[UserSet_Administrator]
ADD CONSTRAINT [PK_UserSet_Administrator]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Deck_Id], [Cards_Id] in table 'DeckCard'
ALTER TABLE [dbo].[DeckCard]
ADD CONSTRAINT [PK_DeckCard]
    PRIMARY KEY CLUSTERED ([Deck_Id], [Cards_Id] ASC);
GO

-- Creating primary key on [Teams_Id], [Players_Id] in table 'TeamPlayer'
ALTER TABLE [dbo].[TeamPlayer]
ADD CONSTRAINT [PK_TeamPlayer]
    PRIMARY KEY CLUSTERED ([Teams_Id], [Players_Id] ASC);
GO

-- Creating primary key on [Teams_Id], [TeamTournaments_Id] in table 'TeamTeamTournament'
ALTER TABLE [dbo].[TeamTeamTournament]
ADD CONSTRAINT [PK_TeamTeamTournament]
    PRIMARY KEY CLUSTERED ([Teams_Id], [TeamTournaments_Id] ASC);
GO

-- Creating primary key on [StandardTournaments_Id], [Players_Id] in table 'StandardTournamentPlayer'
ALTER TABLE [dbo].[StandardTournamentPlayer]
ADD CONSTRAINT [PK_StandardTournamentPlayer]
    PRIMARY KEY CLUSTERED ([StandardTournaments_Id], [Players_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Referee_Id] in table 'GameSet'
ALTER TABLE [dbo].[GameSet]
ADD CONSTRAINT [FK_RefereeGame]
    FOREIGN KEY ([Referee_Id])
    REFERENCES [dbo].[UserSet_Referee]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RefereeGame'
CREATE INDEX [IX_FK_RefereeGame]
ON [dbo].[GameSet]
    ([Referee_Id]);
GO

-- Creating foreign key on [Deck_Id] in table 'DeckCard'
ALTER TABLE [dbo].[DeckCard]
ADD CONSTRAINT [FK_DeckCard_Deck]
    FOREIGN KEY ([Deck_Id])
    REFERENCES [dbo].[DeckSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Cards_Id] in table 'DeckCard'
ALTER TABLE [dbo].[DeckCard]
ADD CONSTRAINT [FK_DeckCard_Card]
    FOREIGN KEY ([Cards_Id])
    REFERENCES [dbo].[CardSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeckCard_Card'
CREATE INDEX [IX_FK_DeckCard_Card]
ON [dbo].[DeckCard]
    ([Cards_Id]);
GO

-- Creating foreign key on [DeckId1] in table 'GameSet'
ALTER TABLE [dbo].[GameSet]
ADD CONSTRAINT [FK_DeckGame]
    FOREIGN KEY ([DeckId1])
    REFERENCES [dbo].[DeckSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeckGame'
CREATE INDEX [IX_FK_DeckGame]
ON [dbo].[GameSet]
    ([DeckId1]);
GO

-- Creating foreign key on [DeckId2] in table 'GameSet'
ALTER TABLE [dbo].[GameSet]
ADD CONSTRAINT [FK_DeckGame1]
    FOREIGN KEY ([DeckId2])
    REFERENCES [dbo].[DeckSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeckGame1'
CREATE INDEX [IX_FK_DeckGame1]
ON [dbo].[GameSet]
    ([DeckId2]);
GO

-- Creating foreign key on [Tournament_Id] in table 'GameSet_StandardGame'
ALTER TABLE [dbo].[GameSet_StandardGame]
ADD CONSTRAINT [FK_StandardGameStandardTournament]
    FOREIGN KEY ([Tournament_Id])
    REFERENCES [dbo].[TournamentSet_StandardTournament]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StandardGameStandardTournament'
CREATE INDEX [IX_FK_StandardGameStandardTournament]
ON [dbo].[GameSet_StandardGame]
    ([Tournament_Id]);
GO

-- Creating foreign key on [PlayerId1] in table 'GameSet_StandardGame'
ALTER TABLE [dbo].[GameSet_StandardGame]
ADD CONSTRAINT [FK_PlayerStandardGame]
    FOREIGN KEY ([PlayerId1])
    REFERENCES [dbo].[PlayerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerStandardGame'
CREATE INDEX [IX_FK_PlayerStandardGame]
ON [dbo].[GameSet_StandardGame]
    ([PlayerId1]);
GO

-- Creating foreign key on [PlayerId2] in table 'GameSet_StandardGame'
ALTER TABLE [dbo].[GameSet_StandardGame]
ADD CONSTRAINT [FK_PlayerStandardGame1]
    FOREIGN KEY ([PlayerId2])
    REFERENCES [dbo].[PlayerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerStandardGame1'
CREATE INDEX [IX_FK_PlayerStandardGame1]
ON [dbo].[GameSet_StandardGame]
    ([PlayerId2]);
GO

-- Creating foreign key on [Tournament_Id] in table 'GameSet_TeamGame'
ALTER TABLE [dbo].[GameSet_TeamGame]
ADD CONSTRAINT [FK_TeamGameTeamTournament]
    FOREIGN KEY ([Tournament_Id])
    REFERENCES [dbo].[TournamentSet_TeamTournament]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamGameTeamTournament'
CREATE INDEX [IX_FK_TeamGameTeamTournament]
ON [dbo].[GameSet_TeamGame]
    ([Tournament_Id]);
GO

-- Creating foreign key on [TeamId1] in table 'GameSet_TeamGame'
ALTER TABLE [dbo].[GameSet_TeamGame]
ADD CONSTRAINT [FK_TeamTeamGame]
    FOREIGN KEY ([TeamId1])
    REFERENCES [dbo].[TeamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamTeamGame'
CREATE INDEX [IX_FK_TeamTeamGame]
ON [dbo].[GameSet_TeamGame]
    ([TeamId1]);
GO

-- Creating foreign key on [TeamId2] in table 'GameSet_TeamGame'
ALTER TABLE [dbo].[GameSet_TeamGame]
ADD CONSTRAINT [FK_TeamTeamGame1]
    FOREIGN KEY ([TeamId2])
    REFERENCES [dbo].[TeamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamTeamGame1'
CREATE INDEX [IX_FK_TeamTeamGame1]
ON [dbo].[GameSet_TeamGame]
    ([TeamId2]);
GO

-- Creating foreign key on [Teams_Id] in table 'TeamPlayer'
ALTER TABLE [dbo].[TeamPlayer]
ADD CONSTRAINT [FK_TeamPlayer_Team]
    FOREIGN KEY ([Teams_Id])
    REFERENCES [dbo].[TeamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Players_Id] in table 'TeamPlayer'
ALTER TABLE [dbo].[TeamPlayer]
ADD CONSTRAINT [FK_TeamPlayer_Player]
    FOREIGN KEY ([Players_Id])
    REFERENCES [dbo].[PlayerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamPlayer_Player'
CREATE INDEX [IX_FK_TeamPlayer_Player]
ON [dbo].[TeamPlayer]
    ([Players_Id]);
GO

-- Creating foreign key on [Teams_Id] in table 'TeamTeamTournament'
ALTER TABLE [dbo].[TeamTeamTournament]
ADD CONSTRAINT [FK_TeamTeamTournament_Team]
    FOREIGN KEY ([Teams_Id])
    REFERENCES [dbo].[TeamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TeamTournaments_Id] in table 'TeamTeamTournament'
ALTER TABLE [dbo].[TeamTeamTournament]
ADD CONSTRAINT [FK_TeamTeamTournament_TeamTournament]
    FOREIGN KEY ([TeamTournaments_Id])
    REFERENCES [dbo].[TournamentSet_TeamTournament]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamTeamTournament_TeamTournament'
CREATE INDEX [IX_FK_TeamTeamTournament_TeamTournament]
ON [dbo].[TeamTeamTournament]
    ([TeamTournaments_Id]);
GO

-- Creating foreign key on [StandardTournaments_Id] in table 'StandardTournamentPlayer'
ALTER TABLE [dbo].[StandardTournamentPlayer]
ADD CONSTRAINT [FK_StandardTournamentPlayer_StandardTournament]
    FOREIGN KEY ([StandardTournaments_Id])
    REFERENCES [dbo].[TournamentSet_StandardTournament]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Players_Id] in table 'StandardTournamentPlayer'
ALTER TABLE [dbo].[StandardTournamentPlayer]
ADD CONSTRAINT [FK_StandardTournamentPlayer_Player]
    FOREIGN KEY ([Players_Id])
    REFERENCES [dbo].[PlayerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StandardTournamentPlayer_Player'
CREATE INDEX [IX_FK_StandardTournamentPlayer_Player]
ON [dbo].[StandardTournamentPlayer]
    ([Players_Id]);
GO

-- Creating foreign key on [Id] in table 'UserSet_Referee'
ALTER TABLE [dbo].[UserSet_Referee]
ADD CONSTRAINT [FK_Referee_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'GameSet_StandardGame'
ALTER TABLE [dbo].[GameSet_StandardGame]
ADD CONSTRAINT [FK_StandardGame_inherits_Game]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[GameSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'TournamentSet_StandardTournament'
ALTER TABLE [dbo].[TournamentSet_StandardTournament]
ADD CONSTRAINT [FK_StandardTournament_inherits_Tournament]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[TournamentSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'GameSet_TeamGame'
ALTER TABLE [dbo].[GameSet_TeamGame]
ADD CONSTRAINT [FK_TeamGame_inherits_Game]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[GameSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'TournamentSet_TeamTournament'
ALTER TABLE [dbo].[TournamentSet_TeamTournament]
ADD CONSTRAINT [FK_TeamTournament_inherits_Tournament]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[TournamentSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'UserSet_Administrator'
ALTER TABLE [dbo].[UserSet_Administrator]
ADD CONSTRAINT [FK_Administrator_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------