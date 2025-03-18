using System.Collections.Generic;
using System.Data.Entity;
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


        public bool UpdatePassword(string userName,string oldPassword,string newPassword)
        {
            bool respuesta = false;
            Usuarios usuario= this.db.Usuarios
                .SingleOrDefault(p => p.Email.Equals(userName) &&
            p.Password.Equals(oldPassword));
            var transaccion = this.db.Database.BeginTransaction();
            if (usuario != null)
            {
                usuario.Password = newPassword;
                this.db.Entry(usuario).State = EntityState.Modified;
                this.db.SaveChanges();
                respuesta = true;
                transaccion.Commit();
            }
            else 
            {
                transaccion.Rollback();
            }
            return respuesta;
        }


        public List<Roles> GetAllRoles()
        {
            return this.db.Roles.OrderBy(p => p.Nombre).ToList();
        }


        public bool InsertUser(Usuarios usuarios)
        {
            bool respuesta = false;
            var transaccion = this.db.Database.BeginTransaction();
            try
            {
                this.db.Usuarios.Add(usuarios);
                this.db.SaveChanges();
                transaccion.Commit();
                return respuesta = true;
            }
            catch (System.Exception ex)
            {
                transaccion.Rollback();
                return respuesta;               
            }
                      
        }

    }
}