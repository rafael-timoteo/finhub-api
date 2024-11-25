SET search_path TO finhub;

INSERT INTO Usuario (CPF, Nome, Sobrenome, Email) VALUES
('47526501933', 'Joao', 'USP', 'joaousp@email.com');

INSERT INTO Usuario_Contas (Numero_Conta_Corrente, CPF) VALUES
('12345678', '47526501933'),
('56482100', '47526501933'),
('45469208', '47526501933'),
('89461379', '47526501933');

INSERT INTO Instituicoes_Financeiras (ID_Banco, Nome_Banco, CNPJ) VALUES
(6, 'Bradesco', '76234567890123'),
(7, 'BTG Pactual', '87654321000190'),
(8, 'XP Investimentos', '99887766000120'),
(9, 'Banrisul', '13572468000122'),
(10, 'Banco Safra', '98765434000100'),
(11, 'Banco Votorantim', '12309845000101'),
(12, 'Banestes', '56789012000113'),
(13, 'Banco Modal', '23456789000190'),
(14, 'Bacen', '33344455500100'),
(15, 'Banco PAN', '88999877000123');

INSERT INTO Conta_Corrente (ID_Conta, ID_Banco, Agencia, Numero_Conta, Saldo, Tipo_Conta) VALUES
(6, 6, '9999', '12345678', 1000.00, 'Corrente'),
(15, 15, '1111', '56482100', 12500.00, 'Corrente'),
(10, 10, '0001', '45469208', 3000.00, 'Corrente'),
(7, 7, '3333', '89461379', 5000.00, 'Corrente');

INSERT INTO Extrato (ID, ClienteCPF, NumeroConta, NomeEmpresa, DataTransacao, ValorTransacao, Classificacao) VALUES
(11, '47526501933', '45469208', 'Magazine Luiza', '2024-11-11', -150.00, 'Compras'),
(12, '47526501933', '45469208', 'Submarino', '2024-11-12', -50.00, 'Compras'),
(13, '47526501933', '89461379', 'Rappi', '2024-11-13', -45.90, 'Alimentacao'),
(15, '47526501933', '56482100', 'Netflix', '2024-11-15', -45.00, 'Entretenimento'),
(16, '47526501933', '56482100', 'Spotify', '2024-11-16', -36.00, 'Entretenimento'),
(17, '47526501933', '56482100', 'Amazon', '2024-11-17', -350.00, 'Compras'),
(18, '47526501933', '12345678', 'Uber', '2024-11-18', -27.15, 'Transporte'),
(22, '47526501933', '56482100', 'Amazon Prime', '2024-11-22', -14.90, 'Entretenimento'),
(23, '47526501933', '89461379', 'Uber Eats', '2024-11-23', -80.00, 'Alimentacao'),
(24, '47526501933', '56482100', 'Salario', '2024-11-30', 10000.00, 'Entrada'),
(32, '47526501933', '56482100', 'Amazon', '2024-12-02', -90.00, 'Compras'),
(35, '47526501933', '89461379', 'Farmacia Lauretto', '2024-12-05', -532.99, 'Saude'),
(37, '47526501933', '56482100', 'Clube Fitness', '2024-12-07', -120.00, 'Entretenimento'),
(40, '47526501933', '12345678', 'Pão de Açúcar', '2024-12-10', -325.25, 'Alimentacao'),
(41, '47526501933', '56482100', 'Claro', '2024-12-10', -80.00, 'Contas'),
(42, '47526501933', '56482100', 'Enel', '2024-12-10', -76.27, 'Contas'),
(43, '47526501933', '56482100', 'Imobiliaria Predio', '2024-12-10', -1800.00, 'Contas'),
(44, '47526501933', '56482100', 'Sabesp', '2024-12-10', -130.00, 'Contas'),
(45, '47526501933', '56482100', 'Tião do gás', '2024-12-10', -150.00, 'Contas'),
(46, '47526501933', '56482100', 'Spotify', '2024-12-16', -36.00, 'Entretenimento'),
(47, '47526501933', '12345678', 'Cinemark', '2024-12-18', -80.00, 'Entretenimento'),
(48, '47526501933', '12345678', 'Outback', '2024-12-17', -180.00, 'Alimentacao'),
(49, '47526501933', '89461379', 'Shell', '2024-12-18', -300.00, 'Transporte');