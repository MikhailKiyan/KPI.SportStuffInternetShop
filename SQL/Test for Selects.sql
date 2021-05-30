USE [SportStuffInternetShop]
GO

SELECT * FROM dbo.Product

SELECT * FROM dbo.ProductBrand

SELECT * FROM dbo.ProductType

SELECT * FROM [Identity].[User] U 
LEFT JOIN [Identity].[Address] UA ON UA.UserId = U.Id

INSERT INTO dbo.Product ([Name], [Description], [Price], [PictureUrl], [ProductTypeId], [ProductBrandId]) VALUES (NULL, -- Id - uniqueidentifier
		N'',  -- Name - nvarchar(126)
		N'',  -- Description - nvarchar(1024)
		NULL, -- Price - decimal(18, 2)
		N'',  -- PictureUrl - nvarchar(255)
		NULL, -- ProductTypeId - uniqueidentifier
		NULL  -- ProductBrandId - uniqueidentifier
	)