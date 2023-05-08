using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Core.Interfaces.Servicios
{
    public interface IServicioUsuario
    {
        public Task<IList<Usuario>> GetAllAsync(bool? active = true);
        public Task<Usuario> AddAsync(Usuario req);
        public Task<Usuario> DeleteAsync(Usuario req);
        public Task<Usuario> UpdateAsync(Usuario req);
        public Task<IList<Usuario>> SearchAsync(string buscador, bool? active = true);
    }
}
