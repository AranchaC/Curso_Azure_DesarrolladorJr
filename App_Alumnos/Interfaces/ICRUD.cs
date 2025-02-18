namespace App_Alumnos.Interfaces
{
    public interface ICRUD<T>
    {
        Task<bool> Create(T Entity);
        Task<T?> Read(object id);
        Task<List<T>> ReadAll();
        Task<bool> Update(T Entity);
        Task<bool> Delete(object id);
    }
}