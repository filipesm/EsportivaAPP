using App2.Layers.Business;
using App2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class PartidaViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private IList<PartidaModel> partidas;

        public IList<PartidaModel> Partidas
        {
            get { return partidas; }
            set { if (partidas != value) partidas = value; NotifyPropertyChanged(); }
        }

        private PartidaModel partidaSelecionada;

        public PartidaModel PartidaSelecionada
        {
            get { return partidaSelecionada; }
            set { if (partidaSelecionada != value) partidaSelecionada = value; NotifyPropertyChanged(); }
        }

        public ICommand PartidaTappedCommand { get; set; }
        public ICommand CadastrarPartidaClicked { get; set; }

        public PartidaViewModel()
        {
            Partidas = new PartidaBusiness().GetPartida();

            CadastrarPartidaClicked = new Command(() =>
            {
                MessagingCenter.Send(this, "CadastrarPartidaAbrir");
            });

            PartidaTappedCommand = new Command(() =>
            {
                MessagingCenter.Send(PartidaSelecionada.Id, "AcontecimentosAbrir");
            });
        }
    }
}
