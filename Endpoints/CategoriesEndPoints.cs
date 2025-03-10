using System;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Dtos;
using WebApplication2.Entities;
using WebApplication2.Mapping;

namespace WebApplication2.Endpoints;

public static class CategorieEndPoints
{
  const string GetCategorieByIdRouteName = "GetCategorieById";

  public static RouteGroupBuilder MapCategoriesEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("/categories").WithParameterValidation();

    group.MapGet("/", async (CategoriesContext dbContext) =>
    {
      var categories = await dbContext.Categorie
      .Where(categorie => categorie.estatus == 1)
      .Select(g => g)
      .AsNoTracking()
      .ToListAsync();

      return Results.Ok(categories);
    });

    group.MapGet("/{id}", async (int id, CategoriesContext dbContext) =>
    {
      Categorie? categorie = await dbContext.Categorie.FirstOrDefaultAsync(g => g.idCategoria == id);

      return categorie is null ? Results.NotFound() : Results.Ok(categorie.ToDto());
    }).WithName(GetCategorieByIdRouteName);

    group.MapPost("/", async (CreateCategorieDto newCategorie, CategoriesContext dbContext) =>
    {
      var categoria = newCategorie.ToEntity();

      categoria.fecha_registro = DateTime.Now;
      categoria.fecha_actualizacion = DateTime.Now;

      dbContext.Categorie.Add(categoria);
      await dbContext.SaveChangesAsync();

      return Results.CreatedAtRoute(
        GetCategorieByIdRouteName,
        new { id = categoria.idCategoria }, categoria.ToDto()
      );
    });

    group.MapPut("/{id}", async (int id, UpdateCategorieDto categorieDto, CategoriesContext dbContext) =>
    {
      Categorie? categorie = await dbContext.Categorie.FindAsync(id);

      if (categorie is null)
      {
        return Results.NotFound();
      }

      categorie.categoria = categorieDto.categoria;
      categorie.fecha_actualizacion = DateTime.Now;
      categorie.estatus = categorieDto.estatus;

      dbContext.Categorie.Update(categorie);
      await dbContext.SaveChangesAsync();

      return Results.Ok(categorie.ToDto());
    });

    group.MapDelete("/{id}", async (int id, CategoriesContext dbContext) =>
    {
      Categorie? categorie = await dbContext.Categorie.FindAsync(id);

      if (categorie is null)
      {
        return Results.NotFound();
      }

      dbContext.Categorie.Remove(categorie);
      await dbContext.SaveChangesAsync();

      return Results.NoContent();
    });

    return group;
  }
}
