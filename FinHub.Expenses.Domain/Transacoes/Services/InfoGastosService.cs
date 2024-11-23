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
        public ClassificacaoTransacao ClassificarCNAE(string cnae)
        {
            string prefixoCNAE = cnae.Substring(0, 2);

            return prefixoCNAE switch
            {
                "35" => ClassificacaoTransacao.Contas, // Eletricidade e gás
                "36" => ClassificacaoTransacao.Contas, // Água
                "37" => ClassificacaoTransacao.Contas, // Água
                "38" => ClassificacaoTransacao.Contas, // Água
                "39" => ClassificacaoTransacao.Contas, // Água
                "41" => ClassificacaoTransacao.Contas, // Construção
                "42" => ClassificacaoTransacao.Contas, // Construção
                "43" => ClassificacaoTransacao.Contas, // Construção
                "61" => ClassificacaoTransacao.Contas, // Telecomunicações
                "65" => ClassificacaoTransacao.Contas, // SEGUROS, RESSEGUROS, PREVIDÊNCIA COMPLEMENTAR E PLANOS DE SAÚDE
                "66" => ClassificacaoTransacao.Contas, // ATIVIDADES AUXILIARES DOS SERVIÇOS FINANCEIROS, SEGUROS, PREVIDÊNCIA COMPLEMENTAR E PLANOS DE SAÚDE
                "68" => ClassificacaoTransacao.Contas, // Atividades imobiliárias
                "97" => ClassificacaoTransacao.Contas, // Serviços domésticos

                "46" => ClassificacaoTransacao.Compras, // Comércio atacado
                "47" => ClassificacaoTransacao.Compras, // Comércio varejista

                "49" => ClassificacaoTransacao.Transporte, // Transporte terrestre
                "50" => ClassificacaoTransacao.Transporte, // Transporte aéreo

                "56" => ClassificacaoTransacao.Alimentacao, // Alimentacao

                "59" => ClassificacaoTransacao.Entretenimento, // Atividades cinematográficas
                "90" => ClassificacaoTransacao.Entretenimento, // Atividades artísticas, criativas e de espetáculos
                "91" => ClassificacaoTransacao.Entretenimento, // Atividades ligadas ao patrimônio cultural e ambiental
                "93" => ClassificacaoTransacao.Entretenimento, // Atividades esportivas e de recreação e lazer

                "85" => ClassificacaoTransacao.Educacao, // Educação

                "86" => ClassificacaoTransacao.Saude, // Atividades de atenção à saúde humana
                "75" => ClassificacaoTransacao.Saude, // Atividades veterinárias

                _ => ClassificacaoTransacao.Outros
            };
        }
    }
}