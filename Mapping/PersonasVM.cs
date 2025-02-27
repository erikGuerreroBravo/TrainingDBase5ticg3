using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingDBase5ticg3.ViewModels;

namespace TrainingDBase5ticg3.Mapping
{
    public class PersonasVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public int IdDireccion { get; set; }
        public int IdTelefono { get; set; }

        public DireccionVM DireccionVM { get; set; }

        public TelefonoVM TelefonoVM { get; set; }

    }
}