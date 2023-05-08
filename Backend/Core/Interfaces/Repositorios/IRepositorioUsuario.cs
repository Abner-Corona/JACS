using Core.Models;
using Core.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositorios
{
    public interface IRepositorioUsuario : _IBaseRepositorio<TablaUsuario>
    {
        public Task<TablaUsuario?> GetByNombreAsync(string nombre, bool? active = true);
        public Task<TablaUsuario?> GetByEmailAsync(string email, bool? active = true);
        public Task<IList<TablaUsuario>> SearchAsync(string buscador, bool? active = true);

    }
}
