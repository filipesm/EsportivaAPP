using App2.Layers.Business;
using App2.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public ICommand LoginClickedCommand { get; private set; }
        public ICommand RegisterClickedCommand { get; private set; }

        private UsuarioModel usuario;

        public UsuarioModel Usuario
        {
            get { return usuario; }
            set { if (usuario != value) usuario = value; NotifyPropertyChanged(); }
        }


        public LoginViewModel()
        {
            Usuario = new UsuarioModel
            {
                Usuario = "admin2",
                Senha = "admin2"
            };

            LoginClickedCommand = new Command(() =>
            {

                var timeId = new UsuarioBusiness().Login(Usuario.Usuario, Usuario.Senha);

                try
                {
                    if (timeId != null)
                    {
                        MessagingCenter.Send("", "LoginSucesso");
                    }
                }
                catch (Exception)
                {

                    App.MensagemAlerta("Usuário não existe");
                }

            });

            RegisterClickedCommand = new Command(() =>
            {
                if (new UsuarioBusiness().Check(Usuario.Usuario))
                {
                    App.MensagemAlerta("Usuario já existe");
                }
                else
                {
                    Global.Usuario = Usuario;
                    MessagingCenter.Send(this, "CadastrarTimeAbrir");
                }
            });
        }
    }
}
