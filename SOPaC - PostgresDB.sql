
--CREATE SCHEMA main;
--SET SEARCH_PATH = main;

--REVOKE ALL PRIVILEGES ON DATABASE sopc FROM PUBLIC;
--REVOKE ALL PRIVILEGES ON SCHEMA public FROM PUBLIC;

	--Управляющий
--CREATE ROLE main LOGIN SUPERUSER CONNECTION LIMIT 1 PASSWORD '123';
-- Остальные после создания таблиц


/*
CREATE DOMAIN C_DATE AS DATE
NOT NULL CHECK(VALUE <= CURRENT_DATE) DEFAULT CURRENT_DATE;

CREATE DOMAIN C_TIMESTAMP AS TIMESTAMP
NOT NULL CHECK(VALUE <= CURRENT_TIMESTAMP) DEFAULT CURRENT_TIMESTAMP;
*/
/*
 CREATE DOMAIN NUMB_PHONE AS VARCHAR(11) CHECK(VALUE ~ '^[0-9]{11}$');
 */
/*
CREATE DOMAIN COUNT AS INT
DEFAULT 1 CHECK(VALUE >=1);
*/

/*
CREATE DOMAIN NUMB_CARD AS VARCHAR(16)
NOT NULL CHECK(
   	VALUE ~ '[0-9]{16}$'
       );
*/

/*
CREATE DOMAIN NUMB_PHONE AS VARCHAR(15)
CHECK(	VALUE ~ '[^0-9]') ;
*/
CREATE DOMAIN CASH AS MONEY
NOT NULL CHECK(	VALUE::numeric(10,2) >=0);

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
description_order_status  Varchar(25)
);

CREATE TABLE Orders( -- FK client order_
id_order    	  		  SERIAL PRIMARY KEY,
order_date  	  		  TIMESTAMP,
phone_number	  		  VARCHAR(11) , --номер, на который приходит информация о заказе
address     	  		  VARCHAR(255) NULL, -- почта, на которую приходит информация о заказе
id_client   	  		  INT,
id_order_status 		  VARCHAR(10),
CONSTRAINT fk_ord_ordstat FOREIGN KEY (id_Order_status) REFERENCES Order_status (id_Order_status) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_ord_client  FOREIGN KEY (Id_Client) REFERENCES Client (Id_Client) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE workshop(
name_workshop			  VARCHAR(35) PRIMARY KEY,
address    				  text NOT NULL
);
CREATE TABLE Employee_of_company( --FK - employee_type, workshop
id_employee			    VARCHAR(8) PRIMARY KEY,
id_employment_contract  VARCHAR(8) UNIQUE,
passport_serial 	    NUMERIC(4) NOT NULL UNIQUE,
passport_nubmer 	    NUMERIC(6) NOT NULL UNIQUE,
adres 				    TEXT,
id_employee_type 	    VARCHAR(15),
phone       	        VARCHAR(11)  NOT NULL UNIQUE,
date_of_employment 	    DATE NOT NULL,
name_workshop		    VARCHAR(35),
family 			        VARCHAR(30) NOT NULL,
name   			        VARCHAR(30) NOT NULL,
patronymic 		        VARCHAR(30) NULL,
login                   VARCHAR(64) CONSTRAINT nnud_emp_log NOT NULL UNIQUE DEFAULT NULL,
password                VARCHAR(64) CONSTRAINT nnud_emp_pasw NOT NULL UNIQUE DEFAULT NULL,
CONSTRAINT fk_emp_store FOREIGN KEY(name_workshop) REFERENCES workshop (name_workshop) ON DELETE NO ACTION ON UPDATE CASCADE
);
/*
CREATE TABLE Order_delivery( --FK order_, employee_of_company
id_order_delivery 		  SERIAL PRIMARY KEY,
time_delivery_start	      C_DATE,
time_delivery_compleate   DATE,
id_order 				  INT,
id_employee 			  VARCHAR(8),
CONSTRAINT fk_orddeliv_order FOREIGN KEY (Id_Order) REFERENCES Order_(Id_Order) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT fk_orddeliv_empl FOREIGN KEY (id_employee) REFERENCES Employee_of_company(id_employee) ON DELETE RESTRICT ON UPDATE CASCADE
);
 */
/*
CREATE TABLE Pushare_agreement( --FK workshop, client, order
id_pushare_agreement	    SERIAL PRIMARY KEY,
name_workshop		        VARCHAR(35),
id_client 				    INT,
all_cost 				    CASH,
pushare_agreement_date      TIMESTAMP,
id_order 				    INT,
paid        	  		    BOOLEAN CONSTRAINT def_pa_paid DEFAULT false,
CONSTRAINT fk_pa_Id_Client  FOREIGN KEY (Id_Client) REFERENCES Client (Id_Client) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_pa_order      FOREIGN KEY (Id_Order) REFERENCES Orders (Id_Order)  ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_pa_workshop       FOREIGN KEY (Name_workshop) REFERENCES workshop (Name_workshop) ON DELETE NO ACTION ON UPDATE CASCADE
);
*/

CREATE TABLE Guarantee(
id_guarantee 			  VARCHAR(10) PRIMARY KEY,
period_in_months          INTEGER NULL,
conditions 	              TEXT NULL
);

CREATE TABLE Manufacturer(
id_manufacturer 		  VARCHAR(25) PRIMARY KEY,
name 					  VARCHAR(150) UNIQUE NOT NULL
);

/*
CREATE TABLE Supply_order( -- FK Employee_of_company
id_supply_order 	           SERIAL PRIMARY KEY,
date_supl_order 	           TIMESTAMP,
id_employee    				   VARCHAR(10),
CONSTRAINT fk_suplorder_emp    FOREIGN KEY (id_employee) REFERENCES Employee_of_company(id_employee) ON DELETE RESTRICT ON UPDATE CASCADE
);

CREATE TABLE Supplier(
id_supplier 			VARCHAR(25) PRIMARY KEY,
adress				    TEXT NOT NULL,
name			  		VARCHAR(25) NOT NULL
);

CREATE TABLE Supply( -- FK supplier, Supply_order
id_supply 				        SERIAL PRIMARY KEY,
id_supply_order			        INT,
id_supplier			            VARCHAR(15),
date_supply 			        TIMESTAMP,
price_supply 			        CASH,
description_supply 		        TEXT NULL,
CONSTRAINT fk_supply_supplorder FOREIGN KEY (id_supply_order) REFERENCES Supply_order (id_supply_order) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_supply_supplier   FOREIGN KEY (Id_supplier) REFERENCES Supplier (Id_supplier) ON DELETE RESTRICT ON UPDATE CASCADE
);
*/
CREATE TABLE Product( 
id_product		    VARCHAR(40) PRIMARY KEY,
name                VARCHAR(40),
price		        CASH,
counts 		        COUNT
);

CREATE TABLE supplied_product( -- FK  supply, workshop
name_workshop	                VARCHAR(35) NOT NULL,
id_suppply		  	            INT,
id_product					    INT,
count 						    COUNT,
price						    CASH,
CONSTRAINT pk_supplied_product  PRIMARY KEY (id_suppply, id_product),
CONSTRAINT fk_pa_workshop           FOREIGN KEY (name_workshopREFERENCES workshop (name_workshopON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_pa_idproduct      FOREIGN KEY (id_product) REFERENCES Product (id_product) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT fk_suplgod_Supply    FOREIGN KEY (Id_suppply) REFERENCES Supply (Id_supply) ON DELETE RESTRICT ON UPDATE CASCADE
);

CREATE TABLE Position_in_order( --FK pushare_agreement, product
id_position 			    SERIAL,
id_pushare_agreement 	    INT,
id_product				    varchar(40),
count_staf				    COUNT,
CONSTRAINT pk_pos_listgoods PRIMARY KEY (id_position, id_pushare_agreement),

CONSTRAINT fk_pos_product   FOREIGN KEY (id_product) REFERENCES product(id_product) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_pos_pushagree FOREIGN KEY (id_pushare_agreement) REFERENCES Pushare_agreement(id_pushare_agreement) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Phone_model( -- FK Guarantee, List_of_supported_models, product, Manufacturer
id_phone_model 			         VARCHAR(25) PRIMARY KEY,
name_model				         VARCHAR(35) NOT NULL,
specifications 			         TEXT NOT NULL,
guarantee_phone_model 	         VARCHAR(15),
manufacturer 			         VARCHAR(25),
id_product						 VARCHAR(40),
CONSTRAINT fk_phmod_id_product   FOREIGN KEY(id_product) REFERENCES product (id_product) ON DELETE NO ACTION ON UPDATE RESTRICT,
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
id_product					    VARCHAR(40),
CONSTRAINT fk_comp_id_product   FOREIGN KEY(id_product) REFERENCES product (id_product) ON DELETE NO ACTION ON UPDATE RESTRICT,
CONSTRAINT fk_comp_guarantee    FOREIGN KEY(id_guarantee) REFERENCES Guarantee (ID_Guarantee) ON DELETE RESTRICT ON UPDATE RESTRICT,
CONSTRAINT fk_comp_manufacturer FOREIGN KEY(manufacturer) REFERENCES Manufacturer (Id_Manufacturer) ON DELETE RESTRICT ON UPDATE CASCADE
);

CREATE TABLE List_of_supported_models( -- FK - phone model, component
id_list_of_sup_models 	        VARCHAR (5) PRIMARY KEY,
list_supmodel_name			    VARCHAR(25),
id_component 			        VARCHAR(25),
id_phone_model 			        VARCHAR(25),
CONSTRAINT  fk_lm_phone_model   FOREIGN KEY (Id_Phone_model) REFERENCES Phone_model (Id_Phone_model) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT  fk_lm_component    	FOREIGN KEY (Id_component) REFERENCES Component (Id_component) ON DELETE NO ACTION ON UPDATE CASCADE
);


CREATE FUNCTION pickup_order() RETURNS TRIGGER AS
$$
    BEGIN
        IF(EXISTS(
                SELECT *
                FROM order_ o
                    JOIN Pushare_agreement Pa on OLD.id_Order = Pa.id_order
                WHERE paid = true
            )
            OR EXISTS(
                SELECT *
                FROM order_ o
                    JOIN order_status os on OLD.id_Order_status = os.id_order_status
                WHERE NEW.description_Order_status != 'получено'
            )
        )
        THEN
            RETURN NEW;
        ELSE
            RAISE EXCEPTION 'Заказ не оплачен';
        end if;
    end;
$$
language plpgsql;
CREATE TRIGGER t_pickup_order
    BEFORE UPDATE ON order_
    FOR EACH  STATEMENT EXECUTE  FUNCTION pickup_order();
	
    --Не разрешать заказывать товара больше, чем есть на складе
    --НЕ РАБОТАЕТ
--DROP FUNCTION no_more_count() CASCADE;
/*
CREATE FUNCTION no_more_count() RETURNS TRIGGER AS
$$
BEGIN-- Это работает только на апдейт
    IF (NEW.count_staf<=( --нужно сравнить количество товара
        SELECT counts FROM component --вытащенного из компонента
        WHERE id_product = ( --идентификатор которого это
            SELECT id_product FROM Product) -- ид товара
        --соответствующий изменяемому/добавляемому товару
        ))
    THEN RETURN NEW;
        ELSE RAISE EXCEPTION 'Количество заказанного товара превосходит складского запаса';
    END IF;
END
$$
language plpgsql;
CREATE TRIGGER t_no_more_count
 BEFORE INSERT OR UPDATE ON position_in_order
 FOR EACH ROW EXECUTE FUNCTION no_more_count();
*/

    -- При добавлении компонента он автоматически заносится в список товаров
CREATE OR REPLACE FUNCTION insert_c_to_products_b() RETURNS TRIGGER AS
$$
BEGIN
    INSERT INTO product
        VALUES (NEW.id_component, NEW.name , 99, 1);
    RETURN NEW;
END
$$ LANGUAGE plpgsql;

CREATE TRIGGER t_insert_c_to_products_b
BEFORE INSERT ON Component
FOR EACH ROW EXECUTE FUNCTION insert_c_to_products_b();


CREATE OR REPLACE FUNCTION insert_c_to_products_a() RETURNS TRIGGER AS
$$
BEGIN
    UPDATE Component
        SET NEW.id_product = (
            SELECT id_product FROM product
                WHERE name = NEW.name
            )
        WHERE name = NEW.name;
    RETURN NEW;
END
$$ LANGUAGE plpgsql;

CREATE TRIGGER t_insert_c_to_products_a
AFTER INSERT ON Component
FOR EACH ROW EXECUTE FUNCTION insert_c_to_products_a();

    -- При добавлении модели телефона он автоматически заносится в список товаров
CREATE OR REPLACE FUNCTION insert_p_to_list() RETURNS TRIGGER AS
$$
BEGIN
    INSERT INTO product
    VALUES (DEFAULT, new.id_component);
    RETURN NEW;
END
$$ LANGUAGE plpgsql;

CREATE TRIGGER t_insert_p_to_list
AFTER INSERT ON Phone_model
FOR EACH ROW EXECUTE FUNCTION insert_p_to_list();

    --Не разрешать забирать заказ, если он не оплачен
--DROP FUNCTION pickup_order() CASCADE;
CREATE FUNCTION pickup_order() RETURNS TRIGGER AS
$$
    BEGIN
        IF(EXISTS(
                SELECT *
                FROM order_ o
                    JOIN Pushare_agreement Pa on OLD.id_Order = Pa.id_order
                WHERE paid = true
            )
            OR EXISTS(
                SELECT *
                FROM order_
                WHERE NEW.id_Order_status != 's_6'
            )
        )
        THEN
            RETURN NEW;
        ELSE
            RAISE EXCEPTION 'Заказ не оплачен, нельзя получить';
        end if;
    end
$$
LANGUAGE plpgsql;
CREATE TRIGGER t_pickup_order
    BEFORE UPDATE ON order_
    FOR EACH ROW EXECUTE  FUNCTION pickup_order();

