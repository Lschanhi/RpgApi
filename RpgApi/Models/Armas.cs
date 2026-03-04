using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RpgApi.Models
{
    public class Armas
    {
        public int id { get; set; }
        public string nome { get; set; }    
        public int dano { get; set; }
        public Personagem? Personagem { get; set; }
        public int? PersonagemId { get; set; }
       
    }
}