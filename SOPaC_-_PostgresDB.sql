create table client
(
    id_client  serial
        primary key,
    namecl     varchar(25)  not null,
    family     varchar(45)  not null,
    patronymic varchar(45),
    phone      varchar(11)
        unique,
    email      varchar(255) not null
        unique,
    clpassword varchar(64)  not null
);
INSERT INTO Client (namecl, family, patronymic, phone, email, clpassword) VALUES
('Иван', 'Иванов', 'Иванович','89091234561','iii@m.com','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3' ), --123
('Дмитрий', 'Быстринский', 'Игоревич','89091234562','dbi@m.com','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3' ), --123
('Василий', 'Иванов', 'Андреевич','89091234563','via@m.com','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3' ), --123
('Дмитрий', 'Васиков', 'Игоревич','89091234564','dvi@m.com','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3' ), --123
('Дмитрий', 'Андров', 'Игоревич','89091234565','dai@m.com','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3' ), --123
('Василий', 'Васиков', null,'89091234566','vv@m.com','b3a8e0e1f9ab1bfe3a36f231f676f78bb30a519d2b21e6c530c0eee8ebb4a5d0' ), --456
('Андрей', 'Андров', 'Андреевич','89091234567','aaa@m.com','35a9e381b1a27567549b5f8a6f783c167ebf809f1c4d6a9e367240484d8ce281' ); --789


create table order_status
(
    idos             varchar(10) not null
        primary key,
    descriptionos    text,
    logical_sequence serial
);
insert into order_status (idos, descriptionos, logical_sequence) values -- СТАТУСЫ
('received_0', 'Устройство хранится на складе', 1);


create table list_workshops
(
    id          serial
        primary key,
    address     text not null,
    description text not null,
    type        text not null
);
INSERT INTO list_workshops (address, description, type) VALUES
('Ул. Московская 36','Основной пункт приема','Пункт приема'),
('Ул. Московская 36','Основная мастерская', 'Мастерская'),
('Ул. Московская 36','Основной склад', 'Склад');


create table employee
(
    id               serial
        primary key,
    id_contract      varchar(8)
        unique,
    paspserial       varchar(4)                                  not null
        unique,
    paspnumber       varchar(6)                                  not null
        unique,
    empaddress       text,
    type             varchar(15),
    phone            varchar(11)                                 not null
        unique,
    dateemploymentet date                                        not null,
    workshop         integer                                     not null
        constraint fk_emp_store
            references list_workshops
            on update cascade,
    family           varchar(30)                                 not null,
    name             varchar(30)                                 not null,
    patronymic       varchar(30),
    login            varchar(64) default NULL::character varying not null
        unique,
    password         varchar(64) default NULL::character varying not null
        unique
);
INSERT INTO  employee (id_contract, paspserial, paspnumber, empaddress, type, phone, dateemploymentet, workshop, family, name, patronymic, login, password)  VALUES
('12345678', '3315', '123123', 'г. Киров','admin',  '89091324445', '2022-04-08', 1, 'Широков','Роман','Дмитриевич','admin','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3'),
('12345677', '3314', '123124', 'г. Киров','master',  '89091324444', '2022-04-09', 1, 'Дитриев','Дмитрий','Иванович','cartavr','b3a8e0e1f9ab1bfe3a36f231f676f78bb30a519d2b21e6c530c0eee8ebb4a5d0');

create table guarantee
(
    id_guarantee serial
        primary key,
    period       integer,
    conditions   text
);
INSERT INTO guarantee (period, conditions) VALUES -- ГАРАНТИЯ
(0,'Гарантия отсутствует');

create table manufacturer
(
    id_manufacturer serial
        primary key,
    name            varchar(150) not null
        unique
);
INSERT INTO manufacturer (name) VALUES
('Hohuwai'),
('Horon'),
('Xemion'),
('GAMSUNS'),
('Rus Electronic Corporation'),
('The Microcomponents Crafting Service'),
('Chinivanyoay neiyiao stafs');

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

create table component
(
    id_component    serial
        primary key,
    typecmp         varchar(20) not null,
    namecmp         varchar(40) not null,
    id_guaranteecmp integer
        constraint fk_comp_guarantee
            references guarantee
            on update restrict on delete restrict,
    manufacturercmp integer     not null
        constraint fk_comp_manufacturer
            references manufacturer
            on update cascade on delete restrict,
    pricecmp        numeric(12, 2),
    count           integer default 0
);
INSERT INTO component (typecmp, namecmp, id_guaranteecmp, manufacturercmp,pricecmp) VALUES
('Стекло', 'Универсальное защитное стекло', 1,7,400),
('Экранный модуль', 'Экранный модуль Xemion', 1,3, 2000);
--
create table components_complibility
(
    idcc         serial
        primary key,
    id_component integer
        constraint fk_cc_c
            references component
            on update cascade,
    id_phmodel   integer
        constraint fk_cc_p
            references phone_model
            on update cascade
);

create table list_sirvices
(
    id             serial
        primary key,
    namesrv        varchar(55),
    typesrv        varchar(25),
    descriptionsrv text,
    costsrv        numeric(12, 2),
    timesrv        text
);
insert into list_sirvices (namesrv, typesrv,  descriptionsrv, costsrv, timesrv) values
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
create table orders
(
    id_order        serial
        primary key,
    dateord         timestamp,
    phonenumber     varchar(11),
    address         varchar(255),
    id_client       integer
        constraint fk_ord_client
            references client,
    id_master       integer,
    id_phone        integer
        constraint fk_ord_phonee
            references phone,
    id_order_status varchar(10)
        constraint fk_ord_ordstat
            references order_status
            on update cascade on delete restrict,
    descriptionord  text,
    comments        text,
    priceord        numeric(12, 2) default 0,
    agreement       boolean        default false
);
insert into orders (dateord, phonenumber, address, id_client, id_phone, id_order_status, descriptionord, comments) values -- ЗАКАЗЫ
(current_date, '89591233331', 'Ул. Московская 36', 1, 3,'received_0', 'Помята задня крышка', ''),
(current_date, '89491233332', 'Ул. Московская 36', 2, 4,'received_0', 'Нужна установка защитного стекла', 'Стекло для этого телефона очень редкое, посмотреть на универсальные'),
(current_date, '89391233333', 'Ул. Московская 36', 3, 2,'received_0', 'Не держит заряд батареи', ''),
(current_date, '89291233334', 'Ул. Московская 36', 4, 2,'received_0', 'Зависает на холоде', ''),
(current_date, '89191233335', 'Ул. Московская 36', 5, 4,'received_0', 'Не работает зарядка', 'Менять разъем micro-usb');

/*
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
*/
CREATE TABLE story_order_move( --
idmove      	                SERIAL PRIMARY KEY,
idorder                         int,
idhuman                         int,
idoldstatus                     VARCHAR(10),
idnewstatus                     VARCHAR(10),
idoldaddress                    int,
idnewaddress                    int,
somdate      timestamp default CURRENT_TIMESTAMP,
CONSTRAINT  fk_som_order   FOREIGN KEY (idorder) REFERENCES orders (id_order) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT  fk_som_human   FOREIGN KEY (idhuman) REFERENCES employee (id) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT  fk_som_oldstatus   FOREIGN KEY (idoldstatus) REFERENCES order_status (idos) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT  fk_som_newstatus   FOREIGN KEY (idnewstatus) REFERENCES order_status (idos) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT  fk_som_oldaddress  FOREIGN KEY (idoldaddress) REFERENCES list_workshops (id) ON DELETE NO ACTION ON UPDATE CASCADE,
CONSTRAINT  fk_som_newaddress  FOREIGN KEY (idnewaddress) REFERENCES list_workshops (id) ON DELETE NO ACTION ON UPDATE CASCADE
);

create table on_order_cmp
(
    id_cmp_onord     serial
        primary key,
    id_order_forcomp integer
        constraint fk_cmponorder_order
            references orders
            on update cascade,
    id_cmp_onlist    integer
        constraint fk_cmponorder_component
            references component
            on update cascade
);

create table on_order_srv
(
    id_srv_onord        serial
        primary key,
    id_order_forservice integer
        constraint fk_cmponorder_order
            references orders
            on update cascade,
    id_srv_onlist       integer
        constraint fk_cmponorder_component
            references list_sirvices
            on update cascade
);

