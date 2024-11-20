using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaginaRecetas.Models.dbModels;

[Table("comentarios")]
public partial class Comentario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("contenido", TypeName = "text")]
    public string Contenido { get; set; } = null!;

    [Column("usuario_id")]
    public int UsuarioId { get; set; }

    [Column("receta_id")]
    public int RecetaId { get; set; }

    [Column("fecha_comentario", TypeName = "datetime")]
    public DateTime FechaComentario { get; set; }

    [ForeignKey("RecetaId")]
    [InverseProperty("Comentarios")]
    public virtual Receta Receta { get; set; } = null!;

    [InverseProperty("Comentario")]
    public virtual ICollection<ReportesComentario> ReportesComentarios { get; set; } = new List<ReportesComentario>();

    [ForeignKey("UsuarioId")]
    [InverseProperty("Comentarios")]
    public virtual Usuario Usuario { get; set; } = null!;
}
