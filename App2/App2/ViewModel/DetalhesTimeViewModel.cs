using App2.Layers.Business;
using App2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App2.ViewModel
{
    class DetalhesTimeViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private DetalhesTimeModel detalhesTime;

        public DetalhesTimeModel DetalhesTime
        {
            get { return detalhesTime; }
            set { if (detalhesTime != value) detalhesTime = value; NotifyPropertyChanged(); }
        }

        public DetalhesTimeViewModel()
        {
            DetalhesTime = new DetalhesTimeModel();

            DetalhesTime = new TimeBusiness().GetDetalheTime();
        }
    }
}
