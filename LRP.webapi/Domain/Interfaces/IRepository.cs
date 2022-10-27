using LRP.webapi.Domain.Entities;

namespace LRP.webapi.Domain.Interfaces;

public interface IRepository<T>
{
    Task Add(T entity);

    Task Update(T entity);

    Task Patch();

    Task Delete(int id);

    Task<T> GetById(int id);

    Task<IEnumerable<T>> GetByQuery(Dictionary<string, string> query);
}