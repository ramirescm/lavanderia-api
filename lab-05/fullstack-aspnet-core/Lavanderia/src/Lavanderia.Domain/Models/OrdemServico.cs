using System;
using System.Collections.Generic;

namespace Lavanderia.Domain.Models
{
    public class OrdemServico : Entity
    {
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public decimal ValorTotal { get; set; }
        public List<ItensOrdens> Items { get; set; }

        public OrdemServico()
        {
            Items = new List<ItensOrdens>();
        }
    }
}
