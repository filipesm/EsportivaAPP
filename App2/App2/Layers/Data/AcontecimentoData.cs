﻿using App2.Layers.Data.Config;
using App2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App2.Layers.Data
{
    public class AcontecimentoData
    {
        private DBConnection _dbConn;
        public AcontecimentoData()
        {
            _dbConn = new DBConnection();
            _dbConn.Connection.CreateTable<ListAcontecimentoModel>();
        }
        {
            return _dbConn.Connection.Table<ListAcontecimentoModel>().ToList();
        }
        {
            _dbConn.Connection.Insert(acontecimento);
        }
        public void DropTable()
        {
            _dbConn.Connection.DropTable<ListAcontecimentoModel>();
        }
    }
}