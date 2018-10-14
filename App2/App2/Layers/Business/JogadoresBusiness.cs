using App2.Layers.Data;
using App2.Layers.Service;
using App2.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace App2.Layers.Business
{
    public class JogadoresBusiness
    {
        public IList<JogadorSalesForceModel> GetJogadores()
        {

            IList<JogadorSalesForceModel> searchResults = null;

            searchResults = new JogadorSalesForceData().GetList();

            if (searchResults.Count == 0)
            {

                var jogadores = new JogadoresService().GetJogadoresFromSalesForce();

                JObject jObject = JObject.Parse(jogadores);

                IList<JToken> results = jObject["records"].Children().ToList();

                searchResults = new List<JogadorSalesForceModel>();

                foreach (var result in results)
                {
                    JogadorSalesForceModel searchResult = result.ToObject<JogadorSalesForceModel>();
                    searchResults.Add(searchResult);

                    new JogadorSalesForceData().Insert(searchResult);

                }
            }
            return searchResults;
        }

        public void SaveJogador(JogadorSalesForceModel jogadorSalesForce)
        {
            if (!DateTime.TryParseExact(jogadorSalesForce.Data_de_nascimento__c, "dd/MM/yyyy",CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                throw new Exception("Informar formato de data válido (dd/MM/yyyy)");

            var id = new JogadoresService().SaveJogadoresOnSalesForce(jogadorSalesForce);

            jogadorSalesForce.Id = id;

            new JogadorSalesForceData().Insert(jogadorSalesForce);
        }

        public void UpdateJogador(JogadorSalesForceModel jogadorSalesForceModel)
        {
            new JogadoresService().UpdateJogadorOnSalesForce(jogadorSalesForceModel);

            new JogadorSalesForceData().Update(jogadorSalesForceModel);
        }

        internal void DeleteJogador(string id, JogadorSalesForceModel jogadorSalesForceModel)
        {
            new JogadoresService().DeleteJogadorOnSalesForce(id);

            new JogadorSalesForceData().Delete(jogadorSalesForceModel);
        }
    }
}
