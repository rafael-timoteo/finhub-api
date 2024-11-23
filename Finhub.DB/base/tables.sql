SET search_path TO finhub;

CREATE TABLE IF NOT EXISTS Usuario (
    CPF VARCHAR(11) PRIMARY KEY,
    Nome VARCHAR(25) NOT NULL,
    Sobrenome VARCHAR(25) NOT NULL,
    Email VARCHAR(25) NOT NULL
);

CREATE TABLE IF NOT EXISTS Usuario_Contas (
    id_conta INT NOT NULL PRIMARY KEY,
    CPF VARCHAR(11) REFERENCES Usuario(CPF)
);

CREATE TABLE IF NOT EXISTS Instituicoes_Financeiras (
    ID_Banco INT PRIMARY KEY,
    Nome_Banco VARCHAR(100) NOT NULL,
    CNPJ VARCHAR(14) NOT NULL
);

CREATE TABLE IF NOT EXISTS Conta_Corrente (
    ID INT PRIMARY KEY,
    ID_Conta INT REFERENCES Usuario_Contas(id_conta),
    ID_Banco INT REFERENCES Instituicoes_Financeiras(ID_Banco),
    Agencia VARCHAR(20) NOT NULL,
    Numero_Conta VARCHAR(20) NOT NULL,
    Saldo MONEY NOT NULL,
    Tipo_Conta VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS Extrato (
    ID INT PRIMARY KEY,
    ClienteCPF VARCHAR(11) REFERENCES Usuario(CPF),
    NumeroConta VARCHAR(20),
    NomeEmpresa VARCHAR(100),
    DataTransacao DATE NOT NULL,
    ValorTransacao MONEY NOT NULL,
    Classificacao VARCHAR(50)
);