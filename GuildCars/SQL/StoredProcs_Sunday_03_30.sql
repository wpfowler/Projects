USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[AddContact]    Script Date: 3/31/2019 4:28:04 PM ******/
DROP PROCEDURE [dbo].[AddContact]
GO

/****** Object:  StoredProcedure [dbo].[AddContact]    Script Date: 3/31/2019 4:28:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[AddContact](
@ContactName varchar(50),
@Phone varchar(15),
@Email varchar(25),
@Message varchar(500),
@NewID int OUTPUT
)
as

Insert into Contacts(ContactName, Phone, Email, Message,CreateDate) Values (@ContactName,@Phone,@Email,@Message,GetDate())
SELECT @NewID = SCOPE_IDENTITY()
GO


/****** Object:  StoredProcedure [dbo].[AddMake]    Script Date: 3/31/2019 4:28:30 PM ******/
DROP PROCEDURE [dbo].[AddMake]
GO

/****** Object:  StoredProcedure [dbo].[AddMake]    Script Date: 3/31/2019 4:28:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[AddMake](
@Description varchar(50),
@UserId nvarchar(128),
@DateAdded Datetime,
@NewId int OUTPUT
)
as

Insert into Make(Description,UserId,DateAdded) Values (@Description,@UserId,@DateAdded)
SELECT @NewId = SCOPE_IDENTITY();
GO

/****** Object:  StoredProcedure [dbo].[AddModel]    Script Date: 3/31/2019 4:29:14 PM ******/
DROP PROCEDURE [dbo].[AddModel]
GO

/****** Object:  StoredProcedure [dbo].[AddModel]    Script Date: 3/31/2019 4:29:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[AddModel](
@Description varchar(50),
@MakeId int,
@UserId nvarchar(128),
@DateAdded Datetime,
@NewId int OUTPUT
)
as

Insert into Model(Description,MakeId,UserId,DateAdded) Values (@Description,@MakeId,@UserId,@DateAdded)
SELECT @NewId = SCOPE_IDENTITY();
GO

/****** Object:  StoredProcedure [dbo].[AddSpecial]    Script Date: 3/31/2019 4:29:50 PM ******/
DROP PROCEDURE [dbo].[AddSpecial]
GO

/****** Object:  StoredProcedure [dbo].[AddSpecial]    Script Date: 3/31/2019 4:29:50 PM ******/
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

/****** Object:  StoredProcedure [dbo].[AddVehicle]    Script Date: 3/31/2019 4:30:53 PM ******/
DROP PROCEDURE [dbo].[AddVehicle]
GO

/****** Object:  StoredProcedure [dbo].[AddVehicle]    Script Date: 3/31/2019 4:30:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddVehicle](
@Modelid int,
@Year int,
@VIN Char(17),
@TransmissionType varchar(10),
@ConditionType varchar(10),
@BodyStyle varchar(10),
@InteriorColor varchar(10),
@ExteriorColor varchar(10),
@MSRP decimal(11,2),
@Mileage decimal(10,2),
@Description varchar(255),
@ImageFileName varchar(25),
@SalePrice decimal(11,2),
@UserId nvarchar(128),
@NewId int OUTPUT
)
as
Insert into Vehicle
(ModelId
,Year
, VIN
,TransmissionType
,ConditionType
,BodyStyle
,InteriorColor
,ExteriorColor
,MSRP
,Mileage
,Description
,ImageFileName
,FeaturedFlag
,SoldFlag
,SalePrice
,UserId)
VALUES
(@ModelId
,@Year
,@VIN
,@TransMissionType
,@ConditionType
,@BodyStyle
,@InteriorColor
,@ExteriorColor
,@MSRP
,@Mileage
,@Description
,@ImageFileName
,NULL
,NULL
,@SalePrice
,@UserId)
SELECT @NewId = SCOPE_IDENTITY()
GO


/****** Object:  StoredProcedure [dbo].[dbReset]    Script Date: 3/31/2019 4:31:36 PM ******/
DROP PROCEDURE [dbo].[dbReset]
GO

/****** Object:  StoredProcedure [dbo].[dbReset]    Script Date: 3/31/2019 4:31:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[dbReset]
as
TRUNCATE TABLE SALES
DELETE FROM Vehicle
DELETE FROM MODEL
DELETE FROM Make
DELETE FROM Specials
DELETE FROM Contacts

DECLARE @dt DateTime 
SET @dt = Getdate()

--Make
DBCC CHECKIDENT ('Make', RESEED, 1)
SET Identity_Insert Make ON
INSERT INTO Make(MakeId, Description,UserId,DateAdded)
VALUES 
	(1,'Acura','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
	(2,'BMW','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
	(3,'Toyota','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
	(4,'Infinity','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
	(5,'Chevrolet','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
	(6,'Ford','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
	(7,'Audi','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt)
 SET Identity_Insert Make Off

 --Model
DBCC CHECKIDENT ('Model', RESEED, 1)
SET Identity_Insert Model ON
  INSERT INTO model(ModelId, MakeId, Description,userId,DateAdded)
 VALUES
 	 (1,1,'Legend','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
	 (2,1,'NSX','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
	 (3,2,'435i','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
	 (4,3,'Tacoma','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
	 (5,5,'Camaro','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
	 (6,4,'G3','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
	 (7,7,'S3','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
	 (8,6,'Mustang GT','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
	 (9,6,'Shelby GT-500','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
	 (10,5,'Silverado','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt)

SET Identity_Insert Model OFF
  
--Vehicle
 DBCC CHECKIDENT ('Vehicle', RESEED, 1)
 SET Identity_Insert Vehicle ON
 Insert into Vehicle(VehicleId, ModelId,Year, VIN,TransmissionType,ConditionType,BodyStyle,InteriorColor,ExteriorColor,MSRP,Mileage,Description,ImageFileName,FeaturedFlag,SoldFlag,SalePrice,UserId)
 Values(1,1,2017,'12345678912345678','Manual','Used','Car','Black','Red',29000,10000,'Acura Graeci consequat eum ne. Est id vero viris, duo probo novum volutpat te. In sed','car1.jpg',null,null,22250,'913dd4f1-4506-4fad-91ae-4539b7a5bdb5')
 
 Insert into Vehicle(VehicleId, ModelId,Year, VIN,TransmissionType,ConditionType,BodyStyle,InteriorColor,ExteriorColor,MSRP,Mileage,Description,ImageFileName,FeaturedFlag,SoldFlag,SalePrice,UserId)
 Values(2,7,2019,'12345678912345999','Manual','New','Car','Black','Red',65000,9,'Audi Graeci consequat eum ne. Est id vero viris, duo probo novum volutpat te. In sed','car1.jpg',1,null,59500,'913dd4f1-4506-4fad-91ae-4539b7a5bdb5')
 
 Insert into Vehicle(VehicleId, ModelId,Year, VIN,TransmissionType,ConditionType,BodyStyle,InteriorColor,ExteriorColor,MSRP,Mileage,Description,ImageFileName,FeaturedFlag,SoldFlag,SalePrice,UserId)
 Values(3,5,2019,'ABCD5678912345999','Manual','New','Car','Tan','White',45900,4,'Camaro Graeci consequat eum ne. Est id vero viris, duo probo novum volutpat te. In sed','car1.jpg',1,null,41000,'913dd4f1-4506-4fad-91ae-4539b7a5bdb5')
 
 Insert into Vehicle(VehicleId, ModelId,Year, VIN,TransmissionType,ConditionType,BodyStyle,InteriorColor,ExteriorColor,MSRP,Mileage,Description,ImageFileName,FeaturedFlag,SoldFlag,SalePrice,UserId)
 Values(4,3,2017,'EFGH5678912345999','Manual','Used','Car','Red','Black',33000,4,'BMW 435 Graeci consequat eum ne. Est id vero viris, duo probo novum volutpat te. In sed','car1.jpg',1,null,32000,'913dd4f1-4506-4fad-91ae-4539b7a5bdb5')
  
 Insert into Vehicle(VehicleId, ModelId,Year, VIN,TransmissionType,ConditionType,BodyStyle,InteriorColor,ExteriorColor,MSRP,Mileage,Description,ImageFileName,FeaturedFlag,SoldFlag,SalePrice,UserId)
 Values(5,4,2019,'EFGH5678912345998','Manual','New','Truck','Blue','Black',34000,4,'Tacoma Graeci consequat eum ne. Est id vero viris, duo probo novum volutpat te. In sed','car1.jpg',1,null,29000,'913dd4f1-4506-4fad-91ae-4539b7a5bdb5')
 

 SET Identity_Insert Vehicle OFF

 --Specials
DBCC CHECKIDENT ('Specials', RESEED, 1)
SET Identity_Insert Specials ON
Insert into Specials(SpecialsId,Description,Title)
Values(1,'Oil change $29.95','OIL!'),(2,'Brake Job $59.95 per axle','BRAKES!'),(3,'Coolant Flush And Fill $99.99','RADIATOR!'),(4,'Buy 3 Tires Get 1 Free - Any Brand','TIRES!'),(5,'Free Beer and Pizza while you wait','INDULGENCE!')
SET Identity_Insert Specials OFF

--Contact
DBCC CHECKIDENT ('Contacts', RESEED, 1)
SET Identity_Insert Contacts ON

Insert into Contacts(Contactsid, ContactName,Phone,Message,Email,CreateDate)
Values(1,'John Smith', '(555) 555-5555','Contact me about VIN: 12345678912345999','John@smith.com',@dt),
(2,'Ricky Bobby', '(409) 222-5555','I wanna go Fast! VIN: ABCDEFGCougar1234','Ricky@OnFire.com',@dt)

SET Identity_Insert Contacts OFF

DBCC CHECKIDENT ('Sales', RESEED, 1)


--Contact
DBCC CHECKIDENT ('Sales', RESEED, 1)
SET Identity_Insert Sales ON
Insert into Sales (SalesId,CustomerName,Street1,Street2,City, State, ZipCode,VehicleId,PurchasePrice,PurchaseType,UserId,PurchaseDate)
Values(1,'Ricky Bobby','222 Gofast street','Shake and bake','Redneckville','Al',30300,1,55000,'Cash','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt),
(2,'Ricky Bobby','222 Gofast street','Shake and bake','Redneckville','Al',30300,2,99000,'Cash','913dd4f1-4506-4fad-91ae-4539b7a5bdb5',@dt)
SET Identity_Insert Sales OFF
update vehicle set SoldFlag = 1 Where VehicleId in (select VehicleId from sales)

update AspNetUserRoles set RoleId = 'dc170be0-cf89-4641-9ad2-2dd203f9e304' WHERE Userid = '913dd4f1-4506-4fad-91ae-4539b7a5bdb5'
update AspNetUsers  set firstName = 'Joe',Lastname ='Administrator' where id = '913dd4f1-4506-4fad-91ae-4539b7a5bdb5'

 
GO

/****** Object:  StoredProcedure [dbo].[DeleteSpecial]    Script Date: 3/31/2019 4:33:35 PM ******/
DROP PROCEDURE [dbo].[DeleteSpecial]
GO

/****** Object:  StoredProcedure [dbo].[DeleteSpecial]    Script Date: 3/31/2019 4:33:35 PM ******/
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


/****** Object:  StoredProcedure [dbo].[DeleteVehicle]    Script Date: 3/31/2019 4:50:47 PM ******/
DROP PROCEDURE [dbo].[DeleteVehicle]
GO

/****** Object:  StoredProcedure [dbo].[DeleteVehicle]    Script Date: 3/31/2019 4:50:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[DeleteVehicle](
@VehicleId int
)
AS
 
BEGIN TRAN
	--Delete From Vehicle where VehicleId = @VehicleId and Isnull(SoldFlag,0) = 0
	update Vehicle set isDeleted = 1 where VehicleId = @VehicleId
COMMIT TRAN
GO


/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 3/31/2019 4:51:24 PM ******/
DROP PROCEDURE [dbo].[EditUser]
GO

/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 3/31/2019 4:51:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[EditUser](
@UserId nvarchar(128),
@FirstName nvarchar(max),
@LastName nvarchar(max),
@Email nvarchar(256),
@RoleId nvarchar(128)
)
AS
SET XACT_ABORT ON

Begin Tran
	Update AspNetUsers
	Set Firstname = @FirstName,
	LastName = @LastName,
	Email = @Email
	WHERE id = @UserId
   
   Update AspNetUserRoles set RoleId = @RoleId Where UserId = @UserId
commit

GO

/****** Object:  StoredProcedure [dbo].[EditVehicle]    Script Date: 3/31/2019 4:52:04 PM ******/
DROP PROCEDURE [dbo].[EditVehicle]
GO

/****** Object:  StoredProcedure [dbo].[EditVehicle]    Script Date: 3/31/2019 4:52:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[EditVehicle](
@VehicleId int,
@ModelId int,
@Year int,
@VIN Char(17),
@TransmissionType varchar(10),
@ConditionType varchar(10),
@BodyStyle varchar(10),
@InteriorColor varchar(10),
@ExteriorColor varchar(10),
@MSRP decimal(11,2),
@Mileage decimal(10,2),
@Description varchar(255),
@ImageFileName varchar(25),
@FeaturedFlag bit,
@SalePrice decimal(11,2),
@UserId nvarchar(128)
)
AS

Update Vehicle
	SET  ModelId = @ModelId
	,Year = @Year
	, VIN = @VIN
	,TransmissionType = @TransmissionType
	,ConditionType = @ConditionType
	,BodyStyle = @BodyStyle
	,InteriorColor = @InteriorColor
	,ExteriorColor = @ExteriorColor
	,MSRP = @MSRP
	,Mileage = @Mileage
	,Description = @Description
	,ImageFileName = @ImageFileName
	,FeaturedFlag = @FeaturedFlag
	,SoldFlag  = NULL
	,SalePrice = @SalePrice
	,UserId = @UserId
WHERE VehicleId = @VehicleId
 
GO

/****** Object:  StoredProcedure [dbo].[GetContactById]    Script Date: 3/31/2019 4:52:50 PM ******/
DROP PROCEDURE [dbo].[GetContactById]
GO

/****** Object:  StoredProcedure [dbo].[GetContactById]    Script Date: 3/31/2019 4:52:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[GetContactById](
@ContactId int)

as 

Select 
	 ContactsId
	,ContactName
	,Phone
	,Message
	,Email
from Contacts
where contactsid = @ContactId
GO

/****** Object:  StoredProcedure [dbo].[GetContacts]    Script Date: 3/31/2019 4:53:12 PM ******/
DROP PROCEDURE [dbo].[GetContacts]
GO

/****** Object:  StoredProcedure [dbo].[GetContacts]    Script Date: 3/31/2019 4:53:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[GetContacts] 
AS

select * from contacts
order by contactsid asc
GO

/****** Object:  StoredProcedure [dbo].[GetFeaturedVehicles]    Script Date: 3/31/2019 4:53:26 PM ******/
DROP PROCEDURE [dbo].[GetFeaturedVehicles]
GO

/****** Object:  StoredProcedure [dbo].[GetFeaturedVehicles]    Script Date: 3/31/2019 4:53:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetFeaturedVehicles]
 AS
 SELECT 
	v.VehicleId
	 ,Year
	 , VIN
	 ,TransmissionType
	 ,ConditionType
	 ,BodyStyle
	 ,InteriorColor
	 ,ExteriorColor
	 ,MSRP
	 ,Mileage
	 ,v.Description
	 ,ImageFileName
	 ,FeaturedFlag
	 ,SoldFlag
	 ,SalePrice
	 ,v.UserId
	 ,mk.makeId
	 ,mk.Description as 'MakeDescription'
	 ,m.ModelId
	 ,m.Description as 'ModelDescription'

 From Vehicle v 
	join model m on v.ModelId = m.ModelId
	join make mk on m.MakeId = mk.MakeId
WHERE FeaturedFlag = 1 and ISnull(SoldFlag,0) = 0 and Isnull(isDeleted,0) = 0
GO

/****** Object:  StoredProcedure [dbo].[GetInventoryReport]    Script Date: 3/31/2019 4:54:46 PM ******/
DROP PROCEDURE [dbo].[GetInventoryReport]
GO

/****** Object:  StoredProcedure [dbo].[GetInventoryReport]    Script Date: 3/31/2019 4:54:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetInventoryReport](
@ConditionType varchar(10)
)
AS
select Year, mk.Description 'Make', md.Description 'Model', count(*) 'Count', Sum(MSRP) 'StockValue'
from vehicle v
	join model md on v.ModelId = md.modelId
	join make mk on md.MakeId = mk.MakeId
WHERE ConditionType = @ConditionType and Isnull(v.IsDeleted,0) = 0
group by year, mk.Description, md.Description
GO


/****** Object:  StoredProcedure [dbo].[GetMakeById]    Script Date: 3/31/2019 4:55:10 PM ******/
DROP PROCEDURE [dbo].[GetMakeById]
GO

/****** Object:  StoredProcedure [dbo].[GetMakeById]    Script Date: 3/31/2019 4:55:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[GetMakeById](
@MakeId int
)
AS
SELECT MakeId, Description 
FROM Make
where MakeId = @MakeID
order by MakeID ASC
GO


/****** Object:  StoredProcedure [dbo].[GetMakes]    Script Date: 3/31/2019 4:55:29 PM ******/
DROP PROCEDURE [dbo].[GetMakes]
GO

/****** Object:  StoredProcedure [dbo].[GetMakes]    Script Date: 3/31/2019 4:55:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE Procedure [dbo].[GetMakes]
AS
SELECT MakeId, Description,userId,DateAdded,a.FirstName + space(1) + a.LastName 'UserName' 
FROM Make m join  AspnetUsers a on m.UserId = a.Id
order by Description ASC
GO

/****** Object:  StoredProcedure [dbo].[GetModelById]    Script Date: 3/31/2019 4:55:46 PM ******/
DROP PROCEDURE [dbo].[GetModelById]
GO

/****** Object:  StoredProcedure [dbo].[GetModelById]    Script Date: 3/31/2019 4:55:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[GetModelById](
@ModelId int
)
AS
SELECT m.ModelId, m.MakeId, m.[Description],m.UserId --, ma.[Description] as makeDescription
FROM Model m
--join Make ma on  m.MakeId = ma.MakeId
where ModelId = @ModelId
order by m.MakeID ASC
GO

/****** Object:  StoredProcedure [dbo].[GetModels]    Script Date: 3/31/2019 4:56:01 PM ******/
DROP PROCEDURE [dbo].[GetModels]
GO

/****** Object:  StoredProcedure [dbo].[GetModels]    Script Date: 3/31/2019 4:56:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[GetModels]
as
SELECT modelId, m.MakeId, m.Description,m.userId,a.FirstName + space(1) + a.LastName 'UserName',mk.Description 'MakeDescription', m.DateAdded
From Model m join AspNetUsers a on m.UserId = a.id
	join make mk on mk.MakeId = m.MakeId
	Order by mk.Description,m.Description asc
GO


/****** Object:  StoredProcedure [dbo].[GetModelsByMakeId]    Script Date: 3/31/2019 4:56:20 PM ******/
DROP PROCEDURE [dbo].[GetModelsByMakeId]
GO

/****** Object:  StoredProcedure [dbo].[GetModelsByMakeId]    Script Date: 3/31/2019 4:56:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetModelsByMakeId](
@MakeId int
)
AS
select modelId,MakeId,Description,userid
 from model
 WHERE makeID = @MakeId
GO


/****** Object:  StoredProcedure [dbo].[GetRoles]    Script Date: 3/31/2019 4:56:49 PM ******/
DROP PROCEDURE [dbo].[GetRoles]
GO

/****** Object:  StoredProcedure [dbo].[GetRoles]    Script Date: 3/31/2019 4:56:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetRoles]
as
Select id as 'RoleId', name as 'Role' from AspNetRoles
GO


/****** Object:  StoredProcedure [dbo].[GetSalesReport]    Script Date: 3/31/2019 4:57:13 PM ******/
DROP PROCEDURE [dbo].[GetSalesReport]
GO

/****** Object:  StoredProcedure [dbo].[GetSalesReport]    Script Date: 3/31/2019 4:57:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[GetSalesReport](
	@UserId nvarchar(128) = null,
	@minDate DateTime = null,
	@maxDate DateTime = null
)
AS

Select au.FirstName + space(1) + au.LastName 'User'
,Sum(PurchasePrice) TotalSales
,Count(*) 'TotalVehicles' 
From Sales s join AspNetUsers au on s.UserId = au.id
WHERE au.id = Isnull(@UserId,au.id)
	and s.PurchaseDate between Isnull(@minDate, s.PurchaseDate) 
	and Isnull(@maxDate,s.PurchaseDate)
group by au.FirstName, au.LastName 
order by au.LastName asc
 
GO

/****** Object:  StoredProcedure [dbo].[GetSpecials]    Script Date: 3/31/2019 4:57:43 PM ******/
DROP PROCEDURE [dbo].[GetSpecials]
GO

/****** Object:  StoredProcedure [dbo].[GetSpecials]    Script Date: 3/31/2019 4:57:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[GetSpecials]
AS
Select SpecialsId, Description,Title From Specials
ORDER by SpecialsId ASC
GO

/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 3/31/2019 4:58:17 PM ******/
DROP PROCEDURE [dbo].[GetUserById]
GO

/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 3/31/2019 4:58:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[GetUserById](
@UserId varchar(128)
)
as
Select au.FirstName,au.LastName, au.UserName,ar.Name 'Role', au.id 'UserId',ar.Id as 'RoleId',au.Email
from AspNetUsers au 
	join AspNetUserRoles aur on au.Id = aur.UserId
	join AspNetRoles ar on aur.RoleId = ar.Id
where au.id = @UserId
order by au.LastName

GO

/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 3/31/2019 4:58:44 PM ******/
DROP PROCEDURE [dbo].[GetUsers]
GO

/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 3/31/2019 4:58:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetUsers]
AS
Select au.FirstName,au.LastName, au.UserName,ar.Name 'Role', au.id 'UserId',ar.Id as 'RoleId',au.Email
from AspNetUsers au 
	join AspNetUserRoles aur on au.Id = aur.UserId
	join AspNetRoles ar on aur.RoleId = ar.Id
order by au.LastName
 
GO

/****** Object:  StoredProcedure [dbo].[GetVehicleById]    Script Date: 3/31/2019 4:59:02 PM ******/
DROP PROCEDURE [dbo].[GetVehicleById]
GO

/****** Object:  StoredProcedure [dbo].[GetVehicleById]    Script Date: 3/31/2019 4:59:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetVehicleById]
	@VehicleId int
 AS
 SELECT 
	 v.VehicleId
	 ,Year
	 , VIN
	 ,TransmissionType
	 ,ConditionType
	 ,BodyStyle
	 ,InteriorColor
	 ,ExteriorColor
	 ,MSRP
	 ,Mileage
	 ,v.Description
	 ,ImageFileName
	 ,FeaturedFlag
	 ,SoldFlag
	 ,SalePrice
	 ,v.UserId
	 ,mk.makeId
	 ,mk.Description as 'MakeDescription'
	 ,m.ModelId
	 ,m.Description as 'ModelDescription'

 From Vehicle v 
	join model m on v.ModelId = m.ModelId
	join make mk on m.MakeId = mk.MakeId
WHERE vehicleId = @VehicleId
GO

/****** Object:  StoredProcedure [dbo].[GetVehicles]    Script Date: 3/31/2019 4:59:24 PM ******/
DROP PROCEDURE [dbo].[GetVehicles]
GO

/****** Object:  StoredProcedure [dbo].[GetVehicles]    Script Date: 3/31/2019 4:59:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetVehicles]
	@MinYear int,
	@MaxYear int,
	@MinPrice decimal(11,2),
	@MaxPrice decimal(11,2),
	@Condition varchar(10) = null,
	@SearchTerm varchar(25) = null
 AS


IF @MinPrice = 0 
	Set @MinPrice = NULL
If @MaxPrice = 0
	SET @MaxPrice = NULL
IF @MinYear = 0
	SET @MinYear = NULL
IF @MaxYear = 0
	SET @MaxYear = NULL
IF @SearchTerm = '' OR @SearchTerm = '-1' --Have to send this in from Post man to indicate NULL. Doesn't handle empty string or null well
SET @SearchTerm = NULL

IF @Condition = ''OR @Condition ='-1'
SET @Condition = NULL

 SELECT TOP 20
	 v.VehicleId
	 ,Year
	 , VIN
	 ,TransmissionType
	 ,ConditionType
	 ,BodyStyle
	 ,InteriorColor
	 ,ExteriorColor
	 ,MSRP
	 ,Mileage
	 ,v.[Description]
	 ,ImageFileName
	 ,FeaturedFlag
	 ,SoldFlag
	 ,SalePrice
	 ,v.UserId
	 ,mk.makeId
	 ,mk.Description as 'MakeDescription'
	 ,m.ModelId
	 ,m.Description as 'ModelDescription'
 From Vehicle v 
	join model m on v.ModelId = m.ModelId
	join make mk on m.MakeId = mk.MakeId
WHERE ISnull(SoldFlag,0) = 0 and Isnull(IsDeleted,0) = 0
	and SalePrice Between Isnull(@minPrice,SalePrice) and IsNull(@maxPrice,SalePrice) 
	and(mk.Description like '%' + isnull(@SearchTerm,mk.Description) + '%' or m.Description like '%' + isnull (@SearchTerm, m.Description) + '%' or year like '%' + @SearchTerm + '%')
	and (year between isnull(@minYear,Year) and isnull(@maxYear,Year))
	and ConditionType = Isnull(@Condition,ConditionType)
ORDER by MSRP DESC
--	
GO

/****** Object:  StoredProcedure [dbo].[PurchaseVehicle]    Script Date: 3/31/2019 5:00:05 PM ******/
DROP PROCEDURE [dbo].[PurchaseVehicle]
GO

/****** Object:  StoredProcedure [dbo].[PurchaseVehicle]    Script Date: 3/31/2019 5:00:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE procedure [dbo].[PurchaseVehicle](
@CustomerName Varchar(50),
@Street1 varchar(50),
@Street2 varchar(50),
@City varchar(50),
@State char(2),
@Zipcode varchar(10),
@VehicleId int,
@PurchasePrice decimal(11,2),
@PurchaseType varchar(15),
@UserId nvarchar(128),
@NewID int OUTPUT
)
AS

SET XACT_ABORT ON

BEGIN TRAN

Update Vehicle SET SoldFlag = 1 where VehicleId = @VehicleId

Insert into Sales(CustomerName,	Street1,Street2,City,State,ZipCode,VehicleId,PurchasePrice,PurchaseType,UserId,PurchaseDate)
Values (@CustomerName,@Street1,@Street2,@City,@State,@ZipCode,@VehicleId,@PurchasePrice,@PurchaseType,@UserId,GetDate())
SELECT @NewID = SCOPE_IDENTITY()
COMMIT TRAN


GO

