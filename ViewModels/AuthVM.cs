using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingDBase5ticg3.ViewModels
{
	public class AuthVM
	{
        public int Id { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Email { get; set; }
        public  string Password { get; set; }

        public List<UsuarioRolVM> UsuarioRolVMs { get; set; }
    }
}