namespace WebApplication2.Dtos;

public record class CategorieDTO(
  int idCategoria, 
  string categoria,
  DateTime fecha_registro,
  DateTime fecha_actualizacion,
  int estatus
);
