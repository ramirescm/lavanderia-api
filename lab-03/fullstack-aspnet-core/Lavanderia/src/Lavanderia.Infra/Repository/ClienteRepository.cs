using Dapper;
using Lavanderia.Domain.Interfaces.Repository;
using Lavanderia.Domain.Models;
using Lavanderia.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Lavanderia.Infra.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(LavanderiaContext context) : base(context)
        {
        }

        public List<Cliente> BuscarTodos()
        {
            DbConnection connection = _context.Database.GetDbConnection();

            connection.Open();
            var lista = connection.Query<Cliente>("select * from clientes").ToList();
            connection.Close();
            return lista;
        }

        public void InserirLote(List<Cliente> clientes)
        {
            DbConnection connection = _context.Database.GetDbConnection();

            connection.Open();
            connection.Execute("insert into clientes values (@clientes)", clientes);
            connection.Close();
        }
    }
}
