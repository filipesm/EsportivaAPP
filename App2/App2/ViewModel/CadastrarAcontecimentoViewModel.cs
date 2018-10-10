using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App2.ViewModel
{
    public class CadastrarAcontecimentoViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public List<string> Acontecimentos { get; set; }

        private string acontecimentoSelecionado;

        public string AcontecimentoSelecionado
        {
            get { return acontecimentoSelecionado; }
            set
            {
                if (acontecimentoSelecionado != value)
                {
                    acontecimentoSelecionado = value;
                    Check = $"Evento : {acontecimentoSelecionado}";
                }
            }
        }

        private string check;

        public string Check
        {
            get { return acontecimentoSelecionado; }
            set { if (check != value) check = value; NotifyPropertyChanged(); }
        }



        public CadastrarAcontecimentoViewModel()
        {
            Acontecimentos = new List<string>
            {
                "Chute",
                "Passe",
                "Drible"
            };
        }


    }
}
