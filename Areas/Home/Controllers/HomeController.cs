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

namespace ECommerce.Areas.Home.Controllers
{
    [Area("Home")]
    [Controller]
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll([FromServices] ECommerceContext context)
        {
            var produtos = await context.Produtos.AsNoTracking().ToListAsync();
            return View("Index", produtos.Where(x => x.Ativo == 1));
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id, [FromServices] ECommerceContext context)
        {
            var produto = context.Produtos.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (produto != null)
                return View("Produto", produto);

            return View("Index");
        }

        [HttpGet("login")]
        public IActionResult Cadastro()
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
    }
}