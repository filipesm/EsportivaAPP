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
                Usuario = "root",
                Senha = "root"
            };

            LoginClickedCommand = new Command(() =>
            {

                var timeId = new UsuarioBusiness().Login(Usuario.Usuario, Usuario.Senha);

                try
                {
                    if (timeId != null)
                    {
                        MessagingCenter.Send(this, "LoginSucesso");
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
