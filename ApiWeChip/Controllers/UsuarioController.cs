using ApiWeChip.Models;
using Domain.Interfaces;
using EntitiesWeChip;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiWeChip.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuario _IUsuario;

        public UsuarioController(IUsuario ICep)
        {
            _IUsuario = ICep;
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] Usuario dados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _IUsuario.Add(dados);

                return Ok(new ApiResposta<DateTime>(DateTime.Now, true, 200, "Ok"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResposta<DateTime>(DateTime.Now, false, 400, "Ocorreu um erro"));
            }
        }
        [HttpGet("BuscarLista")]
        public async Task<IActionResult> BuscarLista()
        {
            try
            {
                return Ok(await _IUsuario.List());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResposta<DateTime>(DateTime.Now, false, 400, "Ocorreu um erro"));
            }
        }
        [HttpGet("Buscar")]
        public async Task<IActionResult> Buscar(int id)
        {
            try
            {
                return Ok(await _IUsuario.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResposta<DateTime>(DateTime.Now, false, 400, "Ocorreu um erro"));
            }
        }
        [HttpPost("Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Usuario user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _IUsuario.Update(user);

                return Ok(new ApiResposta<DateTime>(DateTime.Now, true, 200, "Ok"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResposta<DateTime>(DateTime.Now, false, 400, "Ocorreu um erro"));
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] Usuario user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _IUsuario.Delete(user);

                return Ok(new ApiResposta<DateTime>(DateTime.Now, true, 200, "Ok"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResposta<DateTime>(DateTime.Now, false, 400, "Ocorreu um erro"));
            }
        }
    }
}
