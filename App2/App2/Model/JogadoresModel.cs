using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App2.Model
{
    public class JogadoresModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private int page;

        public int Page
        {
            get { return page; }
            set { if (page != value) page = value; NotifyPropertyChanged(); }
        }

        private int per_page;

        public int Per_page
        {
            get { return per_page; }
            set { if (per_page != value) per_page = value; NotifyPropertyChanged(); }
        }

        private int total;

        public int Total
        {
            get { return total; }
            set { if (total != value) total = value; NotifyPropertyChanged(); }
        }

        private int total_pages;

        public int Total_pages
        {
            get { return total_pages; }
            set { if (total_pages != value) total_pages = value; NotifyPropertyChanged(); }
        }

        private List<DateModel> data;

        public List<DateModel> Data
        {
            get { return data; }
            set { if (data != value) data = value; NotifyPropertyChanged(); }
        }

    }
}
