namespace ECommerce.Models
{
    public class Cliente
    {
        public Cliente()
        {
            TipoUsuario = "cliente";
            Ativo = 1;
        }

        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public String TipoUsuario { get; set; }
        public byte Ativo { get; set; }
        public String Imagem { get; set; }

    }
}