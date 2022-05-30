insert into list_sirvices (name, type,  description, min_cost, min_time) values
('Диагностика', 'выездное','Произведем полную диагностику устройства', 0, '3 days'),
('Замена экарана', 'замена','Демонтаж старого дисплейного модуля и установка нового', 0, '1 hours'),
('Замена сенсора', 'замена','Демонтаж старого сенсорного модуля и установка нового', 900, '1 hours'),
('Замена аккумулятора', 'замена','Разбор смартфона и установка нового аккумулятора', 500, '1 hours'),
('Замена разъема зарядки', 'замена','', 1000, '1 hours'),
('Замена разъема наушников', 'замена','', 1000, '1 hours'),
('Замена задней крышки', 'замена','', 500, '1 hours'),
('Замена разговорного динамика', 'замена','', 1000, '1 hours'),
('Замена основного динамика', 'замена','', 1000, '1 hours'),
('Замена кнопок', 'замена','', 800, '1 hours'),
('Замена микрофона', 'замена','', 1000, '2 hours'),
('Замена шлейфов', 'замена','', 500, '1 hours'),
('Обновление ПО', 'по','', 500, '1 hours'),
('Обновление прошивки ПО ', 'по','', 500, '1 hours'),
('Ремонт материнской платы ', 'восстановление','', 1500, '4 hours'),
('Поклейка защитной пленки', 'интеграция','', 300, '1 hours'),
('Установка защитного стекла', 'интеграция','', 300, '1 hours'),
('Чистка раъемов', 'обслуживание','Выполнение чистки основных разъемов телефона', 150.50, '30 mins')
;
/*
('Обновление  ', 'по','', 0, '4 hours'),
('Замена ', 'замена','', 0, '4 hours'),
('Восстановление ', 'восстановление','', 0, '4 hours'),
(' ', 'прочее','', 0, '4 hours'),
(' ', 'интеграция','', 0, '4 hours'),
*/
-- 1 year 2 months 3 days 4 hours 5 minutes 6 seconds


with client_json (doc) as ( -- client
   values
    (
	'
	[
	{
		"name" 	    : "Василий",
		"family" 	: "Васиков",
        "phone" : "89091234541"
    },
    {
		"name" 	    : "Андрей",
		"family" 	: "Андров",
		"patronymic" : "Андреевич",
        "phone" : "89091234542"

    },
    {
		"name" 	    : "Алексей",
		"family" 	: "Алексеев",
		"patronymic" : "Алексеевич",
        "phone" : "89091234543"

    },
    {
		"name" 	    : "Иван",
		"family" 	: "Иванович",
		"patronymic" : "Иванов",
        "phone" : "89091234544",
        "email" : "iii@gmail.com"

    }
	]
	'::json
	)
)
insert into Client (name, family, patronymic, phone, email)
select  jpr.name, jpr.family , jpr.patronymic , jpr.phone , jpr.email
from client_json j
cross join lateral json_populate_recordset(null::Client, doc) as jpr
;

INSERT INTO Client (name, family, patronymic, phone, email) VALUES ('Дмитрий', 'Быстринский', 'Игоревич','89091234567','pocta@m.com');

with guarante_json (doc) as ( -- guarante
   values
    (
	'
	[
	{
		"id_guarantee"              : "n_0",
        "warranty_period_in_months" : "0",
        "garranty_conditions"       : "Отсутствие гарантии"
    },
	{
		"id_guarantee"              : "r_1",
        "warranty_period_in_months" : "1",
        "garranty_conditions"       : "Гарантися на ремонт - 1 месяц"
    }
	]
	'::json
	)
)
insert into Guarantee
select  jpr.*
from guarante_json j
cross join lateral json_populate_recordset(null::Guarantee, doc) as jpr
;

with shop_json (doc) as ( -- shop !!! не то
   values
    (
	'
	[
	{
		"name_store"       : "Телефоны и запчасти",
        "address"          : "г. Киров"
    }
	]
	'::json
	)
)
insert into Shop
select  jpr.*
from shop_json j
cross join lateral json_populate_recordset(null::Shop, doc) as jpr
;

/*with Employee_type_json (doc) as ( -- Employee_type
   values
    (
	'
	[
	{
		"id_employee_type"       : "mngr_logistic_1",
        "responsible_description": "Сотрудник выполняет обязанности по сортировке товара на складе, а так же осуществляет доставку заказов"
    },
	{
		"id_employee_type"       : "main_1",
        "responsible_description": "Сотрудник выполняет обязанности по руководству компанией"
    },
	{
		"id_employee_type"       : "selman_1",
        "responsible_description": "Сотрудник осуществляет продажи товаров"
    }
	]
	'::json
	)
)

 */
INSERT INTO  employee (id_contract, passport_serial, passport_number, emp_address, type, phone, date_of_employment, workshop, family, name, patronymic, login, password)  VALUES
('12345678', '3315', '123123', 'г. Киров','admin',  '89091324445', '2022-04-08', 1, 'Широков','Роман','Дмитриевич','admin','123'),
('12345677', '3314', '123124', 'г. Киров','master',  '89091324444', '2022-04-09', 1, 'Дитриев','Дмитрий','Иванович','cartavr','456');

--truncate component cascade;
with Component_json (doc) as ( -- Component
   values
    (
	'
        [
        {
    "id_component"  : "c_glass",
    "type_c" 		: "glass",
    "counts" 		: 10,
    "price_c" 	    : 100,
    "name"  		: "Защитное стекло",
    "id_guarantee"  : "n_0",
    "manufacturer"  : "cp_tmcs"
        },
        {
    "id_component"  : "c_case",
    "type_c" 		: "case",
    "counts" 		: 5,
    "price_c" 	    : 200,
    "name"  		: "Защитный чехол",
    "id_guarantee"  : "n_0",
    "manufacturer"  : "cp_tmcs"
        }
        ]
        '::json
	)
)
insert into Component
select  jpr.*
from Component_json j
cross join lateral json_populate_recordset(null::Component, doc) as jpr
;
/*
UPDATE component
SET id_product = id_component;
*/
INSERT INTO phone_model VALUES ('pb_sgh', 'Телефон 5 про + компакт', 'Надежнейший телефон', 'n_0', 'ph_gmsns', 'p_base_phone');

with Order_status_json (doc) as ( -- Order_status
   values
    (
	'
        [
        {
    "id_order_status"  : "s_10",
    "description_order_status" 		: "принят"
        },
        {
    "id_order_status"  : "s_50",
    "description_order_status" 		: "готов к выдаче"
        },
        {
    "id_order_status"  : "s_60",
    "description_order_status" 		: "получено"
        }
        ]
        '::json
	)
)
insert into Order_status
select  jpr.*
from Order_status_json j
cross join lateral json_populate_recordset(null::Order_status, doc) as jpr
;

with Order_json (doc) as ( -- Order_
   values
    (
	'
            [
            {
                "phone_number"	  : "89991231234",
                "address"     	  : "1@main.ru",
                "id_client"   	  : "2",
                "id_order_status" : "received_0",
                "order_date"      : "2021-02-05 14:02:00"
            },
            {
                "phone_number"	  : "89091231234",
                "address"     	  : "3@main.ru",
                "id_client"   	  : "1",
                "id_order_status" : "received_0",
                "order_date"      : "2021-01-08 04:05:06"
            }
            ]
            '::json
	)
)
insert into Orders (phone_number, address, id_Client, id_Order_status, order_date, id_master)
select  jpr.phone_number, jpr.address, jpr.id_Client, jpr.id_Order_status, jpr.order_date, jpr.id_master
from Order_json j
cross join lateral json_populate_recordset(null::Orders, doc) as jpr
;

with Pushare_agreement_json (doc) as ( -- Pushare_agreement
   values
    (
	'
            [
            {
                "name_store"	  : "Телефоны и запчасти",
                "id_client"       : 2,
                "all_cost"   	  : 1,
                "id_order"        : 2,
                "paid"            : true,
                "pushare_agreement_date"      : "2021-01-08 05:05:06"
            },
            {
                "name_store"	  : "Телефоны и запчасти",
                "id_client"       : 1,
                "all_cost"   	  : 1,
                "id_order"        : 1,
                "paid"            : true,
                "pushare_agreement_date"      : "2021-01-08 05:05:06"
            }
            ]
            '::json
	)
)
insert into Pushare_agreement (name_store, id_client, all_cost, id_order, paid, pushare_agreement_date)
select  jpr.name_store, jpr.id_client, jpr.all_cost, jpr.id_order, jpr.paid, jpr.pushare_agreement_date
from Pushare_agreement_json j
cross join lateral json_populate_recordset(null::Pushare_agreement, doc) as jpr
;

TRUNCATE Position_in_order;
with Position_in_order_json (doc) as ( -- Position_in_order
   values
    (
	'
            [
            {
                "id_position"           : "1",
                "id_pushare_agreement"  : 1,
                "id_product"        	: "c_glass",
                "count_staf"            : 1
            },
            {
                "id_position"           : "2",
                "id_pushare_agreement"  : 2,
                "id_product"   	        : "c_case",
                "count_staf"            : 1
            }
            ]
            '::json
	)
)
insert into Position_in_order
select  jpr.*
from Position_in_order_json j
cross join lateral json_populate_recordset(null::Position_in_order, doc) as jpr
;


with Phone_model_json (doc) as ( -- Phone_model
   values
    (
	'
            [
            {
                "id_phone_model"   : "Телефоны и запчасти",
                "name_model"       : 1,
                "specifications"   	  : 1,
                "guarantee_phone_model"        : 1,
                "manufacturer"            : "ph_gmsns",
                "id_product"            : true
            }
            ]
            '::json
	)
)
insert into Pushare_agreement (name_store, id_client, all_cost, id_order, paid)
select  jpr.name_store, jpr.id_client, jpr.all_cost, jpr.id_order, jpr.paid
from Phone_model_json j
cross join lateral json_populate_recordset(null::Pushare_agreement, doc) as jpr
;


insert into order_status (id_order_status, description_order_status) values -- СТАТУСЫ
('received_0', 'Устройство хранится на складе');


