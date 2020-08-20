namespace Lavanderia.Domain.Models
{
    public class Cliente : Entity
    {
        public string Documento { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
