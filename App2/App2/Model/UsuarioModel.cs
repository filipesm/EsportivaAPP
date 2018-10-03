using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App2.Model
{
    public class UsuarioModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set
            {
                if (value != usuario)
                {
                    usuario = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set
            {
                if (value != senha)
                {
                    senha = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}