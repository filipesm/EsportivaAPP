using App2.Layers.Business;
using App2.Model;
using App2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class JogadorDetalhesViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private JogadorSalesForceModel jogadorSalesForceModel;

        public JogadorSalesForceModel JogadorSalesForceModel
        {
            get { return jogadorSalesForceModel; }
            set { if (jogadorSalesForceModel != value) jogadorSalesForceModel = value; NotifyPropertyChanged(); }
        }

        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public JogadorDetalhesViewModel()
        {
            JogadorSalesForceModel = Global.JogadorSalesForceModel;

            UpdateCommand = new Command(() =>
            {
                try
                {
                    new JogadoresBusiness().UpdateJogador(JogadorSalesForceModel);

                    App.MensagemAlerta("Jogador atualizado com sucesso");

                    MessagingCenter.Send("", "JogadoresAbrir");
                }
                catch (Exception ex)
                {
                    App.MensagemAlerta($"Deu ruim \n{ex.Message}");
                }
            });

            DeleteCommand = new Command(() =>
            {
                new JogadoresBusiness().DeleteJogador(JogadorSalesForceModel.Id, JogadorSalesForceModel);

                App.MensagemAlerta("Jogador excluido com sucesso");

                MessagingCenter.Send("", "JogadoresAbrir");
            });
        }
    }
}
