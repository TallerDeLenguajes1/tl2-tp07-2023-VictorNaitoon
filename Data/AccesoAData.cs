using System.Security.Cryptography;
using System.Text.Json;
using TP7.Models;

namespace TP7.Data
{
    public class AccesoAData
    {
        private string ruta = "Tareas.json";
        public List<Tarea> ObtenerTareas()
        {
            string archivo = File.ReadAllText(ruta);
            List<Tarea> Tareas = JsonSerializer.Deserialize<List<Tarea>>(archivo);
            return Tareas;
        }

        public void GuardarDatos(List<Tarea> tareas)
        {
            string json = JsonSerializer.Serialize(tareas);
            File.WriteAllText("Tareas.json",json);
        }
    }
}
