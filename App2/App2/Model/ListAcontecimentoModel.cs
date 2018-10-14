using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App2.Model
{
    public class ListAcontecimentoModel : INotifyPropertyChanged
    {

                
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        private string id;

        [PrimaryKey]
        public string Id
        {
            get { return id; }
            set { if (id != value) id = value; NotifyPropertyChanged(); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { if (name != value) name = value; NotifyPropertyChanged(); }
        }



    }
}
