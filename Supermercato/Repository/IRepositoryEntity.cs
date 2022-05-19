﻿using Supermercato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato.Repository
{
    public interface IRepositoryEntity 
    {
        public IEntity GetByCode(string codice);
      
    }
}
