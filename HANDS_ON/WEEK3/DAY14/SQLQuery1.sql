CREATE DATABASE AutoRetailDatabase;
GO

USE AutoRetailDatabase;
GO

--Problem1
CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100)
);


CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100)
);


CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

INSERT INTO categories VALUES
(1, 'Mountain Bikes'),
(2, 'Road Bikes'),
(3, 'Electric Bikes');

INSERT INTO brands VALUES
(1, 'Trek'),
(2, 'Giant'),
(3, 'Specialized');

INSERT INTO products VALUES
(1, 'Trek Marlin 7', 1, 1, 2018, 850),
(2, 'Giant Talon 3', 2, 1, 2019, 650),
(3, 'Specialized Rockhopper', 3, 1, 2018, 750),

(4, 'Trek Domane AL 2', 1, 2, 2019, 1000),
(5, 'Giant Contend 3', 2, 2, 2018, 900),
(6, 'Specialized Allez', 3, 2, 2019, 1100),

(7, 'Trek Verve+', 1, 3, 2019, 2500),
(8, 'Giant Explore E+', 2, 3, 2018, 2200),
(9, 'Specialized Turbo Vado', 3, 3, 2019, 3000);


select * from brands;
select * from categories;
select * from products;

SELECT 
    product_name + ' (' + CAST(model_year AS VARCHAR) + ')' AS Product_Info,
    model_year,
    list_price,
    
    -- Category Average Price
    (SELECT AVG(list_price) 
     FROM products p2
     WHERE p2.category_id = p1.category_id) AS Category_Avg_Price,

    -- Difference between product price and category average
    list_price - 
    (SELECT AVG(list_price) 
     FROM products p3
     WHERE p3.category_id = p1.category_id) AS Price_Difference

FROM products p1

WHERE list_price >
(
    SELECT AVG(list_price)
    FROM products p4
    WHERE p4.category_id = p1.category_id
);


--Problem2

CREATE TABLE customers
(
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100),
    phone VARCHAR(15)
);


INSERT INTO customers VALUES
(1, 'John', 'Smith', 'john.smith@gmail.com', '9876543210'),
(2, 'David', 'Miller', 'david.miller@gmail.com', '9876543211'),
(3, 'Emma', 'Johnson', 'emma.johnson@gmail.com', '9876543212'),
(4, 'Sophia', 'Williams', 'sophia.w@gmail.com', '9876543213'),
(5, 'Liam', 'Brown', 'liam.brown@gmail.com', '9876543214'),
(6, 'Noah', 'Davis', 'noah.d@gmail.com', '9876543215');


CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    order_value DECIMAL(10,2),

    FOREIGN KEY (customer_id)
    REFERENCES customers(customer_id)
);


INSERT INTO orders VALUES
(101, 1, '2023-01-10', 4000),
(102, 1, '2023-02-15', 7000),

(103, 2, '2023-03-05', 3000),
(104, 2, '2023-03-20', 2500),

(105, 3, '2023-04-10', 12000),

(106, 4, '2023-05-12', 4500),

(107, 5, '2023-06-18', 8000);


-- Customers who placed orders
SELECT 
    c.customer_id,
    c.first_name + ' ' + c.last_name AS Full_Name,

    -- Nested Query to calculate total order value
    (SELECT SUM(o2.order_value)
     FROM orders o2
     WHERE o2.customer_id = c.customer_id) AS Total_Order_Value,

    CASE 
        WHEN (SELECT SUM(o3.order_value) 
              FROM orders o3 
              WHERE o3.customer_id = c.customer_id) > 10000 
             THEN 'Premium'

        WHEN (SELECT SUM(o3.order_value) 
              FROM orders o3 
              WHERE o3.customer_id = c.customer_id) BETWEEN 5000 AND 10000 
             THEN 'Regular'

        ELSE 'Basic'
    END AS Customer_Type

FROM customers c
JOIN orders o 
ON c.customer_id = o.customer_id

GROUP BY c.customer_id, c.first_name, c.last_name


UNION


-- Customers who never placed orders
SELECT
    c.customer_id,
    c.first_name + ' ' + c.last_name AS Full_Name,
    0 AS Total_Order_Value,
    'No Orders' AS Customer_Type

FROM customers c
WHERE c.customer_id NOT IN
(
    SELECT customer_id
    FROM orders
);



--Problem3

CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(50)
);

INSERT INTO stores VALUES
(1, 'Downtown Bikes', 'New York'),
(2, 'City Cycle Hub', 'Chicago'),
(3, 'Urban Ride Store', 'Los Angeles');


CREATE TABLE stocks
(
    store_id INT,
    product_id INT,
    quantity INT,

    PRIMARY KEY (store_id, product_id),

    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO stocks VALUES
(1,1,10),
(1,2,0),
(1,3,5),
(2,4,3),
(2,5,0),
(2,6,7),
(3,7,2),
(3,8,0),
(3,9,4);

CREATE TABLE order_items
(
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(10,2),

    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);


INSERT INTO order_items VALUES
(1,101,1,2,850,50),
(2,101,2,1,650,0),
(3,102,3,1,750,20),
(4,103,4,2,1000,100),
(5,104,5,1,900,0),
(6,105,6,3,1100,150),
(7,106,7,1,2500,200),
(8,107,8,2,2200,100);

SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS Total_Quantity_Sold,

    SUM((oi.quantity * oi.list_price) - oi.discount) AS Total_Revenue

FROM order_items oi
JOIN orders o
ON oi.order_id = o.order_id

JOIN products p
ON oi.product_id = p.product_id

JOIN stocks st
ON st.product_id = p.product_id

JOIN stores s
ON s.store_id = st.store_id

WHERE st.quantity = 0

GROUP BY s.store_name, p.product_name;

UPDATE stocks
SET quantity = 0
WHERE product_id = 5;


