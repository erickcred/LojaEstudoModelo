using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetInicio.Models
{
    public class Produto
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obtigatório!")]
        public String Nome { get;  set; }

        [Required(ErrorMessage = "Campo Preco é obrigatório!")]
        public double Preco { get;  set; }

        [Required(ErrorMessage = "Campo Quantidade é obrigatório!")]
        public int Estoque { get; set; }

        public String Descricao { get; set; }
        public String Imagem { get; set; }
        public byte Ativo { get; set; }


        public void AdicionarEstoque(int valor)
        {
            this.Estoque += valor;
        }

        public void Venda(int valor)
        {
            if (valor <= Estoque)
                Estoque -= valor;
        }

        public double GetTotal()
        {
            return this.Preco * Estoque;
        }

    
    }
}