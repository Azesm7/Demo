CREATE TABLE `user` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `login` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL,
  `fio` varchar(50) NOT NULL,
  `post` varchar(20) NOT NULL,
  `data` TIMESTAMP
);

CREATE TABLE `projects` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `id_user_admin` int NOT NULL,
  `name` varchar(60) NOT NULL,
  `data` TIMESTAMP,
  `status` bool
);

CREATE TABLE `cipher_project` (
  `id_project` int NOT NULL,
  `id_country` int NOT NULL,
  `developer_code` varchar(20),
  `code_classifier` varchar(20),
  `Editorial_number` varchar(20)
);

CREATE TABLE `Officials` (
  `id_project` int NOT NULL,
  `id_chief_engineer` int NOT NULL,
  `id_control` int NOT NULL
);

CREATE TABLE `country` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(30),
  `country_code` varchar(10)
);

CREATE TABLE `Information_organization` (
  `full_name` varchar(50),
  `abbreviated_name` varchar(30),
  `inn` int NOT NULL,
  `kpp` varchar(30),
  `ogrn` int NOT NULL,
  `address` varchar(30),
  `city` varchar(30),
  `okpno` int NOT NULL,
  `id_country` int NOT NULL,
  `post_manager` varchar(30),
  `fio_manager` varchar(50)
);

CREATE TABLE `tip` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(50)
);

CREATE TABLE `status` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `id_fail` int NOT NULL,
  `status` varchar(50)
);

CREATE TABLE `files` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `id_project` int NOT NULL,
  `name` varchar(50) NOT NULL,
  `datatime` TIMESTAMP,
  `id_tip` int NOT NULL,
  `text` text
);

ALTER TABLE `projects` ADD FOREIGN KEY (`id_user_admin`) REFERENCES `user` (`id`);

ALTER TABLE `files` ADD FOREIGN KEY (`id_project`) REFERENCES `projects` (`id`);

ALTER TABLE `cipher_project` ADD FOREIGN KEY (`id_project`) REFERENCES `projects` (`id`);

ALTER TABLE `Officials` ADD FOREIGN KEY (`id_project`) REFERENCES `projects` (`id`);

ALTER TABLE `files` ADD FOREIGN KEY (`id_tip`) REFERENCES `tip` (`id`);

ALTER TABLE `Information_organization` ADD FOREIGN KEY (`id_country`) REFERENCES `country` (`id`);

ALTER TABLE `cipher_project` ADD FOREIGN KEY (`id_country`) REFERENCES `country` (`id`);

ALTER TABLE `status` ADD FOREIGN KEY (`id_fail`) REFERENCES `files` (`id`);
