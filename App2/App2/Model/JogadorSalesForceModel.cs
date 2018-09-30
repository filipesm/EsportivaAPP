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

        private string nome;

        public string Nome
        {
            get { return nome; }
            set { if (nome != value) nome = value; NotifyPropertyChanged(); }
        }

        private string sobreNome;

        public string SobreNome
        {
            get { return sobreNome; }
            set { if (sobreNome != value) sobreNome = value; NotifyPropertyChanged(); }
        }

        private string posicao;

        public string Posicao
        {
            get { return posicao; }
            set { if (posicao != value) posicao = value; NotifyPropertyChanged(); }
        }

        private string nascimento;

        public string Nascimento
        {
            get { return nascimento; }
            set { if (nascimento != value) nascimento = value; NotifyPropertyChanged(); }
        }

        private string time;

        public string Time
        {
            get { return time; }
            set { if (time != value) time = value; NotifyPropertyChanged(); }
        }

        private int numeroCamisa;

        public int NumeroCamisa
        {
            get { return numeroCamisa; }
            set { if (numeroCamisa != value) numeroCamisa = value; NotifyPropertyChanged(); }
        }

        private string apelido;

        public string Apelido
        {
            get { return apelido; }
            set { if (apelido != value) apelido = value; NotifyPropertyChanged(); }
        }

        private double altura;

        public double Altura
        {
            get { return altura; }
            set { if (altura != value) altura = value; NotifyPropertyChanged(); }
        }
    }
}
