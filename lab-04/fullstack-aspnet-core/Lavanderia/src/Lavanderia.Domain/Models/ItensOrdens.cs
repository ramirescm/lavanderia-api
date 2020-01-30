namespace Lavanderia.Domain.Models
{
    public class ItensOrdens
    {
        public long ItemId { get; set; }
        public Item Item { get; set; }
        public long OrdemId { get; set; }
        public OrdemServico OrdemServico { get; set; }
    }
}
