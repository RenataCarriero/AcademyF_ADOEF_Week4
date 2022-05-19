using Microsoft.EntityFrameworkCore;
using Supermercato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato.Repository
{
    public class RepositoryReparto : IRepositoryReparto
    {
        public Reparto Create(Reparto item)
        {
            using (var ctx = new SupermercatoContext())
            {
                ctx.Reparti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }


        public ICollection<Reparto> GetAll()
        {
            using (var ctx = new SupermercatoContext())
            {
                return ctx.Reparti.ToList();
            }
        }

        public Reparto? GetByNumero(int numero)
        {
            return GetAll().FirstOrDefault(r=>r.NumeroReparto==numero);    
        }
    }
}
