namespace ECommerce.Models
{
    public class Estoque
    {
        public Estoque()
        {
            DataAtualizacao = DateTime.Now;
        }

        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}