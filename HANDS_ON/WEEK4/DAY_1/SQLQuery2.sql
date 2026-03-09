--problem3
CREATE TABLE Orders
(
    order_id INT PRIMARY KEY,
    order_date DATE,
    shipped_date DATE,
    order_status INT
);

INSERT INTO Orders (order_id, order_date, shipped_date, order_status)
VALUES
(1,'2024-01-10','2024-01-12',3),
(2,'2024-01-15',NULL,2),
(3,'2024-02-05','2024-02-07',3),
(4,'2024-02-10',NULL,1),
(5,'2024-02-15','2024-02-18',4);

/*
1 pending
2 processing
3 shipped
4 completed*/


SELECT * FROM Orders;

GO
CREATE TRIGGER trg_ValidateOrderStatus
ON Orders
AFTER UPDATE
AS
BEGIN

BEGIN TRY

    IF EXISTS
    (
        SELECT 1
        FROM inserted
        WHERE order_status = 4
        AND shipped_date IS NULL
    )
    BEGIN
        RAISERROR('Cannot set order status to Completed when shipped_date is NULL.',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

END TRY

BEGIN CATCH

    PRINT 'Error occurred while validating order status';
    ROLLBACK TRANSACTION;

END CATCH

END


UPDATE Orders
SET order_status = 4
WHERE order_id = 4;/*Cannot set order status to Completed when shipped_date is NULL.*/


UPDATE Orders
SET shipped_date = '2024-02-20',
    order_status = 4
WHERE order_id = 4;/* it will update*/


SELECT * FROM Orders;