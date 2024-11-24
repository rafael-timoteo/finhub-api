using Dapper;
using FinHub.Infra.Models;

namespace FinHub.Infra
{
    public class ContaCorrenteRepository
    {
        public static List<ContaCorrenteDTO> ObterDadosContaCorrente(string numeroConta)
        {
            using var dbConnection = new DBConnection();
            string query = @"
            SELECT tableCC.numero_conta AS NumeroConta, tableIF.nome_banco AS NomeBanco, tableCC.saldo AS Saldo
            FROM finhub.conta_corrente tableCC
            JOIN finhub.usuario_contas tableUC ON tableUC.Numero_Conta_Corrente = tableCC.numero_conta
            JOIN finhub.instituicoes_financeiras tableIF ON tableIF.id_banco = tableCC.id_banco
            WHERE tableUC.Numero_Conta_Corrente = @numeroConta;";

            return dbConnection.Connection.Query<ContaCorrenteDTO>(query, new { numeroConta }).AsList();
        }
    }
}