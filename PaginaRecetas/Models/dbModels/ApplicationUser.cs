using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PaginaRecetas.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {
     
        [Column("nombre")]
        [StringLength(16)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;

        [Column("fecha_registro")]
        public DateOnly FechaRegistro { get; set; }

        [Column("contraseña")]
        [StringLength(10)]
        [Unicode(false)]
        public string Contraseña { get; set; } = null!;

        [InverseProperty("Usuario")]
        public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

        [InverseProperty("Usuario")]
        public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();

        [InverseProperty("Usuario")]
        public virtual ICollection<ValoracionReceta> ValoracionReceta { get; set; } = new List<ValoracionReceta>();

        [ForeignKey("UsuarioId")]
        [InverseProperty("UsuariosNavigation")]
        public virtual ICollection<Receta> Receta1 { get; set; } = new List<Receta>();

        [ForeignKey("UsuarioId")]
        [InverseProperty("Usuarios")]
        public virtual ICollection<Receta> RecetaNavigation { get; set; } = new List<Receta>();

      
    }

}
