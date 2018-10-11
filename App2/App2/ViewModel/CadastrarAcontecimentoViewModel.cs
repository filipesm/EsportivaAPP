using App2.Layers.Business;
using App2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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

        public List<ListAcontecimentoModel> Acontecimentos { get; set; }
        public IList<JogadorSalesForceModel> Jogadores { get; set; }
        
        public CadAcontecimentoModel CadAcontecimentoModel { get; set; }
        public ICommand CadastrarClickedCommand { get; private set; }
    

        public CadastrarAcontecimentoViewModel()
        {
            CadAcontecimentoModel = new CadAcontecimentoModel();
            Acontecimentos = new AcontecimentoBusiness().GetAcontecimento();
            Jogadores = new JogadoresBusiness().GetJogadores();
            CadastrarClickedCommand = new Command(()=>
            {
         
                App.MensagemAlerta($"{CadAcontecimentoModel.Tempo_do_acontecimento__c},{CadAcontecimentoModel.Jogador__c}");
            });
        }

        
    }
}
