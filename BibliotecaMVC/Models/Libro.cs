namespace BibliotecaMVC.Models
{
    public class Libro
    {

        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public int copias { get; set; }

        public int IdGenero { get; set; }

        public int IdAutor { get; set; }
       
        public int IdUbicacion { get; set; }

        public int IdEditorial { get; set; }
      


        public Genero? Genero { get; set; }
        public Autor? Autor { get; set; }
        public Ubicacion? Ubicacion { get; set; }
        public Editorial? Editorial { get; set; }

    }
}
