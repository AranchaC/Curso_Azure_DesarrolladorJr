using Microsoft.AspNetCore.Mvc;

namespace WebAppi_Almacenes.Interfaces
{
    public interface ICRUD<T>
    {
        Task<T> Create(T Entity);
        Task<T> Read(object id);
        Task<List<T>> ReadAll();
        Task<T> Update(T Entity);
        Task<T> Delete(T Entity);

    }
}
