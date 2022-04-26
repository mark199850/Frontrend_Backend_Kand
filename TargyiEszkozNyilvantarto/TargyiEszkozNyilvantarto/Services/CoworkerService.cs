using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargyiEszkozNyilvantarto.Models;

namespace TargyiEszkozNyilvantarto.Services
{
    public class CoworkerService
    {
        private readonly companyContext context;

        public CoworkerService(companyContext context)
        {
            this.context = context;
        }

        public Coworker GetAllCoworkerByEmail(string email)
        {
            return context.Coworkers.Where(c => c.Email == email).Include(c => c.Notebooks).Include(c => c.Phones).FirstOrDefault();
        }
        public int GetCoworkerNumber()
        {
            return context.Coworkers.Count();
        }
    }
}
