﻿CREATE TABLE [dbo].[Pasports]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Type] NVARCHAR(50) NOT NULL, 
    [Number] NVARCHAR(50) NOT NULL
)
