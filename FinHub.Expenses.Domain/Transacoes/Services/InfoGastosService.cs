using FinHub.Gastos.Domain.Transacoes.Interfaces;
using FinHub.Gastos.Domain.Transacoes.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FinHub.Gastos.Domain.Transacoes.Services
{
    /// <inheritdoc />
    public class InfoGastosService : IInfoGastosService
    {
        /// <inheritdoc />
        public async Task<EmpresaDTO> ConsultarCNPJ(string cnpj)
        {
            using var client = new HttpClient();
            try
            {
                string url = $"https://api.cnpjs.dev/v1/{cnpj}";

                var response = await client.GetStringAsync(url);

                JObject jsonResponse = JObject.Parse(response);
                
                var empresaInfo = jsonResponse.ToObject<EmpresaDTO>();

                return empresaInfo!;
            }
            catch (HttpRequestException e)
            {
                throw new Exception($"Erro na requisição: {e.Message}");
            }
            catch (JsonException e)
            {
                throw new Exception($"Erro ao processar os dados: {e.Message}");
            }
        }

        /// <inheritdoc />
        public ClassificacaoCNAE ClassificarCNAE(string cnae)
        {
            string prefixoCNAE = cnae.Substring(0, 2);

            return prefixoCNAE switch
            {
                "35" => ClassificacaoCNAE.Contas, // Eletricidade e gás
                "36" => ClassificacaoCNAE.Contas, // Água
                "37" => ClassificacaoCNAE.Contas, // Água
                "38" => ClassificacaoCNAE.Contas, // Água
                "39" => ClassificacaoCNAE.Contas, // Água
                "41" => ClassificacaoCNAE.Contas, // Construção
                "42" => ClassificacaoCNAE.Contas, // Construção
                "43" => ClassificacaoCNAE.Contas, // Construção
                "61" => ClassificacaoCNAE.Contas, // Telecomunicações
                "65" => ClassificacaoCNAE.Contas, // SEGUROS, RESSEGUROS, PREVIDÊNCIA COMPLEMENTAR E PLANOS DE SAÚDE
                "66" => ClassificacaoCNAE.Contas, // ATIVIDADES AUXILIARES DOS SERVIÇOS FINANCEIROS, SEGUROS, PREVIDÊNCIA COMPLEMENTAR E PLANOS DE SAÚDE
                "68" => ClassificacaoCNAE.Contas, // Atividades imobiliárias
                "97" => ClassificacaoCNAE.Contas, // Serviços domésticos

                "46" => ClassificacaoCNAE.Compras, // Comércio atacado
                "47" => ClassificacaoCNAE.Compras, // Comércio varejista

                "49" => ClassificacaoCNAE.Transporte, // Transporte terrestre
                "50" => ClassificacaoCNAE.Transporte, // Transporte aéreo

                "56" => ClassificacaoCNAE.Alimentacao, // Alimentacao

                "59" => ClassificacaoCNAE.Entretenimento, // Atividades cinematográficas
                "90" => ClassificacaoCNAE.Entretenimento, // Atividades artísticas, criativas e de espetáculos
                "91" => ClassificacaoCNAE.Entretenimento, // Atividades ligadas ao patrimônio cultural e ambiental
                "93" => ClassificacaoCNAE.Entretenimento, // Atividades esportivas e de recreação e lazer

                "85" => ClassificacaoCNAE.Educacao, // Educação

                "86" => ClassificacaoCNAE.Saude, // Atividades de atenção à saúde humana
                "75" => ClassificacaoCNAE.Saude, // Atividades veterinárias

                _ => ClassificacaoCNAE.Outros
            };
        }
    }
}