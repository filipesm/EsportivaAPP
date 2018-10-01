using App2.Layers.Business;
using App2.Model;
using App2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class CadastrarTimeViewModel
    {
        public TimeModel TimeModel { get; set; }
        public ICommand CadastrarTimeCommand { get; private set; }
        public ICommand VoltarCommand { get; private set; }

        public CadastrarTimeViewModel()
        {
            TimeModel = new TimeModel();

            CadastrarTimeCommand = new Command(() =>
            {
                new TimeBusiness().SaveTime(TimeModel);
            });

            VoltarCommand = new Command(() =>
            {
                MessagingCenter.Send(new Jogadores(), "JogadoresAbrir");
            });
        }
    }
}
