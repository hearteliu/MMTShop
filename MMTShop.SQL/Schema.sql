USE [MMTShop]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* Create the Category table */

CREATE TABLE [dbo].[Category](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/* Create the Product table */

CREATE TABLE [dbo].[Products](
	[SKU] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[Price] [int] NULL,
	[CategoryId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[SKU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/* Set the foreign key */

ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Product_Category]
GO


/* Populate Category table */

insert into [dbo].[Category] values ('964a61ed-47ef-492c-9cc9-6a45f1be938f', 'Home')
insert into [dbo].[Category] values ('bf7252ba-9a3e-492f-b945-305b357f127d', 'Garden')
insert into [dbo].[Category] values ('81318948-3797-4807-a209-1688fa945521', 'Electronics')
insert into [dbo].[Category] values ('1bc3ca36-4e8b-4507-af64-2a74024e6509', 'Fitness')
insert into [dbo].[Category] values ('76c58703-1012-456d-9277-bda4c861f36e', 'Toys')

/* Populate the Product table */

insert into [dbo].[Products] values ('10000',  'Table', 'Wood table', 99, '964a61ed-47ef-492c-9cc9-6a45f1be938f')
insert into [dbo].[Products] values ('10001',  'Chair', 'Metal chair', 42, '964a61ed-47ef-492c-9cc9-6a45f1be938f')
insert into [dbo].[Products] values ('10002',  'Shelf Set', 'Set of five shelf pieces', 67, '964a61ed-47ef-492c-9cc9-6a45f1be938f')
insert into [dbo].[Products] values ('10003',  'Desk', 'Wooden desk set', 121, '964a61ed-47ef-492c-9cc9-6a45f1be938f')
insert into [dbo].[Products] values ('10004',  'Lamp', 'Led light lump', 27, '964a61ed-47ef-492c-9cc9-6a45f1be938f')

insert into [dbo].[Products] values ('20000',  'Flower Pot', 'Ceramic flower pot', 22, 'bf7252ba-9a3e-492f-b945-305b357f127d')
insert into [dbo].[Products] values ('20001',  'Watering Pot', 'Plant watering pot metal', 19, 'bf7252ba-9a3e-492f-b945-305b357f127d')
insert into [dbo].[Products] values ('20002',  'Flower Seeds', 'Spring flower seeds 5 pack', 9, 'bf7252ba-9a3e-492f-b945-305b357f127d')
insert into [dbo].[Products] values ('20003',  'Desk Plant', 'Desk plant in a pot', 17, 'bf7252ba-9a3e-492f-b945-305b357f127d')
insert into [dbo].[Products] values ('20004',  'Soil', 'Planting soil one sack', 11, 'bf7252ba-9a3e-492f-b945-305b357f127d')

insert into [dbo].[Products] values ('30000',  'Wireless Keyboard', 'Wireless keyboard set', 20, '81318948-3797-4807-a209-1688fa945521')
insert into [dbo].[Products] values ('30001',  'LCD Monitor', 'LCD Monitor non smart TV', 121, '81318948-3797-4807-a209-1688fa945521')
insert into [dbo].[Products] values ('30002',  'Smart TV', 'Smart TV wireless and 3D', 399, '81318948-3797-4807-a209-1688fa945521')
insert into [dbo].[Products] values ('30003',  'Laptop', 'Acer Laptop all inclusive', 561, '81318948-3797-4807-a209-1688fa945521')
insert into [dbo].[Products] values ('30004',  'Printer Wireless', 'Wireless printer laser', 79, '81318948-3797-4807-a209-1688fa945521')

insert into [dbo].[Products] values ('40000',  'Fitness Rug', 'Fitness rug 1800 x 600', 27, '1bc3ca36-4e8b-4507-af64-2a74024e6509')
insert into [dbo].[Products] values ('40001',  'Lifting Weight', '3kg lifting weights pack of two', 45, '1bc3ca36-4e8b-4507-af64-2a74024e6509')
insert into [dbo].[Products] values ('40002',  'Running Machine', 'Runninc machine with tracking electronics', 568, '1bc3ca36-4e8b-4507-af64-2a74024e6509')
insert into [dbo].[Products] values ('40003',  'Bicycle', 'Fitness indoor bicycle with tracking electronics', 299, '1bc3ca36-4e8b-4507-af64-2a74024e6509')
insert into [dbo].[Products] values ('40004',  'Rubber Ball', 'Rubber ball set of one', 23, '1bc3ca36-4e8b-4507-af64-2a74024e6509')

insert into [dbo].[Products] values ('50000',  'Football Ball', 'Leather football ball authentic', 99, '76c58703-1012-456d-9277-bda4c861f36e')
insert into [dbo].[Products] values ('50001',  'Wireless Car', 'Realistic wireless remote controlled car', 47, '76c58703-1012-456d-9277-bda4c861f36e')
insert into [dbo].[Products] values ('50002',  'Mini Train', 'Mini train set with tracks', 99, '76c58703-1012-456d-9277-bda4c861f36e')
insert into [dbo].[Products] values ('50003',  'Stress Ball', 'Stress ball set of one', 6, '76c58703-1012-456d-9277-bda4c861f36e')
insert into [dbo].[Products] values ('50004',  'Airplane Model', 'Model airplane with remote control', 231, '76c58703-1012-456d-9277-bda4c861f36e')
