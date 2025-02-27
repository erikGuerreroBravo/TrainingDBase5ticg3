using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingDBase5ticg3.ViewModels
{
    public class ProfesionesPersonaVM
    {
        public int Id { get; set; }
        public int Id_Personas { get; set; }
        public int IdProfesiones { get; set; }
        public DateTime fechaRegistro { get; set; }

        public PersonasVM PersonasVM { get; set; }

        public ProfesionesVM ProfesionesVM { get;set; }

    }
}