/* ***************************************************** DATABASE CREATION SCRIPT ***************************************************************************************/

-- DATABASE CRETION
CREATE DATABASE [MASTERESTOQUE]

---------------- TABLES -----------------------------------------------------------------------------------------------

CREATE TABLE PRODUCT_GROUP
(
	[ID_PRODUCT_GROUP] INT PRIMARY KEY IDENTITY(1,1),
	[DESCRIPTION] VARCHAR(MAX),
	[ACTIVE] BIT DEFAULT(1)
);

CREATE TABLE SUPPLIER
(
	[ID_SUPPLIER] INT PRIMARY KEY IDENTITY(1,1),
	[NAME] VARCHAR(MAX),
	[CNPJ] VARCHAR(MAX),
	[IE] VARCHAR(MAX),
	[ACTIVE] BIT DEFAULT(1)
);

CREATE TABLE PRODUCT
(
	[ID_PRODUCT] INT PRIMARY KEY IDENTITY(1,1),
	[DESCRIPTION] VARCHAR(MAX),
	[QUANTITY] INT,
	[ID_PRODUCT_GROUP] INT,
	[ID_SUPPLIER] INT,
	[ACTIVE] BIT DEFAULT(1)
);
ALTER TABLE PRODUCT
ADD CONSTRAINT FK_ID_PRODUCT_GROUP FOREIGN KEY ([ID_PRODUCT_GROUP]) REFERENCES PRODUCT_GROUP([ID_PRODUCT_GROUP]);

ALTER TABLE PRODUCT
ADD CONSTRAINT FK_ID_SUPPLIER_PRODUCT FOREIGN KEY ([ID_SUPPLIER]) REFERENCES SUPPLIER([ID_SUPPLIER]);

CREATE TABLE PRODUCT_COUNT
(
	[ID_PRODUCT_COUNT] INT PRIMARY KEY IDENTITY(1,1),
	[DESCRIPTION] VARCHAR(MAX),
	[QUANTITY] INT,
	[ID_PRODUCT] INT,
	[DATE] DATE
);
ALTER TABLE PRODUCT_COUNT
ADD CONSTRAINT FK_ID_PRODUCT FOREIGN KEY ([ID_PRODUCT]) REFERENCES PRODUCT([ID_PRODUCT]);


-------------------------- PROCEDURES ----------------------------------------------------
USE [MASTERESTOQUE]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--========================================================================================================
-- Description:	Create a counting routine
-- Create:		Leonardo Leal	05/07/2023
-- Alter:		
--========================================================================================================

CREATE PROCEDURE [dbo].[PRC_COUNTING_CREATE]
(
	@DESCRIPTION VARCHAR(60),
	@QUANTITY INT,
	@ID_PRODUCT INT,
	@DATE DATE
)

AS
BEGIN	
		
		-- Saving Product Count and get inserted ID
		INSERT INTO PRODUCT_COUNT( [DESCRIPTION], [QUANTITY], [ID_PRODUCT], [DATE])
		OUTPUT INSERTED.[ID_PRODUCT_COUNT]
		VALUES(@DESCRIPTION, @QUANTITY, @ID_PRODUCT, @DATE)

		-- Update product quantity based on Products count
		UPDATE PRODUCT
		SET [QUANTITY] = @QUANTITY
		WHERE [ID_PRODUCT] = @ID_PRODUCT
END

------------------------------------------------------------------------------

----- DROP TABLES ----------
DROP TABLE PRODUCT_GROUP
DROP TABLE SUPPLIER
DROP TABLE PRODUCT
DROP TABLE PRODUCT_COUNT