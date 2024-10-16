
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TMP.aplication.contracts.repository;
using TMP.aplication.exceptions;
using TMP.aplication.response.db;
using TMP.aplication.utils;
using TMP.infraestructure.persistence;
using TPM.domain.commons;

namespace TMP.infraestructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DbContextTMP _dbContext;

        public BaseRepository(DbContextTMP dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DbResponse> AddAsync(T entity)
        {
            return await ExceptionHandlerDbResponse.HandleAsync(async () => 
            {
                _dbContext.Add(entity);
                await _dbContext.SaveChangesAsync();

                return MakeResponse.CreateResponse(true, $"EntIdad añadIda correctamente, Id Generado :{entity.Id}", entity);
            }, $"Error al crear la entIdad {entity}", 500);
           
        }

        public async Task<DbResponse> DeleteAsync(T entity)
        {
            return await ExceptionHandlerDbResponse.HandleAsync(async () => 
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return MakeResponse.CreateResponse(true, $"EntIdad {entity.Id}, eliminada correctamente.", null);
            }, $"No se encontro el registro con Id {entity.Id} o ocurrio un error al eliminar el registro.",404);
            
        }

        public async Task<DbResponse> GetAllAsync()
        {
            return await ExceptionHandlerDbResponse.HandleAsync(async () => 
            {
                var entity = await _dbContext.Set<T>().ToListAsync();
                return MakeResponse.CreateResponse(true, $"Datos obtenIdos correctamente", entity);
            }, $"No se pudieron obtener los registros relacionados a la entIdad {typeof(T).Name}",400);
             
        }

        public async Task<DbResponse> GetAsync(Expression<Func<T, bool>> predicate)
        {

            return await ExceptionHandlerDbResponse.HandleAsync(async () =>
            {
                var entities = await _dbContext.Set<T>().Where(predicate).ToListAsync();
                return MakeResponse.CreateResponse(true, $"Datos obtenIdos correctamente", entities);

            }, $"No se pudo obtener el registro filtrado.",404);
        }

        public async Task<DbResponse> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disabledTracking = true)
        {

            return await ExceptionHandlerDbResponse.HandleAsync(async () =>
            {
            
                IQueryable<T> query = _dbContext.Set<T>();
                if (disabledTracking) query = query.AsNoTracking();
                if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);
                if (predicate != null) query = query.Where(predicate);
                var entities = await query.ToListAsync();
                if (orderBy != null)  entities =  await orderBy(query).ToListAsync();

                return MakeResponse.CreateResponse(true, $"Datos obtenIdos correctamente", entities);

            }, $"No se pudo obtener el registro filtrado.", 404);
        }

        public async Task<DbResponse> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disabledTracking = true)
        {
            return await ExceptionHandlerDbResponse.HandleAsync(async () =>
            {
                IQueryable<T> query = _dbContext.Set<T>();
                if (disabledTracking) query = query.AsNoTracking();
                if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));
                if (orderBy != null) query = orderBy(query);  // Apply ordering
                var entities = await query.ToListAsync();

                return MakeResponse.CreateResponse(true, $"Datos obtenIdos correctamente", entities);
            }, $"No se pudo obtener el registro filtrado.", 404);
        }

        public async Task<DbResponse> GetByIdAsync(int Id)
        {
            return await ExceptionHandlerDbResponse.HandleAsync(async () =>
            {
                var entity = await _dbContext.Set<T>().FindAsync(Id);
                return MakeResponse.CreateResponse(true, $"EntIdad con Id {Id} obtenIda correctamente.", entity);
            }, $"No se pudo obtener la entIdad con Id {Id}.", 404);
        }

        public async Task<DbResponse> UpdateAsync(T entity)
        {
            return await ExceptionHandlerDbResponse.HandleAsync(async () =>
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return MakeResponse.CreateResponse(true, $"EntIdad con Id {entity.Id} actualizada correctamente.", entity);
            }, $"No se pudo actualizar la entIdad con Id {entity.Id}.", 404);
        }
    }
}
