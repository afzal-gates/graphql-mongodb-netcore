namespace GraphQL.Core.Repositories
{
    using GraphQL.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<ICollection<T>> GetByIdsAsync(IList<string> ids);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> InsertAsync(T entity);
        Task<IEnumerable<T>> InsertRangeAsync(IEnumerable<T> entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> RemoveAsync(string id);
        Task<bool> RemoveRangeAsync(IEnumerable<T> items);

        //#region LINQ QUERY

        //int Count { get; }
        //long LongCount { get; }
        //void Add(T item);
        //Task<T> AddAsync(T item);
        //void AddRange(IEnumerable<T> items);
        //Task AddRangeAsync(IEnumerable<T> items);
        //void Remove(T item);
        //void RemoveRange(IEnumerable<T> items);
        //void Modify(T item);
        //T Get(Expression<Func<T, bool>> predicate);
        //T GetUntracked(Expression<Func<T, bool>> predicate);
        //Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        //Task<T> GetUntrackedAsync(Expression<Func<T, bool>> predicate);
        //IQueryable<T> All();
        //IQueryable<T> AllUntracked();
        //IEnumerable<T> GetAll();
        //int CountFunc(Expression<Func<T, bool>> predicate);
        //long LongCountFunc(Expression<Func<T, bool>> predicate);
        //bool IsExist(Expression<Func<T, bool>> predicate);
        //T First(Expression<Func<T, bool>> predicate);
        //T FirstOrDefault(Expression<Func<T, bool>> predicate);
        //T Find(Expression<Func<T, bool>> predicate);
        //string Max(Expression<Func<T, string>> predicate);
        //string MaxFunc(Expression<Func<T, string>> predicate, Expression<Func<T, bool>> where);
        //IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        //IQueryable<T> WhereUntracked(Expression<Func<T, bool>> predicate);
        //IQueryable<T> FindAll(Expression<Func<T, bool>> predicate);
        //T Create(T item);
        //int Update(T item);
        //int Update(Expression<Func<T, bool>> predicate);
        //int Delete(T item);
        //int Delete(Expression<Func<T, bool>> predicate);
        //string Min(Expression<Func<T, string>> predicate);
        //string MinFunc(Expression<Func<T, string>> predicate, Expression<Func<T, bool>> where);

        //#endregion


        //#region DATABSE TRANSACTION

        //void Attach<TEntity>(TEntity item) where TEntity : class;
        //void SetModified<TEntity>(TEntity item) where TEntity : class;
        //void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;
        //void ApplyCommonTask();
        //int SaveChanges();
        //void SaveAndRefreshChanges();
        //void RollbackChanges();

        //#endregion


        //#region LINQ ASYNC

        //Task<ICollection<T>> GetAllAsync();
        //Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        //Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
        //Task<T> CreateAsync(T entity);
        //Task<string> UpdateAsync(T item);
        //Task<string> UpdateAsync(Expression<Func<T, bool>> predicate);
        //Task<string> DeleteAsync(T t);
        //Task<string> DeleteAsync(Expression<Func<T, bool>> predicate);
        //Task<int> CountAsync();
        //Task<long> LongCountAsync();
        //Task<int> CountFuncAsync(Expression<Func<T, bool>> predicate);
        //Task<long> LongCountFuncAsync(Expression<Func<T, bool>> predicate);
        //Task<T> FirstAsync(Expression<Func<T, bool>> predicate);
        //Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        //Task<string> MaxAsync(Expression<Func<T, string>> predicate);
        //Task<string> MaxFuncAsync(Expression<Func<T, string>> predicate, Expression<Func<T, bool>> where);
        //Task<string> MinAsync(Expression<Func<T, string>> predicate);
        //Task<string> MinFuncAsync(Expression<Func<T, string>> predicate, Expression<Func<T, bool>> where);
        //Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate);
        //Task<string> SaveChangesAsync();
        //#endregion


        //#region SQL RAW QUERY

        ////List<T> RunGetQuery(string query, Func<DbDataReader, T> map);

        //#endregion
    }
}
