CREATE DATABASE AeroportoCN;
USE AeroportoCN;

-- Tabela de Aeronaves
CREATE TABLE Aeronaves (
    id INT IDENTITY (1, 1) PRIMARY KEY, -- Primary Key Constraint
    tipo NVARCHAR(50) NOT NULL,
    numero_Assento INT NOT NULL
);

-- Tabela de Voos
CREATE TABLE Voos (
    id INT IDENTITY (1, 1) PRIMARY KEY, -- Primary Key Constraint
    aeroporto_origem NVARCHAR(100) NOT NULL,
    aeroporto_destino NVARCHAR(100) NOT NULL,
    horario_saida DATETIME NOT NULL,
    horario_previsto_chegada DATETIME NOT NULL,
    aeronave_id INT,
    FOREIGN KEY (aeronave_id) REFERENCES Aeronaves(id) -- Foreign Key Constraint
);

-- Tabela de Escalas
CREATE TABLE Escalas (
    id INT IDENTITY (1, 1) PRIMARY KEY, -- Primary Key Constraint
    voo_id INT,
    aeroporto_saida NVARCHAR(100) NOT NULL,
    horario_saida DATETIME NOT NULL,
    FOREIGN KEY (voo_id) REFERENCES Voos(id) -- Foreign Key Constraint
);

-- Tabela de Assento
CREATE TABLE Assento (
    id INT IDENTITY (1, 1) PRIMARY KEY, -- Primary Key Constraint
    aeronave_id INT,
    numero NVARCHAR(10) NOT NULL,
    localizacao NVARCHAR(20) NOT NULL,
    disponibilidade NVARCHAR(15)
    FOREIGN KEY (aeronave_id) REFERENCES Aeronaves(id) -- Foreign Key Constraint
);

CREATE TABLE ClientesPreferenciais (
    id INT IDENTITY (1, 1) PRIMARY KEY,
    nome NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    telefone NVARCHAR(20) NOT NULL,
    data_nascimento DATE NOT NULL,
    gestante NVARCHAR(4),
    idoso NVARCHAR(4)
);


CREATE TABLE Reservas (
    id INT IDENTITY (1, 1) PRIMARY KEY, -- Primary Key Constraint
    voo_id INT,
    poltrona_id INT,
    cliente_id INT,
    FOREIGN KEY (voo_id) REFERENCES Voos(id), -- Foreign Key Constraint
    FOREIGN KEY (poltrona_id) REFERENCES Assento(id), -- Foreign Key Constraint
    FOREIGN KEY (cliente_id) REFERENCES ClientesPreferenciais(id) -- Foreign Key Constraint
);