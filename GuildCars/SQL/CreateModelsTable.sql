USE [GuildCars]
GO

/****** Object:  Table [dbo].[Model]    Script Date: 3/30/2019 7:18:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Model](
	[ModelId] [int] IDENTITY(1,1) NOT NULL,
	[MakeId] [int] NOT NULL,
	[Description] [varchar](25) NOT NULL,
	[UserId] [nvarchar](128) NULL,
 CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED 
(
	[ModelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Model]  WITH CHECK ADD  CONSTRAINT [FK_Model_Make] FOREIGN KEY([MakeId])
REFERENCES [dbo].[Make] ([MakeId])
GO

ALTER TABLE [dbo].[Model] CHECK CONSTRAINT [FK_Model_Make]
GO


