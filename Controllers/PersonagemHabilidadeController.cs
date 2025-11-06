using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;

namespace Aula04RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemHabilidadeController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonagemHabilidadeController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagemHabilidade(PersonagemHabilidade novoPersonagemHabilidade)
        {
            try
            {
                Personagem personagem = await _context.TB_PERSONAGENS.Include(p => p.Arma).Include(p => p.PersonagemHabilidades).ThenInclude(ps => ps.Habilidade)
                .FirstOrDefaultAsync(p => p.Id == novoPersonagemHabilidade.PersonagemId);

                if (personagem == null)
                {
                    throw new System.Exception("Personagem Não Encontrado para o Id informado");
                }

                Habilidade habilidade = await _context.TB_HABILIDADE.FirstOrDefaultAsync(h => h.Id == novoPersonagemHabilidade.HabilidadeId);

                if (habilidade == null)
                {
                    throw new System.Exception("Habilidade Não Encontrada");
                }


                PersonagemHabilidade ph = new PersonagemHabilidade();
                ph.Personagem = personagem;
                ph.Habilidade = habilidade;
                await _context.TB_PERSONAGENS_HABILIDADES.AddAsync(ph);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message + " - "+ ex.InnerException);
            }
        }

        [HttpGet("ListaPH/{personagemId}")]
        public async Task<IActionResult> ListaPH(int personagemId)
        {
            try
            {
                List<PersonagemHabilidade> habilidades = await _context.TB_PERSONAGENS_HABILIDADES
                .Where(ph => ph.PersonagemId == personagemId)
                .Include(ph => ph.Habilidade)   // opcional, caso queira trazer os dados completos da habilidade
                .Include(ph => ph.Personagem)   // opcional, caso queira trazer o personagem também
                .ToListAsync();

                if (habilidades == null || habilidades.Count == 0)
                    return NotFound("Nenhuma habilidade encontrada para esse personagem.");

                return Ok(habilidades);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message + " - "+ ex.InnerException);
            }
        }

        [HttpGet("GetHabilidades")]
        public async Task<IActionResult> GetHabilidades()
        {
            try
            {
                // Busca todas as habilidades no banco
                var habilidades = await _context.TB_HABILIDADE.ToListAsync();

                return Ok(habilidades);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - "+ ex.InnerException);
            }
        }
        [HttpPost("DeletePersonagemHabilidade")]
        public async Task<IActionResult> DeletePersonagemHabilidade(PersonagemHabilidade ph)
        {
            try
            {
                var personagemHabilidade = await _context.TB_PERSONAGENS_HABILIDADES
                    .FirstOrDefaultAsync(x => x.PersonagemId == ph.PersonagemId && x.HabilidadeId == ph.HabilidadeId);

                if (personagemHabilidade == null)
                    return NotFound("Registro não encontrado.");

                _context.TB_PERSONAGENS_HABILIDADES.Remove(personagemHabilidade);
                await _context.SaveChangesAsync();

                return Ok("Registro removido com sucesso!");
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message + " - "+ ex.InnerException);
            }

        }

    }
}