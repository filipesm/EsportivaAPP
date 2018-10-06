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
            MessagingCenter.Send("", "JogadoresAbrir");
        }

        private void CadastrarTimeClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "CadastrarTimeAbrir");
        }

        private void CadastrarPartidaClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "CadastrarPartidaAbrir");
        }
    }
}