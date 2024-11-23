using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaginaRecetas.Models.dbModels;

[PrimaryKey("UsuarioId", "RecetaId")]
[Table("valoracion_recetas")]
public partial class ValoracionReceta
{
    [Key]
    [Column("usuario_id")]
    public int UsuarioId { get; set; }

    [Key]
    [Column("receta_id")]
    public int RecetaId { get; set; }

    [Column("puntuacion")]
    public int Puntuacion { get; set; }

    [ForeignKey("RecetaId")]
    [InverseProperty("ValoracionReceta")]
    public virtual Receta Receta { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("ValoracionReceta")]
    public virtual Usuario Usuario { get; set; } = null!;
}
