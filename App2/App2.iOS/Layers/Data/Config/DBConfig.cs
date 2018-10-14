using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App2.Layers.Data.Config;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(App2.iOS.Layers.Data.Config.DBConfig))]
namespace App2.iOS.Layers.Data.Config
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
                    _path = System.IO.Path.Combine(_path, "..", "Library");
                }
                return _path;
            }
        }
    }
}