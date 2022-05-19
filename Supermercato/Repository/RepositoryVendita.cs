using Microsoft.EntityFrameworkCore;
using Supermercato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato.Repository
{
    class RepositoryVendita : IRepositoryVendita
    {
        public Vendita Create(Vendita item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int numero)
        {
            throw new NotImplementedException();
        }

        public ICollection<Vendita> GetAll()
        {
            throw new NotImplementedException();
        }

        public Vendita GetByNumero(int numero)
        {
            throw new NotImplementedException();
        }
       
    }
}
