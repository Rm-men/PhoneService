
/*
CREATE DOMAIN CASH AS MONEY
NOT NULL CHECK(	VALUE::numeric(10,2) >=0);
*/
create table list_address
(
    address     text not null
        constraint list_address_pk
            primary key,
    description text
);

CREATE TABLE Client(
id_client 		  SERIAL PRIMARY KEY,
name 	  		  VARCHAR(25) NOT NULL,
family	  		  VARCHAR(45) NOT NULL,
patronymic 		  VARCHAR(45) NULL,
phone             VARCHAR(11) NULL UNIQUE,
email             VARCHAR(255) NULL UNIQUE
);
CREATE TABLE Order_status(
id_order_status 		  VARCHAR(10) PRIMARY KEY,
description_order_status  TEXT
);
CREATE TABLE Orders( -- FK client order_
id_order    	  		  SERIAL PRIMARY KEY,
order_date  	  		  TIMESTAMP,
phone_number	  		  VARCHAR(11) , --номер, на который приходит информация о заказе
address     	  		  TEXT,
id_client   	  		  INT,
id_master   	  		  INT,
id_phone                  INT,
id_order_status 		  VARCHAR(10),
description               text,
comments                  text,
CONSTRAINT fk_ord_address FOREIGN KEY (address) REFERENCES list_address (address) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_ord_ordstat FOREIGN KEY (id_Order_status) REFERENCES Order_status (id_Order_status) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_ord_client  FOREIGN KEY (Id_Client) REFERENCES Client (Id_Client) ON DELETE NO ACTION ON UPDATE NO ACTION,
CONSTRAINT fk_ord_master  FOREIGN KEY (id_master) REFERENCES Employee (id) ON DELETE NO ACTION ON UPDATE NO ACTION,
CONSTRAINT fk_ord_phone  FOREIGN KEY (id_phone) REFERENCES Phone (id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

insert into orders (order_date, phone_number, address, id_client, id_phone, id_order_status,description,comments, id_master) values -- ЗАКАЗЫ
-- (current_date, '89091233333', 'Ул. Московская 36', 1, 1,'received_0', 'Плохо работает экран', 'Похоже дело в тачскриние, но менять придется целиком'),
(current_date, '89091233334', 'Ул. Московская 36', 2, 1,'received_0', 'Не работают науншники', 'Менять разъем 3.5', 1);


CREATE TABLE list_workshops(
id			              serial PRIMARY KEY,
address    				  text NOT NULL,
description    		      text NOT NULL,
type                      text NOT NULL
);
INSERT INTO list_workshops (address, description, type) VALUES
('Ул. Московская 36','Основной пункт приема','Пункт приема'),
('Ул. Московская 36','Основная мастерская', 'Мастерская'),
('Ул. Московская 36','Основной склад', 'Склад');


CREATE TABLE Employee( --FK - employee_type, workshop
id      			    SERIAL PRIMARY KEY,
id_contract             VARCHAR(8) UNIQUE,
passport_serial 	    VARCHAR(4) NOT NULL UNIQUE,
passport_number 	    VARCHAR(6) NOT NULL UNIQUE,
emp_address 		    TEXT,
type 	                VARCHAR(15),
phone       	        VARCHAR(11)  NOT NULL UNIQUE,
date_of_employment 	    DATE NOT NULL,
workshop   		        int NOT NULL,
family 			        VARCHAR(30) NOT NULL,
name   			        VARCHAR(30) NOT NULL,
patronymic 		        VARCHAR(30) NULL,
login                   VARCHAR(64) CONSTRAINT emp_log NOT NULL UNIQUE DEFAULT NULL,
password                VARCHAR(64) CONSTRAINT emp_pass NOT NULL UNIQUE DEFAULT NULL,
CONSTRAINT fk_emp_store FOREIGN KEY(workshop) REFERENCES list_workshops (id) ON DELETE NO ACTION ON UPDATE CASCADE
);
INSERT INTO  employee (id_contract, passport_serial, passport_number, emp_address, type, phone, date_of_employment, workshop, family, name, patronymic, login, password)  VALUES
('12345678', '3315', '123123', 'г. Киров','admin',  '89091324445', '2022-04-08', 1, 'Широков','Роман','Дмитриевич','admin','123'),
('12345677', '3314', '123124', 'г. Киров','master',  '89091324444', '2022-04-09', 1, 'Дитриев','Дмитрий','Иванович','cartavr','456');


CREATE TABLE Guarantee(
id_guarantee 			  SERIAL PRIMARY KEY,
period_in_months          INTEGER NULL,
conditions 	              TEXT NULL
);
INSERT INTO guarantee (period_in_months, conditions) VALUES -- ГАРАНТИЯ
(0,'Гарантия отсутствует');

CREATE TABLE Manufacturer(
id_manufacturer 		  SERIAL PRIMARY KEY,
name 					  VARCHAR(150) UNIQUE NOT NULL
);
INSERT INTO manufacturer (name) VALUES
('Hohuwai'),
('Horon'),
('Xemion'),
('GAMSUNS'),
('Rus Electronic Corporation'),
('The Microcomponents Crafting Service');

CREATE TABLE Phone_model( -- FK Guarantee, List_of_supported_models, product, Manufacturer
id_phone_model 			         SERIAL PRIMARY KEY,
name_model				         VARCHAR(35) NOT NULL,
specifications 			         TEXT NOT NULL,
guarantee_phone_model 	         INT,
manufacturer 			         INT,
--id_product						 VARCHAR(40),
--CONSTRAINT fk_phmod_id_product   FOREIGN KEY(id_product) REFERENCES product (id_product) ON DELETE NO ACTION ON UPDATE RESTRICT,
CONSTRAINT fk_phmod_guarante     FOREIGN KEY(Guarantee_Phone_model) REFERENCES Guarantee (ID_Guarantee) ON DELETE NO ACTION ON UPDATE RESTRICT,
CONSTRAINT fk_phmod_manufacturer FOREIGN KEY(Manufacturer) REFERENCES Manufacturer (Id_Manufacturer) ON DELETE RESTRICT ON UPDATE CASCADE
);
INSERT INTO phone_model (name_model, specifications, guarantee_phone_model, manufacturer) VALUES
('SuperPhone', '2 ядра 4 гига  и экран с кнопками', 1, 3);

CREATE TABLE Phone( -- FK phone model
id                          SERIAL PRIMARY KEY,
imei 				        VARCHAR(17),
id_phone_model  	        INT,
CONSTRAINT fk_phone_phmodel FOREIGN KEY(Id_Phone_model) REFERENCES Phone_model(id_phone_model) ON DELETE RESTRICT ON UPDATE CASCADE
);
INSERT INTO Phone (imei, id_phone_model) VALUES
('354809104570953', 1) ;

CREATE TABLE Component( --FK - Guarantee, Manufacturer
id_component   			        VARCHAR(25) PRIMARY KEY,
type_c 			   			    VARCHAR(20) NOT NULL,
name  		       			    VARCHAR(40) NOT NULL,
id_guarantee 	       		    INT,
manufacturer       			    INT NOT NULL,
--id_product					    VARCHAR(40),
--CONSTRAINT fk_comp_id_product   FOREIGN KEY(id_product) REFERENCES product (id_product) ON DELETE NO ACTION ON UPDATE RESTRICT,
CONSTRAINT fk_comp_guarantee    FOREIGN KEY(id_guarantee) REFERENCES Guarantee (ID_Guarantee) ON DELETE RESTRICT ON UPDATE RESTRICT,
CONSTRAINT fk_comp_manufacturer FOREIGN KEY(manufacturer) REFERENCES Manufacturer (Id_Manufacturer) ON DELETE RESTRICT ON UPDATE CASCADE
);
--
CREATE TABLE List_of_supported_models( -- FK - phone model, component
id_list_of_sup_models 	        VARCHAR (5) PRIMARY KEY,
list_supmodel_name			    VARCHAR(25),
id_component 			        VARCHAR(25),
id_phone_model 			        VARCHAR(25),
CONSTRAINT  fk_lm_phone_model   FOREIGN KEY (Id_Phone_model) REFERENCES Phone_model (Id_Phone_model) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT  fk_lm_component    	FOREIGN KEY (Id_component) REFERENCES Component (Id_component) ON DELETE NO ACTION ON UPDATE CASCADE
);

CREATE TABLE List_sirvices( -- FK - phone model, component
id      	                    SERIAL PRIMARY KEY,
name			                VARCHAR(55),
type                            VARCHAR(25),
description 			        TEXT,
min_cost 			            NUMERIC,
min_time                        INTERVAL
);


create view orders_view
            (id_order, order_date, phone_number, address, id_client, family, name, patronymic, name_model,
             description_order_status, description, comments, id_master, id_phone, id_order_status)
as
SELECT orders.id_order,
       orders.order_date,
       orders.phone_number,
       orders.address,
       c.id_client,
       c.family,
       c.name,
       c.patronymic,
       pm.name_model,
       os.description_order_status,
       orders.description,
       orders.comments,
       orders.id_master,
       orders.id_phone,
       orders.id_order_status
FROM orders
         JOIN phone p ON p.id = orders.id_phone
         JOIN phone_model pm ON p.id_phone_model = pm.id_phone_model
         JOIN order_status os ON orders.id_order_status::text = os.id_order_status::text
         JOIN client c ON c.id_client = orders.id_client;

CREATE VIEW employees_view as
    SELECT e.*, lw.address
    FROM employee e
        JOIN list_workshops lw on lw.id = e.workshop