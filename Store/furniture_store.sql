-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Хост: localhost:3306
-- Время создания: Окт 27 2026 г., 13:04
-- Версия сервера: 8.4.5
-- Версия PHP: 8.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `furniture_store`
--

-- --------------------------------------------------------

--
-- Структура таблицы `color`
--

CREATE TABLE `color` (
  `color_id` int NOT NULL,
  `color` varchar(20) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `color`
--

INSERT INTO `color` (`color_id`, `color`) VALUES
(2, 'Белый'),
(1, 'Бук'),
(3, 'Венге');

-- --------------------------------------------------------

--
-- Структура таблицы `counteragent`
--

CREATE TABLE `counteragent` (
  `counteragent_id` int NOT NULL,
  `ownership_id` int NOT NULL,
  `person_id` int NOT NULL,
  `name` varchar(150) COLLATE utf8mb4_general_ci NOT NULL,
  `address` varchar(200) COLLATE utf8mb4_general_ci NOT NULL,
  `ITN` varchar(12) COLLATE utf8mb4_general_ci NOT NULL,
  `phone` varchar(15) COLLATE utf8mb4_general_ci NOT NULL
) ;

--
-- Дамп данных таблицы `counteragent`
--

INSERT INTO `counteragent` (`counteragent_id`, `ownership_id`, `person_id`, `name`, `address`, `ITN`, `phone`) VALUES
(1, 2, 2, 'Ромашка', ';dfkh\'ojhg;ldijh', '1234567894', '77555979625'),
(2, 1, 3, 'Сатурн', 'Энгельс, Строителей 41', '1234567891', '77123456789'),
(3, 1, 3, 'Колос', 'Саратов, Танкистов 37', '123456789123', '77123456789'),
(4, 1, 4, 'Кузнечик', 'мчбмьтдчдльтдэ', '1212121212', '79959690700'),
(5, 1, 3, 'Колокольчик', 'чмсттчптчмтичт', '3232323232', '77777777777'),
(6, 3, 6, 'Семенова Ирина Ивановна', 'нет', '000000000000', '77126881736');

-- --------------------------------------------------------

--
-- Структура таблицы `delivery`
--

CREATE TABLE `delivery` (
  `delivery_id` int NOT NULL,
  `saleProducts_id` int NOT NULL,
  `address` varchar(200) COLLATE utf8mb4_general_ci NOT NULL,
  `phone` varchar(15) COLLATE utf8mb4_general_ci NOT NULL
) ;

--
-- Дамп данных таблицы `delivery`
--

INSERT INTO `delivery` (`delivery_id`, `saleProducts_id`, `address`, `phone`) VALUES
(6, 38, 'tsfghzfhfjhxz', '77777777777'),
(7, 39, '/s/kmbm\'sljhsl\';', '77777777777'),
(8, 40, 'аплдрыждщ', '77777777777'),
(9, 41, 'fsl;zbjs;kjg', '75555555555'),
(10, 42, 'vvxbjkns;gjs;fjgap;', '76666666666'),
(11, 43, 'Далеко', '71111111111');

-- --------------------------------------------------------

--
-- Структура таблицы `element`
--

CREATE TABLE `element` (
  `element_id` int NOT NULL,
  `element` varchar(15) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `element`
--

INSERT INTO `element` (`element_id`, `element`) VALUES
(1, 'Корпус'),
(4, 'Столешница'),
(2, 'Фасад');

-- --------------------------------------------------------

--
-- Структура таблицы `employe`
--

CREATE TABLE `employe` (
  `employe_id` int NOT NULL,
  `person_id` int NOT NULL,
  `position_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `employe`
--

INSERT INTO `employe` (`employe_id`, `person_id`, `position_id`) VALUES
(2, 1, 1),
(1, 3, 4);

-- --------------------------------------------------------

--
-- Структура таблицы `material`
--

CREATE TABLE `material` (
  `material_id` int NOT NULL,
  `material` varchar(50) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `material`
--

INSERT INTO `material` (`material_id`, `material`) VALUES
(9, 'губ'),
(7, 'ЛДСП'),
(8, 'МДФ');

-- --------------------------------------------------------

--
-- Структура таблицы `ownership`
--

CREATE TABLE `ownership` (
  `ownership_id` int NOT NULL,
  `ownership` varchar(150) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `ownership`
--

INSERT INTO `ownership` (`ownership_id`, `ownership`) VALUES
(1, 'Общество с ограниченной ответственностью OOO'),
(2, 'Открытое акционерное общество'),
(3, 'Частное лицо');

-- --------------------------------------------------------

--
-- Структура таблицы `person`
--

CREATE TABLE `person` (
  `person_id` int NOT NULL,
  `name` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `secondname` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `surname` varchar(50) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `person`
--

INSERT INTO `person` (`person_id`, `name`, `secondname`, `surname`) VALUES
(1, 'Иван', 'Иванович', 'Иванов'),
(2, 'Светлана', 'Ильинична', 'Петрова'),
(3, 'Игорь', 'Викторович', 'Черепанов'),
(4, 'Галина', 'Ильинична', 'Петрова'),
(5, 'Технический', NULL, 'пользователь'),
(6, 'Ирина', 'Ивановна', 'Семенова');

-- --------------------------------------------------------

--
-- Структура таблицы `position`
--

CREATE TABLE `position` (
  `position_id` int NOT NULL,
  `position` varchar(20) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `position`
--

INSERT INTO `position` (`position_id`, `position`) VALUES
(1, 'Директор'),
(4, 'Менеджер по закупкам'),
(3, 'Менеджер по продажам');

-- --------------------------------------------------------

--
-- Структура таблицы `product`
--

CREATE TABLE `product` (
  `product_id` int NOT NULL,
  `color_id` int NOT NULL,
  `product` varchar(150) COLLATE utf8mb4_general_ci NOT NULL,
  `length` int NOT NULL,
  `width` int NOT NULL,
  `height` int NOT NULL
) ;

--
-- Дамп данных таблицы `product`
--

INSERT INTO `product` (`product_id`, `color_id`, `product`, `length`, `width`, `height`) VALUES
(4, 1, 'Шкаф книжный', 800, 400, 2200),
(2, 2, 'Кровать', 200, 160, 70),
(5, 2, 'Стол компьютерный', 800, 600, 750),
(3, 3, 'Комод', 100, 400, 1000),
(1, 3, 'Шкаф платяной распашной', 120, 50, 210);

-- --------------------------------------------------------

--
-- Дублирующая структура для представления `product_balance`
-- (См. Ниже фактическое представление)
--
CREATE TABLE `product_balance` (
`supProdTable_id` int
,`product_id` int
,`product` varchar(150)
,`total_incoming` decimal(32,0)
,`total_sold` decimal(32,0)
,`current_balance` decimal(33,0)
);

-- --------------------------------------------------------

--
-- Структура таблицы `product_material`
--

CREATE TABLE `product_material` (
  `product_material_id` int NOT NULL,
  `product_id` int NOT NULL,
  `material_id` int NOT NULL,
  `element_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `product_material`
--

INSERT INTO `product_material` (`product_material_id`, `product_id`, `material_id`, `element_id`) VALUES
(5, 1, 8, 1),
(1, 1, 9, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `saleprodtable`
--

CREATE TABLE `saleprodtable` (
  `saleProdTable_id` int NOT NULL,
  `saleProducts_id` int NOT NULL,
  `supProdTable_id` int NOT NULL,
  `quantity` int NOT NULL
) ;

--
-- Дамп данных таблицы `saleprodtable`
--

INSERT INTO `saleprodtable` (`saleProdTable_id`, `saleProducts_id`, `supProdTable_id`, `quantity`) VALUES
(3, 41, 5, 2),
(4, 41, 4, 1),
(5, 42, 11, 1),
(6, 42, 4, 2),
(7, 43, 11, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `saleproducts`
--

CREATE TABLE `saleproducts` (
  `saleProducts_id` int NOT NULL,
  `date` date NOT NULL DEFAULT (curdate()),
  `counteragent_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `saleproducts`
--

INSERT INTO `saleproducts` (`saleProducts_id`, `date`, `counteragent_id`) VALUES
(37, '2026-03-20', 1),
(38, '2026-03-20', 1),
(39, '2026-03-20', 1),
(40, '2026-03-20', 1),
(41, '2026-03-20', 1),
(42, '2026-03-23', 1),
(43, '2026-05-14', 6);

-- --------------------------------------------------------

--
-- Структура таблицы `saleservice`
--

CREATE TABLE `saleservice` (
  `saleService_id` int NOT NULL,
  `saleProducts_id` int NOT NULL,
  `services_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `saleservice`
--

INSERT INTO `saleservice` (`saleService_id`, `saleProducts_id`, `services_id`) VALUES
(12, 42, 1),
(13, 42, 6),
(14, 43, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `services`
--

CREATE TABLE `services` (
  `services_id` int NOT NULL,
  `services` varchar(150) COLLATE utf8mb4_general_ci NOT NULL,
  `price` decimal(15,2) NOT NULL
) ;

--
-- Дамп данных таблицы `services`
--

INSERT INTO `services` (`services_id`, `services`, `price`) VALUES
(1, 'Доставка', '10.00'),
(6, 'Сборка', '15.00');

-- --------------------------------------------------------

--
-- Структура таблицы `supplierproducts`
--

CREATE TABLE `supplierproducts` (
  `supplierProducts_id` int NOT NULL,
  `counteragent_id` int NOT NULL,
  `inpNum` varchar(15) COLLATE utf8mb4_general_ci NOT NULL,
  `inpDate` date NOT NULL DEFAULT (curdate()),
  `date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `supplierproducts`
--

INSERT INTO `supplierproducts` (`supplierProducts_id`, `counteragent_id`, `inpNum`, `inpDate`, `date`) VALUES
(2, 1, '4', '2026-03-03', '2026-03-04'),
(3, 2, '1', '2026-03-05', '2026-03-05'),
(4, 1, '11', '2026-03-05', '2026-03-05'),
(5, 1, '7', '2026-03-05', '2026-03-05'),
(6, 1, '3', '2026-03-05', '2026-03-05'),
(8, 2, '5', '2026-03-05', '2026-03-05'),
(10, 2, '7', '2026-03-05', '2026-03-05'),
(11, 1, '51', '2026-03-05', '2026-03-05'),
(15, 1, '6', '2026-03-11', '2026-03-11'),
(16, 2, '12', '2026-03-11', '2026-03-11'),
(18, 1, '12', '2026-03-11', '2026-03-11'),
(24, 1, '44', '2026-03-11', '2026-03-11'),
(27, 2, '66', '2026-03-16', '2026-03-16');

-- --------------------------------------------------------

--
-- Структура таблицы `supprodtable`
--

CREATE TABLE `supprodtable` (
  `supProdTable_id` int NOT NULL,
  `supplierProducts_id` int NOT NULL,
  `product_id` int NOT NULL,
  `quantity` int NOT NULL,
  `price` decimal(15,2) NOT NULL
) ;

--
-- Дамп данных таблицы `supprodtable`
--

INSERT INTO `supprodtable` (`supProdTable_id`, `supplierProducts_id`, `product_id`, `quantity`, `price`) VALUES
(1, 10, 3, 4, '46.00'),
(3, 11, 3, 4, '2.00'),
(4, 11, 1, 5, '12.00'),
(5, 11, 2, 2, '14.00'),
(6, 11, 4, 3, '45.00'),
(9, 15, 4, 4, '78.00'),
(10, 15, 1, 1, '74.00'),
(11, 16, 2, 2, '63.00'),
(12, 16, 4, 98, '4.00'),
(13, 18, 3, 4, '2.00'),
(15, 18, 4, 3, '45.00'),
(16, 18, 2, 2, '14.00'),
(19, 24, 3, 4, '2.00'),
(21, 24, 4, 3, '45.00'),
(22, 27, 3, 4, '2.00'),
(23, 27, 4, 3, '45.00');

-- --------------------------------------------------------

--
-- Структура таблицы `trademargintable`
--

CREATE TABLE `trademargintable` (
  `trademargintable_id` int NOT NULL,
  `product_id` int NOT NULL,
  `percent` int NOT NULL,
  `status` tinyint(1) DEFAULT NULL,
  `date` date NOT NULL DEFAULT (curdate())
) ;

--
-- Дамп данных таблицы `trademargintable`
--

INSERT INTO `trademargintable` (`trademargintable_id`, `product_id`, `percent`, `status`, `date`) VALUES
(7, 1, 5, 0, '2026-02-12'),
(4, 1, 11, 0, '2026-02-12'),
(3, 1, 12, 0, '2026-02-12'),
(1, 1, 13, 0, '2025-12-18'),
(12, 1, 15, 1, '2026-03-23'),
(10, 1, 55, 0, '2026-02-13'),
(11, 1, 56, 0, '2026-02-13'),
(5, 2, 10, 0, '2026-02-12'),
(2, 2, 12, 0, '2026-02-12'),
(13, 2, 14, 1, '2026-03-23'),
(9, 2, 55, 0, '2026-02-13'),
(8, 2, 85, 0, '2026-02-12'),
(6, 2, 125, 0, '2026-02-12');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `users_id` int NOT NULL,
  `login` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`users_id`, `login`, `password`) VALUES
(1, 'i.ivanov', 'AQAAAAIAAYagAAAAENR6T/wo3mVI7/ayvaX9+XF3mdokE5RMUdqH0fH4hTAH5+59HdAF3pIPYkU4+eyQPw=='),
(2, 's.petrova', 'AQAAAAIAAYagAAAAENgUzyLWRpd8A4hjXqALiD2bsTCS3L1LBm3ajSUyAZWujHbz5xdh1WcUsjl3GBIYjQ=='),
(3, 'cherrypy', 'AQAAAAIAAYagAAAAEJEn68Clo2Nper1wh8AqGWE30JEcnI0pIZgz3jTBk4ho96gvyE+k2v8UdB+Z0NZ7kQ=='),
(4, 'g.petrova', 'AQAAAAIAAYagAAAAENZKi77lI6QznJzG3/n4CPB7gfACFF36vwL8Yuts5uDs3HGrNXV/yCQmXokgVYVVaA=='),
(5, 'Admin', 'AQAAAAIAAYagAAAAEBu9auC5VyZ7Di8gIp2iKIfMvgDLqUz8RIyJ8W3Mxn7UbfZOKDOHEb92a70tRdnmpQ=='),
(6, 'i.semenova', 'AQAAAAIAAYagAAAAEHuvON3LUGY2mk2EXYA5Y0+DtyDRzgtdmknsDJ8skTihq7PKWm9FPZGZ4hkM4E54/Q==');

-- --------------------------------------------------------

--
-- Структура для представления `product_balance`
--
DROP TABLE IF EXISTS `product_balance`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `product_balance`  AS SELECT `sup`.`supProdTable_id` AS `supProdTable_id`, `p`.`product_id` AS `product_id`, `p`.`product` AS `product`, coalesce(sum(`sup`.`quantity`),0) AS `total_incoming`, coalesce(sum(`spt`.`quantity`),0) AS `total_sold`, (coalesce(sum(`sup`.`quantity`),0) - coalesce(sum(`spt`.`quantity`),0)) AS `current_balance` FROM ((`product` `p` left join `supprodtable` `sup` on((`p`.`product_id` = `sup`.`product_id`))) left join `saleprodtable` `spt` on((`sup`.`supProdTable_id` = `spt`.`supProdTable_id`))) GROUP BY `sup`.`supProdTable_id`, `p`.`product_id`, `p`.`product``product`  ;

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `color`
--
ALTER TABLE `color`
  ADD PRIMARY KEY (`color_id`),
  ADD UNIQUE KEY `color` (`color`);

--
-- Индексы таблицы `counteragent`
--
ALTER TABLE `counteragent`
  ADD PRIMARY KEY (`counteragent_id`),
  ADD UNIQUE KEY `ITN` (`ITN`),
  ADD KEY `person_id` (`person_id`),
  ADD KEY `ownership_id` (`ownership_id`);

--
-- Индексы таблицы `delivery`
--
ALTER TABLE `delivery`
  ADD PRIMARY KEY (`delivery_id`),
  ADD UNIQUE KEY `saleProducts_id` (`saleProducts_id`);

--
-- Индексы таблицы `element`
--
ALTER TABLE `element`
  ADD PRIMARY KEY (`element_id`),
  ADD UNIQUE KEY `element` (`element`);

--
-- Индексы таблицы `employe`
--
ALTER TABLE `employe`
  ADD PRIMARY KEY (`employe_id`),
  ADD UNIQUE KEY `unique_person_position` (`person_id`,`position_id`),
  ADD KEY `position_id` (`position_id`);

--
-- Индексы таблицы `material`
--
ALTER TABLE `material`
  ADD PRIMARY KEY (`material_id`),
  ADD UNIQUE KEY `material` (`material`);

--
-- Индексы таблицы `ownership`
--
ALTER TABLE `ownership`
  ADD PRIMARY KEY (`ownership_id`),
  ADD UNIQUE KEY `ownership` (`ownership`);

--
-- Индексы таблицы `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`person_id`);

--
-- Индексы таблицы `position`
--
ALTER TABLE `position`
  ADD PRIMARY KEY (`position_id`),
  ADD UNIQUE KEY `position` (`position`);

--
-- Индексы таблицы `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`product_id`),
  ADD UNIQUE KEY `color_id` (`color_id`,`product`,`length`,`width`,`height`);

--
-- Индексы таблицы `product_material`
--
ALTER TABLE `product_material`
  ADD PRIMARY KEY (`product_material_id`),
  ADD UNIQUE KEY `product_id` (`product_id`,`material_id`,`element_id`),
  ADD KEY `material_id` (`material_id`),
  ADD KEY `element_id` (`element_id`);

--
-- Индексы таблицы `saleprodtable`
--
ALTER TABLE `saleprodtable`
  ADD PRIMARY KEY (`saleProdTable_id`),
  ADD KEY `saleProducts_id` (`saleProducts_id`),
  ADD KEY `supProdTable_id` (`supProdTable_id`);

--
-- Индексы таблицы `saleproducts`
--
ALTER TABLE `saleproducts`
  ADD PRIMARY KEY (`saleProducts_id`),
  ADD KEY `counteragent_id` (`counteragent_id`);

--
-- Индексы таблицы `saleservice`
--
ALTER TABLE `saleservice`
  ADD PRIMARY KEY (`saleService_id`),
  ADD UNIQUE KEY `saleProducts_id` (`saleProducts_id`,`services_id`),
  ADD KEY `services_id` (`services_id`);

--
-- Индексы таблицы `services`
--
ALTER TABLE `services`
  ADD PRIMARY KEY (`services_id`),
  ADD UNIQUE KEY `services` (`services`);

--
-- Индексы таблицы `supplierproducts`
--
ALTER TABLE `supplierproducts`
  ADD PRIMARY KEY (`supplierProducts_id`),
  ADD UNIQUE KEY `counteragent_id` (`counteragent_id`,`inpNum`);

--
-- Индексы таблицы `supprodtable`
--
ALTER TABLE `supprodtable`
  ADD PRIMARY KEY (`supProdTable_id`),
  ADD UNIQUE KEY `supplierProducts_id` (`supplierProducts_id`,`product_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Индексы таблицы `trademargintable`
--
ALTER TABLE `trademargintable`
  ADD PRIMARY KEY (`trademargintable_id`),
  ADD UNIQUE KEY `product_id` (`product_id`,`percent`,`status`,`date`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`users_id`),
  ADD UNIQUE KEY `login` (`login`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `color`
--
ALTER TABLE `color`
  MODIFY `color_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `counteragent`
--
ALTER TABLE `counteragent`
  MODIFY `counteragent_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `delivery`
--
ALTER TABLE `delivery`
  MODIFY `delivery_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `element`
--
ALTER TABLE `element`
  MODIFY `element_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `employe`
--
ALTER TABLE `employe`
  MODIFY `employe_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `material`
--
ALTER TABLE `material`
  MODIFY `material_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT для таблицы `ownership`
--
ALTER TABLE `ownership`
  MODIFY `ownership_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `person`
--
ALTER TABLE `person`
  MODIFY `person_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `position`
--
ALTER TABLE `position`
  MODIFY `position_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT для таблицы `product`
--
ALTER TABLE `product`
  MODIFY `product_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `product_material`
--
ALTER TABLE `product_material`
  MODIFY `product_material_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `saleprodtable`
--
ALTER TABLE `saleprodtable`
  MODIFY `saleProdTable_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `saleproducts`
--
ALTER TABLE `saleproducts`
  MODIFY `saleProducts_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT для таблицы `saleservice`
--
ALTER TABLE `saleservice`
  MODIFY `saleService_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT для таблицы `services`
--
ALTER TABLE `services`
  MODIFY `services_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `supplierproducts`
--
ALTER TABLE `supplierproducts`
  MODIFY `supplierProducts_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT для таблицы `supprodtable`
--
ALTER TABLE `supprodtable`
  MODIFY `supProdTable_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `trademargintable`
--
ALTER TABLE `trademargintable`
  MODIFY `trademargintable_id` int NOT NULL AUTO_INCREMENT;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `counteragent`
--
ALTER TABLE `counteragent`
  ADD CONSTRAINT `counteragent_ibfk_1` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`) ON DELETE RESTRICT,
  ADD CONSTRAINT `counteragent_ibfk_2` FOREIGN KEY (`ownership_id`) REFERENCES `ownership` (`ownership_id`) ON DELETE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `delivery`
--
ALTER TABLE `delivery`
  ADD CONSTRAINT `delivery_ibfk_1` FOREIGN KEY (`saleProducts_id`) REFERENCES `saleproducts` (`saleProducts_id`) ON DELETE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `employe`
--
ALTER TABLE `employe`
  ADD CONSTRAINT `employe_ibfk_1` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`) ON DELETE RESTRICT,
  ADD CONSTRAINT `employe_ibfk_2` FOREIGN KEY (`position_id`) REFERENCES `position` (`position_id`) ON DELETE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `product_ibfk_1` FOREIGN KEY (`color_id`) REFERENCES `color` (`color_id`) ON DELETE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `product_material`
--
ALTER TABLE `product_material`
  ADD CONSTRAINT `product_material_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `product` (`product_id`) ON DELETE RESTRICT,
  ADD CONSTRAINT `product_material_ibfk_2` FOREIGN KEY (`material_id`) REFERENCES `material` (`material_id`) ON DELETE RESTRICT,
  ADD CONSTRAINT `product_material_ibfk_3` FOREIGN KEY (`element_id`) REFERENCES `element` (`element_id`) ON DELETE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `saleprodtable`
--
ALTER TABLE `saleprodtable`
  ADD CONSTRAINT `saleprodtable_ibfk_1` FOREIGN KEY (`saleProducts_id`) REFERENCES `saleproducts` (`saleProducts_id`) ON DELETE RESTRICT,
  ADD CONSTRAINT `saleprodtable_ibfk_2` FOREIGN KEY (`supProdTable_id`) REFERENCES `supprodtable` (`supProdTable_id`) ON DELETE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `saleproducts`
--
ALTER TABLE `saleproducts`
  ADD CONSTRAINT `saleproducts_ibfk_1` FOREIGN KEY (`counteragent_id`) REFERENCES `counteragent` (`counteragent_id`) ON DELETE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `saleservice`
--
ALTER TABLE `saleservice`
  ADD CONSTRAINT `saleservice_ibfk_1` FOREIGN KEY (`services_id`) REFERENCES `services` (`services_id`) ON DELETE RESTRICT,
  ADD CONSTRAINT `saleservice_ibfk_2` FOREIGN KEY (`saleProducts_id`) REFERENCES `saleproducts` (`saleProducts_id`) ON DELETE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `supplierproducts`
--
ALTER TABLE `supplierproducts`
  ADD CONSTRAINT `supplierproducts_ibfk_1` FOREIGN KEY (`counteragent_id`) REFERENCES `counteragent` (`counteragent_id`) ON DELETE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `supprodtable`
--
ALTER TABLE `supprodtable`
  ADD CONSTRAINT `supprodtable_ibfk_1` FOREIGN KEY (`supplierProducts_id`) REFERENCES `supplierproducts` (`supplierProducts_id`) ON DELETE RESTRICT,
  ADD CONSTRAINT `supprodtable_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `product` (`product_id`) ON DELETE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `trademargintable`
--
ALTER TABLE `trademargintable`
  ADD CONSTRAINT `trademargintable_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `product` (`product_id`) ON DELETE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`users_id`) REFERENCES `person` (`person_id`) ON DELETE RESTRICT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
