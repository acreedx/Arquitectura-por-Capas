using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Entidades.DataContracts;
using Tools;
namespace DAL
{
    public class UserManager
    {
        private ArquitecturaCapasDBContext _context = new ArquitecturaCapasDBContext();
        public Response InsertarUsuario(Entidades.User user)
        {
            Encryption encrypter = new Encryption();
            user.Password = encrypter.HashPassword(user.Password);
            try
            {
                _context.Add(new Models.User(user.Id, user.Username, user.Password));
                _context.SaveChanges();
                user.ErrorCode = 200;
                user.Description = "";
                user.Message = "Usuario guardado correctamente en la base de datos";
                return user;
            }
            catch (Exception e)
            {
                user.ErrorCode = 200;
                user.Description = e.Message;
                user.Message = "Error al insertar el usuario en la base de datos";
                return user;
            }
            
        }
        public LoginResponse Login(LoginRequest user)
        {
            Encryption encrypter = new Encryption();
            string username = user.username;
            string password = user.password;
            if (_context.Users.Any(e => e.Username == username))
            {
                if (encrypter.VerifyPassword(password, _context.Users.Where(e => e.Username == username).FirstOrDefault().Password))
                {
                    LoginResponse resp = new LoginResponse();
                    resp.ErrorCode = 200;
                    resp.Description = "";
                    resp.Message = "Iniciaste sesión";
                    return resp;
                }
                else
                {
                    Exception e = new Exception("Log/Err/002");
                    throw e;
                }
            }
            else
            {
                Exception e = new Exception("Log/Err/001");
                throw e;
            }
        }
    }
}
