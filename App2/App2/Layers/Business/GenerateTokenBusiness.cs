using App2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace App2.Layers.Business
{
    public class GenerateTokenBusiness
    {
        public TokenSalesForceModel GetTokenFromSalesForce()
        {
            return Auth();
        }
       

        private static TokenSalesForceModel Auth()
        {
            var _securityKey = "SEgOWkb1C63v5fvZ8eD6OkYVL"; // Recebido por email
            var _clientSecret = "2123739089566497057";
            var _clientId = "3MVG9vrJTfRxlfl7_jbPluPXasCJiEoAX2nWW8MmjSwTrgmG_BusKtdI6brwdleGr5T5NWNoZd13nNbPHBAuh";
            var _grantAcess = "password";
            var _userName = "joaovcabral@fiap.com.br";
            var _password = "jvictor12" + _securityKey;
            var _urlSalesForceAuth = "https://login.salesforce.com/services/oauth2/token";

            var parameters = new Dictionary<string, string> {
                { "client_id", _clientId },
                { "client_secret", _clientSecret },
                { "grant_type" , _grantAcess },
                { "username" , _userName },
                { "password" , _password },
            };

            var encodedContent = new FormUrlEncodedContent(parameters);

            HttpClient client = new HttpClient();
            var response = client.PostAsync(_urlSalesForceAuth, encodedContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;
                TokenSalesForceModel token = JsonConvert.DeserializeObject<TokenSalesForceModel>(conteudoResposta);

                return token;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }

        //private static void InvokeSalesForceAccountApi(string _accessToken)
        //{
        //    var _urlAccountApi = "https://na49.salesforce.com/services/data/v43.0/sobjects/";

        //    var _body = "{ \"Name\" : \"Flavio 3SIA C# 3.0\" }";

        //    StringContent _conteudo = new StringContent(_body, Encoding.UTF8, "application/json");

        //    HttpClient client = new HttpClient();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
        //    var response = client.PostAsync(_urlAccountApi, _conteudo).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var conteudoResposta = response.Content.ReadAsStringAsync().Result;
        //        dynamic json = JsonConvert.DeserializeObject(conteudoResposta);

        //    }
        //    else
        //    {
        //        throw new Exception(response.ReasonPhrase);
        //    }
        //}
    }
}
