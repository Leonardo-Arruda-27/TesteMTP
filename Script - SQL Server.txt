CREATE DATABASE testeMTP;
GO

USE testeMTP;
GO

CREATE TABLE Task
(
    Id int IDENTITY(1,1) PRIMARY KEY,
    Tasks varchar(50) NOT NULL,
    IsCompleted bit NOT NULL
);
GO

SELECT * FROM Task GO

INSERT INTO Task (Tasks, IsCompleted) VALUES ('Fazer compras', 0);
INSERT INTO Task (Tasks, IsCompleted) VALUES ('Estudar para o teste', 1);
