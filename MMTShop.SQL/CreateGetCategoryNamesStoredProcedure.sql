USE [MMTShop]
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryNames]    Script Date: 07/02/2021 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* Create Stored Procedure GetCategoryNames*/
/* It returns all category names */

CREATE PROCEDURE [dbo].[GetCategoryNames] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Get all category names
	SELECT Name from [dbo].[Category]
END
