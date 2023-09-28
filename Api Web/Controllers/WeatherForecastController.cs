using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Web.Models;
using Api_Web.Functions;
using Entidades.DataContracts;
using Logica_de_negocios;
namespace Api_Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        ArquitecturaCapasDBContext _context = new ArquitecturaCapasDBContext();
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public Response Post([FromBody]Entidades.User user) {
            Servicios services = new Servicios();
            Response us = services.CreateUser(new Entidades.User(user.Id, user.Username, user.Password));
            return us;
        }
        [HttpGet]
        public LoginResponse Get([FromBody]LoginRequest user) {
            Servicios services = new Servicios();
            try
            {
                return services.Login(user);
            }
            catch (Exception e)
            {
                ErrorController errorController = new ErrorController();
                return errorController.GetError(e);
            }
        }
    }
}
