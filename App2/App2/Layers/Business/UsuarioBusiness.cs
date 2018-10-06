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
    }
}
