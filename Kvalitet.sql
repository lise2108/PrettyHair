USE A_DB29_2018

CREATE TABLE K_Customer
(
CustomerID		INT					Identity,
Name			NVARCHAR (50)		NOT NULL,
Address			NVARCHAR (50)		NOT NULL,
Zip				INT					NOT NULL,
Town			NVARCHAR (50)		NOT NULL,
Telephone		NVARCHAR (50)		NOT NULL

CONSTRAINT K_Customer_PK PRIMARY KEY (CustomerID)
);

CREATE TABLE K_Order
(
OrderID			INT					Identity,
Orderdate		DATETIME2			NOT NULL,
Deliverydate	DATETIME2			NOT NULL,
ProductTypeID	INT					NOT NULL,
Quantity		INT					NOT NULL

CONSTRAINT K_Order_PK PRIMARY KEY (OrderID)
);

CREATE TABLE K_Product
(
ProductID		INT					NOT NULL,
Name			NVARCHAR (50)		NOT NULL,
Description		NVARCHAR (100)		NOT NULL,
Price			FLOAT				NOT NULL,
MinInStock		INT					NOT NULL

CONSTRAINT K_Product_PK PRIMARY KEY (ProductID)
);

CREATE TABLE K_SaleOrderLine
(
ProductID		INT					NOT NULL,
Quantity		INT					NOT NULL,
Price			FLOAT				NOT NULL

CONSTRAINT K_SaleOrderLine_PK PRIMARY KEY (ProductID)
);


ALTER PROCEDURE AddCustomer
@Name			NVARCHAR (50),
@Address		NVARCHAR (50),
@Zip			INT,
@Town			NVARCHAR (50),
@Telephone		NVARCHAR (50)
AS
		INSERT INTO K_Customer
		VALUES (@Name, @Address, @Zip, @Town, @Telephone)


CREATE PROCEDURE AddOrder
@Orderdate		DATETIME2,
@Deliverydate	DATETIME2,
@ProductTypeID	INT,
@Quantity		INT
AS
		INSERT INTO K_Order
		VALUES (@Orderdate, @Deliverydate, @ProductTypeID, @Quantity)