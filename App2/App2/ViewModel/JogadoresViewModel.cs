using App2.Layers.Business;
using App2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class JogadoresViewModel
    {


        private IList<DateModel> jogadores;

        public IList<DateModel> Jogadores
        {
            get { return jogadores; }
            set { jogadores = value; }
        }

        private DateModel jogadorSelecionado;

        public DateModel JogadorSelecionado
        {
            get { return jogadorSelecionado; }
            set { jogadorSelecionado = value; }
        }

        public ICommand JogadorTappedCommand { get; set; }

        public JogadoresViewModel()
        {
            Jogadores = new JogadoresBusiness().GetJogadores();

            JogadorTappedCommand = new Command(() =>
            {
                MessagingCenter.Send(JogadorSelecionado, "JogadorDetalhesAbrir");
            });
        }
    }
}
