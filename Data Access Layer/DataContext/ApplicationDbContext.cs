﻿using APIBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBiblioteca.Data_Access_Layer.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }

        //Utilización de Fluent API en vez de Data Nottations, para configurar los modelos de EF (prop de entidades en este caso).
        //Ahora al haber pocas propiedades y pocos metodos puede hacerse de esta manera, en caso contrario lo podemos pasar a una carpeta específica con el nombre Configuraciones,
        //donde tendremos una clase específica para cada entidad, ConfigLibro-ConfigAutor, etc. Para priorizar el orden y no sobrecargar de codigo las clases.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genero>().Property(x => x.Nombre).HasMaxLength(150);

            modelBuilder.Entity<Autor>().Property(x => x.Nombre).HasMaxLength(150);
            modelBuilder.Entity<Autor>().Property(x => x.FechaNacimiento).HasColumnType("date");

            modelBuilder.Entity<Libro>().Property(x => x.Titulo).HasMaxLength(200);
            modelBuilder.Entity<Libro>().Property(x => x.FechaLanzamiento).HasColumnType("date");

            modelBuilder.Entity<Comentario>().Property(x => x.Contenido).HasMaxLength(500);
            
        }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Libro> Libros { get; set; }


    }
}
