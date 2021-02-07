USE [MMTShop]
GO
/****** Object:  StoredProcedure [dbo].[GetFeaturedProducts]    Script Date: 07/02/2021 18:43:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* Create Stored Procedure GetFeaturedProducts*/
/* It returns all featured products */

CREATE PROCEDURE [dbo].[GetFeaturedProducts]
AS
BEGIN
	/* Select SKU, Name, Description and Price for SKU that begins with 1xxxx, 2xxxx and 3xxxx */
	SELECT SKU, Name, Description, Price
	FROM Products
	WHERE SKU like '1%' OR SKU like '2%' OR SKU like '3%'
END
