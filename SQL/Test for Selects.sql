USE [SportStuffInternetShop]
GO

SELECT * FROM dbo.Product WHERE Id = '5e3f60f1-8954-4897-b697-ed2372181fa4'

SELECT * FROM dbo.ProductBrand

SELECT * FROM dbo.ProductType

SELECT * FROM [Identity].[User] U 
LEFT JOIN [Identity].[Address] UA ON UA.UserId = U.Id

DELETE FROM dbo.Product

SELECT * FROM dbo.DeliveryMethods
SELECT * FROM dbo.Orders