using App2.Model;
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

            MessagingCenter.Subscribe<Contato>(new Contato(), "ContatoAbrir", (sender) =>
            {
                Detail = new NavigationPage(new Contato());
                IsPresented = false;
            });

            MessagingCenter.Subscribe<QuemSomos>(new QuemSomos(), "QuemSomosAbrir", (sender) =>
            {
                Detail = new NavigationPage(new QuemSomos());
                IsPresented = false;
            });

            MessagingCenter.Subscribe<Jogadores>(new Jogadores(), "JogadoresAbrir", (sender) =>
            {
                Detail = new NavigationPage(new Jogadores());
                IsPresented = false;
            });

            MessagingCenter.Subscribe<DateModel>(new DateModel(), "JogadorDetalhesAbrir", (sender) =>
            {
                Global.Jogador = sender;
                Detail = new NavigationPage(new JogadorDetalhes());
                IsPresented = false;
            });

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Contato>(this, "ContatoAbrir");
            MessagingCenter.Unsubscribe<QuemSomos>(this, "QuemSomosAbrir");
            MessagingCenter.Unsubscribe<Jogadores>(this, "JogadoresAbrir");
        }
    }
}