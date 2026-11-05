using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;
using Capa_Entidades;

namespace Capa_Logica
{
    public class ContactoClienteLogica
    {
        private ContactoClienteDatos _datos = new ContactoClienteDatos();

        public void GuardarContacto(ContactoCliente contacto)
        {
            if (!string.IsNullOrWhiteSpace(contacto.Telefono))
            {
                string telNumeros = new string(contacto.Telefono.Where(char.IsDigit).ToArray());

                while (telNumeros.StartsWith("5454"))
                {
                    telNumeros = telNumeros.Substring(2);
                }

                string numeroLocal = telNumeros;
                if (numeroLocal.StartsWith("549"))
                {
                    numeroLocal = numeroLocal.Substring(3);
                }
                else if (numeroLocal.StartsWith("54"))
                {
                    numeroLocal = numeroLocal.Substring(2);
                }

                if (numeroLocal.StartsWith("1115") && numeroLocal.Length == 12)
                {
                    numeroLocal = "11" + numeroLocal.Substring(4);
                }
                else if (numeroLocal.StartsWith("911") && numeroLocal.Length == 11)
                {
                    numeroLocal = "11" + numeroLocal.Substring(3);
                }

                if (numeroLocal.Length != 10)
                    throw new Exception("El teléfono debe tener 10 dígitos (código de área + número). Ejemplo: 11 2345-6789.");

                if (numeroLocal.StartsWith("11"))
                {
                    contacto.Telefono = $"+54 9 11 {numeroLocal.Substring(2, 4)}-{numeroLocal.Substring(6, 4)}";
                }
                else
                {
                    contacto.Telefono = $"+54 9 {numeroLocal}";
                }
            }

            _datos.GuardarContacto(contacto);
        }

        public ContactoCliente ObtenerPorCliente(int idCliente)
        {
            return _datos.ObtenerPorCliente(idCliente);
        }
    }
}