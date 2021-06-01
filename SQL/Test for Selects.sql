USE [SportStuffInternetShop]
GO

SELECT * FROM dbo.Product

SELECT * FROM dbo.ProductBrand

SELECT * FROM dbo.ProductType

SELECT * FROM [Identity].[User] U 
LEFT JOIN [Identity].[Address] UA ON UA.UserId = U.Id

DELETE FROM dbo.Product