using System;
using System.Collections.Generic;
using Capa_Entidades;
using Capa_Datos;

namespace Capa_Logica
{
    public class ClienteLogica
    {
        private ClienteDatos objClienteDatos = new ClienteDatos();

        public int RegistrarCliente(Cliente objCliente, int idUsuario)
        {
            ValidarReglasNegocio(objCliente);
            return objClienteDatos.InsertarCliente(objCliente, idUsuario);
        }

        public List<Cliente> ListarClientes()
        {
            return objClienteDatos.ListarClientes();
        }

        public void ActualizarCliente(Cliente objCliente, int idUsuario)
        {
            if (objCliente.ID <= 0)
            {
                throw new Exception("Debe seleccionar un cliente válido para modificar.");
            }
            ValidarReglasNegocio(objCliente);
            objClienteDatos.ActualizarCliente(objCliente, idUsuario);
        }

        public void BajaCliente(int idCliente, int idUsuario)
        {
            if (idCliente <= 0)
            {
                throw new Exception("Debe seleccionar un cliente válido para dar de baja.");
            }
            objClienteDatos.BajaCliente(idCliente, idUsuario);
        }

        private void ValidarReglasNegocio(Cliente objCliente)
        {
            string errorDoc = Validaciones.ValidarDocumento(objCliente.CUIT_DNI, out _);
            if (errorDoc != null)
                throw new Exception(errorDoc);

            if (objClienteDatos.ExisteCuit(objCliente.CUIT_DNI, objCliente.ID))
                throw new Exception("El CUIT/DNI ingresado ya pertenece a otro cliente.");

            if (objCliente.Limite_Credito < 0)
                throw new Exception("El límite de crédito no puede ser menor a cero.");

            if (objCliente.Descuento_General < 0 || objCliente.Descuento_General > 100)
                throw new Exception("El descuento general debe estar entre 0 y 100%.");
        }

        public bool ReactivarCliente(int idCliente, int idUsuario)
        {
            if (idCliente <= 0)
            {
                throw new Exception("No se puede reactivar un cliente con un ID inválido.");
            }

            bool resultado = objClienteDatos.ReactivarCliente(idCliente, idUsuario);

            if (!resultado)
            {
                throw new Exception("No se pudo reactivar el cliente en la base de datos. Verifique que el cliente exista.");
            }

            return resultado;
        }

        public Cliente BuscarClientePorId(int idCliente)
        {
            if (idCliente <= 0)
            {
                throw new Exception("El ID de búsqueda no es válido.");
            }

            return objClienteDatos.BuscarClientePorId(idCliente);
        }
    }
}