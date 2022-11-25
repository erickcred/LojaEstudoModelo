using ECommerce.Models;

namespace ECommerce.ViewModels
{
    public class EstoqueViewModel
    {
        public EstoqueViewModel()
        {
            DataAtualizacao = DateTime.Now;
        }

        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}