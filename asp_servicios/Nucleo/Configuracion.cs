using lib_dominio.Nucleo;

namespace asp_servicios.Nucleo
{
    public class Configuracion
    {
        private static Dictionary<string, string>? datos = null;
        public static string ObtenerValor(string clave)
        {
            string respuesta = "";
            if (datos == null)
                Cargar();

            respuesta = datos![clave].ToString();
            return respuesta;

            //if (datos!.TryGetValue(clave, out var valor))
            //    return valor;

            //throw new KeyNotFoundException($"La clave '{clave}' no está definida en Configuración.");
        }
        public static void Cargar()
        {
            datos = new Dictionary<string, string>(); // ← aseguramos que exista

            if (!File.Exists(DatosGenerales.ruta_json))
                return;

            StreamReader jsonStream = File.OpenText(DatosGenerales.ruta_json);
            var json = jsonStream.ReadToEnd();
            var leidos = JsonConversor.ConvertirAObjeto<Dictionary<string, string>>(json);

            // Debug:
            foreach (var kv in datos)
                Console.WriteLine($"CARGADO: {kv.Key} = {kv.Value}");

            if (leidos != null)
            {
                foreach (var kv in leidos)
                    datos[kv.Key] = kv.Value;
            }
        }

    }
}
