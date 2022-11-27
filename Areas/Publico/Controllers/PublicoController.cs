using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Models;
using Microsoft.Extensions.Options;
using ECommerce.ViewModels;

namespace ECommerce.Areas.Publico.Controllers
{
    [Area("Publico")]
    [Controller]
    [Route("/")]
    public class PublicoController : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> Produtos([FromServices] ECommerceContext context)
        {
            var produtos = await context.Produtos.AsNoTracking().ToListAsync();
            return View("Index", produtos.Where(x => x.Ativo == 1));
        }

        [HttpGet("{id:int}")]
        public IActionResult Produto([FromRoute] int id, [FromServices] ECommerceContext context)
        {
            var produto = context.Produtos.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (produto != null)
                return View("Produto", produto);

            return View("Index");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost("login-validar")]
        public IActionResult ValidaLogin([FromForm] LoginViewModel model, [FromServices] ECommerceContext context)
        {
            var cliente = context.Clientes.FirstOrDefault(x => x.Email == model.Email);

            if (cliente != null)
            {
                if (cliente.Senha == model.Senha)
                    return Redirect("/adm");
            }

            return View("Login", model);
        }

        [HttpGet("cadastro")]
        public IActionResult Cadastro()
        {
            return View("ClienteCadastro");
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastro([FromForm] Cliente modelCliente, [FromServices] ECommerceContext context)
        {
            if (modelCliente == null)
                return Redirect("/cadastro");

            modelCliente.TipoUsuario = "cliente";
            await context.Clientes.AddAsync(modelCliente);
            await context.SaveChangesAsync();
            return View("CadastroFinalizado");
        }
    }
}