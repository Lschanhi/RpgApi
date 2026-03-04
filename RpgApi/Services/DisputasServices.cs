using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Dto;

namespace RpgApi.Services
{
    public class DisputasServices
    {
        private readonly DataContext _context;
        public DisputasServices(DataContext context)
        {
            _context = context;
        }

        public async Task<List<DisputaDto>> ObterDisputas()
        {
            var resultado = _context.Database.SqlQueryRaw<DisputaDto>
             (@"    SELECT 
                    DISPUTAS.AtacanteId, 
                    ATACANTE.Nome AS AtacanteNome,
                    ATACANTEARMA.nome AS NomeArma,
                    ATACANTEARMA.dano AS DanoArma,
                    DISPUTAS.OponenteId, 
                    OPONENTE.Nome AS OponenteNome,  
                    OPONENTE.Defesa, 
                    DISPUTAS.Tx_Narracao
                FROM TB_DISPUTAS DISPUTAS 
                INNER JOIN TB_PERSONAGENS ATACANTE ON DISPUTAS.AtacanteId = ATACANTE.Id
                INNER JOIN TB_PERSONAGENS OPONENTE ON DISPUTAS.OponenteId = OPONENTE.Id
                INNER JOIN TB_ARMAS ATACANTEARMA ON ATACANTEARMA.PersonagemId = ATACANTE.Id
                INNER JOIN TB_USUARIOS USUARIOATACANTE ON ATACANTE.UsuarioId = USUARIOATACANTE.Id
                INNER JOIN TB_USUARIOS USUARIOOPONENTE ON OPONENTE.UsuarioId = USUARIOOPONENTE.Id;
"
            );
            return resultado.ToList();
        }

    }
}