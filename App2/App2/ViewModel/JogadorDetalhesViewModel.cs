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

        public ICommand ChecarIdCommand { get; set; }
        public ICommand VoltarCommand { get; set; }
        public JogadorDetalhesViewModel()
        {
            JogadorSalesForceModel = Global.JogadorSalesForceModel;

            ChecarIdCommand = new Command(() =>
            {
                App.MensagemAlerta($"{JogadorSalesForceModel.Name}, {JogadorSalesForceModel.Apelido__c}, {JogadorSalesForceModel.Posicao__c}");
            });

            VoltarCommand = new Command(() =>
            {
                MessagingCenter.Send(new Jogadores(), "JogadoresAbrir");
            });
        }
    }
}
