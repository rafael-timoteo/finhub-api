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
        /// <returns>Valor do gasto</returns>
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