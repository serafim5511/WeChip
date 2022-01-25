using EntitiesWeChip;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebWeChip.API;
//using WebWeChip.API;
using WebWeChip.Models;

namespace WebWeChip.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastro()
        {
            return View();
        }
 
        public IActionResult Lista()
        {
            return View(APIUsuario.ApiGetAll().Where(a=>a.FinalizaCliente == false).ToList());
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro(Usuario dados)
        {
            try
            {
                APIUsuario.ApiPost(dados);
                ViewBag.Class = "success";
                ViewBag.Mensagem = "Dados criado com sucesso!";

                return View(dados);
            }
            catch (Exception ex)
            {
                ViewBag.Class = "danger";
                ViewBag.Mensagem = "Erro cadastrar o endereço. Erro :" + ex;
                return View(dados);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Usuario user)
        {
            try
            {
                if (APIUsuario.ApiPostEdit(user))
                {
                    ViewBag.Class = "success";
                    ViewBag.Mensagem = "Dados atualizados com sucesso!";
                }
                else
                {
                    ViewBag.Class = "danger";
                    ViewBag.Mensagem = "Erro na hora de atualizar no banco!";
                }
                return RedirectToAction("Editar", "Home", new { id = user.Id });
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpGet("{id}/Ofertar")]
        public async Task<ActionResult> Ofertar(int id)
        {
            try
            {
                ViewBag.Ofertar = APIProdutos.ApiGetAll();
                return View(APIUsuario.ApiGet(id));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<JsonResult> FinaizarOferta( Usuario user )
        {
            try
            {
                APIUsuario.ApiPostEdit(user);
                return Json(new { });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
