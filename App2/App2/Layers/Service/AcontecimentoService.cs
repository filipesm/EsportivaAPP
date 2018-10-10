using App2.Model;
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
    }
}
