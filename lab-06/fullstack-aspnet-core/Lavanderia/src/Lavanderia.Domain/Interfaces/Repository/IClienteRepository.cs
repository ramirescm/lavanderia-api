using Lavanderia.Domain.Models;
using System.Collections.Generic;

namespace Lavanderia.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        List<Cliente> BuscarTodos();
        void InserirLote(List<Cliente> clientes);
    }
}
