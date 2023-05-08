using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Tablas
{

    public partial class _BaseTabla
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public uint Id { get; set; }

        [Column("Active", TypeName = "tinyint(1)")]
        [DefaultValue(true)]
        public bool Activo { get; set; } = true;
        [Column("fechaCreacion", TypeName = "datetime(6)"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime fechaCreacion { get; set; } = DateTime.Now;
        [Column("fechaModificacion", TypeName = "datetime(6)"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(null)]
        public DateTime? FechaModificacion { get; set; } = null;

    }
}
