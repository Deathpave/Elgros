/*####################################################
			## Static Data ##
####################################################*/
CALL `elgrosdb`.`spCreateCategory`(1, 'kabler');
CALL `elgrosdb`.`spCreateSubCategory`(1, 'SkærmKabler', 1);
CALL `elgrosdb`.`spCreateProduct`(1, 'HDMI Kabel', 'Skærm kabel', 100,3, '', 1, 1);

CALL `elgrosdb`.`spCreateUser`(1, 'M0CfJ4nA9e4uci4AJgWDA==', 'c6a4w947lhu+j26YHFEl6hTyfoYLZ7hQOKiLLTs2wNQ=');
CALL `elgrosdb`.`spCreateUserInformation`(1, 'Frank', 'Frø', 'FrøManden@gmail.com', 'Ahorn Alle 3', '4100', 'Ringsted', '69696969');

