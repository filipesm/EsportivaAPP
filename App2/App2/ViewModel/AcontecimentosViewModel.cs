using App2.Layers.Business;
using App2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class AcontecimentosViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private IList<AcontecimentosModel> acontecimentos;

        public IList<AcontecimentosModel> Acontecimentos
        {
            get { return acontecimentos; }
            set { if (acontecimentos != value) acontecimentos = value; NotifyPropertyChanged(); }
        }

        public ICommand CadastrarAcontecimentoClicked { get; private set; }

        public AcontecimentosViewModel()
        {
            Acontecimentos = new PartidaBusiness().GetAcontecimentos();

            CadastrarAcontecimentoClicked = new Command(() =>
            {
                MessagingCenter.Send(this, "CadastrarAcontecimentoClicked");
            });
        }
    }
}
