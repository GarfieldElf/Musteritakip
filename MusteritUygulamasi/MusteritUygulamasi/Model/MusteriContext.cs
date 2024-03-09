using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteritUygulamasi.Model
{
    public class MusteriContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Musteriler.db");
        }

        public DbSet<Musteri> Musteriler { get; set; }
        public List<Musteri> Databasemusteriler { get; internal set; } = null!;
    }
}
