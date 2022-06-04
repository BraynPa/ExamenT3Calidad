namespace Pajares_T3.Web.Models
{
    public class Especie
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Historial> Historial { get; set; }
    }
}
