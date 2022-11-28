using Microsoft.AspNetCore.Mvc;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;

namespace ECommerce.Areas.Administrativo.Controllers
{
    [Area("Administrativo")]
    [Controller]
    [Route("/adm/")]
    public class ClienteController : Controller
    {
        [HttpGet("clientes")]
        public async Task<IActionResult> Get([FromServices] ECommerceContext context)
        {
            var clientes = await context.Clientes.AsNoTracking().ToListAsync();
            return View("Clientes", clientes);
        }

        [HttpGet("clientes/cadastro")]
        public IActionResult Cadastro()
        {
            return View("Cadastro");
        }

        [HttpPost("clientes/insert")]
        public async Task<IActionResult> Cadastro(IFormFile file, [FromForm] Cliente model, [FromServices] ECommerceContext context)
        {
            Cliente cliente;

            // if (file != null)
            // {
            //     var originName = file.FileName.Split(".")[0];
            //     var originType = file.FileName.Split(".")[1];

            //     string fileName = $"{originName}_{Guid.NewGuid().ToString()}.{originType}";
            //     var newPath = Path.Combine("wwwroot/image/produtos/", fileName);

            //     using (var stream = new FileStream(newPath, FileMode.Create))
            //         await file.CopyToAsync(stream);
                
            //     produto = new Produto{
            //         Nome = model.Nome, 
            //         Preco = preco,
            //         Estoque =  model.Estoque,
            //         Descricao = model.Descricao, Imagem = newPath.Substring(8), Ativo = model.Ativo};
            // } 
            // else
            // {
                cliente = new Cliente{
                    Nome = model.Nome, 
                    Email = model.Email,
                    Senha = "123",
                    // Imagem = "image/produtos/produto_default.jpg"
                    };
            // }


            var resultado = context.Clientes.Add(cliente);
            await context.SaveChangesAsync();
            return Redirect("/adm/clientes");
        }

        [HttpGet("clientes/editar/{id:int}")]
        public async Task<IActionResult> Editar([FromRoute] int id, [FromServices] ECommerceContext context)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (cliente == null)
                return Redirect("/adm/clientes");
            
            return View("Editar", cliente);
        }

        [HttpPost("clientes/update")]
        public async Task<IActionResult> Editar([FromForm] Cliente model, [FromServices] ECommerceContext context)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == model.Id);
            cliente.Nome = model.Nome;
            cliente.Email = model.Email;
            cliente.Ativo = model.Ativo;

            context.Clientes.Update(cliente);
            await context.SaveChangesAsync();

            return Redirect("/adm/clientes");
        }

        [HttpGet("clientes/ativo/{id:int}")]
        public async Task<IActionResult> Ativo([FromRoute] int id, [FromServices] ECommerceContext context)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (cliente == null)
                return Redirect("/adm/clientes");
            
            if (cliente.Ativo == 0)
                cliente.Ativo = 1;
            else
                cliente.Ativo = 0;
            
            context.Clientes.Update(cliente);
            await context.SaveChangesAsync();
            return Redirect("/adm/clientes");
        }


    }
}