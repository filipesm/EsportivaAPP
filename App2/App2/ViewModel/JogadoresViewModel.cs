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
    public class JogadoresViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private IList<JogadorSalesForceModel> jogadores;

        public IList<JogadorSalesForceModel> Jogadores
        {
            get { return jogadores; }
            set { if (jogadores != value) jogadores = value; NotifyPropertyChanged(); }
        }

        private JogadorSalesForceModel jogadorSelecionado;

        public JogadorSalesForceModel JogadorSelecionado
        {
            get { return jogadorSelecionado; }
            set { if (jogadorSelecionado != value) jogadorSelecionado = value; NotifyPropertyChanged(); }
        }

        public ICommand JogadorTappedCommand { get; set; }
        public ICommand CadastrarJogadorClicked { get; set; }

        public JogadoresViewModel()
        {
            Jogadores = new JogadoresBusiness().GetJogadores();

            JogadorTappedCommand = new Command(() =>
            {
                MessagingCenter.Send(JogadorSelecionado, "JogadorDetalhesAbrir");
            });

            CadastrarJogadorClicked = new Command(() =>
            {
                MessagingCenter.Send(this, "CadastrarJogadorAbrir");
            });
        }
    }
}
