using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App2.Layers.Service;
using App2.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace App2.Layers.Business
{
    public class PartidaBusiness
    {
        public void SavePartida(PartidaModel partidaModel)
        {
            new PartidaService().SavePartidaOnSalesforce(partidaModel);
        }

        public IList<PartidaModel> GetPartida()
        {
            var partidas = new PartidaService().GetPartidaFromSalesforce();

            JObject jObject = JObject.Parse(partidas);

            IList<JToken> results = jObject["records"].Children().ToList();

            IList<PartidaModel> searchResults = new List<PartidaModel>();

            foreach (var result in results)
            {
                PartidaModel searchResult = result.ToObject<PartidaModel>();
                searchResults.Add(searchResult);
            }
            return searchResults;
        }

        public IList<AcontecimentosModel> GetAcontecimentos()
        {

            var acontecimentos = new PartidaService().GetAcontecimentosFromSalesForce();

            return JsonConvert.DeserializeObject<List<AcontecimentosModel>>((JToken.Parse(acontecimentos)).ToString());
        }
    }
}
