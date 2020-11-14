IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'zapatosUPIICSA')
	BEGIN
		CREATE DATABASE zapatosUPIICSA
	END
GO

USE zapatosUPIICSA;

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'zapatosUPIICSA')
	BEGIN
		CREATE TABLE users(
			id_user INT NOT NULL IDENTITY(1,1),
			name_user VARCHAR(50),
			password_user VARCHAR(30),
			email_user VARCHAR(50),
			phone_user VARCHAR(50),
			PRIMARY KEY (id_user))

		CREATE TABLE clients(
			id_client INT NOT NULL IDENTITY(1,1),
			name_client VARCHAR(50),
			email_client VARCHAR(50),
			phone_client VARCHAR(50),
			PRIMARY KEY (id_client))
		
		CREATE TABLE models(
			id_model INT NOT NULL IDENTITY(1,1),
			model_model VARCHAR(50),
			size_model VARCHAR(10),
			type_model VARCHAR(30),
			color_model VARCHAR(30),
			PRIMARY KEY (id_model))

			INSERT INTO users (name_user, password_user, email_user, phone_user) VALUES 
			('root', 'root', 'root@gmail.com', null),
			('LuisF', '4051', 'luisflahan4051@gmail.com', '2461506175'),
			('Brian', 'brian', 'BrianMurilloSalas@gmail.com', '123456789'),
			('Yael', 'yael', 'AbrahamYaelRebollarGonzales@gmail.com', '123456789'),
			('LuisS', 'luisS', 'LuisManuelSanchezSantes@gmail.com', '123456789')

			INSERT INTO clients (name_client, email_client, phone_client) VALUES 
			('Cliente 1', 'Cliente1@gmail.com', '123456789'),
			('Cliente 2', 'Cliente2@gmail.com', '123456789'),
			('Cliente 2', 'Cliente3@gmail.com', '123456789'),
			('Cliente 4', 'Cliente4@gmail.com', '123456789')

			INSERT INTO models (model_model, size_model, type_model, color_model) VALUES 
			('Modelo 1', '25', 'Tipo 1', 'Black'),
			('Modelo 2', '26', 'Tipo 2', 'White'),
			('Modelo 3', '28', 'Tipo 3', 'Gray'),
			('Modelo 4', '27', 'Tipo 4', 'Blue')
	END
GO

SELECT * FROM users;