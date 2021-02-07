USE [MMTShop]
GO
/****** Object:  StoredProcedure [dbo].[GetProductsByCategoryName]    Script Date: 07/02/2021 18:44:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* Create Stored Procedure GetProductsByCategoryName*/
/* It returns all products that belong to the category represented by @categoryName*/

CREATE PROCEDURE [dbo].[GetProductsByCategoryName] @categoryName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Get all product details for the @categoryName
	SELECT Products.SKU, Products.Name, Products.Description, Products.Price from [dbo].[Products] 
	Inner Join [dbo].[Category] on Products.CategoryId = Category.Id 
	WHERE Category.Name = @categoryName
END
