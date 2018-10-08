using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App2.Model
{
    public class PartidaModel : INotifyPropertyChanged
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

        private string data_da_partida__c;

        public string Data_da_partida__c
        {
            get { return data_da_partida__c; }
            set { if (data_da_partida__c != value) data_da_partida__c = value; NotifyPropertyChanged(); }
        }

        private string time_1__C;

        public string Time_1__C
        {
            get { return time_1__C; }
            set { if (time_1__C != value) time_1__C = value; NotifyPropertyChanged(); }
        }

        private string local_competicao__c;

        public string Local_competicao__c
        {
            get { return local_competicao__c; }
            set { if (local_competicao__c != value) local_competicao__c = value; NotifyPropertyChanged(); }
        }
        private string competicao__C;

        public string Competicao__C
        {
            get { return competicao__C; }
            set { if (competicao__C != value) competicao__C = value; NotifyPropertyChanged(); }
        }
    }

}
