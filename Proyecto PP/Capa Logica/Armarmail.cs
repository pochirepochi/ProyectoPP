namespace Capa_Logica
{
    public static class ArmarMail
    {
        public static string DireccionCorreo { get; set; } = string.Empty;
        public static string Asunto { get; set; } = string.Empty;
        public static string NuevaContraseña { get; set; } = string.Empty;

        public static void Preparar()
        {
            string body = @"<style>
                            h1{color:dodgerblue;}
                            h2{color:darkorange;}
                            </style>
                            <h1> Aviso: Contraseña del sistema </h1></br>
                            <h2> " + NuevaContraseña + "</h2>";
            EnviarMail.sendMail(DireccionCorreo, Asunto, body);
        }
    }
}