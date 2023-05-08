using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Tablas
{
    [Table("Books")]
    [Index(nameof(Email), Name = "email_index", IsUnique = true)]
   public  class TablaUsuario : _BaseTabla
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
