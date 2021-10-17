-- Одному продукту может соотвествовать много категорий, в одной категории может быть много продуктов
-- Запрос для выбора всех пар "Имя продукта - Имя категории"
-- Если у продукта нет категорий, то его имя все равно должно выводиться

CREATE TABLE Product (
     Id uniqueidentifier NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
     Name varchar(100) NOT NULL
);

INSERT INTO Product (Id, Name)
VALUES ('382f23c2-e553-48df-8c82-6b1ca5b0d99b', 'Ball'),
       ('3ea009fc-2d35-47a5-9703-1513e5f7d542', 'TV'),
       ('0367b502-a83d-421a-a145-a36e73a21d06', 'Car');

CREATE TABLE Category (
      Id uniqueidentifier NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
      Name varchar(100) NOT NULL
);

INSERT INTO Category (Id, Name)
VALUES ('5246b085-814e-4166-9f1a-b437ecd5712d', 'Sport'),
       ('513abc6b-bffb-4d63-a646-f05c07f7b97c', 'House'),
       ('28de7bd3-f1b8-4339-b442-13a5a3f41a00', 'Electronic');

CREATE TABLE ProductCategory (
     ProductId uniqueidentifier NOT NULL,
     CategoryId uniqueidentifier NOT NULL,
     PRIMARY KEY (ProductId, CategoryId),
     CONSTRAINT FK_ProductCategory_Category FOREIGN KEY (CategoryId)
         REFERENCES Category (Id),
     CONSTRAINT FK_ProductCategory_Product FOREIGN KEY (ProductId)
         REFERENCES Product (Id)
);

INSERT INTO ProductCategory (ProductId, CategoryId)
VALUES ('382f23c2-e553-48df-8c82-6b1ca5b0d99b', '5246b085-814e-4166-9f1a-b437ecd5712d'),
       ('3ea009fc-2d35-47a5-9703-1513e5f7d542', '28de7bd3-f1b8-4339-b442-13a5a3f41a00'),
       ('382f23c2-e553-48df-8c82-6b1ca5b0d99b', '513abc6b-bffb-4d63-a646-f05c07f7b97c');

SELECT p.Name as ProductName, c.Name as CategoryName
FROM Product p
LEFT JOIN ProductCategory pc on p.Id = pc.ProductId
LEFT JOIN Category c on c.Id = pc.CategoryId
