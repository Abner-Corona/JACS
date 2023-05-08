using Core.Tablas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioEntityCore
{
    public class _Contexto : DbContext
    {

        public DbSet<TablaUsuario> TablaUsuario { get; set; }
        public _Contexto(DbContextOptions<_Contexto> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
