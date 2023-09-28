using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Diccionario
    {
        public Dictionary<string, string> ErrorDictionary { get; set; } = new Dictionary<string, string>
        {
            { "Log/Err/001" , "Usuario no encontrado" },
            { "Log/Err/002" , "Password no coincide" },
            { "Log/Err/003" , "Usuario bloqueado" },
            { "Log/Err/004" , "Error al conectarse con la base de datos" },
            { "Log/Err/005" , "El servidor tardo demasiado en responder" },
            { "Log/Err/006" , "Excepción no controlada" }
        };
    }
}
