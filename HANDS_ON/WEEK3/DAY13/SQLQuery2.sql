
/*Problem3*/
CREATE DATABASE DAY132;

USE DAY132;

CREATE TABLE stores (
    store_Id INT PRIMARY KEY,
    store_Name VARCHAR(20) NOT NULL
);


CREATE TABLE orders (
    order_Id INT PRIMARY KEY,
    store_Id INT,
    order_Status INT,

    FOREIGN KEY (store_Id)
    REFERENCES stores(store_Id)
);

CREATE TABLE order_Items (
    item_Id INT PRIMARY KEY,
    order_Id INT,
    quantity INT,
    list_Price DECIMAL(10,2),
    discount DECIMAL(4,2),

    FOREIGN KEY (order_Id)
    REFERENCES orders(order_Id)
);


INSERT INTO stores VALUES
(1,'anathapur_Store'),
(2,'kurnool_Store'),
(3,'tirupathi_Store');

INSERT INTO orders VALUES
(101,1,4),
(102,1,1),
(103,2,4),
(104,2,4),
(105,3,4);

INSERT INTO order_items VALUES
(1,101,2,500,0.10),
(2,101,1,800,0.05),
(3,103,3,400,0.00),
(4,104,2,600,0.10),
(5,105,4,300,0.05);


SELECT 
    s.store_Name,
    SUM(oi.quantity * oi.list_Price * (1 - oi.discount)) AS total_Sales
FROM stores s
INNER JOIN orders o
ON s.store_Id = o.store_Id
INNER JOIN order_Items oi
ON o.order_Id = oi.order_Id
WHERE o.order_status = 4
GROUP BY s.store_Name
ORDER BY total_Sales DESC;