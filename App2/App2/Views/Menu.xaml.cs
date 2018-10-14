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
        private void VerPartidasClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send("", "VerPartidasAbrir");
        }
        private void DetalhesTimeClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DetalhesTimeAbrir");
        }
        private void LogoffClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "LogoffClicked");
        }
    }
}