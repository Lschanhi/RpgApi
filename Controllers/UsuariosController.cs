using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Utils;

namespace Aula04RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _contex;
        public UsuariosController(DataContext context)
        {
            _contex = context;
        }

        private async Task<bool> UsuarioExistente(string username)
        {
            if (await _contex.TB_USUARIOS.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;


        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try
            {
                if (await UsuarioExistente(user.Username))
                {
                    throw new System.Exception("Nome de usuário já existente");
                }
                else if (String.IsNullOrWhiteSpace(user.PasswordString))
                {
                    throw new System.Exception("Senha não pode ser vazia");
                }
                else if (user.PasswordString.Length < 8)
                {
                    throw new System.Exception("Senha Tem que ter + 8 Caracteres");
                }

                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _contex.TB_USUARIOS.AddAsync(user);
                await _contex.SaveChangesAsync();

                return Ok(user.Id);

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {

                Usuario? usuario = await _contex.TB_USUARIOS.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if (usuario == null)
                {
                    throw new System.Exception("Usuário não Encontrado");
                }
                else if (!Criptografia.VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha Inválida");
                }
                else
                {
                    usuario.DataAcesso = DateTime.Now;
                    _contex.TB_USUARIOS.Update(usuario);
                    return Ok(usuario);

                }
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
                // Busca o usuário pelo ID
                var usuario = await _contex.TB_USUARIOS.FirstOrDefaultAsync(u => u.Id == id);

                // Verifica se existe
                if (usuario == null)
                    return NotFound("Usuário não encontrado.");

                // Remove do banco
                _contex.TB_USUARIOS.Remove(usuario);
                await _contex.SaveChangesAsync();

                return Ok("Usuário removido com sucesso!");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("AlterarSenha")]
        public async Task<IActionResult> AlterarSenha(Usuario credenciais)
        {
            try
            {
                Usuario? usuario = await _contex.TB_USUARIOS.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if (usuario == null)
                {
                    throw new System.Exception("Usuário não Encontrado");
                }
                if (string.IsNullOrWhiteSpace(credenciais.PasswordString))
                    return BadRequest("A nova senha não pode ser vazia.");

                if (credenciais.PasswordString.Length < 8)
                    return BadRequest("A nova senha deve ter pelo menos 8 caracteres.");

                Criptografia.CriarPasswordHash(credenciais.PasswordString, out byte[] novoHash, out byte[] novoSalt);
                bool mesmaSenha = Criptografia.VerificarPasswordHash
                (
                   credenciais.PasswordString,
                   usuario.PasswordHash,
                   usuario.PasswordSalt
               );

                if (mesmaSenha)
                    return BadRequest("A nova senha não pode ser igual à senha atual.");

                // 4️⃣ Atualiza os campos do usuário
                usuario.PasswordHash = novoHash;
                usuario.PasswordSalt = novoSalt;

                // 5️⃣ Salva as alterações
                _contex.TB_USUARIOS.Update(usuario);
                await _contex.SaveChangesAsync();

                return Ok("Senha alterada com sucesso!");

            }
            catch (System.Exception ex)
            {

                return BadRequest($"Erro ao alterar senha: {ex.Message}");
            }
        }
        [HttpGet("ListaUsuarios")]
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                List<Usuario> users = await _contex.TB_USUARIOS.ToListAsync();
                return Ok(users);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }




    }
}