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
        private void BotaoJogadoresClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(new Jogadores(), "JogadoresAbrir");
        }

        private void CadastrarJogadorClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(new CadastrarJogador(), "CadastrarJogadorAbrir");
        }

        private void CadastrarTimeClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(new CadastrarTime(), "CadastrarTimeAbrir");
        }

        private void CadastrarPartidaClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(new CadastrarPartida(), "CadastrarPartidaAbrir");
        }
    }
}