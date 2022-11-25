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

        [HttpGet("/login")]
        public IActionResult Cadastro()
        {
            return View("Login");
        }

        // [HttpPost("insert")]
        // public async Task<IActionResult> Cadastro(IFormFile file, [FromForm] Produto produtoModel, [FromServices] ECommerceContext context)
        // {

        //     // Recebendo e salvando a aimagem
        //     if (file == null)
        //     {
        //         return Redirect("/cadastro");
        //     }

        //     var originName = file.FileName.Split(".")[0];
        //     var originType = file.FileName.Split(".")[1];

        //     string fileName = $"{originName}_{Guid.NewGuid().ToString()}.{originType}";
        //     var newPath = Path.Combine("wwwroot/image/produtos/", fileName);

        //     using (var stream = new FileStream(newPath, FileMode.Create))
        //         await file.CopyToAsync(stream);
            
        //     // Savando o produto
        //     double price = produtoModel.Price / 100;
        //     produtoModel.Price = price;
        //     produtoModel.Image = newPath.Substring(8);

        //     var resultado = context.Produtos.Add(produtoModel);
        //     context.SaveChanges();
        //     return Redirect("/");
        // }

        // [HttpGet("/delete/{id:int}")]
        // public async Task<IActionResult> Lixeira([FromRoute] int id, [FromServices] ECommerceContext context)
        // {
        //     var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        //     if (produto == null)
        //         return Redirect("/");

        //     produto.Ativo = 0;
        //     context.Produtos.Update(produto);
        //     await context.SaveChangesAsync();
        //     return Redirect("/");
        // }

        // [HttpGet("/ativar/{id:int}")]
        // public async Task<IActionResult> Ativar([FromRoute] int id, [FromServices] ECommerceContext context)
        // {
        //     var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        //     if (produto == null)
        //         return Redirect("/");

        //     produto.Ativo = 1;
        //     context.Produtos.Update(produto);
        //     await context.SaveChangesAsync();
        //     return Redirect("/");
        // }
    }
}