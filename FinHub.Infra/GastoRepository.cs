using Dapper;

namespace FinHub.Infra
{
    public class GastoRepository
    {
        public bool InsertGasto(string cpf, string numeroConta, string nomeEmpresa, DateTime data, decimal valor, string classificacao)
        {
            using var dbConnection = new DBConnection();

            // Gerar um valor aleatório para o id
            //var random = new Random();
            //int id = random.Next(1, int.MaxValue);

            int id = SelectIDExtrato() + 1;

            string query = @"INSERT INTO finhub.extrato (id, clientecpf, numeroconta, nomeempresa, datatransacao, valortransacao, classificacao) 
                                VALUES (@id, @cpf, @numeroConta, @nomeEmpresa, @data, @valor, @classificacao);";

            var result = dbConnection.Connection.Execute(query, new { id, cpf, numeroConta, nomeEmpresa, data, valor, classificacao });

            return result == 1;
        }

        public int SelectIDExtrato()
        {
            using var dbConnection = new DBConnection();
            string query = @"SELECT MAX(id) FROM finhub.extrato;";
            return dbConnection.Connection.QueryFirstOrDefault<int>(query);
        }
    }
}