using Core.Interfaces.Repositorios;
using Core.Tablas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioEntityCore
{
    public class RepositorioUsuario : _BaseRepositorio<TablaUsuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(_Contexto context) : base(context)
        {
        }

        public async Task<TablaUsuario?> GetByNombreAsync(string nombre, bool? active = true)
        {
            var entity = _context.TablaUsuario.AsQueryable();
            if (active != null) entity = entity.Where(i => i.Activo == active);
            return await entity.Where(i => i.Nombre == nombre).FirstOrDefaultAsync();
        }
        public async Task<TablaUsuario?> GetByEmailAsync(string email, bool? active = true)
        {
            var entity = _context.TablaUsuario.AsQueryable();
            if (active != null) entity = entity.Where(i => i.Activo == active);
            return await entity.Where(i => i.Email == email).FirstOrDefaultAsync();
        }
        public async Task<IList<TablaUsuario>> SearchAsync(string buscador, bool? active = true)
        {
            var entity = _context.TablaUsuario.AsQueryable();
            if (active != null) entity = entity.Where(i => i.Activo == active);
            return await entity.Where(i => i.Email == buscador || i.Nombre == buscador || i.Telefono == buscador || i.Direccion== buscador).ToListAsync();
        }
    }
}
