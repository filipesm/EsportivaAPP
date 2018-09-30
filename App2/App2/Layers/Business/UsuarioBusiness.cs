using System;
using System.Collections.Generic;
using System.Text;
using App2.Layers.Service;
using App2.Model;

namespace App2.Layers.Business
{
    public class UsuarioBusiness
    {
        public TokenModel Login(string usuario, string senha)
        {
            var token = new UsuarioService().GetUserAPI(usuario, senha);

            if (token.Token == null)
                throw new Exception("Usuário não encontrado");

            return token;
        }
    }
}
