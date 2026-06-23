CREATE TABLE CUSTOMER_T2(
  id int PRIMARY KEY AUTO_INCREMENT,
  full_name varchar(100) NOT NULL,
  email varchar(150) UNIQUE NOT NULL,
  phone varchar(20),
  registration_date DATE NOT NULL DEFAULT (CURRENT_DATE)
);
CREATE TABLE CATEGORY_T2(
  id int PRIMARY KEY AUTO_INCREMENT,
  name varchar(100) NOT NULL,
  parent_category_id int REFERENCES CATEGORY_T2(id)
);
CREATE TABLE PRODUCT_T2(
  id int PRIMARY KEY AUTO_INCREMENT,
  name varchar(150) NOT NULL,
  category_id int NOT NULL REFERENCES CATEGORY_T2(id),
  unit_price double NOT NULL,
  stock_quantity int NOT NULL DEFAULT 0
);
CREATE TABLE ORDERS_T2(
  id int PRIMARY KEY AUTO_INCREMENT,
  customer_id int NOT NULL REFERENCES CUSTOMER_T2(id),
  order_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  order_total double NOT NULL DEFAULT 0,
  payment_status varchar(20) NOT NULL DEFAULT 'Pending',
  payment_date DATETIME
);
CREATE TABLE ORDER_ITEM_T2(
  id int PRIMARY KEY AUTO_INCREMENT,
  order_id int NOT NULL REFERENCES ORDERS_T2(id),
  product_id int NOT NULL REFERENCES PRODUCT_T2(id),
  quantity int NOT NULL,
  unit_price_at_sale double NOT NULL
);
