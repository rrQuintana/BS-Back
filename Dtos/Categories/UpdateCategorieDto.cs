using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Dtos;

public record class UpdateCategorieDto(
  [Required][StringLength(50)] string categoria,
  [Required]                   DateTime fecha_registro,
  [Required]                   DateTime fecha_actualizacion,
  [Required]                  int estatus
);
