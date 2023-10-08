namespace TP7.Models
{
    public enum Estado
    {
        Pendiente,
        EnProgreso,
        Completada
    }
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public Estado Estado { get; set; }
    }
}
