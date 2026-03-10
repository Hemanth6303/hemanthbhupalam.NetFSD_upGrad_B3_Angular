CREATE DATABASE AutoRetailDB;

USE AutoRetailDB;

CREATE TABLE products(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    stock_quantity INT
);

INSERT INTO products VALUES
(1,'Car Battery',50),
(2,'Brake Pad',30),
(3,'Engine Oil',40);

CREATE TABLE orders(
    order_id INT PRIMARY KEY,
    order_date DATE
);

CREATE TABLE order_items(
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,

    FOREIGN KEY(order_id) REFERENCES orders(order_id),
    FOREIGN KEY(product_id) REFERENCES products(product_id)
);

---Trigger to Reduce Stock

CREATE TRIGGER trg_UpdateStock
ON order_items
AFTER INSERT
AS
BEGIN

    -- Check stock availability
    IF EXISTS (
        SELECT 1
        FROM products p
        JOIN inserted i ON p.product_id = i.product_id
        WHERE p.stock_quantity < i.quantity
    )
    BEGIN
        PRINT 'Stock insufficient!';
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Reduce stock
    UPDATE p
    SET p.stock_quantity = p.stock_quantity - i.quantity
    FROM products p
    JOIN inserted i
    ON p.product_id = i.product_id;

END;


--Transaction to Place Order

BEGIN TRANSACTION;

BEGIN TRY

INSERT INTO orders VALUES
(101,GETDATE());

INSERT INTO order_items VALUES
(1,101,1,10),
(2,101,2,5);

COMMIT TRANSACTION;

PRINT 'Order placed successfully';

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION;

PRINT 'Order failed due to stock issue';

END CATCH


select * from orders
select * from order_items
select * from products

ALTER TABLE orders
ADD order_status INT DEFAULT 1;



---Problem2

DECLARE @orderId INT = 101;

BEGIN TRANSACTION;

BEGIN TRY

    -- SAVEPOINT before stock restoration
    SAVE TRANSACTION BeforeStockRestore;

    -- Restore product stock
    UPDATE p
    SET p.stock_quantity = p.stock_quantity + oi.quantity
    FROM products p
    JOIN order_items oi 
        ON p.product_id = oi.product_id
    WHERE oi.order_id = @orderId;

    -- Update order status to Rejected
    UPDATE orders
    SET order_status = 3
    WHERE order_id = @orderId;

    COMMIT TRANSACTION;

    PRINT 'Order cancelled successfully and stock restored';

END TRY

BEGIN CATCH

    PRINT 'Error occurred during stock restoration';

    -- Rollback only to SAVEPOINT
    ROLLBACK TRANSACTION BeforeStockRestore;

    PRINT 'Stock restoration rolled back';

    -- Optional: full rollback if needed
    ROLLBACK TRANSACTION;

END CATCH;

select * from orders;