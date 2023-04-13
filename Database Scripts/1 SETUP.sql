USE sys;
DROP DATABASE IF EXISTS elgrosdb;
CREATE DATABASE elgrosdb;
USE elgrosdb;

/*####################################################
			## Drop Tables ##
####################################################*/
DROP TABLE IF EXISTS `products`;
DROP TABLE IF EXISTS `categories`;
DROP TABLE IF EXISTS `subCategories`;
DROP TABLE IF EXISTS `logs`;
DROP TABLE IF EXISTS `logTypes`;

/*####################################################
			## Create Tables ##
####################################################*/

CREATE TABLE IF NOT EXISTS `categories` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `subCategories` ( 
`id` INT NOT NULL AUTO_INCREMENT, 
`name` VARCHAR(255) NOT NULL,
`categoryId` int NOT NULL,
PRIMARY KEY (id),
FOREIGN KEY (categoryId) REFERENCES categories (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE IF NOT EXISTS `products` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL,
  `description` TEXT NOT NULL,
  `price` DECIMAL NOT NULL,
  `quantity` INT NOT NULL,
  `categoryId` INT NOT NULL,
  `subcategoryId` INT NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (categoryId) REFERENCES categories (id),
  FOREIGN KEY (subcategoryId) REFERENCES subCategories (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `log` 
( 
`id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY, 
`type` INT NOT NULL , 
`description` VARCHAR(255) NOT NULL, 
`timestamp` DATETIME DEFAULT NOW()
);

CREATE TABLE `logTypes` 
( 
`id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY, 
`errorCodes` VARCHAR(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL
) ;

/*####################################################
			## Alter Tables ##
####################################################*/

ALTER TABLE `log` ADD FOREIGN KEY (`type`) REFERENCES `logTypes`(`id`) ON DELETE RESTRICT ON UPDATE RESTRICT; 




