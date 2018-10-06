using App2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace App2.Layers.Service
{
    public class UsuarioService
    {
        public string GetUserAPI(string usuario, string senha)
        {

            var _urlAccountApi = "https://na49.salesforce.com/services/apexrest/v1/login";

            var _body = JsonConvert.SerializeObject(new { usuario, senha });

            StringContent _conteudo = new StringContent(_body, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.TokenSalesForce.access_token);
            var response = client.PostAsync(_urlAccountApi, _conteudo).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;
                Global.TimeId = JsonConvert.DeserializeObject<string>(conteudoResposta);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

            return Global.TimeId;

        }
    }
}
