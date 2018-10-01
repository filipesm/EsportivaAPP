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

        private string nome;

        public string Nome
        {
            get { return nome; }
            set { if (nome != value) nome = value; NotifyPropertyChanged(); }
        }

        private string sigla;

        public string Sigla
        {
            get { return sigla; }
            set { if (sigla != value) sigla = value; NotifyPropertyChanged(); }
        }

        private string cor1;

        public string Cor1
        {
            get { return cor1; }
            set { if (cor1 != value) cor1 = value; NotifyPropertyChanged(); }
        }

        private string cor2;

        public string Cor2
        {
            get { return cor2; }
            set { if (cor2 != value) cor2 = value; NotifyPropertyChanged(); }
        }

        private string cor3;

        public string Cor3
        {
            get { return cor3; }
            set { if (cor3 != value) cor3 = value; NotifyPropertyChanged(); }
        }

        private string nacionalidade;

        public string Nacionalidade
        {
            get { return nacionalidade; }
            set { if (nacionalidade != value) nacionalidade = value; NotifyPropertyChanged(); }
        }

        private string dataDeFundacao;

        public string DataDeFundacao
        {
            get { return dataDeFundacao; }
            set { if (dataDeFundacao != value) dataDeFundacao = value; NotifyPropertyChanged(); }
        }
    }
}
