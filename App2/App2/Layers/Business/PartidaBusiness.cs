using System;
using System.Collections.Generic;
using System.Text;
using App2.Layers.Service;
using App2.Model;

namespace App2.Layers.Business
{
    public class PartidaBusiness
    {
        public void SavePartida(PartidaModel partidaModel)
        {
            new PartidaService().SavePartidaOnSalesforce(partidaModel);
        }
    }
}
