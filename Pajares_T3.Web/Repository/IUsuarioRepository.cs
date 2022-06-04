using Microsoft.EntityFrameworkCore;
using Pajares_T3.Web.Bd;
using Pajares_T3.Web.Models;
using Pajares_T3.Web.Repository;
using Pajares_T3.Web.Service;
using System.Security.Claims;

namespace Pajares_T3.Web.Repository
{
    public interface IUsuarioRepository
    {
        public Usuario ObtenerUsuarioLogin(Claim claim);
        public Usuario EncontrarUsuario(String user, String password);
        public Dictionary<int, String> IndicesPorId();
        List<Historial> ListaHistorial();
        List<Raza> ListaRazas();
        List<Especie> ListaEspecies();
        List<Sexo> ListaSexos();
        void RegistrarHistorial(Historial nueva);
        
    }
    
   
    public class UsuarioRepository : IUsuarioRepository
    {
        private IVeterinariaContext _context;
        private readonly ICookieAuthService _cookieAuthService;

        public UsuarioRepository(VeterinariaContext context, ICookieAuthService cookieAuthService)
        {
            _context = context;
            _cookieAuthService = cookieAuthService;

        }
        public Usuario EncontrarUsuario(string user, string password)
        {
            var Usuario = _context._usuario.FirstOrDefault(o => o.Username == user && o.Password == password);
            return Usuario;
        }


        public Dictionary<int, string> IndicesPorId()
        {
            Dictionary<int, string> indices = new Dictionary<int, string>();
            var usuarios = _context._usuario.ToList();

            foreach (var item in usuarios)
            {
                indices.Add(item.Id, item.Username);
            }

            return indices;
        }

        public Usuario ObtenerUsuarioLogin(Claim claim)
        {
            var user = _context._usuario.FirstOrDefault(o => o.Username == claim.Value);
            return user;
        }

        public List<Historial> ListaHistorial()
        {
            return _context._historial.Include(s => s.Razas).Include(s => s.Especies).Include(s => s.Sexos).ToList();
        }

        public List<Raza> ListaRazas()
        {
            return _context._raza.ToList();
        }

        public List<Especie> ListaEspecies()
        {
            return _context._especie.ToList();
        }
        public List<Sexo> ListaSexos()
        {
            return _context._sexo.ToList();
        }

        public void RegistrarHistorial(Historial nueva)
        {
            _context._historial.Add(nueva);
            _context.SaveChanges();

        }
      
    }
}


