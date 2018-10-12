using App2.Model;
using App2.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace App2.Layers.Service
{
    public class AcontecimentoService
    {

       
        public string GetAcontecimentosFromSalesforce()
        {
            
            var _urlAccountApi = "https://na49.salesforce.com/services/data/v43.0/sobjects/Acontecimentotype__c";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.TokenSalesForce.access_token);

            var resposta = client.GetAsync(_urlAccountApi).Result;

            if (resposta.IsSuccessStatusCode)
            {
                var resultado = resposta.Content.ReadAsStringAsync().Result;

                return resultado;
            }
            else
            {
                throw new Exception("Perfis não encontrados!");
            }
            
        }

        public void SaveAcontecimentosSalesForce(CadAcontecimentoModel cadAcontecimento)
        {
            var _urlAccountApi = "https://na49.salesforce.com/services/data/v43.0/sobjects/Acontecimento__c";

            var _body = JsonConvert.SerializeObject(
                new
                {
                    Jogador__c = cadAcontecimento.JogadorSalesForceModel.Id,
                    Partida__c = Global.PartidaId,
                    cadAcontecimento.Tempo_do_acontecimento__c,
                    Time__c = Global.TimeId,
                    AcontecimentoType__c = cadAcontecimento.ListAcontecimentoModel.Id
                });

            StringContent _conteudo = new StringContent(_body, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.TokenSalesForce.access_token);
            var response = client.PostAsync(_urlAccountApi, _conteudo).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(conteudoResposta);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }
    }
}
