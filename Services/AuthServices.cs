using System.Linq;
using TrainingDBase5ticg3.Infraestructura;
using TrainingDBase5ticg3.Models;

namespace TrainingDBase5ticg3.Services
{
	public class AuthServices: IAuthServices
    {
        private readonly TestDbMensajeriaEntities db = null;
        public AuthServices()
        {
            db = new TestDbMensajeriaEntities();
        }

        public Usuarios Login(string userName, string password) 
        {
            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            Usuarios usuario = db.Usuarios
                .Include("UsuarioRol")
                .FirstOrDefault(u => u.Email == userName);
            if (usuario == null)
            {
                return null;
            }
            usuario.UsuarioRol = db.UsuarioRol
                .Where(u => u.IdUsuario == usuario.Id).ToList();
            return usuario;
        }
    }
}