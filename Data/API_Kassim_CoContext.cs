using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_Kassim_Co.Models;

namespace API_Kassim_Co.Data
{
    public class API_Kassim_CoContext : DbContext
    {
        public API_Kassim_CoContext (DbContextOptions<API_Kassim_CoContext> options)
            : base(options)
        {
        }

        public DbSet<API_Kassim_Co.Models.Continent> Continent { get; set; } = default!;

        public DbSet<API_Kassim_Co.Models.Pays> Pays { get; set; }

        public DbSet<API_Kassim_Co.Models.Population> Population { get; set; }
    }
}
