using App2.Layers.Data.Config;
using App2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App2.Layers.Data
{
    public class JogadorSalesForceData
    {
        private DBConnection _dbConn;
        public JogadorSalesForceData()
        {
            _dbConn = new DBConnection();
            _dbConn.Connection.CreateTable<JogadorSalesForceModel>();
        }        public List<JogadorSalesForceModel> GetList()
        {
            return _dbConn.Connection.Table<JogadorSalesForceModel>().Where(p => p.Time__c == Global.TimeId).ToList();
        }
        public JogadorSalesForceModel Get(string _id)
        {
            return _dbConn.Connection.Table<JogadorSalesForceModel>().Where(p => p.Id == _id).SingleOrDefault();
        }        public void Insert(JogadorSalesForceModel _jogador)
        {
            _dbConn.Connection.Insert(_jogador);
        }
        public void Update(JogadorSalesForceModel _jogador)
        {
            _dbConn.Connection.Update(_jogador);
        }
        public void Delete(JogadorSalesForceModel _jogador)
        {
            _dbConn.Connection.Delete(_jogador);
        }
        public void DropTable()
        {
            _dbConn.Connection.DropTable<JogadorSalesForceModel>();
        }
    }
}
