using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App2.Layers.Data.Config;
using Xamarin.Forms;
using Environment = System.Environment;

[assembly: Dependency(typeof(App2.Droid.Layers.Data.Config.DBConfig))]

namespace App2.Droid.Layers.Data.Config
{
    public class DBConfig : IDBConfig
    {
        private string _path;
        public string Path
        {
            get
            {
                if (string.IsNullOrEmpty(_path))
                {
                    _path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                }
                return _path;
            }
        }
    }
}