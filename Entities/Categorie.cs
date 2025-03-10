using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Entities;

public class Categorie
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int idCategoria { get; set; }
  public required string categoria { get; set; }
  public DateTime fecha_registro { get; set; }
  public DateTime fecha_actualizacion { get; set; }
  public int estatus { get; set; }
}
