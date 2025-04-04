namespace CRUD.Controllers
{
    using CRUD.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/Libros")]
    public class CRUDController : Controller
    {
        private static List<Libro> libros = new List<Libro>();

        [HttpPost]
        public IActionResult Create([FromBody] Libro libro)
        {
            if (libro == null)
            {
                return BadRequest("El libro no puede ser nulo.");
            }

            // Asignar un ID único automáticamente
            libro.Id = libros.Count > 0 ? libros.Max(l => l.Id) + 1 : 1;

            libros.Add(libro);
            Console.WriteLine($"Libros en memoria: {libros.Count}");
            return Ok(libro);
        }


        [HttpGet("{id}")]
        public IActionResult Read([FromRoute] int id)
        {
            Console.WriteLine($"Libros en memoria: {libros.Count}");
            foreach (var libro in libros)
            {
                Console.WriteLine($"Libro ID: {libro.Id}, Titulo: {libro.Titulo}");
            }

            var libroObtenido = libros.FirstOrDefault(c => c.Id == id);
            if (libroObtenido == null)
            {
                return NotFound("No hay libros por mostrar");
            }
            return Ok(libroObtenido);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var librosObtenidos = libros.ToList();
            if (librosObtenidos == null || librosObtenidos.Count == 0)
            {
                return NotFound("No hay libros por mostrar");
            }
            return Ok(librosObtenidos);
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Libro libroActualizado)
        {
            var libro = libros.FirstOrDefault(c => c.Id == id);
            if (libro == null)
            {
                return NotFound("No hay libros por mostrar");
            }

            libro.Titulo = libroActualizado.Titulo;
            libro.Autor = libroActualizado.Autor;
            libro.Genero = libroActualizado.Genero;
            libro.FechaPublicacion = libroActualizado.FechaPublicacion;
            libro.Editorial = libroActualizado.Editorial;
            libro.Paginas = libroActualizado.Paginas;
            libro.Idioma = libroActualizado.Idioma;


            return Ok(libro);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var libro = libros.FirstOrDefault(c => c.Id == id);
            if (libro == null)
            {
                return NotFound("No hay libros por mostrar");
            }

            libros.Remove(libro);
            return Ok(libro);
        }
    }
}