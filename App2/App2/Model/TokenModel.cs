using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App2.Model
{
    public class TokenModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private string token;

        public string Token
        {
            get { return token; }
            set { if (token != value) token = value; NotifyPropertyChanged(); }
        }


    }
}
