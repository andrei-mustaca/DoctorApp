namespace DoctorApp.Application;

public interface IRepository<T> where T: class
{
    Task<T?> GetById(Guid id);
    Task<List<T>> GetAll();
    Task Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChanges();
}