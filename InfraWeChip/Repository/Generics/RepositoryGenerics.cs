using Domain.Interfaces.Generics;
using InfraWeChip.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfraWeChip.Repository.Generics
{
    public interface RepositoryGenerics
    {
        public class RepositoryGenerics<T> : IGeneric<T> where T : class
        {
            private readonly DbContextOptions<ContextBase> _OptionsBuilder;

            public RepositoryGenerics()
            {
                _OptionsBuilder = new DbContextOptions<ContextBase>();
            }

            public async Task Add(T Objeto)
            {
                try
                {
                    using (var data = new ContextBase(_OptionsBuilder))
                    {
                        await data.Set<T>().AddAsync(Objeto);
                        await data.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            public async Task Delete(T Objeto)
            {
                using (var data = new ContextBase(_OptionsBuilder))
                {
                    data.Set<T>().Remove(Objeto);
                    await data.SaveChangesAsync();
                }
            }

            public async Task<T> GetEntityById(int Id)
            {
                using (var data = new ContextBase(_OptionsBuilder))
                {
                    return await data.Set<T>().FindAsync(Id);
                }
            }

            public async Task<List<T>> List()
            {
                using (var data = new ContextBase(_OptionsBuilder))
                {
                    return await data.Set<T>().AsNoTracking().ToListAsync();
                }
            }

            public async Task Update(T Objeto)
            {
                using (var data = new ContextBase(_OptionsBuilder))
                {
                    data.Set<T>().Update(Objeto);
                    await data.SaveChangesAsync();
                }
            }
        }
    }
}
