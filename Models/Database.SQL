CREATE DATABASE picpay_desafio_backend;

USE picpay_desafio_backend;

CREATE TABLE type_users
(
    type_id INT IDENTITY(1,1) PRIMARY KEY,
    type_name VARCHAR(50) NOT NULL,
);

CREATE TABLE users
(
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    full_name VARCHAR(200) NOT NULL,
    CPF_CNPJ VARCHAR(30) UNIQUE NOT NULL,
    user_email VARCHAR(13) UNIQUE NOT NULL,
    balance MONEY DEFAULT 0,
    user_type INT REFERENCES type_users(type_id)
);

CREATE TABLE transactions
(
    transaction_id INT IDENTITY(1,1) PRIMARY KEY,
    transaction_value MONEY,
    payee INT REFERENCES users(user_id), 
    payer INT REFERENCES users(user_id), 
);
