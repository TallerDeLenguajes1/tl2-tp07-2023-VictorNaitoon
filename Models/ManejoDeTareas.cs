using TP7.Data;

namespace TP7.Models
{
    public class ManejoDeTareas
    {
        private AccesoAData _accesoAData;
        public ManejoDeTareas(AccesoAData accesoAData)
        {
            _accesoAData = accesoAData;
        }

        public bool CrearTarea(Tarea tarea)
        {
            if (tarea != null)
            {
                var Tareas = _accesoAData.ObtenerTareas();
                tarea.Id = Tareas.Count;
                Tareas.Add(tarea);
                _accesoAData.GuardarDatos(Tareas);
                return true;
            }
            return false;
        }

        public Tarea ObtenerTarea(int idTarea)
        {
            var Tareas = _accesoAData.ObtenerTareas();
            var tarea = Tareas.FirstOrDefault(x => x.Id == idTarea);
            return tarea;
        }

        public bool ActualizarTarea(Tarea tareaActualizada)
        {
            var listadoDeTareas = _accesoAData.ObtenerTareas();
            var tarea = listadoDeTareas.FirstOrDefault(x => x.Id == tareaActualizada.Id);
            if(tarea != null)
            {
                tarea.Id = tareaActualizada.Id;
                tarea.Titulo = tareaActualizada.Titulo;
                tarea.Descripcion = tareaActualizada.Descripcion;
                tarea.Estado = tareaActualizada.Estado;
                listadoDeTareas.Add(tarea);
                _accesoAData.GuardarDatos(listadoDeTareas);
                return true;
            }
            return false;
        }

        public bool EliminarTarea(int idTarea)
        {
            var Tareas = _accesoAData.ObtenerTareas();
            var tarea = Tareas.FirstOrDefault(x => x.Id == idTarea);
            if(tarea != null)
            {
                Tareas.Remove(tarea);
                _accesoAData.GuardarDatos(Tareas);
                return true;
            }
            return false;
        }

        public List<Tarea> ObtenerTareas()
        {
            return _accesoAData.ObtenerTareas();
        }

        public List<Tarea> ObtenerTareasCompletas()
        {
            var tareas = _accesoAData.ObtenerTareas().FindAll(x => x.Estado == Estado.Completada);
            return tareas;
        }


    }
}
