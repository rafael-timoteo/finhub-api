using Dapper;
using FinHub.Infra.Models;

namespace FinHub.Infra
{
    public class ExtratoRepository
    {
        public static List<ContaCorrenteDTO> ObterDadosContaCorrente(string numeroConta)
        {
            using var dbConnection = new DBConnection();
            string query = @"
            SELECT tableCC.numero_conta AS NumeroConta, tableIF.nome_banco AS NomeBanco, tableCC.saldo AS Saldo
            FROM finhub.conta_corrente tableCC
            JOIN finhub.usuario_contas tableUC ON tableUC.numero_conta_corrente = tableCC.numero_conta
            JOIN finhub.instituicoes_financeiras tableIF ON tableIF.id_banco = tableCC.id_banco
            WHERE tableUC.numero_conta_corrente = @numeroConta;";

            var extrato = dbConnection.Connection.Query<ContaCorrenteDTO>(query, new { numeroConta }).AsList();

            return extrato;
        }

        public static decimal ObterSaldoTotal(string cpf)
        {
            using var dbConnection = new DBConnection();
            string query = @"SELECT SUM(cc.saldo) AS SaldoTotal
            FROM finhub.usuario u
            JOIN finhub.usuario_contas uc ON u.cpf = uc.cpf
            JOIN finhub.conta_corrente cc ON uc.numero_conta_corrente = cc.numero_conta
            WHERE u.cpf = @cpf;";

            var saldo = dbConnection.Connection.QueryFirstOrDefault<decimal>(query, new { cpf });

            return saldo;
        }

        public static List<EntradaSaidaDTO> ObterEntradasConta(string cpf)
        {
            using var dbConnection = new DBConnection();
            string query = @"SELECT e.DataTransacao,
                            e.ValorTransacao,
                            e.NomeEmpresa
                            FROM finhub.extrato e
                            JOIN finhub.usuario u ON u.cpf = e.ClienteCPF
                            JOIN finhub.conta_corrente cc ON cc.numero_conta = e.NumeroConta
                            WHERE u.cpf = @cpf AND e.Classificacao = 'Entrada'
                            ORDER BY e.DataTransacao DESC;";

            var entradas = dbConnection.Connection.Query<EntradaSaidaDTO>(query, new { cpf }).AsList();

            return entradas;
        }

        public static List<EntradaSaidaDTO> ObterSaidasConta(string cpf)
        {
            using var dbConnection = new DBConnection();
            string query = @"SELECT e.DataTransacao,
                            e.ValorTransacao,
                            e.NomeEmpresa
                            FROM finhub.extrato e
                            JOIN finhub.usuario u ON u.cpf = e.ClienteCPF
                            JOIN finhub.conta_corrente cc ON cc.numero_conta = e.NumeroConta
                            WHERE u.cpf = @cpf AND e.Classificacao <> 'Entrada'
                            ORDER BY e.DataTransacao DESC;";

            var saidas = dbConnection.Connection.Query<EntradaSaidaDTO>(query, new { cpf }).AsList();

            return saidas;
        }
    }
}