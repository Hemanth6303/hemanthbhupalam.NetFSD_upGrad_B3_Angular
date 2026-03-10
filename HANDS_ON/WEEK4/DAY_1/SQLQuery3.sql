

create database cursorrowbyrow;

use cursorrowbyrow;

CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(50)
);

INSERT INTO stores VALUES
(1,'Hyderabad Store','Hyderabad'),
(2,'Bangalore Store','Bangalore'),
(3,'Chennai Store','Chennai');

CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    customer_id INT,
    store_id INT,
    order_date DATE,
    order_status INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

INSERT INTO orders VALUES
(1,101,1,'2025-03-01',4),
(2,102,2,'2025-03-02',4),
(3,103,1,'2025-03-03',2),
(4,104,3,'2025-03-04',4),
(5,105,2,'2025-03-05',1);

CREATE TABLE products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100)
);

INSERT INTO products VALUES
(201,'Bike'),
(202,'Helmet'),
(203,'Gloves'),
(204,'Jacket'),
(205,'Tyre');

CREATE TABLE order_items
(
    order_id INT,
    item_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),

    PRIMARY KEY(order_id,item_id),

    FOREIGN KEY(order_id) REFERENCES orders(order_id),
    FOREIGN KEY(product_id) REFERENCES products(product_id)
);


INSERT INTO order_items VALUES
(1,1,201,2,50000,0.10),
(1,2,202,1,2000,0.05),

(2,1,203,3,1500,0.10),

(3,1,205,2,3000,0.00),

(4,1,204,1,7000,0.05),
(4,2,202,2,2000,0.10);


BEGIN TRY

BEGIN TRANSACTION;

-- Temporary table to store revenue per order
CREATE TABLE #TempRevenue
(
    store_id INT,
    order_id INT,
    revenue DECIMAL(12,2)
);

-- Variables for cursor
DECLARE @order_id INT
DECLARE @store_id INT
DECLARE @revenue DECIMAL(12,2)

-- Cursor to fetch completed orders
DECLARE order_cursor CURSOR FOR
SELECT order_id, store_id
FROM orders
WHERE order_status = 4;   -- Completed orders

OPEN order_cursor

FETCH NEXT FROM order_cursor INTO @order_id, @store_id

WHILE @@FETCH_STATUS = 0
BEGIN

    -- Calculate revenue for the order
    SELECT @revenue = SUM(quantity * list_price * (1 - discount))
    FROM order_items
    WHERE order_id = @order_id

    -- Insert into temporary table
    INSERT INTO #TempRevenue
    VALUES(@store_id, @order_id, @revenue)

    FETCH NEXT FROM order_cursor INTO @order_id, @store_id

END

CLOSE order_cursor
DEALLOCATE order_cursor


-- Store-wise revenue summary
SELECT 
    store_id,
    SUM(revenue) AS Total_Revenue
FROM #TempRevenue
GROUP BY store_id

COMMIT TRANSACTION;

END TRY

BEGIN CATCH

    PRINT 'Error occurred. Rolling back transaction.'

    ROLLBACK TRANSACTION;

END CATCH