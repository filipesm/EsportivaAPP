using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App2.Model
{
    public class CadAcontecimentoModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string jogador__c;

        public string Jogador__c
        {
            get { return jogador__c; }
            set { if (jogador__c != value) jogador__c = value; NotifyPropertyChanged(); }
        }

        private string partida__c;

        public string Partida__c
        {
            get { return partida__c; }
            set { if (partida__c != value) partida__c = value; NotifyPropertyChanged(); }
        }
        private int tempo_do_acontecimento__c;

        public int Tempo_do_acontecimento__c
        {
            get { return tempo_do_acontecimento__c; }
            set { if (tempo_do_acontecimento__c != value) tempo_do_acontecimento__c = value; NotifyPropertyChanged(); }
        }

        private ListAcontecimentoModel listAcontecimentoModel;

        public ListAcontecimentoModel ListAcontecimentoModel
        {
            get { return listAcontecimentoModel; }
            set { if (listAcontecimentoModel != value) listAcontecimentoModel = value; NotifyPropertyChanged(); }
        }

        private JogadorSalesForceModel jogadorSalesForceModel;

        public JogadorSalesForceModel JogadorSalesForceModel
        {
            get { return jogadorSalesForceModel; }
            set { if (jogadorSalesForceModel != value) jogadorSalesForceModel= value; NotifyPropertyChanged(); }
        }





    }
}
