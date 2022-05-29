
/*
CREATE DOMAIN CASH AS MONEY
NOT NULL CHECK(	VALUE::numeric(10,2) >=0);
*/
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
address     	  		  VARCHAR(255) NULL, -- почта, на которую приходит информация о заказе
id_client   	  		  INT,
id_master   	  		  INT,
id_order_status 		  VARCHAR(10),
CONSTRAINT fk_ord_ordstat FOREIGN KEY (id_Order_status) REFERENCES Order_status (id_Order_status) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_ord_client  FOREIGN KEY (Id_Client) REFERENCES Client (Id_Client) ON DELETE NO ACTION ON UPDATE NO ACTION,
CONSTRAINT fk_ord_master  FOREIGN KEY (id_master) REFERENCES Employee (id) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE workshop(
name_workshop			  VARCHAR(35) PRIMARY KEY,
address    				  text NOT NULL
);
CREATE TABLE Employee( --FK - employee_type, workshop
id      			    SERIAL PRIMARY KEY,
id_contract             VARCHAR(8) UNIQUE,
passport_serial 	    VARCHAR(4) NOT NULL UNIQUE,
passport_number 	    VARCHAR(6) NOT NULL UNIQUE,
address 				TEXT,
type 	                VARCHAR(15),
phone       	        VARCHAR(11)  NOT NULL UNIQUE,
date_of_employment 	    DATE NOT NULL,
name_workshop		    VARCHAR(35),
family 			        VARCHAR(30) NOT NULL,
name   			        VARCHAR(30) NOT NULL,
patronymic 		        VARCHAR(30) NULL,
login                   VARCHAR(64) CONSTRAINT emp_log NOT NULL UNIQUE DEFAULT NULL,
password                VARCHAR(64) CONSTRAINT emp_pass NOT NULL UNIQUE DEFAULT NULL,
CONSTRAINT fk_emp_store FOREIGN KEY(name_workshop) REFERENCES workshop (name_workshop) ON DELETE NO ACTION ON UPDATE CASCADE
);

CREATE TABLE Guarantee(
id_guarantee 			  VARCHAR(10) PRIMARY KEY,
period_in_months          INTEGER NULL,
conditions 	              TEXT NULL
);
CREATE TABLE Manufacturer(
id_manufacturer 		  VARCHAR(25) PRIMARY KEY,
name 					  VARCHAR(150) UNIQUE NOT NULL
);

CREATE TABLE Phone_model( -- FK Guarantee, List_of_supported_models, product, Manufacturer
id_phone_model 			         VARCHAR(25) PRIMARY KEY,
name_model				         VARCHAR(35) NOT NULL,
specifications 			         TEXT NOT NULL,
guarantee_phone_model 	         VARCHAR(15),
manufacturer 			         VARCHAR(25),
--id_product						 VARCHAR(40),
--CONSTRAINT fk_phmod_id_product   FOREIGN KEY(id_product) REFERENCES product (id_product) ON DELETE NO ACTION ON UPDATE RESTRICT,
CONSTRAINT fk_phmod_guarante     FOREIGN KEY(Guarantee_Phone_model) REFERENCES Guarantee (ID_Guarantee) ON DELETE NO ACTION ON UPDATE RESTRICT,
CONSTRAINT fk_phmod_manufacturer FOREIGN KEY(Manufacturer) REFERENCES Manufacturer (Id_Manufacturer) ON DELETE RESTRICT ON UPDATE CASCADE
);
CREATE TABLE Phone( -- FK phone model
imei 				        VARCHAR(17) PRIMARY KEY,
id_phone_model  	        VARCHAR(25),
CONSTRAINT fk_phone_phmodel FOREIGN KEY(Id_Phone_model) REFERENCES Phone_model(Id_Phone_model) ON DELETE RESTRICT ON UPDATE CASCADE
);
CREATE TABLE Component( --FK - Guarantee, Manufacturer
id_component   			        VARCHAR(25) PRIMARY KEY,
type_c 			   			    VARCHAR(20) NOT NULL,
name  		       			    VARCHAR(40) NOT NULL,
id_guarantee 	       		    VARCHAR(15),
manufacturer       			    VARCHAR(25) NOT NULL,
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


