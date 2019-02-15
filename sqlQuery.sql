CREATE SCHEMA `lightspeed_airline` ;
CREATE TABLE `lightspeed_airline`.`aircraft` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `manufacturer` VARCHAR(45) NOT NULL,
  `model` VARCHAR(45) NOT NULL,
  `registration` VARCHAR(45) NOT NULL,
  `fin` INT NOT NULL,
  `manufacture_date` DATE NOT NULL,
  PRIMARY KEY (`id`));

INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FITL', '731', '2007-03-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FITU', '732', '2007-04-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FITW', '733', '2007-05-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FIUL', '734', '2007-06-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FIUR', '735', '2007-07-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FIUV', '736', '2008-03-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FIUW', '737', '2008-04-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FIVM', '738', '2008-05-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FRAM', '739', '2008-06-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FIVQ', '740', '2008-12-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FIVR', '741', '2009-02-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FIVS', '742', '2009-06-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FIVW', '743', '2013-05-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FIVX', '744', '2013-07-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FNNQ', '745', '2013-10-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FNNU', '746', '2013-11-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FNNW', '747', '2014-01-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FJZS', '748', '2016-03-01');
INSERT INTO `lightspeed_airline`.`aircraft` (`manufacturer`, `model`, `registration`, `fin`, `manufacture_date`) VALUES ('Boeing', '777-300ER', 'C-FKAU', '749', '2016-05-01');


-------------------------------------------------------------------------------------------------------------------------
SQL SERVER 2017

CREATE TABLE dbo.Aircraft (
	AircraftID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Manufacturer VARCHAR(45) NOT NULL,
	Model VARCHAR(45) NOT NULL,
	Registration VARCHAR(45) NOT NULL,
	FIN INT NOT NULL,
	ManufactureDate DATE NOT NULL
)

INSERT INTO [LightSpeedAirlines].[dbo].[Aircraft] (Manufacturer, Model, Registration, FIN, ManufactureDate)
   VALUES  ('Boeing', '777-300ER', 'C-FITL', '731', '2007-03-01'),
		   ('Boeing', '777-300ER', 'C-FITU', '732', '2007-04-01'),
		   ('Boeing', '777-300ER', 'C-FITW', '733', '2007-05-01'),
		   ('Boeing', '777-300ER', 'C-FIUL', '734', '2007-06-01'),
		   ('Boeing', '777-300ER', 'C-FIUR', '735', '2007-07-01'),
		   ('Boeing', '777-300ER', 'C-FIUV', '736', '2008-03-01'),
		   ('Boeing', '777-300ER', 'C-FIUW', '737', '2008-04-01'),
		   ('Boeing', '777-300ER', 'C-FIVM', '738', '2008-05-01'),
		   ('Boeing', '777-300ER', 'C-FRAM', '739', '2008-06-01'),
		   ('Boeing', '777-300ER', 'C-FIVQ', '740', '2008-12-01'),
		   ('Boeing', '777-300ER', 'C-FIVR', '741', '2009-02-01'),
		   ('Boeing', '777-300ER', 'C-FIVS', '742', '2009-06-01'),
		   ('Boeing', '777-300ER', 'C-FIVW', '743', '2013-05-01'),
		   ('Boeing', '777-300ER', 'C-FIVX', '744', '2013-07-01'),
		   ('Boeing', '777-300ER', 'C-FNNQ', '745', '2013-10-01'),
		   ('Boeing', '777-300ER', 'C-FNNU', '746', '2013-11-01'),
		   ('Boeing', '777-300ER', 'C-FNNW', '747', '2014-01-01'),
		   ('Boeing', '777-300ER', 'C-FJZS', '748', '2016-03-01'),
		   ('Boeing', '777-300ER', 'C-FKAU', '749', '2016-05-01');