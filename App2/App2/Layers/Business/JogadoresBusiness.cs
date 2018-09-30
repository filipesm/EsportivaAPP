using App2.Layers.Service;
using App2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Layers.Business
{
    public class JogadoresBusiness
    {
        public IList<DateModel> GetJogadores()
        {
            var jogadores = new JogadoresService().GetJogadoresFromSalesForce();

            return jogadores;
        }

        public void SaveJogador()
        {
            var jogadores = new JogadoresService().SaveJogadoresOnSalesForce();

            return jogadores;
        }
    }
}
