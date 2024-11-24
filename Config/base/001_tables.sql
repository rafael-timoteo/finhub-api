SET search_path TO finhub;

CREATE TABLE IF NOT EXISTS Usuario (
    CPF VARCHAR(11) PRIMARY KEY,
    Nome VARCHAR(25) NOT NULL,
    Sobrenome VARCHAR(25) NOT NULL,
    Email VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS Usuario_Contas (
    Numero_Conta_Corrente VARCHAR(20) NOT NULL PRIMARY KEY,
    CPF VARCHAR(11) REFERENCES Usuario(CPF)
);

CREATE TABLE IF NOT EXISTS Instituicoes_Financeiras (
    ID_Banco INT PRIMARY KEY,
    Nome_Banco VARCHAR(100) NOT NULL,
    CNPJ VARCHAR(14) NOT NULL
);

CREATE TABLE IF NOT EXISTS Conta_Corrente (
    ID_Conta INT PRIMARY KEY,
    ID_Banco INT REFERENCES Instituicoes_Financeiras(ID_Banco),
    Agencia VARCHAR(20) NOT NULL,
    Numero_Conta VARCHAR(20) NOT NULL UNIQUE,
    Saldo MONEY NOT NULL,
    Tipo_Conta VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS Extrato (
    ID INT PRIMARY KEY,
    ClienteCPF VARCHAR(11) REFERENCES Usuario(CPF),
    NumeroConta VARCHAR(20) REFERENCES Conta_Corrente(Numero_Conta),
    NomeEmpresa VARCHAR(100),
    DataTransacao DATE NOT NULL,
    ValorTransacao MONEY NOT NULL,
    Classificacao VARCHAR(50)
);