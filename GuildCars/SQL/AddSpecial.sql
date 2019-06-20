USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[AddSpecial]    Script Date: 3/30/2019 7:18:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[AddSpecial](
@Description varchar(255),
@Title varchar(50)
)
as
Insert into Specials(Description,Title) Values (@Description,@Title)
GO


