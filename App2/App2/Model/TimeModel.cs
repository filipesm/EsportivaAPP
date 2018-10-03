using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App2.Model
{
    public class TimeModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string name;

        public string Name
        {
            get { return name; }
            set { if (name != value) name = value; NotifyPropertyChanged(); }
        }

        private string sigla__c;

        public string Sigla__c
        {
            get { return sigla__c; }
            set { if (sigla__c != value) sigla__c = value; NotifyPropertyChanged(); }
        }

        private string cor1__c;

        public string Cor1__c
        {
            get { return cor1__c; }
            set { if (cor1__c != value) cor1__c = value; NotifyPropertyChanged(); }
        }

        private string cor2__c;

        public string Cor2__c
        {
            get { return cor2__c; }
            set { if (cor2__c != value) cor2__c = value; NotifyPropertyChanged(); }
        }

        private string cor3__c;

        public string Cor3__c
        {
            get { return cor3__c; }
            set { if (cor3__c != value) cor3__c = value; NotifyPropertyChanged(); }
        }

        private string nacionalidade__c;

        public string Nacionalidade__c
        {
            get { return nacionalidade__c; }
            set { if (nacionalidade__c != value) nacionalidade__c = value; NotifyPropertyChanged(); }
        }

        private string dataDeFundacao__c;

        public string Data_De_Fundacao__c
        {
            get { return dataDeFundacao__c; }
            set { if (dataDeFundacao__c != value) dataDeFundacao__c = value; NotifyPropertyChanged(); }
        }
    }
}
