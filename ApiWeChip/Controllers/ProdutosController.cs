using ApiWeChip.Models;
using Domain.Interfaces;
using EntitiesWeChip;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiWeChip.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class ProdutosController : Controller
    {
        private readonly IProdutos _IProdutos;

        public ProdutosController(IProdutos IProdutos)
        {
            _IProdutos = IProdutos;
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] Produtos dados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _IProdutos.Add(dados);

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
                return Ok(await _IProdutos.List());
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
                return Ok(await _IProdutos.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResposta<DateTime>(DateTime.Now, false, 400, "Ocorreu um erro"));
            }
        }
        [HttpPost("Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Produtos user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _IProdutos.Update(user);

                return Ok(new ApiResposta<DateTime>(DateTime.Now, true, 200, "Ok"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResposta<DateTime>(DateTime.Now, false, 400, "Ocorreu um erro"));
            }
        }
        [HttpDelete("/Delete")]
        public async Task<IActionResult> Delete([FromBody] Produtos prod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _IProdutos.Delete(prod);

                return Ok(new ApiResposta<DateTime>(DateTime.Now, true, 200, "Ok"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResposta<DateTime>(DateTime.Now, false, 400, "Ocorreu um erro"));
            }
        }
    }
}
