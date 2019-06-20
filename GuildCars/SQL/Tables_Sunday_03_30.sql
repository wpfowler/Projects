--USE [GuildCars]
GO

/****** Object:  Table [dbo].[Make]    Script Date: 3/31/2019 5:01:04 PM ******/
DROP TABLE [dbo].[Make]
GO

/****** Object:  Table [dbo].[Make]    Script Date: 3/31/2019 5:01:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Make](
	[MakeId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[UserId] [nvarchar](128) NULL,
	[DateAdded] [datetime] NULL,
 CONSTRAINT [PK_Make] PRIMARY KEY CLUSTERED 
(
	[MakeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[Model] DROP CONSTRAINT [FK_Model_Make]
GO

/****** Object:  Table [dbo].[Model]    Script Date: 3/31/2019 5:01:14 PM ******/
DROP TABLE [dbo].[Model]
GO

/****** Object:  Table [dbo].[Model]    Script Date: 3/31/2019 5:01:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Model](
	[ModelId] [int] IDENTITY(1,1) NOT NULL,
	[MakeId] [int] NOT NULL,
	[Description] [varchar](25) NOT NULL,
	[UserId] [nvarchar](128) NULL,
	[DateAdded] [datetime] NULL,
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

ALTER TABLE [dbo].[Vehicle] DROP CONSTRAINT [FK_Vehicle_Model]
GO

/****** Object:  Table [dbo].[Vehicle]    Script Date: 3/31/2019 5:01:34 PM ******/
DROP TABLE [dbo].[Vehicle]
GO

/****** Object:  Table [dbo].[Vehicle]    Script Date: 3/31/2019 5:01:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vehicle](
	[VehicleId] [int] IDENTITY(1,1) NOT NULL,
	[ModelId] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[Vin] [char](17) NOT NULL,
	[TransmissionType] [varchar](10) NOT NULL,
	[ConditionType] [varchar](10) NOT NULL,
	[BodyStyle] [varchar](10) NOT NULL,
	[InteriorColor] [varchar](10) NOT NULL,
	[ExteriorColor] [varchar](10) NOT NULL,
	[MSRP] [decimal](11, 2) NOT NULL,
	[Mileage] [decimal](10, 2) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[ImageFileName] [varchar](25) NULL,
	[FeaturedFlag] [bit] NULL,
	[SoldFlag] [bit] NULL,
	[SalePrice] [decimal](11, 2) NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Model] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Model] ([ModelId])
GO

ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Model]
GO


ALTER TABLE [dbo].[Sales] DROP CONSTRAINT [FK_Sales_Vehicle]
GO

/****** Object:  Table [dbo].[Sales]    Script Date: 3/31/2019 5:01:55 PM ******/
DROP TABLE [dbo].[Sales]
GO

/****** Object:  Table [dbo].[Sales]    Script Date: 3/31/2019 5:01:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sales](
	[SalesId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[Street1] [varchar](50) NOT NULL,
	[Street2] [varchar](50) NULL,
	[City] [varchar](50) NOT NULL,
	[State] [char](2) NOT NULL,
	[ZipCode] [char](10) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[PurchasePrice] [decimal](11, 2) NOT NULL,
	[PurchaseType] [varchar](15) NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[SalesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Vehicle] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicle] ([VehicleId])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Vehicle]
GO


/****** Object:  Table [dbo].[Contacts]    Script Date: 3/31/2019 5:02:40 PM ******/
DROP TABLE [dbo].[Contacts]
GO

/****** Object:  Table [dbo].[Contacts]    Script Date: 3/31/2019 5:02:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contacts](
	[ContactsId] [int] IDENTITY(1,1) NOT NULL,
	[ContactName] [varchar](50) NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Message] [varchar](500) NOT NULL,
	[Email] [varchar](25) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Specials]    Script Date: 3/31/2019 5:02:58 PM ******/
DROP TABLE [dbo].[Specials]
GO

/****** Object:  Table [dbo].[Specials]    Script Date: 3/31/2019 5:02:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Specials](
	[SpecialsId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[Title] [varchar](50) NULL,
 CONSTRAINT [PK_Specials] PRIMARY KEY CLUSTERED 
(
	[SpecialsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

