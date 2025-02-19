using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Proyecto_Interfaces_simple

{
    public class Actividad_Cliente : ICRUD<Cliente>
    {
        Persistir_Cliente persistir_cliente = new Persistir_Cliente();

        public bool Create(T Entidad)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object Id)
        {
            throw new NotImplementedException();
        }

        public T Read(object Id)
        {
            throw new NotImplementedException();
        }

        public List<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(T Entidad)
        {
            throw new NotImplementedException();
        }

        bool ICRUD<Cliente>.Create(Cliente Entidad)
        {
            throw new NotImplementedException();
        }

        bool ICRUD<Cliente>.Delete(object Id)
        {
            throw new NotImplementedException();
        }

        Cliente ICRUD<Cliente>.Read(object Id)
        {
            throw new NotImplementedException();
        }

        List<Cliente> ICRUD<Cliente>.ReadAll()
        {
            throw new NotImplementedException();
        }

        bool ICRUD<Cliente>.Update(Cliente Entidad)
        {
            throw new NotImplementedException();
        }
    }
}
