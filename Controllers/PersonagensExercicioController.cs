
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RpgApi.Models.Emuns;
using RpgApi.Models;

namespace RpgApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PersonagensExercicioController : ControllerBase
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            //Colar os objetos da lista do chat aqui
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida= 110, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=105, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=150, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=200, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 8, Nome = "Felipe", PontosVida=1000, Forca=-1000, Defesa=-1000, Inteligencia=-1000, Classe=ClasseEnum.Mendigo }
        };

        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {

            var listaBusca = personagens.FindAll(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)).Select(p => new
            {
                p.Id,
                p.Nome,
                p.PontosVida,
                p.Forca,
                p.Defesa,
                p.Inteligencia,
                Classe = p.Classe.ToString()
            }).ToList();
            if (listaBusca.Count == 0)
            {
                return NotFound("Not Found! Personagem não existe");
            }
            return Ok(listaBusca);
        }

        [HttpGet("GetClerigoMago")]
        public IActionResult GetClerigoMago()
        {

            int removidos = personagens.RemoveAll(p => p.Classe == ClasseEnum.Cavaleiro || p.Classe == ClasseEnum.Mendigo);

            var listaOrdenada = personagens.OrderByDescending(p => p.PontosVida).Select(p => new
            {
                p.Id,
                p.Nome,
                p.PontosVida,
                p.Forca,
                p.Defesa,
                p.Inteligencia,
                Classe = p.Classe.ToString()

            }).ToList();

            return Ok(listaOrdenada);
        }

        [HttpGet("QtdPersSumInt")]
        public IActionResult GetQtdPersSumInt()
        {
            return Ok("Quantidade Total de Personagens é: " + personagens.Count +
            " Personagens. \nE a Somatória total das Inteligencias deles é: " + personagens.Sum(p => p.Inteligencia) + " pontos");
        }

        [HttpPost("PostValidacao")]
        public IActionResult ValidacaoPersonagem(Personagem novoPersonagem)
        {

            if (novoPersonagem.Defesa < 10)
            {
                return BadRequest("Defesa precisa ser maior que 10 pontos");
            }
            else if (novoPersonagem.Inteligencia > 30)
            {
                return BadRequest("Inteligencia não pode ser Maior que 30 pontos");

            }
            else
            {
                personagens.Add(novoPersonagem);
            }
            return Ok(personagens);
        }


        [HttpPost("PostValidacaoMago")]
        public IActionResult ValidacaoMago(Personagem novoPersonagem)
        {

            if (novoPersonagem.Classe == ClasseEnum.Mago && novoPersonagem.Inteligencia < 35)
            {
                return BadRequest("Personagem do tipo Mago deve ter inteligência maior ou igual a 35.");
            }
            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }

        [HttpGet("GetByClasse/{classeId}")]
        public IActionResult GetPorClasse(int classeId)
        {
            if (classeId  < 1 || classeId > 4)
            {
                return BadRequest("Classe não Encontrada");
            }

            ClasseEnum classeSelecionada = (ClasseEnum)classeId;

            List<Personagem> listaBusca = personagens.FindAll(p => p.Classe == classeSelecionada);
            var listaOriginal = listaBusca.Select(p => new
            {
                p.Id,
                p.Nome,
                p.PontosVida,
                p.Forca,
                p.Defesa,
                p.Inteligencia,
                Classe = p.Classe.ToString()

            }).ToList();

            return Ok(listaOriginal);
        }
        


    }
}