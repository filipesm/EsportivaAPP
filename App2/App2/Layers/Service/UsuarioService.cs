using App2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace App2.Layers.Service
{
    public class UsuarioService
    {
        public TokenModel GetUserAPI(string usuario, string senha)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri("https://reqres.in/api/login");
                var user = new { email = usuario, password = senha };
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var result = client.PostAsync(uri, content).Result;
                var jsonString = result.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<TokenModel>(jsonString.Result);

                return token;
            }

        }
    }
}
