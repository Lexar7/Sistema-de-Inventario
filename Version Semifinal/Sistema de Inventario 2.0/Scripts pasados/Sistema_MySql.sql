CREATE SCHEMA IF NOT EXISTS `Sistema`;
USE `Sistema` ;


CREATE TABLE IF NOT EXISTS `Sistema`.`Usuarios` (
  `IdUsuario` INT NOT NULL auto_increment,
  `Nombre` VARCHAR(45) NOT NULL,
  `Apellido` VARCHAR(45) NOT NULL,
  `Direccion` VARCHAR(45) NOT NULL,
  `FechaNac` DATE NOT NULL,
  `Telefono` INT(10) NOT NULL,
  `Usuario` VARCHAR(45) NOT NULL,
   Password VARCHAR(45) NOT NULL,
   `Cargo` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IdUsuario`)
  )
ENGINE = InnoDB;

use Sistema;

insert into Usuarios(Nombre,Apellido,Direccion,FechaNac,Telefono,Usuario,Password,Cargo)
VALUES('Luis','Garcia','San Salvador','1995-07-10','78954689','Luis','admin','Administrador');


insert into Usuarios(Nombre,Apellido,Direccion,FechaNac,Telefono,Usuario,Password,Cargo)
VALUES('Juan','Perez','Santa Ana','1990-12-08','7098321','Juan','emp','Empleado');

                             
SELECT * FROM Usuarios;
