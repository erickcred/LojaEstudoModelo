using System;
using System.ComponentModel.DataAnnotations;
using ECommerce.ViewModels;

namespace ECommerce.ViewModels
{
    public class ProdutoViewModel
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obtigatório!")]
        public String Nome { get;  set; }

        [Required(ErrorMessage = "Campo Preco é obrigatório!")]
        // [DisplayFormat(DataFormatString="{0:C}")]
        public double Preco { get;  set; }

        [Required(ErrorMessage = "Campo Estoque Quantidade é obrigatório!")]
        public int Estoque { get; set; }

        [Required(ErrorMessage = "Campo Descrição é obrigatório!")]
        public String Descricao { get; set; }

        public String Imagem { get; set; }
        public byte Ativo { get; set; }

        public List<EstoqueViewModel> Estoques { get; set; }


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