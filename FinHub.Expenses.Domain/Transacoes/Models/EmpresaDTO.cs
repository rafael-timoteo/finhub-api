using Newtonsoft.Json;

namespace FinHub.Gastos.Domain.Transacoes.Models
{
    public class EmpresaDTO
    {
        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("razao_social")]
        public string RazaoSocial { get; set; }

        [JsonProperty("natureza_juridica")]
        public string NaturezaJuridica { get; set; }

        [JsonProperty("qualificacao_responsavel")]
        public string QualificacaoResponsavel { get; set; }

        [JsonProperty("capital_social")]
        public double CapitalSocial { get; set; }

        [JsonProperty("porte")]
        public string Porte { get; set; }

        [JsonProperty("ente_federativo_responsavel")]
        public string EnteFederativoResponsavel { get; set; }

        [JsonProperty("nome_fantasia")]
        public string NomeFantasia { get; set; }

        [JsonProperty("situacao_cadastral")]
        public string SituacaoCadastral { get; set; }

        [JsonProperty("data_situacao_cadastral")]
        public string DataSituacaoCadastral { get; set; }

        [JsonProperty("motivo_situacao_cadastral")]
        public string MotivoSituacaoCadastral { get; set; }

        [JsonProperty("nome_da_cidade_no_exterior")]
        public string NomeDaCidadeNoExterior { get; set; }

        [JsonProperty("pais")]
        public string Pais { get; set; }

        [JsonProperty("endereco")]
        public EnderecoDTO Endereco { get; set; }

        [JsonProperty("data_inicio_atividade")]
        public string DataInicioAtividade { get; set; }

        [JsonProperty("cnae_fiscal_principal")]
        public CnaeDTO CnaeFiscalPrincipal { get; set; }

        [JsonProperty("cnae_fiscal_secundaria")]
        public List<CnaeDTO> CnaeFiscalSecundaria { get; set; }
    }

    public class EnderecoDTO
    {
        [JsonProperty("tipo_logradouro")]
        public string TipoLogradouro { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("municipio")]
        public string Municipio { get; set; }
    }

    public class CnaeDTO
    {
        [JsonProperty("codigo")]
        public int Codigo { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}