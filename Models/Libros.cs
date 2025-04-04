namespace CRUD.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public DateTime FechaPublicacion { get; set; }
        public string Editorial { get; set; } = string.Empty;
        public int Paginas { get; set; }
        public string Idioma { get; set; } = string.Empty;
    }
}


