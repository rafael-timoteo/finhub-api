namespace FinHub.Infra.DbSets
{
    public class ContaCorrente
    {
        public string ID_Conta { get; set; }
        public string ID_Banco { get; set; }
        public string Agencia { get; set; }
        public string Numero_Conta { get; set; }
        public decimal Saldo { get; set; }
        public string Tipo_Conta { get; set; }
    }
}
