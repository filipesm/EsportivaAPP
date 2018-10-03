using App2.Layers.Business;
using App2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class CadastrarJogadorViewModel
    {
        public JogadorSalesForceModel JogadorSalesForce { get; set; }

        public ICommand CadastrarCommand { get; private set; }

        public CadastrarJogadorViewModel()
        {
            JogadorSalesForce = new JogadorSalesForceModel();

            CadastrarCommand = new Command(() =>
            {
                new JogadoresBusiness().SaveJogador(JogadorSalesForce);
            });
        }
    }
}
