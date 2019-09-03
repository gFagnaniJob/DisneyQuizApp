USE [DisneyQuizApp]
GO

/****** Object:  Trigger [Anagrafica].[SettaLivelloNuovoUtente]    Script Date: 03/09/2019 10:55:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create trigger [Anagrafica].[SettaLivelloNuovoUtente]
on [Anagrafica].[Utenti]
after insert
as
begin
set nocount on;
insert into Relazioni.StatoLivelli (ID_UTENTE, ID_LIVELLO)
select 
i.ID,
1
from inserted as i
end
GO

ALTER TABLE [Anagrafica].[Utenti] ENABLE TRIGGER [SettaLivelloNuovoUtente]
GO


