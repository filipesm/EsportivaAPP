using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App2.Model
{
    public class AcontecimentosModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { if (tipo != value) tipo = value; NotifyPropertyChanged(); }
        }

        private int tempo;


        public int Tempo
        {
            get { return tempo; }
            set { if (tempo != value) tempo = value; NotifyPropertyChanged(); }
        }

        private string tempoFormatado;


        public string TempoFormatado
        {
            get { return tempoFormatado; }
            set { if (tempoFormatado != value) tempoFormatado = value; NotifyPropertyChanged(); }
        }


        private string nome_jogador;

        public string Nome_jogador
        {
            get { return nome_jogador; }
            set { if (nome_jogador != value) nome_jogador = value; NotifyPropertyChanged(); }
        }

    }
}
