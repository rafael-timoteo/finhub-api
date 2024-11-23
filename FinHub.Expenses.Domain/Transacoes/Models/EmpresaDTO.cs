using Newtonsoft.Json;
using System.Collections.Generic;

namespace FinHub.Gastos.Domain.Transacoes.Models
{
    /// <summary>
    /// Representa uma empresa com informações cadastrais e fiscais.
    /// </summary>
    public class EmpresaDTO
    {
        /// <summary>
        /// O CNPJ da empresa.
        /// </summary>
        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        /// <summary>
        /// A razão social da empresa.
        /// </summary>
        [JsonProperty("razao_social")]
        public string RazaoSocial { get; set; }

        /// <summary>
        /// A natureza jurídica da empresa.
        /// </summary>
        [JsonProperty("natureza_juridica")]
        public string NaturezaJuridica { get; set; }

        /// <summary>
        /// A qualificação do responsável pela empresa.
        /// </summary>
        [JsonProperty("qualificacao_responsavel")]
        public string QualificacaoResponsavel { get; set; }

        /// <summary>
        /// O capital social da empresa.
        /// </summary>
        [JsonProperty("capital_social")]
        public double CapitalSocial { get; set; }

        /// <summary>
        /// O porte da empresa.
        /// </summary>
        [JsonProperty("porte")]
        public string Porte { get; set; }

        /// <summary>
        /// O ente federativo responsável pela empresa.
        /// </summary>
        [JsonProperty("ente_federativo_responsavel")]
        public string EnteFederativoResponsavel { get; set; }

        /// <summary>
        /// O nome fantasia da empresa.
        /// </summary>
        [JsonProperty("nome_fantasia")]
        public string NomeFantasia { get; set; }

        /// <summary>
        /// A situação cadastral da empresa.
        /// </summary>
        [JsonProperty("situacao_cadastral")]
        public string SituacaoCadastral { get; set; }

        /// <summary>
        /// A data da situação cadastral da empresa.
        /// </summary>
        [JsonProperty("data_situacao_cadastral")]
        public string DataSituacaoCadastral { get; set; }

        /// <summary>
        /// O motivo da situação cadastral da empresa.
        /// </summary>
        [JsonProperty("motivo_situacao_cadastral")]
        public string MotivoSituacaoCadastral { get; set; }

        /// <summary>
        /// O nome da cidade no exterior, caso aplicável.
        /// </summary>
        [JsonProperty("nome_da_cidade_no_exterior")]
        public string NomeDaCidadeNoExterior { get; set; }

        /// <summary>
        /// O país de origem da empresa.
        /// </summary>
        [JsonProperty("pais")]
        public string Pais { get; set; }

        /// <summary>
        /// O endereço da empresa.
        /// </summary>
        [JsonProperty("endereco")]
        public EnderecoDTO Endereco { get; set; }

        /// <summary>
        /// A data de início das atividades da empresa.
        /// </summary>
        [JsonProperty("data_inicio_atividade")]
        public string DataInicioAtividade { get; set; }

        /// <summary>
        /// O CNAE fiscal principal da empresa.
        /// </summary>
        [JsonProperty("cnae_fiscal_principal")]
        public CnaeDTO CnaeFiscalPrincipal { get; set; }

        /// <summary>
        /// A lista de CNAEs fiscais secundários da empresa.
        /// </summary>
        [JsonProperty("cnae_fiscal_secundaria")]
        public List<CnaeDTO> CnaeFiscalSecundaria { get; set; }
    }

    /// <summary>
    /// Representa o endereço de uma empresa.
    /// </summary>
    public class EnderecoDTO
    {
        /// <summary>
        /// O tipo de logradouro do endereço.
        /// </summary>
        [JsonProperty("tipo_logradouro")]
        public string TipoLogradouro { get; set; }

        /// <summary>
        /// O logradouro do endereço.
        /// </summary>
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        /// <summary>
        /// O número do endereço.
        /// </summary>
        [JsonProperty("numero")]
        public string Numero { get; set; }

        /// <summary>
        /// O complemento do endereço.
        /// </summary>
        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        /// <summary>
        /// O bairro do endereço.
        /// </summary>
        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        /// <summary>
        /// O CEP do endereço.
        /// </summary>
        [JsonProperty("cep")]
        public string Cep { get; set; }

        /// <summary>
        /// A unidade federativa (UF) do endereço.
        /// </summary>
        [JsonProperty("uf")]
        public string Uf { get; set; }

        /// <summary>
        /// O município do endereço.
        /// </summary>
        [JsonProperty("municipio")]
        public string Municipio { get; set; }
    }

    /// <summary>
    /// Representa um Código Nacional de Atividade Econômica (CNAE).
    /// </summary>
    public class CnaeDTO
    {
        /// <summary>
        /// O código do CNAE.
        /// </summary>
        [JsonProperty("codigo")]
        public int Codigo { get; set; }

        /// <summary>
        /// O nome do CNAE.
        /// </summary>
        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}