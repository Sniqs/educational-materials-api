namespace EducationalMaterials.Data.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllReadOnlyAsync();
        Task<IEnumerable<T>> GetAllReadOnlyWithRelatedEntityAsync(string include);
        Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> condition);
        Task<T> GetSingleByConditionWithRelatedEntityAsync(Expression<Func<T, bool>> condition, string include);
        Task<bool> CheckIfExistsAsync<TEntity>(Expression<Func<TEntity, bool>> condition) where TEntity : class;
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
