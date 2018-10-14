using App2.Layers.Data.Config;
using App2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App2.Layers.Data
{
    public class PartidaData
    {
        private DBConnection _dbConn;
        public PartidaData()
        {
            _dbConn = new DBConnection();
            _dbConn.Connection.CreateTable<PartidaModel>();
        }        public List<PartidaModel> GetList()
        {
            return _dbConn.Connection.Table<PartidaModel>().Where(p => p.Time_1__C == Global.TimeId).ToList();
        }        public void Insert(PartidaModel partida)
        {
            _dbConn.Connection.Insert(partida);
        }

        public void DropTable()
        {
            _dbConn.Connection.DropTable<PartidaModel>();
        }
    }
}
