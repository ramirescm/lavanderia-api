using System.Collections.Generic;

namespace Lavanderia.Domain.Models
{
    public class Item : Entity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public List<ItensOrdens> Items { get; set; }
    }
}
