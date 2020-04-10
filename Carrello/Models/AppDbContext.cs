using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Data.Entity; // scaricato Nuget apposito

namespace Carrello.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<Cliente> Clienti { get; set; }

        public DbSet<Articolo> Articoli { get; set; }
         
    }

}