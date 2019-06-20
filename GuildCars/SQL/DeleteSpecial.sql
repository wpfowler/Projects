USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[DeleteSpecial]    Script Date: 3/30/2019 7:17:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[DeleteSpecial](
@SpecialsId int
)
as 
Delete from Specials where SpecialsId = @SpecialsId
GO


