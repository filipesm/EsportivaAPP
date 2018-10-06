using App2.Model;
using App2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : MasterDetailPage
    {
        public Principal()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<string>(this, "JogadoresAbrir", (sender) =>
            {
                Detail = new NavigationPage(new Jogadores());
                IsPresented = false;
            });

            MessagingCenter.Subscribe<JogadoresViewModel>(this, "CadastrarJogadorAbrir", (sender) =>
            {
                Detail = new NavigationPage(new CadastrarJogador());
                IsPresented = false;
            });

            //MessagingCenter.Subscribe<Menu>(this, "CadastrarTimeAbrir", (sender) =>
            //{
            //    Detail = new NavigationPage(new CadastrarTime());
            //    IsPresented = false;
            //});

            MessagingCenter.Subscribe<Menu>(this, "CadastrarPartidaAbrir", (sender) =>
            {
                Detail = new NavigationPage(new CadastrarPartida());
                IsPresented = false;
            });

            MessagingCenter.Subscribe<JogadorSalesForceModel>(this, "JogadorDetalhesAbrir", (sender) =>
            {
                Global.JogadorSalesForceModel = sender;
                Detail = new NavigationPage(new JogadorDetalhes());
                IsPresented = false;
            });

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Jogadores>(this, "JogadoresAbrir");
            MessagingCenter.Unsubscribe<CadastrarJogador>(this, "CadastrarJogadorAbrir");
            MessagingCenter.Unsubscribe<CadastrarTime>(this, "CadastrarTimeAbrir");
            MessagingCenter.Unsubscribe<JogadorDetalhes>(this, "CadastrarPartidaAbrir");
            MessagingCenter.Unsubscribe<JogadorDetalhes>(this, "JogadorDetalhesAbrir");
        }
    }
}