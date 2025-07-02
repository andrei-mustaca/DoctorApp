namespace DoctorApp.Application;

public interface IRepository<T> where T: class
{
    Task<T> GetById(Guid id);
    Task<List<T>> GetAll();
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task SaveChanges();
}