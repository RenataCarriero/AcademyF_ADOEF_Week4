using Microsoft.EntityFrameworkCore;
using Supermercato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato.Repository
{
    public class RepositoryDipendente : IRepositoryEntity, IRepository<Dipendente>
    {
        public Dipendente Create(Dipendente item)
        {
            using (var ctx = new SupermercatoContext())
            {
                ctx.Dipendenti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }
        public ICollection<Dipendente> GetAll()
        {
            using (var ctx = new SupermercatoContext())
            {
                return ctx.Dipendenti.Include(d=>d.Reparto).ToList();
            }
        }

        public IEntity GetByCode(string codice)
        {
            return GetAll().FirstOrDefault(e => e.Codice == codice);
        }

    }
}
