IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'TowerDefenseGame')
BEGIN
    CREATE DATABASE [TowerDefenseGame];
END
GO

USE [TowerDefenseGame];
GO

IF NOT EXISTS (SELECT * FROM sys.objects
WHERE object_id = OBJECT_ID(N'[dbo].[player]') AND type in (N'U'))

BEGIN

CREATE TABLE [dbo].[player](
    id INT PRIMARY KEY IDENTITY,

    [name]       NVARCHAR(64) NOT NULL,
    current_wave INT NOT NULL,
    rating       INT NOT NULL,

    datetime_online DATETIME2 NOT NULL,
)

END
GO

IF NOT EXISTS (SELECT * FROM sys.objects
WHERE object_id = OBJECT_ID(N'[dbo].[guild_has_player]') AND type in (N'U'))

BEGIN

CREATE TABLE [dbo].[guild_has_player](
    id_guild  INT,
    id_player INT,

    datetime_join DATETIME2 NOT NULL,
    datetime_exit DATETIME2 NOT NULL,

    PRIMARY KEY(id_guild, id_player),
)

END
GO

IF NOT EXISTS (SELECT * FROM sys.objects
WHERE object_id = OBJECT_ID(N'[dbo].[guild]') AND type in (N'U'))

BEGIN

CREATE TABLE [dbo].[guild](
    id INT PRIMARY KEY IDENTITY,

    [name]            NVARCHAR(64) NOT NULL,
    skill_point_count INT NOT NULL,

    datetime_created DATETIME2 NOT NULL,
    datetime_deleted DATETIME2 NOT NULL,
)

END
GO

IF NOT EXISTS (SELECT * FROM sys.objects
WHERE object_id = OBJECT_ID(N'[dbo].[guild_chat]') AND type in (N'U'))

BEGIN

CREATE TABLE [dbo].[guild_chat](
    id_guild INT,
    id_chat  INT,

    PRIMARY KEY(id_guild, id_chat),
)

END
GO

IF NOT EXISTS (SELECT * FROM sys.objects
WHERE object_id = OBJECT_ID(N'[dbo].[guild_chat_has_message]') AND type in (N'U'))

BEGIN

CREATE TABLE [dbo].[guild_chat_has_message](
    id_guild_chat INT,
    id_message    INT,

    datetime_sent    DATETIME2 NOT NULL,
    datetime_deleted DATETIME2 NOT NULL,

    PRIMARY KEY(id_guild_chat, id_message),
)

END
GO

IF NOT EXISTS (SELECT * FROM sys.objects
WHERE object_id = OBJECT_ID(N'[dbo].[message]') AND type in (N'U'))

BEGIN

CREATE TABLE [dbo].[message](
    id INT PRIMARY KEY IDENTITY,
    id_player INT,

    [text] NVARCHAR(256) NOT NULL,

    FOREIGN KEY (id_player) REFERENCES player (id),
)

END
GO

