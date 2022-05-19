using Supermercato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato.Repository
{
    public interface IRepositoryVendita : IRepository<Vendita>
    {
        public Vendita GetByNumero(int numero);
    
    }
}
