using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Dto;

namespace RpgApi.Services
{
    public class PersonagensServices
    {
        private readonly DataContext _context;
        public PersonagensServices(DataContext context)
        {
            _context = context;
        }

        public async Task<List<PersonagemDto>> ListarPersonagens(int id, int classeId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select ");
            sql.AppendLine("p.Id, ");
            sql.AppendLine("p.Nome [NomePersonagem], ");

            sql.AppendLine("case p.Classe ");
            sql.AppendLine("when 1 then 'Cavaleiro' ");
            sql.AppendLine("when 2 then 'Mago' ");
            sql.AppendLine("when 3 then 'Clerigo' ");
            sql.AppendLine("else 'Não definido' ");
            sql.AppendLine("end Classe, ");

            sql.AppendLine("(select count(subHab.PersonagemId) ");
            sql.AppendLine("from TB_PERSONAGENS_HABILIDADES subHab ");
            sql.AppendLine("where subHab.PersonagemId = p.Id) QtdHabilidades, ");


            sql.AppendLine("(select count(subDis.Id) ");
            sql.AppendLine("from TB_DISPUTAS subDis ");
            sql.AppendLine("where subDis.AtacanteId = p.Id or subDis.OponenteId = p.Id) QtdDisputas, ");


            sql.AppendLine("p.PontosVida, ");
            sql.AppendLine("p.Forca, ");
            sql.AppendLine("p.Defesa, ");
            sql.AppendLine("p.Inteligencia, ");
            sql.AppendLine("p.Vitorias, ");
            sql.AppendLine("p.Derrotas, ");
            sql.AppendLine("ar.Nome[ArmaNome], ");
            sql.AppendLine("ar.Dano[ArmaDano], ");
            sql.AppendLine("us.Username[UsuarioNome], ");
            sql.AppendLine("us.Perfil, ");
            sql.AppendLine("us.Email, ");
            sql.AppendLine("h.Nome[HabilidadeNome], ");
            sql.AppendLine("h.Dano[HabilidadeDano] ");

            sql.AppendLine("from TB_PERSONAGENS p ");
            sql.AppendLine("inner ");
            sql.AppendLine("join TB_ARMAS ar on p.Id = ar.PersonagemId ");
            sql.AppendLine("inner ");
            sql.AppendLine("join TB_USUARIOS us on p.UsuarioId = us.Id ");
            sql.AppendLine("inner ");
            sql.AppendLine("join TB_PERSONAGENS_HABILIDADES ph on p.Id = ph.PersonagemId ");
            sql.AppendLine("inner ");
            sql.AppendLine("join TB_HABILIDADES h on ph.HabilidadeId = h.Id ");
            
            sql.AppendLine("where 1 = 1");

            if(id !=0)
            {
                sql.AppendLine("where p.Id = @id and us.Id = 1 ");
                sqlParameters.Add(new SqlParameter("@id", id));
            }

            if(classeId != 0)
            {
                sql.AppendLine("and p.Classe = @classeId ");
                sqlParameters.Add(new SqlParameter("@classeId", classeId));
            }


            sql.AppendLine("order by p.PontosVida desc, p.Vitorias desc  ");
            

            var lista = _context.Database.SqlQueryRaw<PersonagemDto>(sql.ToString(),sqlParameters.ToArray());

            return lista.ToList();

            }
        }
    }