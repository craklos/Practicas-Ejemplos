using AppEjemplo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppEjemplo.Data
{
    public class CrudDbContext : DbContext 
    {
        public CrudDbContext(DbContextOptions<CrudDbContext> options): base(options)
        {

        }
        public DbSet<Vehiculo> Vehiculo { get; set; }
    }
}
