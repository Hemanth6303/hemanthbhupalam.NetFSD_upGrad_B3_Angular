CREATE DATABASE Salesdb;
USE Salesdb;
--Problem1
CREATE TABLE Stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50)
)

CREATE TABLE Products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    list_price DECIMAL(10,2)
)

CREATE TABLE Orders
(
    order_id INT PRIMARY KEY,
    store_id INT,
    order_date DATE,
    FOREIGN KEY (store_id) REFERENCES Stores(store_id)
)

CREATE TABLE Order_Items
(
    item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(5,2),

    FOREIGN KEY (order_id) REFERENCES Orders(order_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
)

INSERT INTO Stores VALUES
(1,'Hyderabad Store'),
(2,'Bangalore Store'),
(3,'Chennai Store')

INSERT INTO Products VALUES
(101,'Laptop',60000),
(102,'Mobile',20000),
(103,'Headphones',2000),
(104,'Keyboard',1500),
(105,'Mouse',800)

INSERT INTO Orders VALUES
(1,1,'2024-01-10'),
(2,2,'2024-02-15'),
(3,1,'2024-03-20'),
(4,3,'2024-04-05')

INSERT INTO Order_Items VALUES
(1,1,101,2,60000,0.10),
(2,1,102,3,20000,0.05),
(3,2,103,5,2000,0.02),
(4,3,101,1,60000,0.15),
(5,4,104,4,1500,0.05),
(6,4,105,6,800,0.03)

---Stored Procedure – Total Sales Per Store

CREATE PROCEDURE sp_TotalSalesPerStore
    @StoreID INT = NULL
AS
BEGIN

SELECT
    s.store_name,
    SUM(oi.quantity * oi.list_price * (1-ISNULL(oi.discount,0))) AS TotalSales
FROM Stores s
JOIN Orders o
    ON s.store_id = o.store_id
JOIN Order_Items oi
    ON o.order_id = oi.order_id

WHERE s.store_id = ISNULL(@StoreID, s.store_id)

GROUP BY s.store_name

END

EXEC sp_TotalSalesPerStore


---Stored Procedure – Orders Between Date Range
CREATE PROCEDURE sp_GetOrdersByDateRange
(
    @StartDate DATE,
    @EndDate DATE
)
AS
BEGIN

SELECT
    order_id,
    store_id,
    order_date
FROM Orders
WHERE order_date BETWEEN @StartDate AND @EndDate

END

EXEC sp_GetOrdersByDateRange '2024-01-01','2024-03-30'



---Calculate Price After Discount
GO
CREATE FUNCTION dbo.fn_FinalPrice
(
    @Price DECIMAL(10,2),
    @Discount DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN

DECLARE @FinalPrice DECIMAL(10,2)

SET @FinalPrice = @Price - (@Price * ISNULL(@Discount,0))

RETURN @FinalPrice

END

GO

--DROP FUNCTION IF EXISTS fn_FinalPrice

SELECT
product_id,
list_price,
discount,
dbo.fn_FinalPrice(list_price,discount) AS FinalPrice
FROM Order_Items


---Top 5 Selling Products
DROP FUNCTION IF EXISTS fn_Top5SellingProducts;

GO
CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
SELECT TOP 5
    p.product_name,
    SUM(oi.quantity) AS TotalSold
FROM Order_Items oi
JOIN Products p
ON oi.product_id = p.product_id
GROUP BY p.product_name
ORDER BY SUM(oi.quantity) DESC

)
GO

SELECT * FROM dbo.fn_Top5SellingProducts()






--Problem2 stock auto trigger

CREATE TABLE stocks
(
    product_id INT PRIMARY KEY,
    stock_quantity INT
);

INSERT INTO stocks VALUES
(101,20),
(102,30),
(103,15),
(104,25),
(105,10);

---DROP TRIGGER trg_UpdateStockAfterOrder;

GO
CREATE TRIGGER trg_UpdateStockAfterOrder
ON Order_Items
AFTER INSERT
AS
BEGIN

BEGIN TRY

    -- Check if stock is available
    IF EXISTS (
        SELECT 1
        FROM stocks s
        JOIN inserted i
        ON s.product_id = i.product_id
        WHERE s.stock_quantity < i.quantity
    )
    BEGIN
        RAISERROR('Stock is insufficient for this order.',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Reduce stock
    UPDATE s
    SET s.stock_quantity = s.stock_quantity - i.quantity
    FROM stocks s
    JOIN inserted i
    ON s.product_id = i.product_id;

END TRY

BEGIN CATCH

    PRINT 'Error occurred while updating stock';
    ROLLBACK TRANSACTION;

END CATCH

END;


INSERT INTO Order_Items
VALUES (20,1,101,3,60000,0.05);