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
DROP TABLE IF EXISTS `users`;
DROP TABLE IF EXISTS `logs`;
DROP TABLE IF EXISTS `logTypes`;

/*####################################################
			## Create Tables ##
####################################################*/

CREATE TABLE `categories` (
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

CREATE TABLE `users` 
( 
`id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY, 
`username` VARCHAR(255) NOT NULL , 
`password` VARCHAR(255) NOT NULL
) ;

CREATE TABLE `userinformation`
(
`id` INT NOT NULL PRIMARY KEY,
`firstName` VARCHAR(20),
`lastName` VARCHAR(20),
`email` VARCHAR(255),
`address` VARCHAR(255),
`zipcode` VARCHAR(255),
`City` VARCHAR(255),
`Phone` VARCHAR(255),
FOREIGN KEY (id) REFERENCES users (id) ON DELETE CASCADE
);

CREATE TABLE `products` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL,
  `description` TEXT NOT NULL,
  `price` DECIMAL NOT NULL,
  `quantity` INT NOT NULL,
  `photoUrl` VARCHAR(255),
  `categoryId` INT,
  `subcategoryId` INT,
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




