USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[dbReset]    Script Date: 3/30/2019 7:19:02 PM ******/
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
--INSERT INTO Make(MakeId, Description, UserID, CreateDate)
INSERT INTO Make(MakeId, Description,UserId)
VALUES 
	(1,'Acura','913dd4f1-4506-4fad-91ae-4539b7a5bdb5'),
	(2,'BMW','913dd4f1-4506-4fad-91ae-4539b7a5bdb5'),
	(3,'Toyota','913dd4f1-4506-4fad-91ae-4539b7a5bdb5'),
	(4,'Infinity','913dd4f1-4506-4fad-91ae-4539b7a5bdb5'),
	(5,'Chevrolet','913dd4f1-4506-4fad-91ae-4539b7a5bdb5'),
	(6,'Ford','913dd4f1-4506-4fad-91ae-4539b7a5bdb5'),
	(7,'Audi','913dd4f1-4506-4fad-91ae-4539b7a5bdb5')
 SET Identity_Insert Make Off

 --Model
DBCC CHECKIDENT ('Model', RESEED, 1)
SET Identity_Insert Model ON
-- INSERT INTO model(ModelId, MakeId, Description, UserId, CreateDate)
  INSERT INTO model(ModelId, MakeId, Description,userId)
 VALUES
 	 (1,1,'Legend','913dd4f1-4506-4fad-91ae-4539b7a5bdb5'),
	 (2,1,'NSX','913dd4f1-4506-4fad-91ae-4539b7a5bdb5'),
	 (3,2,'435i','913dd4f1-4506-4fad-91ae-4539b7a5bdb5'),
	 (4,3,'Tacoma','913dd4f1-4506-4fad-91ae-4539b7a5bdb5'),
	 (5,5,'Camaro','913dd4f1-4506-4fad-91ae-4539b7a5bdb5'),
	 (6,4,'G3','913dd4f1-4506-4fad-91ae-4539b7a5bdb5'),
	 (7,7,'S3','913dd4f1-4506-4fad-91ae-4539b7a5bdb5'),
	 (8,6,'Mustang GT','913dd4f1-4506-4fad-91ae-4539b7a5bdb5'),
	 (9,6,'Shelby GT-500','913dd4f1-4506-4fad-91ae-4539b7a5bdb5'),
	 (10,5,'Silverado','913dd4f1-4506-4fad-91ae-4539b7a5bdb5')

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


