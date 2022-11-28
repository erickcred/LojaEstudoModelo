using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Utils
{
    public static class SalvarArquivo
    {
        public async static Task<String> Salvar(IFormFile file, String caminho)
        {
            var originName = file.FileName.Split(".")[0];
            var originType = file.FileName.Split(".")[1];

            string fileName = $"{originName}_{Guid.NewGuid().ToString()}.{originType}";
            var newPath = Path.Combine("wwwroot/", caminho, fileName);

            using (var stream = new FileStream(newPath, FileMode.Create))
                await file.CopyToAsync(stream);

            return newPath.Substring(8);
        }

        public async static Task Deletar(String caminho, String padrao)
        {
            if (caminho != padrao)
            {
                System.IO.File.Delete($"wwwroot/{caminho}");
            }
        }
    }
}