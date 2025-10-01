using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RpgApi.Models.Emuns;

namespace RpgApi.Models
{
    public class Personagem
    {
       
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int PontosVida { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }
        public int Inteligencia { get; set; }
        public ClasseEnum Classe { get; set; }
        public byte[]? FotoPersonagem {get; set;}
        public int? UsuarioId {get; set;}
        public Usuario? Usuario {get; set;}

        [JsonIgnore]
        public Armas? Arma { get; set; }
        public int Disputas { get; set; } 
        public int Vitorias { get; set; }
        public int Derotas { get; set; }

        public List<PersonagemHabilidade> PersonagemHabilidades{get; set;} = [];

    }
}