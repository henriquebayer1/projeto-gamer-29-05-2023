using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoGamer.Infra;
using ProjetoGamer.Models;

namespace ProjetoGamer.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        [TempData]
        public string Message { get; set; }

        Context c = new Context();
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }


        [Route("Login")]
        public IActionResult Index()
        {

            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            return View();
        }



        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {

            string email = form["Email"].ToString();
            string senha = form["Senha"].ToString();

            Jogador jogadorBuscado = c.Jogador.FirstOrDefault(j => j.Email == email && j.Senha == senha);

            //Aqui implementamos a sessao do usuario  (feito na program.cs com a documentacao)

            if (jogadorBuscado != null)
            {
                HttpContext.Session.SetString("UserName", jogadorBuscado.Nome);
                return LocalRedirect("~/");
            }

            Message = "Dados Invalidos!";
            return LocalRedirect("~/Login/Login");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}