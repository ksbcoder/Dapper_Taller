-- Seleccionar la base de datos
USE Shop;
GO

-- Crear la tabla taller
CREATE TABLE shop (
  shop_id INT PRIMARY KEY IDENTITY,
  name_shop VARCHAR(100) NOT NULL,
  phone_shop VARCHAR(20) NOT NULL,
  address_shop VARCHAR(150) NOT NULL,
  rating_shop INT NOT NULL
);
GO

-- Crear la tabla clientes
CREATE TABLE customers (
  customer_id INT PRIMARY KEY IDENTITY,
  fullname VARCHAR(200) NOT NULL,
  phone_customer VARCHAR(20) NOT NULL,
  address_customer VARCHAR(150) NOT NULL,
  id_shop INT NOT NULL,
  CONSTRAINT fk_shop FOREIGN KEY (id_shop)
  REFERENCES shop(shop_id)
);
GO

-- Crear la tabla vehiculos
CREATE TABLE vehicles (
  vehicle_id INT PRIMARY KEY IDENTITY,
  brand VARCHAR(50) NOT NULL,
  model INT NOT NULL,
  km INT NOT NULL,
  id_customer INT NOT NULL,
  CONSTRAINT fk_customers FOREIGN KEY (id_customer)
  REFERENCES customers(customer_id)
);
GO