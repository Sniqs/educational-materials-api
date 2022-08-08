namespace EducationalMaterials.Data.DAL.Interfaces
{
    interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllReadOnlyAsync();
        Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> condition);
        Task<T> GetSingleByConditionWithIncludeAsync(Expression<Func<T, bool>> condition, string include);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
