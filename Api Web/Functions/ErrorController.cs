using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.DataContracts;
using Entidades;
namespace Api_Web.Functions
{
    public class ErrorController
    {
        public LoginResponse GetError(Exception ex) {
            Diccionario diccionario = new Diccionario();
            LoginResponse resp = new LoginResponse();
            resp.ErrorCode = 200;
            resp.Message = diccionario.ErrorDictionary.GetValueOrDefault(ex.Message);
            resp.Description = ex.Message;
            return resp;
        }
    }
}
