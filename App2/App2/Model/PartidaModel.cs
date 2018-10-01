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

        private string nomePartida;

        public string NomeParitda
        {
            get { return nomePartida; }
            set { if (nomePartida != value) nomePartida = value; NotifyPropertyChanged(); }
        }

        private string data;

        public string Data
        {
            get { return data; }
            set { if (data != value) data = value; NotifyPropertyChanged(); }
        }

        private string hora;

        public string Hora
        {
            get { return hora; }
            set { if (hora != value) hora = value; NotifyPropertyChanged(); }
        }

        private string time1;

        public string Time1
        {
            get { return time1; }
            set { if (time1 != value) time1 = value; NotifyPropertyChanged(); }
        }

        private string time2;

        public string Time2
        {
            get { return time2; }
            set { if (time2 != value) time2 = value; NotifyPropertyChanged(); }
        }

        private string localCompeticao;

        public string LocalCompeticao
        {
            get { return localCompeticao; }
            set { if (localCompeticao != value) localCompeticao = value; NotifyPropertyChanged(); }
        }
        private string competicao;

        public string Competicao
        {
            get { return competicao; }
            set { if (competicao != value) competicao = value; NotifyPropertyChanged(); }
        }

        private string escalacao1;

        public string Escalacao1
        {
            get { return escalacao1; }
            set { if (escalacao1 != value) escalacao1 = value; NotifyPropertyChanged(); }
        }

        private string escalacao2;

        public string Escalacao2
        {
            get { return escalacao2; }
            set { if (escalacao2 != value) escalacao2 = value; NotifyPropertyChanged(); }
        }
    }

}
