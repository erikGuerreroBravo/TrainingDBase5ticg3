using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingDBase5ticg3.ViewModels
{
    public class TelefonoVM
    {
        public int Id { get; set; }
        public string NumeroCelular { get; set; }
        public string NumeroCasa { get; set; }

        public List<PersonasVM> PersonasVM { get; set; }
    }
}