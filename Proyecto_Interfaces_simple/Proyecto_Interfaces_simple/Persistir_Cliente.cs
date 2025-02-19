using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Interfaces_simple
{
    //
    internal class Persistir_Cliente : ICRUD<Cliente>
    {
        List<Cliente> clientes = new List<Cliente>();
        public bool Create(Cliente cliente)
        {
            bool estado = false;

            if (cliente != null)
            {
                clientes.Add(cliente);
                estado = true;
            }
            return estado;
        }

        public Cliente Read(object Id)
        {
            Cliente? cliente = (from c in clientes where c.Id == (int)Id select c).FirstOrDefault();
            return cliente;
        }

        public List<Cliente> ReadAll()
        {
            return clientes;
        }

        public bool Update(Cliente clienteModificado)
        {
            bool estado = false;

            if (clienteModificado != null)
            {
                Cliente? clienteEncontrado = Read(clienteModificado.Id);
                if (clienteEncontrado != null)
                { }
            }
            throw new NotImplementedException();
        }

        public bool Delete(object entidad)
        {
            throw new NotImplementedException();
        }
    }
}
