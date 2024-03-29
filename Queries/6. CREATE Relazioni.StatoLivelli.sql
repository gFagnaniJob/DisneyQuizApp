USE [DisneyQuizApp]
GO

/****** Object:  Table [Relazioni].[StatoLivelli]    Script Date: 03/09/2019 10:38:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Relazioni].[StatoLivelli](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_UTENTE] [int] NOT NULL,
	[ID_LIVELLO] [int] NOT NULL,
 CONSTRAINT [PK_RELAZIONI_STATOLIVELLI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Relazioni].[StatoLivelli]  WITH CHECK ADD  CONSTRAINT [FK_RELAZIONI_STATOLIVELLI_LIVELLO] FOREIGN KEY([ID_LIVELLO])
REFERENCES [Anagrafica].[Livelli] ([ID])
GO

ALTER TABLE [Relazioni].[StatoLivelli] CHECK CONSTRAINT [FK_RELAZIONI_STATOLIVELLI_LIVELLO]
GO

ALTER TABLE [Relazioni].[StatoLivelli]  WITH CHECK ADD  CONSTRAINT [FK_RELAZIONI_STATOLIVELLI_UTENTE] FOREIGN KEY([ID_UTENTE])
REFERENCES [Anagrafica].[Utenti] ([ID])
GO

ALTER TABLE [Relazioni].[StatoLivelli] CHECK CONSTRAINT [FK_RELAZIONI_STATOLIVELLI_UTENTE]
GO


