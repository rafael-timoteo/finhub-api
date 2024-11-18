namespace FinHub.API.Requests
{
    public class TransacaoRequest
    {
        public LoggedUser LoggedUser { get; set; }
        public BusinessEntity BusinessEntity { get; set; }
        public Creditor Creditor { get; set; }
        public Payment Payment { get; set; }
        public DebtorAccount DebtorAccount { get; set; }
    }

    public class LoggedUser
    {
        public Document Document { get; set; }
    }

    public class BusinessEntity
    {
        public Document Document { get; set; }
    }

    public class Document
    {
        public string Identification { get; set; }
        public string Rel { get; set; }
    }

    public class Creditor
    {
        public string PersonType { get; set; }
        public string CpfCnpj { get; set; }
        public string Name { get; set; }
    }

    public class Payment
    {
        public string Type { get; set; }
        public string Date { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public string IbgeTownCode { get; set; }
        public PaymentDetails Details { get; set; }
    }

    public class PaymentDetails
    {
        public string LocalInstrument { get; set; }
        public string QrCode { get; set; }
        public string Proxy { get; set; }
        public CreditorAccount CreditorAccount { get; set; }
    }

    public class CreditorAccount
    {
        public string Ispb { get; set; }
        public string Issuer { get; set; }
        public string Number { get; set; }
        public string AccountType { get; set; }
    }

    public class DebtorAccount
    {
        public string Ispb { get; set; }
        public string Issuer { get; set; }
        public string Number { get; set; }
        public string AccountType { get; set; }
    }
}