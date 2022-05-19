using Microsoft.EntityFrameworkCore;
using Supermercato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato.Repository
{
    public class RepositoryProdotto : IRepositoryEntity, IRepository<Prodotto>
    {
        public Prodotto Create(Prodotto item)
        {
            using (var ctx = new SupermercatoContext())
            {
                ctx.Prodotti.Add(item);
                ctx.SaveChanges();
            }
            return item;

        }

        public ICollection<Prodotto> GetAll()
        {
            using (var ctx = new SupermercatoContext())
            {
                return ctx.Prodotti.Include(p=>p.Reparto).ToList();
            }
        }

        public IEntity GetByCode(string codice)
        {
            return GetAll().FirstOrDefault(p => p.Codice == codice);
        }


    }
}
