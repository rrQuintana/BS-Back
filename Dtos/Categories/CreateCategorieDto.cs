using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Dtos;

public record class CreateCategorieDto(
  [Required][StringLength(50)] string categoria,
  [Required]                  int estatus
);
