using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingDBase5ticg3.ViewModels
{
	public class RolVM
	{
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<AuthVM> AuthVMs { get; set; }

    }
}