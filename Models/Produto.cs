using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetInicio.Models
{
    public class Produto
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obtigatório!")]
        public String Name { get;  set; }

        [Required(ErrorMessage = "Campo Preco é obrigatório!")]
        public double Price { get;  set; }

        [Required(ErrorMessage = "Campo Quantidade é obrigatório!")]
        public int QuantityInStok { get; set; }

        public String Description { get; set; }
        public String Image { get; set; }
        public byte Ativo { get; set; }


        public void AdicionarEstoque(int valor)
        {
            this.QuantityInStok += valor;
        }

        public void Venda(int valor)
        {
            if (valor <= QuantityInStok)
                QuantityInStok -= valor;
        }

        public double GetTotal()
        {
            return this.Price * QuantityInStok;
        }

    
    }
}