using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingDBase5ticg3.Models;

namespace TrainingDBase5ticg3.Infraestructura
{
    public interface IPersonasServices
    {
        bool Crear(personas personas);

        /// <summary>
        /// Este metodo consulta a todas las personas
        /// </summary>
        /// <returns>una lista de personas</returns>
        List<personas> GetAll();
        personas GetById(int? id);
        List<personas> GetByName(string name);
    }
}
