using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApi.Dto
{
    public class PersonagemDto
    {
        public int Id { get; set; }
        public string NomePersonagem { get; set; } = string.Empty;
        public int QtdHabilidades { get; set; }
        public int QtdDisputas { get; set; }
        public int PontosVida { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }
        public int Inteligencia { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public string ArmaNome { get; set; }=string.Empty;
        public int ArmaDano { get; set; }
        public string UsuarioNome { get; set; }= string.Empty;
        public string perfil { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HabilidadeNome { get; set; } = string.Empty;
        public int HabilidadeDano { get; set; }
    }
}