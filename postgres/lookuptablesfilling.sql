INSERT INTO carbrand VALUES
('Lada'),
('Москвич');
INSERT INTO carmodels (brand, model) VALUES
('Lada', 'модель1'),
('Lada', 'модель2'),
('Москвич', 'модель2');
INSERT INTO colors VALUES
('Белый'),
('Красный');
INSERT INTO carstates VALUES
('Эконом', 1.05),
('Комфорт', 1.5),
('Бизнес', 3),
('Минивен', 2);
INSERT INTO orderstates VALUES
('Создан'),
('Отменен'),
('Завершен');
INSERT INTO tickettypes VALUES
('Регистрация машины'),
('Жалоба'),
('Забытая вещь');
INSERT INTO customers VALUES
('a1@yopmail.com', 'Иванов', 'Иван', 'Иванович', 'Москва, ул. Покровка, д. 11', 9991234567, 1111222233334444, 'random', '7815696ecbf1c96e6894b779456d330e');
INSERT INTO drivers VALUES
('a2@yopmail.com', 'Петров', 'Петр', 'Петрович', 9997654321, 2222333344445555, 'a', 'f5b3b9b303f5a0594272f99d191bbf45');
INSERT INTO cars (model, color, carnumber, carstate, carowner) VALUES
(1, 'Красный', 'o123yy799', 'Хорошая', 'a2@yopmail.com');
INSERT INTO suppportworkers VALUES
('a3@yopmail.com', 'Сидоров', 'Петр', 'Иванович', 9997775533, 3333444455556666, 'и', 'b73b539ec2605ba03381d9c77fdaf249');
INSERT INTO orders (sourcelat, sourcelng, destlat, destlng, price, pathlength, starttime, finishtime, customer, driver, orderstatus) VALUES
(40.6892494, 74.0445004, 74.0445004, 40.6892494, 500, 2.8, '1999-01-08 04:05:06', '2023-10-19 04:05:06', 'a1@yopmail.com', 'a2@yopmail.com', 'Завершен');
INSERT INTO suppporttickets (comment, tickettype, responsible, ticketorder)
VALUES ('ААААб все сломалось, помогите', 'Жалоба', 'a3@yopmail.com', 1);
