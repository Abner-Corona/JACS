using Core.Interfaces.Repositorios;
using Core.Interfaces.Servicios;
using Core.Models;
using Core.Tablas;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Servicios
{
    public class ServicioUsuario: IServicioUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        public ServicioUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<Usuario> AddAsync(Usuario req)
        {
            var usuarios = await _repositorioUsuario.GetByEmailAsync(req.Email!);
            if (usuarios != null) throw new Exception("El correo ya existe");
            var item = req.Adapt<TablaUsuario>();
            var res = await _repositorioUsuario.AddAsync(item);
            return res.Adapt<Usuario>();
        }

        public async Task<Usuario> DeleteAsync(Usuario req)
        {
            var usuarios = await _repositorioUsuario.GetByIdAsync(req.Id);
            if (usuarios == null) throw new Exception("Usuario no encontrado");
            await _repositorioUsuario.DeleteAsync(usuarios);
            usuarios.Email +=  "@Deleted" + Guid.NewGuid();
            await _repositorioUsuario.UpdateAsync(usuarios);
            return usuarios.Adapt<Usuario>();
        }

        public async Task<IList<Usuario>> GetAllAsync(bool? active = true)
        {
            var usuarios = await _repositorioUsuario.GetAllAsync(active);
            var res = usuarios.Adapt<IList<Usuario>>();
            return res;
        }

        public async  Task<Usuario> UpdateAsync(Usuario req)
        {
            var usuarios = await _repositorioUsuario.GetByIdAsync(req.Id);
            if (usuarios == null) throw new Exception("Usuario no encontrado");
            var usuarioEmail = await _repositorioUsuario.GetByEmailAsync(req.Email!);
            if  ( usuarioEmail != null && req.Id != usuarioEmail.Id) throw new Exception("El correo ya existe");
            req.Adapt(usuarios);
            await _repositorioUsuario.UpdateAsync(usuarios);
            return usuarios.Adapt<Usuario>();
        }
        public async Task<IList<Usuario>> SearchAsync(string buscador, bool? active = true)
        {
            var usuarios = await _repositorioUsuario.SearchAsync(buscador);
            var res = usuarios.Adapt<IList<Usuario>>();

            return res;
        }
    }
}
