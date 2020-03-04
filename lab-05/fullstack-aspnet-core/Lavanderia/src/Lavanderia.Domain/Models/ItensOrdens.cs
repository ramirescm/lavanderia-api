using System.Text.Json.Serialization;

namespace Lavanderia.Domain.Models
{
    public class ItensOrdens
    {
        public long ItemId { get; set; }
        [JsonIgnore]
        public Item Item { get; set; }
        public long OrdemId { get; set; }
        [JsonIgnore]
        public OrdemServico OrdemServico { get; set; }
    }
}
