namespace Pajares_T3.Web.Models
{
    public class Historial
    {
        public int CodigoRegistro { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public String? NombreMascota { get; set; }
        public DateTime FechaNacimientoMascota { get; set; }
        public int IdEspecie { get; set; }
        public int IdRaza { get; set; }
        public int IdSexo { get; set; }
        public String? Tamanio { get; set; }
        public String? DatosParticulares { get; set; }
        public String? NombreDuenio { get; set; }
        public String? DireccionDuenio { get; set; }
        public String? Telefono { get; set; }
        public String? CorreoDuenio { get; set; }
        public Sexo? Sexos { get; set; }
        public Raza? Razas { get; set; }
        public Especie? Especies { get; set; }
    }
}

