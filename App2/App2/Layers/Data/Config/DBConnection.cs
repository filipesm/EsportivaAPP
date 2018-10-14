using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace App2.Layers.Data.Config
{
    public class DBConnection : IDisposable
    {
        public SQLiteConnection Connection { get; }
        public DBConnection()
        {
            var config = DependencyService.Get<IDBConfig>();
            var caminhoArquivoBanco = Path.Combine(config.Path, "fiapcoin.db");
            Connection = new SQLiteConnection(caminhoArquivoBanco);
        }
        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Dispose(); 
            }
        }
    }
}
