using System.Linq;

namespace Capa_Logica
{
    public static class Validaciones
    {
        private static readonly string[] PrefijosCuit = { "20", "23", "24", "27", "30", "33", "34" };

        public static string SoloDigitos(string texto)
        {
            return new string((texto ?? "").Where(char.IsDigit).ToArray());
        }

        // Devuelve null si es válido, o el mensaje de error. "limpio" queda solo con dígitos.
        public static string ValidarDocumento(string texto, out string limpio)
        {
            limpio = SoloDigitos(texto);

            if (limpio.Length == 0)
                return "El CUIT/DNI no puede estar vacío.";

            if (limpio.Length == 7 || limpio.Length == 8)
            {
                if (long.Parse(limpio) < 1000000)
                    return "El DNI ingresado no es válido.";
                return null;
            }

            if (limpio.Length == 11)
            {
                if (!PrefijosCuit.Contains(limpio.Substring(0, 2)))
                    return "El CUIT debe comenzar con 20, 23, 24, 27, 30, 33 o 34.";

                if (!DigitoVerificadorCuitCorrecto(limpio))
                    return "El CUIT ingresado no es válido (el dígito verificador no coincide).";

                return null;
            }

            return "Formato incorrecto. El DNI debe tener 7 u 8 dígitos y el CUIT exactamente 11 dígitos.";
        }

        private static bool DigitoVerificadorCuitCorrecto(string cuit)
        {
            int[] pesos = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int suma = 0;
            for (int i = 0; i < 10; i++)
                suma += (cuit[i] - '0') * pesos[i];

            int resto = suma % 11;
            int dv = cuit[10] - '0';

            if (resto == 0) return dv == 0;
            if (resto == 1) return cuit.StartsWith("23") && (dv == 9 || dv == 4);
            return dv == 11 - resto;
        }
    }
}