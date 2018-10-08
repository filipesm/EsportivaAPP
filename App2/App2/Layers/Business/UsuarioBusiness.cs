using System;
using System.Collections.Generic;
using System.Text;
using App2.Layers.Service;
using App2.Model;

namespace App2.Layers.Business
{
    public class UsuarioBusiness
    {
        public string Login(string usuario, string senha)
        {
            var timeId = new UsuarioService().GetUserAPI(usuario, senha);

            if (timeId == null)
                throw new Exception("Usuário não encontrado");

            return timeId;
        }
        public bool Check(string usuario)
        {
            return new UsuarioService().CheckUserOnSalesforce(usuario);
        }
        public void Register(string timeId)
        {
            new UsuarioService().RegisterUserOnSalesforce(timeId);

        }
    }
}
