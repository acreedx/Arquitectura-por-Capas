using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.DataContracts;
using DAL;
namespace Logica_de_negocios
{
    public class Servicios
    {
        public Response CreateUser(Entidades.User user) {
            UserManager userManager = new UserManager();
            return userManager.InsertarUsuario(user);
        }
        public LoginResponse Login(LoginRequest user)
        {
            UserManager userManager = new UserManager();
            return userManager.Login(user);
        }
    }
}
