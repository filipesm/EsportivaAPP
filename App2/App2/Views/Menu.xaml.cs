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
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void ContatoClicked(object o, EventArgs e)
        {
            MessagingCenter.Send(new Contato(), "ContatoAbrir");
        }
        private void QuemSomosClicked(object o, EventArgs e)
        {
            MessagingCenter.Send(new QuemSomos(), "QuemSomosAbrir");
        }
        private void BotaoJogadoresClicked(object o, EventArgs e)
        {
            MessagingCenter.Send(new Jogadores(), "JogadoresAbrir");
        }
    }
}