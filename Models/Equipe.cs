using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGamer.Models
{
    public class Equipe
    {

        [Key]
        public int IdEquipe { get; set; }

        public string Nome { get; set; }

        public string Imagem { get; set; }


//Referencia que a classe equipe vai ter acesso 
//A collection "jogodor"
        public ICollection<Jogador> Jogador {get; set;}

    }
}