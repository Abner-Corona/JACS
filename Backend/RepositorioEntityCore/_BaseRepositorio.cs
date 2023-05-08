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
    public class _BaseRepositorio<T> : _IBaseRepositorio<T> where T : _BaseTabla

    {
        public _Contexto _context;

        public _BaseRepositorio(_Contexto context)
        {
            _context = context;
        }

        public T Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> DeleteAsync(T item)
        {
            item.Activo = false;
            await this.UpdateAsync(item);
            return item;
        }

        public T Delete(T item)
        {
            item.Activo = false;
            this.Update(item);
            return item;
        }
        public IList<T> GetAll(bool? active = true)
        {

            var entity = _context.Set<T>().AsQueryable();
            if (active != null) entity = entity.Where(i => i.Activo == active);
            return entity.ToList();
        }
        public async Task<IList<T>> GetAllAsync(bool? active = true)
        {
            var entity = _context.Set<T>().AsQueryable();
            if (active != null) entity = entity.Where(i => i.Activo == active);
            return await entity.ToListAsync();
        }

        public T? GetById(uint id, bool? active = true)
        {
            var entity = _context.Set<T>().AsQueryable();
            if (active != null) entity = entity.Where(i => i.Activo == active);
            return entity.Where(i => i.Id == id).FirstOrDefault();
        }

        public async Task<T?> GetByIdAsync(uint id, bool? active = true)
        {
            var entity = _context.Set<T>().AsQueryable();
            if (active != null) entity = entity.Where(i => i.Activo == active);
            return await entity.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public T Update(T item)
        {
            _context.Set<T>().Update(item);
            _context.SaveChanges();
            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            _context.Set<T>().Update(item);
            await _context.SaveChangesAsync();
            return item;
        }


    }
}
