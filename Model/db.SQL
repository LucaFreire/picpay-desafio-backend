USE picpay_desafio_backend;

CREATE TABLE users
(
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    full_name VARCHAR(200) NOT NULL,
    document VARCHAR(30) UNIQUE NOT NULL,
    email VARCHAR(13) UNIQUE NOT NULL,
    balance MONEY DEFAULT 0 NOT NULL,
    user_type VARCHAR(35) NOT NULL
);

CREATE TABLE transactions
(
    transaction_id INT IDENTITY(1,1) PRIMARY KEY,
    transaction_value MONEY NOT NULL,
    payee INT REFERENCES users(user_id) NOT NULL, 
    payer INT REFERENCES users(user_id) NOT NULL, 
);
