namespace Intercfaces
{
    public interface ICRUD<T>
    {
        Task<bool> Create(T Entidad);
        Task<T?> Read(object id);
        Task<List<T>?> ReadAll();
        Task<bool> Update(T Entidad);
        Task<bool> Delete(T Entidad);


    }
}
