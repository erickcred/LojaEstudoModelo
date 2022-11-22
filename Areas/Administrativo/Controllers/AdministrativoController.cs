using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetInicio.Data;
using AspNetInicio.Models;
using Microsoft.Extensions.Options;

namespace AspNetInicio.Controllers
{
    [Area("Administrativo")]
    [Controller]
    [Route("/adm/")]
    public class AdministrativoController : Controller
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return View("Index");
        }

        [HttpGet("produtos")]
        public async Task<IActionResult> GetAll([FromServices] AspNetInicioContext context)
        {
            var produtos = await context.Produtos.AsNoTracking().ToListAsync();
            return View("Produtos", produtos);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id, [FromServices] AspNetInicioContext context)
        {
            var produto = context.Produtos.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (produto != null)
                return View("Produto", produto);

            return View("Index");
        }

        [HttpGet("cadastro")]
        public IActionResult Cadastro()
        {
            return View("Cadastro");
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Cadastro(IFormFile file, [FromForm] Produto model, [FromServices] AspNetInicioContext context)
        {
            double preco = model.Preco / 100;
            Produto produto;

            if (file != null)
            {
                var originName = file.FileName.Split(".")[0];
                var originType = file.FileName.Split(".")[1];

                string fileName = $"{originName}_{Guid.NewGuid().ToString()}.{originType}";
                var newPath = Path.Combine("wwwroot/image/produtos/", fileName);

                using (var stream = new FileStream(newPath, FileMode.Create))
                    await file.CopyToAsync(stream);
                
                produto = new Produto{
                    Nome = model.Nome, 
                    Preco = preco,
                    Estoque =  model.Estoque,
                    Descricao = model.Descricao, Imagem = newPath.Substring(8), Ativo = model.Ativo};
            } else
            {
                produto = new Produto{
                    Nome = model.Nome, 
                    Preco = preco,
                    Estoque =  model.Estoque,
                    Descricao = model.Descricao, Imagem = "/image/produtos/produto_default.jpg", Ativo = model.Ativo};
            }
            var resultado = context.Produtos.Add(produto);
            await context.SaveChangesAsync();
            return Redirect("/adm/produtos");
        }

        [HttpGet("editar/{id:int}")]
        public async Task<IActionResult> Editar([FromRoute] int id, [FromServices] AspNetInicioContext context)
        {
            var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            if (produto == null)
                return Redirect("/adm/produtos");
            
            return View("Editar", produto);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Editar(IFormFile file, [FromForm] Produto produtoModel, [FromServices] AspNetInicioContext context)
        {
            // Recebendo e salvando a aimagem
            var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == produtoModel.Id);
            produto.Nome = produtoModel.Nome;
            produto.Preco = produtoModel.Preco / 100;
            produto.Ativo = produtoModel.Ativo;
            produto.Descricao = produtoModel.Descricao;
            produto.AdicionarEstoque(produto.Estoque);

            if (file == null)
            {
                produto.Imagem = produto.Imagem;

                context.Produtos.Update(produto);
                await context.SaveChangesAsync();
                return Redirect("/adm/produtos");
            }
   
            var originName = file.FileName.Split(".")[0];
            var originType = file.FileName.Split(".")[1];

            string fileName = $"{originName}_{Guid.NewGuid().ToString()}.{originType}";
            var newPath = Path.Combine("wwwroot/image/produtos/", fileName);

            using (var stream = new FileStream(newPath, FileMode.Create))
                await file.CopyToAsync(stream);
            
            // // Savando o produto
            if (produto.Imagem != "image/produtos/produto_default.jpg")
            {
                System.IO.File.Delete($"wwwroot/{produto.Imagem}");
            }


            produto.Imagem = newPath.Substring(8);

            context.Produtos.Update(produto);
            await context.SaveChangesAsync();
            return Redirect("/adm/produtos");
        }

        [HttpGet("delete/{id:int}")]
        public async Task<IActionResult> Inativar([FromRoute] int id, [FromServices] AspNetInicioContext context)
        {
            var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            if (produto == null)
                return Redirect("/adm/produtos");

            produto.Ativo = 0;
            context.Produtos.Update(produto);
            await context.SaveChangesAsync();
            return Redirect("/adm/produtos");
        }

        [HttpGet("ativar/{id:int}")]
        public async Task<IActionResult> Ativar([FromRoute] int id, [FromServices] AspNetInicioContext context)
        {
            var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            if (produto == null)
                return Redirect("/adm/produtos");

            produto.Ativo = 1;
            context.Produtos.Update(produto);
            await context.SaveChangesAsync();
            return Redirect("/adm/produtos");
        }

        [HttpGet("estoque/{id:int}")]
        public async Task<IActionResult> Estoque([FromRoute] int id, [FromServices] AspNetInicioContext context)
        {
            var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            return View("Estoque", produto);
        }

        [HttpPost("update-estoque")]
        public async Task<IActionResult> Estoque([FromForm] int id, [FromForm] int Estoque, [FromServices] AspNetInicioContext context)
        {
            var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        
            produto.AdicionarEstoque(Estoque);

            context.Produtos.Update(produto);
            await context.SaveChangesAsync();
            return Redirect("/adm/produtos");
        }
    }
}