using App2.Layers.Data;
using App2.Layers.Service;
using App2.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App2.Layers.Business
{
    public class AcontecimentoBusiness
    {

        public List<ListAcontecimentoModel> GetAcontecimento()
        {

            IList<ListAcontecimentoModel> searchResults = null;

            searchResults = new AcontecimentoData().GetList();

            if (searchResults.Count == 0)
            {
                var acontecimentos = new AcontecimentoService().GetAcontecimentosFromSalesforce();

                JObject jObject = JObject.Parse(acontecimentos);

                IList<JToken> results = jObject["recentItems"].Children().ToList();

                searchResults = new List<ListAcontecimentoModel>();

                foreach (var result in results)
                {
                    ListAcontecimentoModel searchResult = result.ToObject<ListAcontecimentoModel>();
                    searchResults.Add(searchResult);

                    new AcontecimentoData().Insert(searchResult);
                }
            }
            return searchResults.ToList();
        }

        public void SaveAcontecimento(CadAcontecimentoModel cadAcontecimento)
        {
            new AcontecimentoService().SaveAcontecimentosSalesForce(cadAcontecimento);
        }
    }
}
