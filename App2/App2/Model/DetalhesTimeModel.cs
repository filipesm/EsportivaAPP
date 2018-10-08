using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App2.Model
{
    public class DetalhesTimeModel : INotifyPropertyChanged
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

        private int tomada_de_bola;

        public int Tomada_de_bola
        {
            get { return tomada_de_bola; }
            set { if (tomada_de_bola != value) tomada_de_bola = value; NotifyPropertyChanged(); }
        }

        private int passe_errado;

        public int Passe_errado
        {
            get { return passe_errado; }
            set { if (passe_errado != value) passe_errado = value; NotifyPropertyChanged(); }
        }

        private int passe_certo;

        public int Passe_certo
        {
            get { return passe_certo; }
            set { if (passe_certo != value) passe_certo = value; NotifyPropertyChanged(); }
        }

        private int gol_tomado;
        public int Gol_tomado
        {
            get { return gol_tomado; }
            set { if (gol_tomado != value) gol_tomado = value; NotifyPropertyChanged(); }
        }

        private int gol;
        public int Gol
        {
            get { return gol; }
            set { if (gol != value) gol = value; NotifyPropertyChanged(); }
        }

        private int falta_tomada;
        public int Falta_tomada
        {
            get { return falta_tomada; }
            set { if (falta_tomada != value) falta_tomada = value; NotifyPropertyChanged(); }
        }

        private int falta_cometida;
        public int Falta_cometida
        {
            get { return falta_cometida; }
            set { if (falta_cometida != value) falta_cometida = value; NotifyPropertyChanged(); }
        }

        private int escalacao;
        public int Escalacao
        {
            get { return escalacao; }
            set { if (escalacao != value) escalacao = value; NotifyPropertyChanged(); }
        }

        private int drible;
        public int Drible
        {
            get { return drible; }
            set { if (drible != value) drible = value; NotifyPropertyChanged(); }
        }

        private int defesa;
        public int Defesa
        {
            get { return defesa; }
            set { if (defesa != value) defesa = value; NotifyPropertyChanged(); }
        }

        private int cruzamento;
        public int Cruzamento
        {
            get { return cruzamento; }
            set { if (cruzamento != value) cruzamento = value; NotifyPropertyChanged(); }
        }

        private int chute_para_gol;
        public int Chute_para_gol
        {
            get { return chute_para_gol; }
            set { if (chute_para_gol != value) chute_para_gol = value; NotifyPropertyChanged(); }
        }

        private int chute_para_fora;
        public int Chute_para_fora
        {
            get { return chute_para_fora; }
            set { if (chute_para_fora != value) chute_para_fora = value; NotifyPropertyChanged(); }
        }

        private int cartao_vermelho;
        public int Cartao_vermelho
        {
            get { return cartao_vermelho; }
            set { if (cartao_vermelho != value) cartao_vermelho = value; NotifyPropertyChanged(); }
        }

        private int cartao_amarelo;
        public int Cartao_amarelo
        {
            get { return cartao_amarelo; }
            set { if (cartao_amarelo != value) cartao_amarelo = value; NotifyPropertyChanged(); }
        }
    }
}
