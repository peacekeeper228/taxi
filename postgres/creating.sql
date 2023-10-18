CREATE TABLE IF NOT EXISTS customers  
(
    email CHARACTER VARYING(50) PRIMARY KEY,
    firstname CHARACTER VARYING(50),
    lastname CHARACTER VARYING(50),
    patronymic CHARACTER VARYING(50),
    adress CHARACTER VARYING(200),
    phonenumber NUMERIC(10),
    bankcard NUMERIC(16),
    sault CHARACTER VARYING(10),
    passhash CHARACTER VARYING(32)
);

CREATE TABLE IF NOT EXISTS drivers  
(
    email CHARACTER VARYING(50) PRIMARY KEY,
    firstname CHARACTER VARYING(50),
    lastname CHARACTER VARYING(50),
    patronymic CHARACTER VARYING(50),
    phonenumber NUMERIC(10),
    bankcard NUMERIC(16),
    sault CHARACTER VARYING(10),
    passhash CHARACTER VARYING(32)
);

CREATE TABLE IF NOT EXISTS carbrand  
(
    brand CHARACTER VARYING(10) PRIMARY KEY
);

CREATE TABLE IF NOT EXISTS carmodels  
(
    code SERIAL PRIMARY KEY,
    brand CHARACTER VARYING(10) REFERENCES carbrand(brand),
    model CHARACTER VARYING(20)
);

CREATE TABLE IF NOT EXISTS colors  
(
    color CHARACTER VARYING(50) PRIMARY KEY 
);

CREATE TABLE IF NOT EXISTS carstates  
(
    carstate CHARACTER VARYING(50) PRIMARY KEY,
    feepercent REAL  
);

CREATE TABLE IF NOT EXISTS cars  
(
    code SERIAL PRIMARY KEY,
    model BIGINT REFERENCES carmodels(code),
    color CHARACTER VARYING(50) REFERENCES colors(color),
    carnumber CHARACTER VARYING(9),
    carstate CHARACTER VARYING(50) REFERENCES carstates(carstate),
    carowner CHARACTER VARYING(50) REFERENCES drivers(email)
);

CREATE TABLE IF NOT EXISTS orderstates  
(
    orderstate CHARACTER VARYING(50) PRIMARY KEY  
);

CREATE TABLE IF NOT EXISTS orders  
(
    code SERIAL PRIMARY KEY,
    sourcelat REAL,
    sourcelng REAL,
    destlat REAL,
    destlng REAL,
    price REAL,
    pathlength REAL,
    starttime TIMESTAMP,
    finishtime TIMESTAMP,
    customer CHARACTER VARYING(50) REFERENCES customers(email),
    driver CHARACTER VARYING(50) REFERENCES drivers(email),
    orderstatus CHARACTER VARYING(50) REFERENCES orderstates(orderstate)
);

CREATE TABLE IF NOT EXISTS tickettypes  
(
    tickettype CHARACTER VARYING(30) PRIMARY KEY
);

CREATE TABLE IF NOT EXISTS suppportworkers  
(
    email CHARACTER VARYING(50) PRIMARY KEY,
    firstname CHARACTER VARYING(50),
    lastname CHARACTER VARYING(50),
    patronymic CHARACTER VARYING(50),
    phonenumber NUMERIC(10),
    bankcard NUMERIC(16),
    sault CHARACTER VARYING(10),
    passhash CHARACTER VARYING(32)
);

CREATE TABLE IF NOT EXISTS suppporttickets  
(
    code SERIAL PRIMARY KEY,
    comment CHARACTER VARYING(200),
    tickettype CHARACTER VARYING(10) REFERENCES tickettypes(tickettype), 
    responsible CHARACTER VARYING(50) REFERENCES suppportworkers(email),
    ticketinitiator CHARACTER VARYING(50) REFERENCES drivers(email),
    ticketorder BIGINT REFERENCES orders(code)
);
