using System;
using System.Collections.Generic;
using System.Text;
using App2.Layers.Service;
using App2.Model;
using Newtonsoft.Json;

namespace App2.Layers.Business
{
    public class TimeBusiness
    {
        public string SaveTime(TimeModel timeModel)
        {
            return new TimeService().SaveTimeOnSalesForce(timeModel);
        }

        public DetalhesTimeModel GetDetalheTime()
        {
            var dados = new TimeService().GetDetalhesTimeSalesForce();
            DetalhesTimeModel detalhes = dados.ToObject<DetalhesTimeModel>();            

            return detalhes;
        }
    }
}
