using Microsoft.AspNetCore.Mvc;
using TP7.Data;
using TP7.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ILogger<TareaController> _logger;
        private AccesoAData _accesoAData;
        private ManejoDeTareas _manejoDeTareas;

        public TareaController(ILogger<TareaController> logger)
        {
            _logger = logger;
            _accesoAData = new AccesoAData();
            _manejoDeTareas = new ManejoDeTareas(_accesoAData);
        }

        
        [HttpGet]
        public ActionResult<List<Tarea>> ObtenerTareas()
        {
            var tareas = _manejoDeTareas.ObtenerTareas();
            if(tareas != null)
            {
                return Ok(tareas);
            }
            return BadRequest();
        }

        
        [HttpGet("ObtenerTarea/{idTarea}")]
        public ActionResult ObtenerTarea(int idTarea)
        {
            var tarea = _manejoDeTareas.ObtenerTarea(idTarea);
            if(tarea != null)
            {
                return Ok(tarea);
            }
            return NotFound();
        }


        [HttpGet("ObtenerTareasCompletadas")]
        public ActionResult<List<Tarea>> ObtenerTareasCompletadas()
        {
            var tareas = _manejoDeTareas.ObtenerTareasCompletas();
            if(tareas != null)
            {
                return Ok(tareas);
            }
            return BadRequest();
        }

        
        [HttpPost("CrearTarea")]
        public ActionResult CrearTarea(Tarea tarea)
        {
            bool exito = _manejoDeTareas.CrearTarea(tarea);
            if (exito)
            {
                return Ok();
            }
            return BadRequest();
        }

        
        [HttpPut("ActualizarTarea")]
        public ActionResult ActualizarTarea(Tarea tarea)
        {
            var exito = _manejoDeTareas.ActualizarTarea(tarea);
            if (exito)
            {
                return Ok(tarea);
            }
            return NotFound();
        }

        
        [HttpDelete("EliminarTarea/{idTarea}")]
        public ActionResult EliminarTarea(int idTarea)
        {
            var exito = _manejoDeTareas.EliminarTarea(idTarea);
            if (exito)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
