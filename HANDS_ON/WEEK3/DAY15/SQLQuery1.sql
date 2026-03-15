CREATE DATABASE EcommDb;
GO

USE EcommDb;
GO

---Problem1

CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100) NOT NULL
);

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100) NOT NULL
);


CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(150),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    city VARCHAR(50),
    phone VARCHAR(20)
);


CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(50)
);



INSERT INTO categories VALUES
(1,'Mountain Bikes'),
(2,'Road Bikes'),
(3,'Electric Bikes'),
(4,'Kids Bikes'),
(5,'Accessories');


INSERT INTO brands VALUES
(1,'Trek'),
(2,'Giant'),
(3,'Specialized'),
(4,'Cannondale'),
(5,'Scott');


INSERT INTO products VALUES
(1,'Trek Marlin 7',1,1,2023,85000),
(2,'Giant Defy Advanced',2,2,2022,120000),
(3,'Specialized Turbo Vado',3,3,2023,150000),
(4,'Cannondale Trail 5',4,1,2022,90000),
(5,'Scott Spark 960',5,1,2023,110000);

INSERT INTO customers VALUES
(1,'Rahul','Sharma','Hyderabad','9876543210'),
(2,'Anita','Reddy','Bangalore','9876501234'),
(3,'Kiran','Kumar','Hyderabad','9123456789'),
(4,'Priya','Singh','Chennai','9988776655'),
(5,'Arjun','Patel','Mumbai','9001122334');

INSERT INTO stores VALUES
(1,'AutoBike Store','Hyderabad'),
(2,'Speed Wheels','Bangalore'),
(3,'Urban Riders','Chennai'),
(4,'Bike Zone','Mumbai'),
(5,'Cycle World','Pune');

SELECT 
p.product_name,
p.model_year,
p.list_price,
b.brand_name,
c.category_name
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id
JOIN categories c
ON p.category_id = c.category_id;

SELECT *
FROM customers
WHERE city = 'Hyderabad';

SELECT 
c.category_name,
COUNT(p.product_id) AS total_products
FROM categories c
LEFT JOIN products p
ON c.category_id = p.category_id
GROUP BY c.category_name;

---Problem2
---View for Product Information
/*CREATE VIEW vw_ProductDetails
AS
SELECT
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id
JOIN categories c
ON p.category_id = c.category_id;

SELECT * FROM vw_ProductDetails;

---View for Order Summary
GO
CREATE VIEW vw_OrderSummary
AS
SELECT
    o.order_id,
    c.first_name + ' ' + c.last_name AS customer_name,
    s.store_name,
    st.first_name + ' ' + st.last_name AS staff_name,
    o.order_date,
    o.order_status
FROM orders o
JOIN customers c
ON o.customer_id = c.customer_id
JOIN stores s
ON o.store_id = s.store_id
JOIN staffs st
ON o.staff_id = st.staff_id;

SELECT * FROM vw_OrderSummary;*/


---Create Indexes on Foreign Keys
---Index on Products Table


CREATE INDEX idx_products_brand_id
ON products(brand_id);

CREATE INDEX idx_products_category_id
ON products(category_id);

---Index on Orders Table
DROP INDEX idx_orders_customer_id ON orders(customer_id);
CREATE INDEX idx_orders_customer_id
ON orders(customer_id);

CREATE INDEX idx_orders_store_id
ON orders(store_id);


