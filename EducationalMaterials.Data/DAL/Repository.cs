﻿namespace EducationalMaterials.Data.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MaterialsContext _context;
        protected MaterialsContext MaterialsContext { get => _context; }

        public Repository(MaterialsContext context)
        {
            _context = context;
        }

        public void Create(T entity)
            => MaterialsContext.Set<T>().Add(entity);

        public void Delete(T entity)
            => MaterialsContext.Set<T>().Remove(entity);

        public async Task<IEnumerable<T>> GetAllReadOnlyAsync()
            => await MaterialsContext.Set<T>().AsNoTracking().ToListAsync();

        public void Update(T entity)
            => MaterialsContext.Set<T>().Update(entity);

        public async Task SaveChangesAsync()
            => await MaterialsContext.SaveChangesAsync();

        public async Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> condition)
        {
            var entity = await MaterialsContext.Set<T>()
            .Where(condition)
            .SingleOrDefaultAsync();

            if (entity is null)
                throw new ResourceNotFoundException($"Requested resource: {typeof(T)} doesn't exist");

            return entity;
        }

        public async Task<T> GetSingleByConditionWithIncludeAsync(Expression<Func<T, bool>> condition, string include)
        {
            var entity = await MaterialsContext.Set<T>()
            .Where(condition)
               .Include(include)
            .SingleOrDefaultAsync();

            if (entity is null)
                throw new ResourceNotFoundException($"Requested resource: {typeof(T)} doesn't exist");

            return entity;
        }
    }
}