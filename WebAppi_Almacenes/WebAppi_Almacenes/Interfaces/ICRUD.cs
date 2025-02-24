using Microsoft.AspNetCore.Mvc;

namespace WebAppi_Almacenes.Interfaces
{
    public interface ICRUD<T>
    {
        Task<ActionResult> Create(T Entity);
        Task<ActionResult> Read(object id);
        Task<List<T>> ReadAll();
        Task<ActionResult> Update(T Entity);
        Task<ActionResult> Delete(T Entity);

    }
}
