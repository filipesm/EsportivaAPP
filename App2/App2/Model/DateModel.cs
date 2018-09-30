using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App2.Model
{
    public class DateModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private int id;

        public int Id
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

        private int year;

        public int Year
        {
            get { return year; }
            set { if (year != value) year = value; NotifyPropertyChanged(); }
        }

        private string color;

        public string Color
        {
            get { return color; }
            set { if (color != value) color = value; NotifyPropertyChanged(); }
        }

        private string pantone_value;

        public string Pantone_value
        {
            get { return pantone_value; }
            set { if (pantone_value != value) pantone_value = value; NotifyPropertyChanged(); }
        }

    }
}
