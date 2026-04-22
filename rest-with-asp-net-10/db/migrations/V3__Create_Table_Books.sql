CREATE TABLE [dbo].[book] (
    [id] [int] IDENTITY NOT NULL ,
    [title] [varchar](MAX) NULL,
    [author] [varchar](MAX) NULL,
    [price] [decimal](18,2) NOT NULL,
    [launch_date] [datetime2](6) NOT NULL,
    PRIMARY KEY ([id])
);