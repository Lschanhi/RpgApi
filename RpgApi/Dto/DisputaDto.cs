using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApi.Dto
{
    public class DisputaDto
    {
        public int Id { get; set; }
        public string Atacante { get; set; }= string.Empty;
        public string Oponente { get; set; } = string.Empty;

        public string Narracao { get; set; } = string.Empty;

        public string NomeUsuario { get; set; } = string.Empty;
        
    }
}