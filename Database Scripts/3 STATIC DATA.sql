/*####################################################
			## Static Data ##
####################################################*/
CALL `elgrosdb`.`spCreateCategory`(1, 'kabler');
CALL `elgrosdb`.`spCreateSubCategory`(1, 'SkærmKabler', 1);
CALL `elgrosdb`.`spCreateProduct`(1, 'HDMI Kabel', 'Skærm kabel', 100,3, '', 1, 1);
