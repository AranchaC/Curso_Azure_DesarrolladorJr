namespace WebApi_Concesionario.Interfaces
{
    public interface ICRUD<T>
    {
        Task<T> Create(T entity);
        Task<List<T>> CrearVarios(List<T> entity);
        Task<T> Read(object id);
        Task<List<T>> ReadAll();
        Task<T> Update(T entity);
        Task<T> Delete(T entity);

    }
}
