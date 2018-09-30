using App2.Layers.Business;
using App2.Model;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class LoginViewModel
    {
        public ICommand LoginClickedCommand { get; private set; }

        public UsuarioModel Usuario { get; set; }

        public LoginViewModel()
        {
            Usuario = new UsuarioModel
            {
                Usuario = "peter@klaven",
                Senha = "cityslicka"
            };

            LoginClickedCommand = new Command(() =>
            {
                try
                {
                    var token = new UsuarioBusiness().Login(Usuario.Usuario, Usuario.Senha);

                    if (token != null)
                    {
                        MessagingCenter.Send(new LoginViewModel(), "LoginSucesso");
                    }

                }
                catch (Exception ex)
                {
                    App.MensagemAlerta(ex.Message);
                }
            });
        }
    }
}
