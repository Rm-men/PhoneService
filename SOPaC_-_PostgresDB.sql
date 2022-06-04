
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
namecl 	  		  VARCHAR(25) NOT NULL,
family	  		  VARCHAR(45) NOT NULL,
patronymic 		  VARCHAR(45) NULL,
phone             VARCHAR(11) NULL UNIQUE,
email             VARCHAR(255) NULL UNIQUE
);
CREATE TABLE Order_status(
id_order_status 		  VARCHAR(10) PRIMARY KEY,
descriptionos  TEXT
);
CREATE TABLE Orders( -- FK client order_
id_order    	  		  SERIAL PRIMARY KEY,
date  	  		          TIMESTAMP,
phonenumber	  		      VARCHAR(11) , --номер, на который приходит информация о заказе
address     	  		  TEXT,
id_client   	  		  INT,
id_master   	  		  INT,
id_phone                  INT,
id_order_status 		  VARCHAR(10),
descriptionord            text,
comments                  text,
CONSTRAINT fk_ord_address FOREIGN KEY (address) REFERENCES list_address (address) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_ord_ordstat FOREIGN KEY (id_Order_status) REFERENCES Order_status (id_Order_status) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_ord_client  FOREIGN KEY (Id_Client) REFERENCES Client (Id_Client) ON DELETE NO ACTION ON UPDATE NO ACTION,
CONSTRAINT fk_ord_master  FOREIGN KEY (id_master) REFERENCES Employee (id) ON DELETE NO ACTION ON UPDATE NO ACTION,
CONSTRAINT fk_ord_phone   FOREIGN KEY (id_phone) REFERENCES Phone (id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

insert into orders (date, phonenumber, address, id_client, id_phone, id_order_status,descriptionord,comments, id_master) values -- ЗАКАЗЫ
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
paspserial 	            VARCHAR(4) NOT NULL UNIQUE,
paspnumber 	            VARCHAR(6) NOT NULL UNIQUE,
empaddress 	            TEXT,
type 	                VARCHAR(15),
phone       	        VARCHAR(11)  NOT NULL UNIQUE,
dateemploymentet 	    DATE NOT NULL,
workshop   		        int NOT NULL,
family 			        VARCHAR(30) NOT NULL,
name   			        VARCHAR(30) NOT NULL,
patronymic 		        VARCHAR(30) NULL,
login                   VARCHAR(64) CONSTRAINT emp_log NOT NULL UNIQUE DEFAULT NULL,
password                VARCHAR(64) CONSTRAINT emp_pass NOT NULL UNIQUE DEFAULT NULL,
CONSTRAINT fk_emp_store FOREIGN KEY(workshop) REFERENCES list_workshops (id) ON DELETE NO ACTION ON UPDATE CASCADE
);
INSERT INTO  employee (id_contract, paspserial, paspnumber, empaddress, type, phone, dateemploymentet, workshop, family, name, patronymic, login, password)  VALUES
('12345678', '3315', '123123', 'г. Киров','admin',  '89091324445', '2022-04-08', 1, 'Широков','Роман','Дмитриевич','admin','123'),
('12345677', '3314', '123124', 'г. Киров','master',  '89091324444', '2022-04-09', 1, 'Дитриев','Дмитрий','Иванович','cartavr','456');


CREATE TABLE Guarantee(
id_guarantee 			  SERIAL PRIMARY KEY,
period                    INTEGER NULL,
conditions 	              TEXT NULL
);
INSERT INTO guarantee (period, conditions) VALUES -- ГАРАНТИЯ
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
namephone    				         VARCHAR(35) NOT NULL,
specifications 			         TEXT NOT NULL,
guarantee 	         INT,
manufacturer 			         INT,
--id_product						 VARCHAR(40),
--CONSTRAINT fk_phmod_id_product   FOREIGN KEY(id_product) REFERENCES product (id_product) ON DELETE NO ACTION ON UPDATE RESTRICT,
CONSTRAINT fk_phmod_guarante     FOREIGN KEY(guarantee) REFERENCES Guarantee (ID_Guarantee) ON DELETE NO ACTION ON UPDATE RESTRICT,
CONSTRAINT fk_phmod_manufacturer FOREIGN KEY(Manufacturer) REFERENCES Manufacturer (Id_Manufacturer) ON DELETE RESTRICT ON UPDATE CASCADE
);
INSERT INTO phone_model (namephone, specifications, guarantee, manufacturer) VALUES
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
typecmp 		   			    VARCHAR(20) NOT NULL,
namecmp  		       			VARCHAR(40) NOT NULL,
id_guarantee 	       		    INT,
manufacturer       			    INT NOT NULL,
--id_product					    VARCHAR(40),
--CONSTRAINT fk_comp_id_product   FOREIGN KEY(id_product) REFERENCES product (id_product) ON DELETE NO ACTION ON UPDATE RESTRICT,
CONSTRAINT fk_comp_guarantee    FOREIGN KEY(id_guarantee) REFERENCES Guarantee (ID_Guarantee) ON DELETE RESTRICT ON UPDATE RESTRICT,
CONSTRAINT fk_comp_manufacturer FOREIGN KEY(manufacturer) REFERENCES Manufacturer (Id_Manufacturer) ON DELETE RESTRICT ON UPDATE CASCADE
);
--
CREATE TABLE List_of_supported_models( -- FK - phone model, component
id_list_of_sup_models 	        SERIAL PRIMARY KEY,
id_component 			        VARCHAR(25),
id_phone_model 			        VARCHAR(25),
CONSTRAINT  fk_lm_phone_model   FOREIGN KEY (Id_Phone_model) REFERENCES Phone_model (Id_Phone_model) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT  fk_lm_component    	FOREIGN KEY (Id_component) REFERENCES Component (Id_component) ON DELETE NO ACTION ON UPDATE CASCADE
);

CREATE TABLE list_sirvices( -- FK - phone model, component
id      	                    SERIAL PRIMARY KEY,
namesrv			                VARCHAR(55),
typesrv                            VARCHAR(25),
descriptionsrv 			        TEXT,
costsrv 			            NUMERIC(12,2),
timesrv                        INTERVAL
);

CREATE TABLE order_servises( -- FK - phone model, component
id      	                    int PRIMARY KEY,
idservie                        int,
CONSTRAINT  fk_lm_phone_model   FOREIGN KEY (id) REFERENCES orders (id_order) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT  fk_lm_phone_model   FOREIGN KEY (idservie) REFERENCES list_sirvices (id) ON DELETE NO ACTION ON UPDATE CASCADE
);

CREATE TABLE order_components( -- FK - phone model, component
id      	                    int PRIMARY KEY,
idcomponents                    int,
CONSTRAINT  fk_lm_phone_model   FOREIGN KEY (id) REFERENCES orders (id_order) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT  fk_lm_phone_model   FOREIGN KEY (idcomponents) REFERENCES component (id_component) ON DELETE NO ACTION ON UPDATE CASCADE
);

--------------------------------------------------- запросы для изменениея конфигурации
------ параметры заказа
UPDATE orders
SET customer=subquery.customer,
    address=subquery.address,
    partn=subquery.partn
FROM (SELECT address_id, customer, address, partn
      FROM  /* big hairy SQL */ ...) AS subquery
WHERE dummy.address_id=subquery.address_id;


------ параметры компонентов
-- сначала удалить все старые
DELETE FROM order_components
    WHERE id = {id};
-- потом добавить все новые
-- циклом добавлять каждый
insert into order_components values (id,idcomponents);


------ параметры услуг
-- сначала удалить все старые
DELETE FROM order_components
    WHERE id = {id};
-- потом добавить все новые
-- циклом добавлять каждый
insert into order_components values (id,idcomponents);




create view orders_view
as
SELECT orders.id_order,
       orders.date,
       orders.phonenumber,
       orders.address,
       c.id_client,
       c.family,
       c.namecl,
       c.patronymic,
       pm.namephone,
       os.descriptionos,
       orders.descriptionord,
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