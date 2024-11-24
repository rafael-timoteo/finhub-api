using Dapper;

namespace FinHub.Infra
{
    public class GastoRepository
    {
        /// <summary>
        /// Insere uma transação no banco de dados.
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="numeroConta"></param>
        /// <param name="nomeEmpresa"></param>
        /// <param name="data"></param>
        /// <param name="valor"></param>
        /// <param name="classificacao"></param>
        /// <returns>Verdadeiro se a transação foi inserido corretamente</returns>
        public static bool InsertTransacao(string cpf, string numeroConta, string nomeEmpresa, DateTime data, decimal valor, string classificacao)
        {
            using var dbConnection = new DBConnection();
            int id = SelectIDExtrato() + 1;

            string query = @"INSERT INTO finhub.extrato (id, clientecpf, numeroconta, nomeempresa, datatransacao, valortransacao, classificacao) 
                                VALUES (@id, @cpf, @numeroConta, @nomeEmpresa, @data, @valor, @classificacao);";

            var result = dbConnection.Connection.Execute(query, new { id, cpf, numeroConta, nomeEmpresa, data, valor, classificacao });
            return result == 1;
        }

        /// <summary>
        /// Seleciona o gasto de um cliente em um intervalo de tempo com base na classificação do agsto.
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="classificacao"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFim"></param>
        /// <returns>Valor do gasto por tipo</returns>
        public static decimal SelectGastoClassificacao(string cpf, string classificacao, DateTime dataInicio, DateTime dataFim)
        {
            using var dbConnection = new DBConnection();
            string query = @"SELECT COALESCE(valortransacao::money, 0::money)
                    FROM finhub.extrato 
                    WHERE clientecpf = @cpf 
                        AND datatransacao BETWEEN @dataInicio AND @dataFim 
                        AND classificacao = @classificacao;";
            return dbConnection.Connection.QueryFirstOrDefault<decimal>(query, new { cpf, classificacao, dataInicio, dataFim });
        }

        /// <summary>
        /// Seleciona o gasto de um cliente em um intervalo de tempo com base no número da conta.
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="numeroConta"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFim"></param>
        /// <returns>Valor do gasto por conta</returns>
        public static decimal SelectGastoConta(string cpf, string numeroConta, DateTime dataInicio, DateTime dataFim)
        {
            using var dbConnection = new DBConnection();
            string query = @"SELECT COALESCE(SUM(valortransacao::money), 0::money)
                    FROM finhub.extrato 
                    WHERE clientecpf = @cpf 
                        AND numeroconta = @numeroConta 
                        AND datatransacao BETWEEN @dataInicio AND @dataFim;";
            return dbConnection.Connection.QueryFirstOrDefault<decimal>(query, new { cpf, numeroConta, dataInicio, dataFim });
        }

        /// <summary>
        /// Verifica se a conta está cadastrada no banco de dados.
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="numeroConta"></param>
        /// <returns>Verdadeiro se a conta está cadastrada</returns>
        public static bool ConferirConta(string cpf, string numeroConta)
        {
            using var dbConnection = new DBConnection();
            string query = @"SELECT cc.ID_conta
                            FROM finhub.usuario u
                            JOIN finhub.usuario_contas uc ON u.CPF = uc.CPF
                            JOIN finhub.conta_corrente cc ON uc.numero_conta_corrente = cc.numero_conta
                            WHERE u.CPF = @cpf
                              AND cc.numero_conta = @numeroConta;";
            string? idConta = dbConnection.Connection.QueryFirstOrDefault<string>(query, new { cpf, numeroConta });
            
            if (idConta != null)
                return true;
            return false;
        }

        /// <summary>
        /// Verifica se o CPF já está cadastrado no banco de dados.
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns>Verdadeiro se o CPF existe</returns>
        public static bool ConferirCPF(string cpf)
        {
            using var dbConnection = new DBConnection();
            string query = @"SELECT COUNT(*) FROM finhub.usuario WHERE cpf = @cpf;";
            return dbConnection.Connection.QueryFirstOrDefault<int>(query, new { cpf }) == 1;
        }

        /// <summary>
        /// Pega o intervalo de data da primeira e ultima transação de uma conta.
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="numeroConta"></param>
        /// <returns>Primeira e última data</returns>
        public static DateTime[] GetIntervaloDataPadraoConta(string cpf, string numeroConta)
        {
            using var dbConnection = new DBConnection();
            string query = @"SELECT MIN(datatransacao) AS MinData, MAX(datatransacao) AS MaxData 
                             FROM finhub.extrato 
                             WHERE clientecpf = @cpf AND numeroconta = @numeroConta;";
            var result = dbConnection.Connection.QueryFirstOrDefault<(DateTime MinData, DateTime MaxData)>(query, new { cpf, numeroConta });
            return [result.MinData, result.MaxData];
        }

        /// <summary>
        /// Pega o intervalo de data da primeira e ultima transação a partir da classificação.
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="classificacao"></param>
        /// <returns>Primeira e última data</returns>
        public static DateTime[] GetIntervaloDataPadraoClassificacao(string cpf, string classificacao)
        {
            using var dbConnection = new DBConnection();
            string query = @"SELECT MIN(datatransacao) AS MinData, MAX(datatransacao) AS MaxData 
                             FROM finhub.extrato 
                             WHERE clientecpf = @cpf AND classificacao = @classificacao";
            var result = dbConnection.Connection.QueryFirstOrDefault<(DateTime MinData, DateTime MaxData)>(query, new { cpf, classificacao });
            return [result.MinData, result.MaxData];
        }

        /// <summary>
        /// Verifica o último ID da tabela de extrato
        /// </summary>
        /// <returns>Retorna o número do último ID</returns>
        public static int SelectIDExtrato()
        {
            using var dbConnection = new DBConnection();
            string query = @"SELECT MAX(id) FROM finhub.extrato;";
            return dbConnection.Connection.QueryFirstOrDefault<int>(query);
        }
    }
}