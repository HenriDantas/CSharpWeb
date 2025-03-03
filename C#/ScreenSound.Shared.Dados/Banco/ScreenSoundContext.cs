﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    public class ScreenSoundContext : DbContext
    {
        public ScreenSoundContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Musica> Musica { get; set; }
        public DbSet<Genero> Genero { get; set; }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;" +
                                          "Integrated Security=True;Encrypt=False;" +
                                          "Trust Server Certificate=False;Application Intent=ReadWrite;" +
                                          "Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musica>().HasMany(m => m.Generos)
                                        .WithMany(g => g.Musicas);
        }
    }
}
