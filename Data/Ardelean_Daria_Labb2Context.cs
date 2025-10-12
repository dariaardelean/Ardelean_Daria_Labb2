using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ardelean_Daria_Labb2.Models;

namespace Ardelean_Daria_Labb2.Data
{
    public class Ardelean_Daria_Labb2Context : DbContext
    {
        public Ardelean_Daria_Labb2Context (DbContextOptions<Ardelean_Daria_Labb2Context> options)
            : base(options)
        {
        }

        public DbSet<Ardelean_Daria_Labb2.Models.Book> Book { get; set; } = default!;

        public DbSet<Ardelean_Daria_Labb2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Ardelean_Daria_Labb2.Models.Author> Author { get; set; } = default!;
    }
}
