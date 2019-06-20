USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[GetSpecials]    Script Date: 3/30/2019 7:17:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[GetSpecials]
AS
Select SpecialsId, Description,Title From Specials
ORDER by SpecialsId ASC
GO


