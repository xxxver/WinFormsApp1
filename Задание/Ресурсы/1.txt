-- Таблица: Тип_Материала
CREATE TABLE Тип_Материала (
    id SERIAL PRIMARY KEY,
    название_типа VARCHAR(255) NOT NULL,
    процент_потерь DECIMAL(5,2) NOT NULL
);

-- Таблица: Типы_Продукции
CREATE TABLE Типы_Продукции (
    id SERIAL PRIMARY KEY,
    название_типа VARCHAR(255) NOT NULL,
    коэффициент_типа DECIMAL(5,2) NOT NULL
);

-- Таблица: Типы_Цеха
CREATE TABLE Типы_Цеха (
    id SERIAL PRIMARY KEY,
    название_типа VARCHAR(255) NOT NULL
);

-- Таблица: Цех
CREATE TABLE Цех (
    id SERIAL PRIMARY KEY,
    название_цеха VARCHAR(255) NOT NULL,
    id_тип_цеха INT NOT NULL REFERENCES Типы_Цеха(id),
    количество_людей INT NOT NULL
);

-- Таблица: Продукты
CREATE TABLE Продукты (
    id SERIAL PRIMARY KEY,
    id_тип_продукции INT NOT NULL REFERENCES Типы_Продукции(id),
    название_продукта VARCHAR(255) NOT NULL,
    артикул VARCHAR(50) NOT NULL,
    минимальная_стоимость DECIMAL(10,2) NOT NULL,
    id_тип_материала INT NOT NULL REFERENCES Тип_Материала(id)
);

-- Таблица: Цех_Продукция
CREATE TABLE Цех_Продукция (
    id SERIAL PRIMARY KEY,
    продукт_id INT NOT NULL REFERENCES Продукты(id),
    цех_id INT NOT NULL REFERENCES Цех(id),
    время_изготовления_часы DECIMAL(5,2) NOT NULL
);

-- Типы материалов
COPY Тип_Материала(название_типа, процент_потерь)
FROM 'D:/1x/Material_type_import.csv'
WITH (FORMAT csv, HEADER false, DELIMITER ';', ENCODING 'UTF8');

-- Типы продукции
COPY Типы_Продукции(название_типа, коэффициент_типа)
FROM 'D:/1x/Product_type_import.csv'
WITH (FORMAT csv, HEADER false, DELIMITER ';', ENCODING 'UTF8');

-- Типы цехов
COPY Типы_Цеха(название_типа)
FROM 'D:/1x/Workshops_type_import.csv'
WITH (FORMAT csv, HEADER false, DELIMITER ';', ENCODING 'UTF8');

-- Цеха
COPY Цех(название_цеха, id_тип_цеха, количество_людей)
FROM 'D:/1x/Workshops_import.csv'
WITH (FORMAT csv, HEADER false, DELIMITER ';', ENCODING 'UTF8');

COPY Продукты(id_тип_продукции, название_продукта, артикул, минимальная_стоимость, id_тип_материала)
FROM 'D:/1x/Products_import.csv'
WITH (FORMAT csv, HEADER false, DELIMITER ';', ENCODING 'UTF8');

COPY Цех_Продукция(продукт_id, цех_id, время_изготовления_часы)
FROM 'D:/1x/Product_workshops_import.csv'
WITH (FORMAT csv, HEADER false, DELIMITER ';', ENCODING 'UTF8');
