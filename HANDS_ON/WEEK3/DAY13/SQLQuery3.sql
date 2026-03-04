create database DAY134;
use DAY134;
/*Problem4*/
CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100)
);


CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT,

    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE order_items (
    item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT
);


INSERT INTO products VALUES
(1,'Mountain Bike'),
(2,'Road Bike'),
(3,'Helmet'),
(4,'Cycling Gloves');

INSERT INTO stores VALUES
(1,'Hyderabad Store'),
(2,'Bangalore Store');


INSERT INTO stocks VALUES
(1,1,20),
(1,2,15),
(1,3,30),
(2,1,25),
(2,3,40),
(2,4,10);


INSERT INTO order_items VALUES
(1,101,1,5),
(2,101,2,3),
(3,102,1,4),
(4,103,3,10);

SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS available_stock,
    SUM(oi.quantity) AS total_sold
FROM stocks st
INNER JOIN products p
ON st.product_id = p.product_id
INNER JOIN stores s
ON st.store_id = s.store_id
LEFT JOIN order_items oi
ON st.product_id = oi.product_id
GROUP BY 
    p.product_name,
    s.store_name,
    st.quantity
ORDER BY p.product_name;