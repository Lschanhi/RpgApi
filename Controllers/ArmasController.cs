using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using RpgApi.Models;
using Microsoft.EntityFrameworkCore;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArmasController : ControllerBase
    {


        private readonly DataContext _context;

        public ArmasController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleArma(int id)
        {
            try
            {
                Armas p = await _context.TB_ARMAS.FirstOrDefaultAsync(pBusca => pBusca.id == id);
                return Ok(p);

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Armas> lista = await _context.TB_ARMAS.ToListAsync();
                return Ok(lista);

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(Armas novaArma)
        {
            try
            {
                if (novaArma.dano > 200)
                {
                    throw new Exception("Dano não pode ultrapassar o limite");
                }
                Personagem p = await _context.TB_PERSONAGENS.FirstOrDefaultAsync(p=>p.Id==novaArma.PersonagemId);
                if(p == null)
                {
                    throw new System.Exception("Não Existe personagem com o Id informado");
                }
                await _context.TB_ARMAS.AddAsync(novaArma);
                await _context.SaveChangesAsync();
                return Ok(novaArma.id);

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Armas novaArma)
        {
            try
            {
                if(novaArma.dano > 150)
                {
                    throw new System.Exception("Não pode aprimorar o dano mais que 150");
                }
                _context.TB_ARMAS.Update(novaArma);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Armas pRemove = await _context.TB_ARMAS.FirstOrDefaultAsync(p => p.id == id);
                _context.TB_ARMAS.Remove(pRemove);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                
               return BadRequest(ex.Message);
            }
        }



   
    }
}