use GuildCars
go

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

Create Procedure [dbo].[AddMake](
@Description varchar(50),
@NewId int OUTPUT
)
as

Insert into Make(Description) Values (@Description)
SELECT @NewId = SCOPE_IDENTITY();
GO

Create Procedure [dbo].[AddModel](
@Description varchar(50),
@MakeId int,
@NewId int OUTPUT
)
as

Insert into Model(Description,MakeId) Values (@Description,@MakeId)
SELECT @NewId = SCOPE_IDENTITY();
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
--INSERT INTO Make(MakeId, Description, UserID, CreateDate)
INSERT INTO Make(MakeId, Description)
VALUES 
	(1,'Acura'),
	(2,'BMW'),
	(3,'Toyota'),
	(4,'Infinity'),
	(5,'Chevrolet'),
	(6,'Ford'),
	(7,'Audi')
 SET Identity_Insert Make Off

 --Model
DBCC CHECKIDENT ('Model', RESEED, 1)
SET Identity_Insert Model ON
-- INSERT INTO model(ModelId, MakeId, Description, UserId, CreateDate)
  INSERT INTO model(ModelId, MakeId, Description)
 VALUES
 	 (1,1,'Legend'),
	 (2,1,'NSX'),
	 (3,2,'435i'),
	 (4,3,'Tacoma'),
	 (5,5,'Camaro'),
	 (6,4,'G3'),
	 (7,7,'S3'),
	 (8,6,'Mustang GT'),
	 (9,6,'Shelby GT-500'),
	 (10,5,'Silverado')

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
 Values(4,3,2019,'EFGH5678912345999','Manual','Used','Car','Red','Black',33000,4,'BMW 435 Graeci consequat eum ne. Est id vero viris, duo probo novum volutpat te. In sed','car1.jpg',1,null,32000,'913dd4f1-4506-4fad-91ae-4539b7a5bdb5')
  
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
GO

CREATE Procedure [dbo].[DeleteVehicle](
@VehicleId int
)
AS
 
BEGIN TRAN
	Delete From Vehicle where VehicleId = @VehicleId and Isnull(SoldFlag,0) = 0
COMMIT TRAN
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

CREATE Procedure [dbo].[GetContacts] 
AS

select * from contacts
order by contactsid asc
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
WHERE FeaturedFlag = 1 and ISnull(SoldFlag,0) = 0
GO

CREATE procedure [dbo].[GetInventoryReport](
@ConditionType varchar(10)
)
AS
select Year, mk.Description 'Make', md.Description 'Model', count(*) 'Count', Sum(MSRP) 'StockValue'
from vehicle v
	join model md on v.ModelId = md.modelId
	join make mk on md.MakeId = mk.MakeId
WHERE ConditionType = @ConditionType
group by year, mk.Description, md.Description
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

CREATE Procedure [dbo].[GetMakes]
AS
SELECT MakeId, Description 
FROM Make
order by MakeID ASC
GO

CREATE Procedure [dbo].[GetModelById](
@ModelId int
)
AS
SELECT m.ModelId, m.MakeId, m.[Description] --, ma.[Description] as makeDescription
FROM Model m
--join Make ma on  m.MakeId = ma.MakeId
where ModelId = @ModelId
order by m.MakeID ASC
GO

Create Procedure [dbo].[GetModels]
as
SELECT modelId, MakeId, Description 
From Model
GO

create procedure [dbo].[GetModelsByMakeId](
@MakeId int
)
AS
select modelId,MakeId,Description
 from model
 WHERE makeID = @MakeId
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

CREATE Procedure [dbo].[GetSpecials]
AS
Select SpecialsId, Description,Title From Specials
ORDER by SpecialsId ASC
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
WHERE ISnull(SoldFlag,0) = 0
	and SalePrice Between Isnull(@minPrice,SalePrice) and IsNull(@maxPrice,SalePrice) 
	and(mk.Description like '%' + isnull(@SearchTerm,mk.Description) + '%' or m.Description like '%' + isnull (@SearchTerm, m.Description) + '%')
	and (year between isnull(@minYear,Year) and isnull(@maxYear,Year))
	and ConditionType = Isnull(@Condition,ConditionType)
ORDER by MSRP DESC

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

