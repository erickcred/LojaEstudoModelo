using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Produto
    {        
        public int Id { get; set; }
        public String Nome { get;  set; }
        public double Preco { get;  set; }
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