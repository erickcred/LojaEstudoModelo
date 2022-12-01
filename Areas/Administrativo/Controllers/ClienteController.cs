using Microsoft.AspNetCore.Mvc;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;
using ECommerce.Utils;

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
            if (file != null)
            {
                var imagem = await SalvarArquivo.Salvar(file, "image/usuarios/");
                model.Imagem = imagem;
            } else
            {
                model.Imagem = "image/usuarios/usuario_default.png";
            }

            var resultado = context.Clientes.Add(model);
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