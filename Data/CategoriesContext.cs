using System;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;

namespace WebApplication2.Data;

public class CategoriesContext(DbContextOptions<CategoriesContext> options) : DbContext(options)
{
    public DbSet<Categorie> Categorie { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorie>().HasKey(c => c.idCategoria);
    }
}
