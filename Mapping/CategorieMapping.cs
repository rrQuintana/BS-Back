using System;
using WebApplication2.Dtos;
using WebApplication2.Entities;

namespace WebApplication2.Mapping;

public static class CategorieMapping
{
  public static Categorie ToEntity(this CreateCategorieDto categorie )
  {
    return new Categorie()
    {
      categoria = categorie.categoria,
      estatus = categorie.estatus
    };
  }

  public static Categorie ToEntity(this UpdateCategorieDto categorie, int id)
  {
    return new Categorie()
    {
      categoria = categorie.categoria,
      idCategoria = id,
      fecha_registro = categorie.fecha_registro,
      fecha_actualizacion = categorie.fecha_actualizacion,
      estatus = categorie.estatus
    };
  }

  public static CategorieDTO ToDto(this Categorie categorie)
  {
    return new(
      categorie.idCategoria,
      categorie.categoria,
      categorie.fecha_registro,
      categorie.fecha_actualizacion,
      categorie.estatus
    );
  }
}
