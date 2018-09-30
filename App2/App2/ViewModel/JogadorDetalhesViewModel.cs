using App2.Model;
using App2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class JogadorDetalhesViewModel
    {
        private DateModel jogador;

        public DateModel Jogador
        {
            get { return jogador; }
            set { jogador = value; }
        }

        public ICommand ChecarIdCommand { get; set; }
        public ICommand VoltarCommand { get; set; }
        public JogadorDetalhesViewModel()
        {
            Jogador = Global.Jogador;

            ChecarIdCommand = new Command(() =>
            {
                App.MensagemAlerta($"{Jogador.Id}, {Jogador.Name}");
            });

            VoltarCommand = new Command(() =>
            {
                MessagingCenter.Send(new Jogadores(), "JogadoresAbrir");
            });
        }
    }
}
