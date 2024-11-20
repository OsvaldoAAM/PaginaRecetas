using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaginaRecetas.Models.dbModels;

[Table("tipo")]
[Index("Nombre", Name = "UQ__tipo__72AFBCC666778F6B", IsUnique = true)]
public partial class Tipo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(25)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("TipoNombreNavigation")]
    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
