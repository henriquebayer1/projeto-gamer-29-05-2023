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


        [Route("InfoJogador")] //http://localhost/Jogador/InfoJogador
        public IActionResult Index()
        {
            ViewBag.Jogador = c.Jogador.ToList();
            ViewBag.Equipe = c.Equipe.ToList();


            return View();
        }


    [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador = new Jogador();

            novoJogador.User = form["Nome"].ToString();
            // novaEquipe.Imagem = form["Imagem"].ToString();

            if (form.Files.Count > 0)
            {

                var file = form.Files[0];

                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                     file.CopyTo(stream);
                }

                novaEquipe.Imagem = file.FileName;
            }
            else
            {
                novaEquipe.Imagem = "padrao.png";

            }

            c.Equipe.Add(novaEquipe);

            c.SaveChanges();

            return LocalRedirect("~/Equipe/Listar");
        }















        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}