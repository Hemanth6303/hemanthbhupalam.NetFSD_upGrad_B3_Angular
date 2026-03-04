CREATE DATABASE DAY13;
USE DAY13;
/*Problem1*/
CREATE TABLE customers(
    customer_Id INT PRIMARY KEY,
    first_Name VARCHAR(20) NOT NULL,
    last_Name VARCHAR(20) NOT NULL
);

CREATE TABLE orders(
    order_Id INT PRIMARY KEY,
    customer_Id INT,
    order_Date DATE,
    order_Status INT,

    FOREIGN KEY(customer_Id)
    REFERENCES customers(customer_Id)
);

INSERT INTO customers VALUES
(1,'Hemanth','Bhupalam'),
(2,'Jayanth','Bhupalam'),
(3,'Poornesh','Chenna'),
(4,'Jithendra','Vennapusa');

INSERT INTO orders VALUES
(101,1,'2024-05-01',1),
(102,2,'2024-05-02',4),
(103,3,'2024-05-03',2),
(104,1,'2024-05-04',1),
(105,1,'2024-05-05',4);

select * from customers;

select * from orders;

select c.first_Name,c.last_Name,o.order_Id,o.order_Date,o.order_Status FROM customers c INNER JOIN orders o
ON c.customer_Id=o.customer_Id WHERE O.order_Status IN(1,4)
ORDER BY o.order_Date DESC;

 /*Problem2*/

CREATE TABLE brands (
    brand_Id INT PRIMARY KEY,
    brand_Name VARCHAR(20) NOT NULL
);

CREATE TABLE categories (
    category_Id INT PRIMARY KEY,
    category_Name VARCHAR(20) NOT NULL
);

CREATE TABLE products (
    product_Id INT PRIMARY KEY,
    product_Name VARCHAR(50) NOT NULL,
    brand_Id INT,
    category_Id INT,
    model_Year INT,
    list_Price DECIMAL(10,2),

    FOREIGN KEY (brand_Id) REFERENCES brands(brand_Id),
    FOREIGN KEY (category_Id) REFERENCES categories(category_Id)
);


INSERT INTO brands VALUES
(1,'Royal Enfield'),
(2,'Bajaj'),
(3,'Hero'),
(4,'Honda');

INSERT INTO categories VALUES
(1,'Bikes'),
(2,'Scooters');

INSERT INTO products VALUES
(101,'Classic 350',1,1,2023,1800),
(102,'Meteor 350',1,1,2024,2100),
(103,'Pulsar 220',2,1,2022,1500),
(104,'Dominar 400',2,1,2023,2200),
(105,'Splendor Plus',3,1,2023,900),
(106,'HF Deluxe',3,1,2022,850),
(107,'Activa 6G',4,2,2024,1200),
(108,'Shine',4,1,2023,1100);


SELECT 
    p.product_Name,
    b.brand_Name,
    c.category_Name,
    p.model_Year,
    p.list_Price
FROM products p
INNER JOIN brands b
ON p.brand_Id = b.brand_Id
INNER JOIN categories c
ON p.category_Id = c.category_Id
WHERE p.list_Price > 500
ORDER BY p.list_Price ASC;
*/











