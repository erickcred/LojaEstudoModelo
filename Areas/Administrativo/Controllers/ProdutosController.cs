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
using ECommerce.Utils;

namespace ECommerce.Areas.Administrativo.Controllers
{
    [Area("Administrativo")]
    [Controller]
    [Route("/adm/")]
    public class ProdutosController : Controller
    {
        [HttpGet("produtos")]
        public async Task<IActionResult> GetAll([FromServices] ECommerceContext context)
        {
            var produtos = await context.Produtos.AsNoTracking().ToListAsync();
            return View("Produtos", produtos);
        }

        [HttpGet("produtos/cadastro")]
        public IActionResult Cadastro()
        {
            return View("Cadastro");
        }

        [HttpPost("produtos/insert")]
        public async Task<IActionResult> Cadastro(IFormFile file, [FromForm] ProdutoViewModel model, [FromServices] ECommerceContext context)
        {
            double preco = model.Preco / 100;
            Produto produto;

            if (file != null)
            {
                // var originName = file.FileName.Split(".")[0];
                // var originType = file.FileName.Split(".")[1];

                // string fileName = $"{originName}_{Guid.NewGuid().ToString()}.{originType}";
                // var newPath = Path.Combine("wwwroot/image/produtos/", fileName);

                // using (var stream = new FileStream(newPath, FileMode.Create))
                //     await file.CopyToAsync(stream);
                var imagem = await SalvarArquivo.Salvar(file, "image/produtos/");
                
                produto = new Produto{
                    Nome = model.Nome, 
                    Preco = preco,
                    Estoque =  model.Estoque,
                    Descricao = model.Descricao, Imagem = imagem, Ativo = model.Ativo};
            } 
            else
            {
                produto = new Produto{
                    Nome = model.Nome, 
                    Preco = preco,
                    Estoque =  model.Estoque,
                    Descricao = model.Descricao, Imagem = "image/produtos/produto_default.jpg", Ativo = model.Ativo};
            }


            var resultado = context.Produtos.Add(produto);
            await context.SaveChangesAsync();
            return Redirect("/adm/produtos");
        }

        [HttpGet("produtos/editar/{id:int}")]
        public async Task<IActionResult> Editar([FromRoute] int id, [FromServices] ECommerceContext context)
        {
            var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            if (produto == null)
                return Redirect("/adm/produtos");
            
            return View("Editar", produto);
        }

        [HttpPost("produtos/update")]
        public async Task<IActionResult> Editar(IFormFile file, [FromForm] Produto produtoModel, [FromServices] ECommerceContext context)
        {
            // Recebendo e salvando a aimagem
            var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == produtoModel.Id);
            produto.Nome = produtoModel.Nome;
            produto.Preco = produtoModel.Preco / 100;
            produto.Ativo = produtoModel.Ativo;
            produto.Descricao = produtoModel.Descricao;

            if (file == null)
            {
                produto.Imagem = produto.Imagem;

                context.Produtos.Update(produto);
                await context.SaveChangesAsync();
                return Redirect("/adm/produtos");
            }
            
            var newPath = await SalvarArquivo.Salvar(file, "image/produtos/");
            
            // Excluindo imagem se não for a default
            await SalvarArquivo.Deletar(produto.Imagem, "image/produtos/produto_default.jpg");


            produto.Imagem = newPath;

            context.Produtos.Update(produto);
            await context.SaveChangesAsync();
            return Redirect("/adm/produtos");
        }

        [HttpGet("produtos/ativo/{id:int}")]
        public async Task<IActionResult> Inativar([FromRoute] int id, [FromServices] ECommerceContext context)
        {
            var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            if (produto == null)
                return Redirect("/adm/produtos");

            if (produto.Ativo == 0)
                produto.Ativo = 1;
            else
                produto.Ativo = 0;
            
            context.Produtos.Update(produto);
            await context.SaveChangesAsync();
            return Redirect("/adm/produtos");
        }

        [HttpGet("produtos/estoque/{id:int}")]
        public async Task<IActionResult> Estoque([FromRoute] int id, [FromServices] ECommerceContext context)
        {
            var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);

            var estoque = await context.Estoques.Where(x => x.ProdutoId == produto.Id).ToListAsync();
            ViewBag.Estoque = estoque;

            return View("Estoque", produto);
        }

        [HttpPost("produtos/update-estoque")]
        public async Task<IActionResult> Estoque([FromForm] int id, [FromForm] int Estoque, [FromServices] ECommerceContext context)
        {
            var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            var estoque = new Estoque
            {
                ProdutoId = produto.Id,
                Quantidade = Estoque
            };

            await context.Estoques.AddAsync(estoque);   
        
            produto.AdicionarEstoque(Estoque);

            context.Produtos.Update(produto);
            await context.SaveChangesAsync();
            return Redirect($"/adm/produtos/estoque/{produto.Id}");
        }
    }
}