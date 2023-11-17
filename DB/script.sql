CREATE SCHEMA IF NOT EXISTS `jardineria` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `jardineria` ;

-- -----------------------------------------------------
-- Table `jardineria`.`boss`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `jardineria`.`boss` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  `dentification_ard` INT NULL DEFAULT NULL,
  `cellphone` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `jardineria`.`provider`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `jardineria`.`provider` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  `dentification_ard` INT NULL DEFAULT NULL,
  `cellphone` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;



-- -----------------------------------------------------
-- Table `jardineria`.`country`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `jardineria`.`country` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `jardineria`.`state`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `jardineria`.`state` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NULL DEFAULT NULL,
  `IdCountryFk` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `Fk_IdCountry` (`IdCountryFk` ASC) VISIBLE,
  CONSTRAINT `Fk_IdCountry`
    FOREIGN KEY (`IdCountryFk`)
    REFERENCES `jardineria`.`country` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `jardineria`.`city`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `jardineria`.`city` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NULL DEFAULT NULL,
  `IdStateFk` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `Fk_IdState` (`IdStateFk` ASC) VISIBLE,
  CONSTRAINT `Fk_IdState`
    FOREIGN KEY (`IdStateFk`)
    REFERENCES `jardineria`.`state` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `jardineria`.`contact`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `jardineria`.`contact` (
  `id` INT NOT NULL,
  `contact_name` VARCHAR(30) NOT NULL,
  `contact_last_name` VARCHAR(30) NOT NULL,
  `contact_numbrer` VARCHAR(15) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  `fax` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS `jardineria`.`office` (
    `office_code` VARCHAR(10) NOT NULL,
    `phone` VARCHAR(20) NOT NULL,
    `location_office_FK` INT NOT NULL,
    PRIMARY KEY (`office_code`)
);

-- -----------------------------------------------------
-- Table `jardineria`.`product_line`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `jardineria`.`product_line` (
  `product_line` VARCHAR(50) NOT NULL,
  `description_text` TEXT NULL DEFAULT NULL,
  `description_html` TEXT NULL DEFAULT NULL,
  `image` VARCHAR(256) NULL DEFAULT NULL,
  PRIMARY KEY (`product_line`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;



-- -----------------------------------------------------
-- Table `jardineria`.`product`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `jardineria`.`product` (
  `product_code` VARCHAR(15) NOT NULL,
  `name` VARCHAR(70) NOT NULL,
  `product_line` VARCHAR(50) NOT NULL,
  `dimensions` VARCHAR(25) NULL DEFAULT NULL,
  `supplier` VARCHAR(50) NULL DEFAULT NULL,
  `description` TEXT NULL DEFAULT NULL,
  `stock_quantity` SMALLINT NOT NULL,
  `selling_price` DECIMAL(15,2) NOT NULL,
  `supplier_price` DECIMAL(15,2) NULL DEFAULT NULL,
  `IdProviderFk` INT NULL DEFAULT NULL,
  PRIMARY KEY (`product_code`),
  INDEX `Fk_product_line` (`product_line` ASC) VISIBLE,
  INDEX `Fk_IdproviderFk` (`IdproviderFk` ASC) VISIBLE,
  CONSTRAINT `Fk_IdproviderFk`
    FOREIGN KEY (`IdproviderFk`)
    REFERENCES `jardineria`.`provider` (`id`),
  CONSTRAINT `Fk_product_line`
    FOREIGN KEY (`product_line`)
    REFERENCES `jardineria`.`product_line` (`product_line`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `jardineria`.`employee`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `jardineria`.`employee` (
  `employee_code` INT NOT NULL,
  `first_name` VARCHAR(50) NOT NULL,
  `last_name1` VARCHAR(50) NOT NULL,
  `last_name2` VARCHAR(50) NULL DEFAULT NULL,
  `extension` VARCHAR(10) NOT NULL,
  `email` VARCHAR(100) NOT NULL,
  `office_code` VARCHAR(10) NOT NULL,
  `IdBossFk` INT NOT NULL,
  `position` VARCHAR(50) NULL DEFAULT NULL,
  PRIMARY KEY (`employee_code`),
  INDEX `Fk_OfficeCodeFk` (`office_code` ASC) VISIBLE,
  INDEX `Fk_IdBossFk` (`IdBossFk` ASC) VISIBLE,
  CONSTRAINT `Fk_IdBossFk`
    FOREIGN KEY (`IdBossFk`)
    REFERENCES `jardineria`.`boss` (`id`),
  CONSTRAINT `Fk_OfficeCodeFk`
    FOREIGN KEY (`office_code`)
    REFERENCES `jardineria`.`office` (`office_code`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `jardineria`.`customer`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `jardineria`.`customer` (
  `client_code` INT NOT NULL,
  `client_name` VARCHAR(50) NOT NULL,
  `credit_limit` DECIMAL(15,2) NULL DEFAULT NULL,
  `IdEmployeeFK` INT NULL DEFAULT NULL,
  `IdContactFK` INT NULL DEFAULT NULL,
  PRIMARY KEY (`client_code`),
  INDEX `FK_Employee_FK` (`IdEmployeeFK` ASC) VISIBLE,
  INDEX `FK_Contact` (`IdContactFK` ASC) VISIBLE,
  CONSTRAINT `FK_Contact`
    FOREIGN KEY (`IdContactFK`)
    REFERENCES `jardineria`.`contact` (`id`),
  CONSTRAINT `FK_Employee_FK`
    FOREIGN KEY (`IdEmployeeFK`)
    REFERENCES `jardineria`.`employee` (`employee_code`))
  
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `jardineria`.`location_customer`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `jardineria`.`location_customer` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `tipoDeVia` VARCHAR(50) NULL DEFAULT NULL,
  `numeroPri` SMALLINT NULL DEFAULT NULL,
  `letra` CHAR(2) NULL DEFAULT NULL,
  `bis` CHAR(10) NULL DEFAULT NULL,
  `letrasec` CHAR(2) NULL DEFAULT NULL,
  `cardinal` CHAR(10) NULL DEFAULT NULL,
  `numeroSec` SMALLINT NULL DEFAULT NULL,
  `letrater` CHAR(2) NULL DEFAULT NULL,
  `numeroTer` SMALLINT NULL DEFAULT NULL,
  `cardinalSec` CHAR(10) NULL DEFAULT NULL,
  `complemento` VARCHAR(50) NULL DEFAULT NULL,
  `idClientFk` INT NULL DEFAULT NULL,
  `idCityFk` INT NULL DEFAULT NULL,
  `PostCode` VARCHAR(10) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `Fk2_idCityFk` (`idCityFk` ASC) VISIBLE,
  INDEX `Fk1_idClientFk` (`idClientFk` ASC) VISIBLE,
  CONSTRAINT `Fk1_idClientFk`
    FOREIGN KEY (`idClientFk`)
    REFERENCES `jardineria`.`customer` (`client_code`),
  CONSTRAINT `Fk2_idCityFk`
    FOREIGN KEY (`idCityFk`)
    REFERENCES `jardineria`.`city` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;



-- -----------------------------------------------------
-- Table `jardineria`.`orders`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `jardineria`.`orders` (
  `order_code` INT NOT NULL,
  `order_date` DATE NOT NULL,
  `expected_date` DATE NOT NULL,
  `delivery_date` DATE NULL DEFAULT NULL,
  `status` VARCHAR(15) NOT NULL,
  `comments` TEXT CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  `client_code` INT NOT NULL,
  PRIMARY KEY (`order_code`),
  INDEX `Fk_client_code` (`client_code` ASC) VISIBLE,
  CONSTRAINT `Fk_client_code`
    FOREIGN KEY (`client_code`)
    REFERENCES `jardineria`.`customer` (`client_code`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;





-- -----------------------------------------------------
-- Table `jardineria`.`order_detail`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `jardineria`.`order_detail` (
  `order_code` INT NOT NULL,
  `product_code` VARCHAR(15) NOT NULL,
  `quantity` INT NOT NULL,
  `unit_price` DECIMAL(15,2) NOT NULL,
  `line_number` SMALLINT NOT NULL,
  PRIMARY KEY (`order_code`, `product_code`),
  INDEX `Fk2_product_code` (`product_code` ASC) VISIBLE,
  CONSTRAINT `Fk1_order_code`
    FOREIGN KEY (`order_code`)
    REFERENCES `jardineria`.`orders` (`order_code`),
  CONSTRAINT `Fk2_product_code`
    FOREIGN KEY (`product_code`)
    REFERENCES `jardineria`.`product` (`product_code`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `jardineria`.`payment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `jardineria`.`payment` (
  `payment_method` VARCHAR(40) NOT NULL,
  `transaction_id` VARCHAR(50) NOT NULL,
  `payment_date` DATE NOT NULL,
  `total` DECIMAL(15,2) NOT NULL,
  `client_code` INT NOT NULL,
  PRIMARY KEY (`transaction_id`),
  INDEX `Fk_cliente_code` (`client_code` ASC) VISIBLE,
  CONSTRAINT `Fk_cliente_code`
    FOREIGN KEY (`client_code`)
    REFERENCES `jardineria`.`customer` (`client_code`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


CREATE TABLE IF NOT EXISTS `jardineria`.`location_office` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `tipoDeVia` VARCHAR(50) NULL DEFAULT NULL,
    `numeroPri` SMALLINT NULL DEFAULT NULL,
    `letra` CHAR(2) NULL DEFAULT NULL,
    `bis` CHAR(10) NULL DEFAULT NULL,
    `letrasec` CHAR(2) NULL DEFAULT NULL,
    `cardinal` CHAR(10) NULL DEFAULT NULL,
    `numeroSec` SMALLINT NULL DEFAULT NULL,
    `letrater` CHAR(2) NULL DEFAULT NULL,
    `numeroTer` SMALLINT NULL DEFAULT NULL,
    `cardinalSec` CHAR(10) NULL DEFAULT NULL,
    `complemento` VARCHAR(50) NULL DEFAULT NULL,
    `PostCode` VARCHAR(10) NULL DEFAULT NULL,
    `idCityFk` INT NULL DEFAULT NULL,
    PRIMARY KEY (`id`),
    CONSTRAINT `Fk1_idCityFk` FOREIGN KEY (`idCityFk`)
        REFERENCES `jardineria`.`city` (`id`)
)  ENGINE=INNODB DEFAULT CHARACTER SET=UTF8MB4 COLLATE = UTF8MB4_0900_AI_CI;


-- Añadir la primera clave externa
ALTER TABLE `jardineria`.`office`
ADD INDEX `fk_office_location_customer_copy11_idx` (`location_office_FK` ASC) VISIBLE,
ADD CONSTRAINT `fk_office_location_customer_copy11`
  FOREIGN KEY (`location_office_FK`)
  REFERENCES `jardineria`.`location_office` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;