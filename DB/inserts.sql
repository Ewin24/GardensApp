--check
INSERT INTO garden.country (name) VALUES
('United States'),
('Canada'),
('United Kingdom');

--check
INSERT INTO garden.state (name, IdCountryFk) VALUES
('New York', 1),
('California', 1),
('Texas', 1);

INSERT INTO garden.state (name, IdCountryFk) VALUES
('Ontario', 2),
('Quebec', 2),
('British Columbia', 2);

INSERT INTO garden.state (name, IdCountryFk) VALUES
('London', 3),
('Manchester', 3),
('Birmingham', 3);

--check
INSERT INTO garden.city (name, IdStateFk) VALUES
('Bucaramanga', 1),
('Cali', 2),
('Barranca', 3);

--check
INSERT INTO garden.boss (name, dentification_ard, cellphone) VALUES
('John Doe', 123456789, 555-1234),
('Jane Smith', 987654321, 555-5678),
('Robert Johnson', 555000111, 555-9999);

--check
INSERT INTO garden.employee (employee_code, first_name, last_name1, last_name2, extension, email, office_code, IdBossFk, `position`) VALUES
(101, 'Alice', 'Johnson', 'Smith', 'ext101', 'alice@example.com', 'NYC', 1, 'Manager'),
(102, 'Bob', 'Smith', 'Johnson', 'ext102', 'bob@example.com', 'LA', 2, 'Sales Representative'),
(103, 'Charlie', 'Doe', 'Brown', 'ext103', 'charlie@example.com', 'CHI', 3, 'Analyst');

--check
INSERT INTO garden.contact (id, contact_name, contact_last_name, contact_numbrer, fax) VALUES
(201, 'John', 'Doe', '555-1111', '555-1112'),
(202, 'Jane', 'Smith', '555-2222', '555-2223'),
(203, 'Robert', 'Johnson', '555-3333', '555-3334');

--check
INSERT INTO garden.client (client_code, client_name, credit_limit, IdEmployeeFK, IdContactFK) VALUES
(1001, 'ABC Corporation', 50000, 101, 201),
(1002, 'XYZ Ltd.', 75000, 102, 202),
(1003, 'Smith Enterprises', 100000, 103, 203);


--check
INSERT INTO garden.location_customer (tipoDeVia, numeroPri, letra, bis, letrasec, cardinal, numeroSec, letrater, numeroTer, cardinalSec, complemento, idClientFk, idCityFk, PostCode) VALUES
('Street', 123, 'A', '', '', 'North', 456, '', 0, '', 'Apt 101', 1001, 4, '12345'),
('Avenue', 789, 'B', 'Bis', '', 'South', 101, 'C', 0, '', 'Suite 200', 1002, 5, '56789'),
('Road', 456, 'C', '', '', 'East', 789, '', 0, '', 'Unit 301', 1003, 6, '98765');

--chack
INSERT INTO garden.location_office (tipoDeVia, numeroPri, letra, bis, letrasec, cardinal, numeroSec, letrater, numeroTer, cardinalSec, complemento, PostCode, idCityFk) VALUES
('Boulevard', 101, 'D', '', '', 'West', 202, '', 0, '', 'Floor 1', '54321', 4),
('Lane', 303, 'E', '', '', 'South', 404, '', 0, '', 'Suite 2', '98765', 4),
('Drive', 505, 'F', 'Bis', '', 'North', 606, 'G', 0, '', 'Room 3', '12345', 5);

--check
INSERT INTO garden.office (office_code, phone, location_office_FK) VALUES
('NYC', '555-1111', 4),
('LA', '555-2222', 5),
('CHI', '555-3333', 6);

--check
INSERT INTO garden.product (Id, product_code, name, product_line, dimensions, supplier, description, stock_quantity, selling_price, supplier_price, IdProviderFk) VALUES
(4001, 'P001', 'Widget A', 'Widgets', '10x10x5', 'Supplier A', 'High-quality widget', 100, 29.99, 15.00, 1),
(4002, 'P002', 'Gadget B', 'Gadgets', '8x8x6', 'Supplier B', 'Versatile gadget', 50, 59.99, 35.00, 2),
(4003, 'P003', 'Tool C', 'Tools', '12x6x4', 'Supplier C', 'Durable tool', 75, 39.99, 20.00, 3);

--check
INSERT INTO garden.order_detail (order_code, product_code, quantity, unit_price, line_number) VALUES
(2001, 4001, 5, 25.99, 1),
(2002, 4002, 3, 49.99, 2),
(2003, 4003, 2, 35.50, 3);

--check
INSERT INTO garden.orders (order_code, order_date, expected_date, delivery_date, status, comments, client_code) VALUES
(2001, '2023-01-05', '2023-01-10', '2023-01-08', 'Shipped', 'Items in good condition', 1001),
(2002, '2023-02-10', '2023-02-15', NULL, 'Pending', 'Waiting for payment', 1002),
(2003, '2023-03-20', '2023-03-25', NULL, 'Processing', 'Custom order', 1003);

--check
INSERT INTO garden.payment (Id, payment_method, transaction_id, payment_date, total, client_code) VALUES
(3001, 'Credit Card', 'CC123456', '2023-01-15', 150.00, 1001),
(3002, 'PayPal', 'PP987654', '2023-02-20', 225.50, 1002),
(3003, 'Bank Transfer', 'BT555555', '2023-03-30', 180.75, 1003);


--check
INSERT INTO garden.product_line (product_line, description_text, description_html, image) VALUES
('Widgets', 'Various types of widgets', '<p>Explore our diverse range of widgets.</p>', 'widget_image.jpg'),
('Gadgets', 'Innovative and exciting gadgets', '<p>Discover the latest in gadget technology.</p>', 'gadget_image.jpg'),
('Tools', 'Quality tools for every need', '<p>Find the right tool for the job.</p>', 'tool_image.jpg');

--check
INSERT INTO garden.provider (name, dentification_ard, cellphone) VALUES
('Supplier A', 123456789, 5551111),
('Supplier B', 987654321, 5552222),
('Supplier C', 555000111, 5553333);

--check
INSERT INTO garden.`user` (Email, Password) VALUES
('john@example.com', 'password123'),
('jane@example.com', 'securepass456'),
('robert@example.com', 'letmein789');


