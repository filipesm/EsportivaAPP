using App2.Layers.Business;
using App2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class CadastrarPartidaViewModel
    {
        public PartidaModel PartidaModel { get; set; }

        public ICommand CadastrarTimeCommand { get; private set; }
        public CadastrarPartidaViewModel()
        {
            PartidaModel = new PartidaModel();

            CadastrarTimeCommand = new Command(() =>
            {
                try
                {
                    new PartidaBusiness().SavePartida(PartidaModel);

                    App.MensagemAlerta("Partida salva com sucesso");

                    MessagingCenter.Send("", "VerPartidasAbrir");
                }
                catch (Exception)
                {
                    App.MensagemAlerta("Dados inválidos ou campos não preenchidos");
                }
            });
        }
    }
}
