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
CustomerID		INT					NOT NULL,
Picked			BIT					NOT NULL

CONSTRAINT K_Order_PK PRIMARY KEY (OrderID)
CONSTRAINT K_Order_FK FOREIGN KEY (CustomerID)
	REFERENCES K_Customer (CustomerID)
		ON UPDATE CASCADE
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

INSERT INTO K_Product(ProductID, Name, Description, Price, MinInStock)
VALUES (1, 'Shampoo', 'Gør dig ren', 89.25, 97)
INSERT INTO K_Product(ProductID, Name, Description, Price, MinInStock)
VALUES (2, 'Ged', 'Råber af dig og slikker dig', 111.25, 4)
INSERT INTO K_Product(ProductID, Name, Description, Price, MinInStock)
VALUES (3, 'Penge', 'Gør dig rig', 23.25, 64)
INSERT INTO K_Product(ProductID, Name, Description, Price, MinInStock)
VALUES (5, 'Pc', 'Du kan bruge den til mange ting f.eks. som skærebræt', 51.95, 37)
INSERT INTO K_Product(ProductID, Name, Description, Price, MinInStock)
VALUES (84, 'Banan', 'Få folk til at skvate på gammeldags manér', 4.5, 7)

CREATE TABLE K_SaleOrderLine
(
OrderID			INT					NOT NULL,
ProductID		INT					NOT NULL,
Quantity		INT					NOT NULL,
Price			FLOAT				NOT NULL

CONSTRAINT K_SaleOrderLine_PK PRIMARY KEY (ProductID)
CONSTRAINT K_SaleOrderLine_FK FOREIGN KEY (OrderID)
	REFERENCES K_Order (OrderID)
		ON UPDATE CASCADE
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


ALTER PROCEDURE AddOrder
@Orderdate		DATETIME2,
@Deliverydate	DATETIME2,
@CustomerID		INT,
@Picked			BIT
AS
		INSERT INTO K_Order
		VALUES (@Orderdate, @Deliverydate, @CustomerID, @Picked)

ALTER PROCEDURE AddOrderLine
@OrderID		INT,
@ProductID		INT,
@Quantity		INT,
@Price			FLOAT
AS
		INSERT INTO K_SaleOrderLine
		VALUES (@OrderID, @ProductID, @Quantity, @Price)

CREATE PROCEDURE GetCustomer
    @CustomerID int   
AS
    SELECT Name, Address
    FROM  K_Customer
    WHERE CustomerID = @CustomerID

CREATE PROCEDURE GetOrderID
AS
SELECT MAX(OrderID)
  FROM K_Order
  EXEC GetOrderID