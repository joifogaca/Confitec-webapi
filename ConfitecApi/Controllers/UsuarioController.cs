using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfitecApi.Data;
using ConfitecApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfitecApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IRepository _repo;
        public UsuarioController(IRepository repository) {
            this._repo = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() 
        {
            try
            {
                var result = await _repo.GetAllUsuarioAsync();
                return Ok(result);

            }
            catch (System.Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }
            
        }

        [HttpGet("{UsuarioId}")]
        public async Task<IActionResult> GetByAlunoId(int UsuarioId)
        {
            try
            {
                var result = await _repo.GetUsuarioById(UsuarioId);
                return Ok(result);

            }
            catch (System.Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            try
            {
                _repo.Add(usuario);

                if (await _repo.SaveChangesAsync()) {
                    return Ok(usuario);
                }
                

            }
            catch (System.Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();

        }

        [HttpPut("{usuarioId}")]
        public async Task<IActionResult> put(int usuarioId, Usuario model)
        {
            try
            {
                var user = await _repo.GetUsuarioById(usuarioId);

                if (user == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }


            }
            catch (System.Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();

        }

        [HttpDelete("{usuarioId}")]
        public async Task<IActionResult> delete(int usuarioId)
        {
            try
            {
                var user = await _repo.GetUsuarioById(usuarioId);

                if (user == null) return NotFound();

                _repo.Delete(user);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok("Deletado com sucesso!");
                }


            }
            catch (System.Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();

        }


    }
}
