using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingDBase5ticg3.ViewModels
{
    public class DireccionVM
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public string NumInterior { get; set; }
        public string NumExterior { get; set; }

        public List<PersonasVM> PersonasVM { get; set; }
    }
}