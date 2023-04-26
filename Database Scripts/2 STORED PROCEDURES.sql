USE elgrosdb;

/*####################################################
			## Category Section ##
####################################################*/
DROP PROCEDURE IF EXISTS `spCreateCategory`;
DROP PROCEDURE IF EXISTS `spUpdateCategory`;
DROP PROCEDURE IF EXISTS `spDeleteCategory`;
DROP PROCEDURE IF EXISTS `spGetCategoryById`;
DROP PROCEDURE IF EXISTS `spGetCategoryByName`;
DROP PROCEDURE IF EXISTS `spGetAllCategories`;

-- Create operation
DELIMITER //
CREATE PROCEDURE `spCreateCategory` (IN categoryId INT, IN newName VARCHAR(255))
BEGIN
	IF (categoryId IS NOT NULL OR 0)
    THEN
		INSERT INTO categories (id, name) 
		VALUES (categoryId, newName);
	ELSE
		INSERT INTO Categories (name) 
		VALUES (newName);
	END IF;
END //
DELIMITER ;

-- Read operation
DELIMITER //
CREATE PROCEDURE `spGetCategoryById` (IN categoryId INT)
BEGIN
SELECT * FROM Categories WHERE id = categoryId;
END //
DELIMITER ;

-- Read operation 
DELIMITER //
CREATE PROCEDURE `spGetCategoryByName` (IN searchName VARCHAR(255))
BEGIN
	SELECT * FROM categories 
    WHERE name = searchName;
END //
DELIMITER ;

-- Read All operation
DELIMITER //
CREATE PROCEDURE `spGetAllCategories` ()
BEGIN
	SELECT * FROM categories;
END //
DELIMITER ;

-- Update operation
DELIMITER //
CREATE PROCEDURE `spUpdateCategory` (IN categoryId INT, IN newName VARCHAR(255))
BEGIN
	UPDATE categories SET 
    name = newName
    WHERE id = categoryId;
END //
DELIMITER ;

-- Delete operation
DELIMITER //
CREATE PROCEDURE `spDeleteCategory` (IN categoryId INT)
BEGIN
	DELETE FROM categories 
    WHERE id = categoryId;
END //
DELIMITER ;


/*####################################################
			## SubCategory Section ##
####################################################*/
DROP PROCEDURE IF EXISTS `spCreateSubCategory`;
DROP PROCEDURE IF EXISTS `spUpdateSubCategory`;
DROP PROCEDURE IF EXISTS `spDeleteSubCategory`;
DROP PROCEDURE IF EXISTS `spGetSubCategoryById`;
DROP PROCEDURE IF EXISTS `spGetSubCategoriesBycategoryId`;
DROP PROCEDURE IF EXISTS `spGetAllSubCategories`;

-- Create operation
DELIMITER //
CREATE PROCEDURE `spCreateSubCategory` (IN subCategoryId INT, IN newName VARCHAR(255), IN newCategoryId INT)
BEGIN
	IF(subCategoryId IS NOT NULL OR 0)
    THEN
		INSERT INTO subCategories (id, name, categoryId) 
		VALUES (subCategoryId, newName, newCategoryId);
	ELSE
		INSERT INTO subCategories (name, categoryId) 
		VALUES (newName, newCategoryId);
	END IF;
END //
DELIMITER ;

-- Read operation
DELIMITER //
CREATE PROCEDURE `spGetSubCategoryById` (IN subCategoryId INT)
BEGIN
	SELECT * FROM subCategories 
    WHERE id = subCategoryId;
END //
DELIMITER ;

-- Read operation
DELIMITER //
CREATE PROCEDURE `spGetSubCategoriesBycategoryId` (IN searchCategoryId INT)
BEGIN
	SELECT * FROM subCategories 
	WHERE categoryId = searchCategoryId;
END //
DELIMITER ;

-- Read All operation
DELIMITER //
CREATE PROCEDURE `spGetAllSubCategories` ()
BEGIN
	SELECT * FROM subCategories;
END //
DELIMITER ;

-- Update operation
DELIMITER //
CREATE PROCEDURE `spUpdateSubCategory` (IN subCategoryId INT, IN newName VARCHAR(255), IN newCategoryId INT)
BEGIN
	UPDATE subCategories SET 
		`name` = newName, 
		`categoryId` = newCategoryId
		WHERE id = subCategoryId;
END //
DELIMITER ;

-- Delete operation
DELIMITER //
CREATE PROCEDURE `spDeleteSubCategory` (IN subCategoryId INT)
BEGIN
	DELETE FROM subCategories 
    WHERE id = subCategoryId;
END //
DELIMITER ;


/*####################################################
			## Products Section ##
####################################################*/
DROP PROCEDURE IF EXISTS `spCreateProduct`;
DROP PROCEDURE IF EXISTS `spUpdateProduct`;
DROP PROCEDURE IF EXISTS `spDeleteProduct`;
DROP PROCEDURE IF EXISTS `spGetProductById`;
DROP PROCEDURE IF EXISTS `spGetProductByName`;
DROP PROCEDURE IF EXISTS `spGetAllProducts`;

-- Create operation
DELIMITER //
CREATE PROCEDURE `spCreateProduct` (IN productId INT, IN newName VARCHAR(255), IN newDescription VARCHAR(255), IN newPrice INT, IN newQuantity INT, IN newPhotoUrl VARCHAR(255), IN newCategoryId INT, IN newSubCategoryId INT)
BEGIN
	IF(productId IS NOT NULL OR 0) 
    THEN
		INSERT INTO products (id, name, description, price, quantity, photoUrl, categoryId, subCategoryId) 
		VALUES (productId, newName, newDescription, newPrice, newQuantity, newPhotoUrl, newCategoryId, newSubCategoryId);
    ELSE
		INSERT INTO products (name, description, price, quantity, photoUrl, categoryId, subCategoryId) 
		VALUES (newName, newDescription, newPrice, newQuantity, newPhotoUrl, newCategoryId, newSubCategoryId);
	END IF;   
END //
DELIMITER ;

-- Read operation
DELIMITER //
CREATE PROCEDURE `spGetProductById` (IN productId INT)
BEGIN
	SELECT * FROM products 
    WHERE id = productId;
END //
DELIMITER ;

-- Read operation
DELIMITER //
CREATE PROCEDURE `spGetProductByName` (IN productName VARCHAR(255))
BEGIN
	SELECT * FROM products
    WHERE name = productName;
END //
DELIMITER;

-- Read all operation
DELIMITER //
CREATE PROCEDURE `spGetAllProducts` ()
BEGIN
	SELECT * FROM products;
END //
DELIMITER ;

-- Update operation
DELIMITER //
CREATE PROCEDURE `spUpdateProduct` (IN productId INT, IN newName VARCHAR(255), IN newDescription VARCHAR(255), IN newPrice INT, IN newQuantity INT, IN newPhotoUrl VARCHAR(255), IN newCategoryId INT, IN newSubCategoryId INT)
BEGIN
	UPDATE products SET 
    name = newName,
    description = newDescription,
    price = newPrice,
    quantity = newQuantity,
    photoUrl = newPhotoUrl,
    categoryId = newCategoryId,
    subCategoryId = newSubCategoryId
    WHERE id = productId;
END //
DELIMITER ;

-- Delete operation
DELIMITER //
CREATE PROCEDURE `spDeleteProduct` (IN productId INT)
BEGIN
	DELETE FROM products WHERE id = productId;
END //
DELIMITER ;

/*####################################################
			## User Section ##
####################################################*/
DROP PROCEDURE IF EXISTS `spCreateUser`;
DROP PROCEDURE IF EXISTS `spUpdateUser`;
DROP PROCEDURE IF EXISTS `spDeleteUser`;
DROP PROCEDURE IF EXISTS `spGetUserById`;
DROP PROCEDURE IF EXISTS `spGetAllUsers`;

-- Create operation
DELIMITER //
CREATE PROCEDURE `spCreateUser` (IN UserId INT, IN newUsername VARCHAR(255), IN newPassword VARCHAR(255))
BEGIN
	IF(UserId IS NOT NULL OR 0) 
    THEN
		INSERT INTO Users (id, username, password) 
		VALUES (UserId, newUsername, newPassword);
    ELSE
		INSERT INTO Users (username, password) 
		VALUES (newUsername, newPassword);
	END IF;   
END //
DELIMITER ;

-- Read operation
DELIMITER //
CREATE PROCEDURE `spGetUserById` (IN UserId INT)
BEGIN
	SELECT * FROM Users 
    WHERE id = UserId;
END //
DELIMITER ;

-- Read operation
DELIMITER //
CREATE PROCEDURE `spGetUserByName` (IN UserName VARCHAR(255))
BEGIN
	SELECT * FROM Users
    WHERE username = UserName;
END //
DELIMITER;

-- Read all operation
DELIMITER //
CREATE PROCEDURE `spGetAllUsers` ()
BEGIN
	SELECT * FROM Users;
END //
DELIMITER ;

-- Update operation
DELIMITER //
CREATE PROCEDURE `spUpdateUser` (IN UserId INT, IN newUsername VARCHAR(255), IN newPassword VARCHAR(255))
BEGIN
	UPDATE Users SET 
    username = newUsername, 
    password = newPassword 
    WHERE id = UserId;
END //
DELIMITER ;

-- Delete operation
DELIMITER //
CREATE PROCEDURE `spDeleteUser` (IN UserId INT)
BEGIN
	DELETE FROM Users WHERE id = UserId;
END //
DELIMITER ;

/*####################################################
			## UserInformation Section ##
####################################################*/
DROP PROCEDURE IF EXISTS `spCreateUserInformation`;
DROP PROCEDURE IF EXISTS `spUpdateUserInformation`;
DROP PROCEDURE IF EXISTS `spDeleteUserInformation`;
DROP PROCEDURE IF EXISTS `spGetUserInformationById`;
DROP PROCEDURE IF EXISTS `spGetAllUserInformations`;

-- Create operation
DELIMITER //
CREATE PROCEDURE `spCreateUserInformation` (IN UserId INT, IN newFirstName VARCHAR(255), IN newLastName VARCHAR(255), IN newEmail VARCHAR(255), IN newAddress VARCHAR(255), IN newZipcode VARCHAR(255), IN newCity VARCHAR(255), IN newPhone VARCHAR(255))
BEGIN	
	INSERT INTO UserInformation (id, firstName, lastName, email, address, zipcode, city, phone) 
	VALUES (UserId, newFirstName, newLastName, newEmail, newAddress, newZipcode, newCity, newPhone);
END //
DELIMITER ;

-- Read operation
DELIMITER //
CREATE PROCEDURE `spGetUserInformationById` (IN UserId INT)
BEGIN
	SELECT * FROM UserInformation 
    WHERE id = UserId;
END //
DELIMITER ;

-- Read operation
DELIMITER //
CREATE PROCEDURE `spGetUserInformationByName` (IN UserName VARCHAR(255))
BEGIN
	SELECT * FROM UserInformation
    WHERE username = UserName;
END //
DELIMITER;

-- Read all operation
DELIMITER //
CREATE PROCEDURE `spGetAllUserInformations` ()
BEGIN
	SELECT * FROM UserInformation;
END //
DELIMITER ;

-- Update operation
DELIMITER //
CREATE PROCEDURE `spUpdateUserInformation` (IN UserId INT, IN newFirstName VARCHAR(255), IN newLastName VARCHAR(255), IN newEmail VARCHAR(255), IN newAddress VARCHAR(255), IN newZipcode VARCHAR(255), IN newCity VARCHAR(255), IN newPhone VARCHAR(255))
BEGIN
	UPDATE UserInformation SET 
    firstName = newFirstName,
    lastName = newLastName,
    email = newEmail,
    address = newAddress,
    zipcode = newZipcode,
    city = newCity,
    phone = newPhone
    WHERE id = UserId;
END //
DELIMITER ;

-- Delete operation
DELIMITER //
CREATE PROCEDURE `spDeleteUserInformation` (IN UserId INT)
BEGIN
	DELETE FROM UserInformation WHERE id = UserId;
END //
DELIMITER ;

/*####################################################
			## Log Section ##
####################################################*/
DROP PROCEDURE IF EXISTS `spCreateLog`;
DROP PROCEDURE IF EXISTS `spUpdateLog`;
DROP PROCEDURE IF EXISTS `spDeleteLog`;
DROP PROCEDURE IF EXISTS `spGetLogById`;
DROP PROCEDURE IF EXISTS `spGetAllLogs`;

-- Create operation
DELIMITER //
CREATE PROCEDURE `spCreateLog` (IN logId INT, IN type INT, IN description VARCHAR(255), IN timestamp DATETIME)
BEGIN
	IF(logId IS NOT NULL OR 0)
    THEN
		INSERT INTO log (id, type, description, timestamp) 
		VALUES (logId, type, description, timestamp);
	ELSE
		INSERT INTO log (type, description, timestamp) 
		VALUES (type, description, timestamp);
	END IF;
END //
DELIMITER ;

-- Read operation
DELIMITER //
CREATE PROCEDURE `spGetLogById` (IN logId INT)
BEGIN
	SELECT * FROM log 
    WHERE id = logId;
END //
DELIMITER ;

-- Read all operation
DELIMITER //
CREATE PROCEDURE `spGetAllLogs` ()
BEGIN
	SELECT * FROM log;
END //
DELIMITER ;

-- Update operation
DELIMITER //
CREATE PROCEDURE `spUpdateLog` (IN logId INT, IN type INT, IN description VARCHAR(255), IN timestamp DATETIME)
BEGIN
	UPDATE log SET 
    type = type, 
    description = description, 
    timestamp = timestamp 
    WHERE id = logId;
END //
DELIMITER ;

-- Delete operation
DELIMITER //
CREATE PROCEDURE `spDeleteLog` (IN logId INT)
BEGIN
	DELETE FROM log 
    WHERE id = logId;
END //
DELIMITER ;


/*####################################################
			## LogType Section ##
####################################################*/
DROP PROCEDURE IF EXISTS `spCreateLogType`;
DROP PROCEDURE IF EXISTS `spUpdateLogType`;
DROP PROCEDURE IF EXISTS `spDeleteLogType`;
DROP PROCEDURE IF EXISTS `spGetLogTypeById`;
DROP PROCEDURE IF EXISTS `spGetAllLogTypes`;

-- Create operation
DELIMITER //
CREATE PROCEDURE `spCreateLogType` (IN logTypeId INT, IN errorCodes VARCHAR(255))
BEGIN
	IF(logTypeId IS NOT NULL OR 0)
    THEN
		INSERT INTO logTypes (id, errorCodes) 
		VALUES (logTypeId, errorCodes);
	ELSE
		INSERT INTO logTypes (errorCodes) 
		VALUES (errorCodes);
	END IF;
END //
DELIMITER ;

-- Read operation
DELIMITER //
CREATE PROCEDURE `spGetLogTypeById` (IN logTypeId INT)
BEGIN
	SELECT * FROM logTypes 
    WHERE id = logTypeId;
END //
DELIMITER ;

-- Read all operation
DELIMITER //
CREATE PROCEDURE `spGetAllLogTypes` ()
BEGIN
	SELECT * FROM logTypes;
END //
DELIMITER ;

-- Update operation
DELIMITER //
CREATE PROCEDURE `spUpdateLogType` (IN logTypeId INT, IN errorCodes VARCHAR(255))
BEGIN
	UPDATE logTypes SET 
    errorCodes = errorCodes 
    WHERE id = logTypeId;
END //
DELIMITER ;

-- Delete operation
DELIMITER //
CREATE PROCEDURE `spDeleteLogType` (IN logTypeId INT)
BEGIN
	DELETE FROM logTypes 
    WHERE id = logTypeId;
END //
DELIMITER ;