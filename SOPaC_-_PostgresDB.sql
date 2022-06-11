
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

create table orders
(
    id_order        serial primary key,
    dateord         timestamp,
    phonenumber     varchar(11),
    address         varchar(255),
    id_client       integer constraint fk_ord_client references client,
    id_master       integer,
    id_phone        integer constraint fk_ord_phonee  references phone,
    id_order_status varchar(10)  constraint fk_ord_ordstat  references order_status  on update cascade on delete restrict,
    descriptionord  text,
    comments        text,
    priceord        numeric(12, 2) default 0
);

insert into orders (dateord, phonenumber, address, id_client, id_phone, id_order_status, descriptionord, comments) values -- ЗАКАЗЫ
(current_date, '89591233333', 'Ул. Московская 36', 1, 3,'received_0', 'Помята задня крышка', ''),
(current_date, '89491233333', 'Ул. Московская 36', 2, 4,'received_0', 'Нужна установка защитного стекла', 'Стекло для этого телефона очень редкое, посмотреть на универсальные'),
(current_date, '89391233333', 'Ул. Московская 36', 3, 2,'received_0', 'Не держит заряд батареи', ''),
(current_date, '89291233333', 'Ул. Московская 36', 4, 2,'received_0', 'Зависает на холоде', ''),
(current_date, '89191233334', 'Ул. Московская 36', 5, 4,'received_0', 'Не работает зарядка', 'Менять разъем micro-usb');

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
('The Microcomponents Crafting Service'),
('Chinivanyoay neiyiao stafs')
                                     ;

CREATE TABLE Phone_model( -- FK Guarantee, List_of_supported_models, product, Manufacturer
id_phone_model 			         SERIAL PRIMARY KEY,
namephone    				     TEXT NOT NULL,
specifications 			         TEXT NOT NULL,
guarantee 	         INT,
manufacturer 			         INT,
--id_product						 VARCHAR(40),
--CONSTRAINT fk_phmod_id_product   FOREIGN KEY(id_product) REFERENCES product (id_product) ON DELETE NO ACTION ON UPDATE RESTRICT,
CONSTRAINT fk_phmod_guarante     FOREIGN KEY(guarantee) REFERENCES Guarantee (ID_Guarantee) ON DELETE NO ACTION ON UPDATE RESTRICT,
CONSTRAINT fk_phmod_manufacturer FOREIGN KEY(Manufacturer) REFERENCES Manufacturer (Id_Manufacturer) ON DELETE RESTRICT ON UPDATE CASCADE
);
INSERT INTO phone_model (namephone, specifications, guarantee, manufacturer) VALUES
('Ноутилус ++', '6 ядер 9 гигабайт, экран, нет кнопок', 1, 5),
('Phonyao note 90 super pro gaming edition', '16 ядер 19 гигабайт, экран 10 дюймов, 2 камеры, 2 кнопки', 1, 7),
('CommonPhone', '1 ядро 1 гигабайт и кнопки с экраном', 1, 3),
('SuperPhone', '2 ядра 4 гига  и экран с кнопками', 1, 3);

CREATE TABLE Phone( -- FK phone model
id                          SERIAL PRIMARY KEY,
imei 				        VARCHAR(17),
id_phone_model  	        INT,
CONSTRAINT fk_phone_phmodel FOREIGN KEY(Id_Phone_model) REFERENCES Phone_model(id_phone_model) ON DELETE RESTRICT ON UPDATE CASCADE
);
INSERT INTO Phone (imei, id_phone_model) VALUES
('454809104570953', 1) ,
('454813104510155', 2) ,
('452219104530954', 4) ,
('454800344511952', 3) ,
('404809114530952', 2) ,
('354802114571953', 1) ;

CREATE TABLE Component( --FK - Guarantee, Manufacturer
id_component   			        SERIAL PRIMARY KEY,
typecmp 		   			    VARCHAR(20) NOT NULL,
namecmp  		       			VARCHAR(40) NOT NULL,
id_guaranteecmp 	       		    INT,
manufacturercmp       			    INT NOT NULL,
pricecmp                        numeric(12,2),
--id_product					    VARCHAR(40),
--CONSTRAINT fk_comp_id_product   FOREIGN KEY(id_product) REFERENCES product (id_product) ON DELETE NO ACTION ON UPDATE RESTRICT,
CONSTRAINT fk_comp_guarantee    FOREIGN KEY(id_guaranteecmp) REFERENCES Guarantee (ID_Guarantee) ON DELETE RESTRICT ON UPDATE RESTRICT,
CONSTRAINT fk_comp_manufacturer FOREIGN KEY(manufacturercmp) REFERENCES Manufacturer (Id_Manufacturer) ON DELETE RESTRICT ON UPDATE CASCADE
);
INSERT INTO component (typecmp, namecmp, id_guaranteecmp, manufacturercmp,pricecmp) VALUES
('Стекло', 'Универсальное защитное стекло', 1,7,400),
('Экранный модуль', 'Экранный модуль Xemion', 1,3, 2000);
--
CREATE TABLE List_of_supported_models( -- FK - phone model, component
id_list_of_sup_models 	        SERIAL PRIMARY KEY,
idcomponent 			        INT,
idphone_model 			        VARCHAR(25),
CONSTRAINT  fk_lm_phone_model   FOREIGN KEY (idphone_model) REFERENCES Phone_model (id_phone_model) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT  fk_lm_component    	FOREIGN KEY (Idcomponent) REFERENCES Component (id_component) ON DELETE NO ACTION ON UPDATE CASCADE
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
            (id_order, dateord, phonenumber, address, id_client, family, namecl, patronymic, namephone, descriptionos,
             descriptionord, comments, id_master, id_phone, id_order_status, contacts)
as
SELECT orders.id_order,
       orders.dateord,
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
       orders.id_order_status,
       concat(c.family, c.namecl, c.patronymic, orders.phonenumber) AS contacts
FROM orders
         JOIN phone p ON p.id = orders.id_phone
         JOIN phone_model pm ON p.id_phone_model = pm.id_phone_model
         JOIN order_status os ON orders.id_order_status::text = os.idos::text
         JOIN client c ON c.id_client = orders.id_client;

alter table orders_view
    owner to work100024;
