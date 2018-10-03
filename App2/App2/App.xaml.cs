using App2.Layers.Business;
using App2.Model;
using App2.ViewModel;
using App2.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Login();
        }

        protected override void OnStart()
        {
            Global.TokenSalesForce = new GenerateTokenBusiness().GetTokenFromSalesForce();
            MessagingCenter.Subscribe<LoginViewModel>(new LoginViewModel(), "LoginSucesso", (sender) =>
            {
                MainPage = new Principal();
            });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        internal static void MensagemAlerta(string texto)
        {
            Current.MainPage.DisplayAlert("Título", texto, "Ok");
        }
    }
}
