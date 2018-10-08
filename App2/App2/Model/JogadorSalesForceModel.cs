using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
namespace App2.Model
{
    public class JogadorSalesForceModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private string id;

        public string Id
        {
            get { return id; }
            set { if (id != value) id = value; NotifyPropertyChanged(); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { if (name != value) name = value; NotifyPropertyChanged(); }
        }

        private string data_de_nascimento__c;

        public string Data_de_nascimento__c
        {
            get { return data_de_nascimento__c; }
            set { if (data_de_nascimento__c != value) data_de_nascimento__c = value; NotifyPropertyChanged(); }
        }

        private string posicao__c;

        public string Posicao__c
        {
            get { return posicao__c; }
            set { if (posicao__c != value) posicao__c = value; NotifyPropertyChanged(); }
        }

        private double altura__c;

        public double Altura__c
        {
            get { return altura__c; }
            set { if (altura__c != value) altura__c = value; NotifyPropertyChanged(); }
        }

        private string time__c;

        public string Time__c
        {
            get { return time__c; }
            set { if (time__c != value) time__c = value; NotifyPropertyChanged(); }
        }

        private string sobrenome__c;

        public string Sobrenome__c
        {
            get { return sobrenome__c; }
            set { if (sobrenome__c != value) sobrenome__c = value; NotifyPropertyChanged(); }
        }

        private string apelido__c;

        public string Apelido__c
        {
            get { return apelido__c; }
            set { if (apelido__c != value) apelido__c = value; NotifyPropertyChanged(); }
        }

        private int numero_na_camisa__c;

        public int Numero_na_camisa__c
        {
            get { return numero_na_camisa__c; }
            set { if (numero_na_camisa__c != value) numero_na_camisa__c = value; NotifyPropertyChanged(); }
        }
    }
}
