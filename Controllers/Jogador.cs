using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoGamer.Infra;

namespace ProjetoGamer.Controllers
{
    [Route("[controller]")]
    public class Jogador : Controller
    {
        private readonly ILogger<Jogador> _logger;

        public Jogador(ILogger<Jogador> logger)
        {
            _logger = logger;
        }


        Context c = new Context();

        public IActionResult Index()
        {
            ViewBag.Jogador = c.Jogador.ToList();
            ViewBag.Equipe = c.Equipe.ToList();


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}