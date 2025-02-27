using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingDBase5ticg3.Models;

namespace TrainingDBase5ticg3.Infraestructura
{
    public interface IProfesionesServices
    {
        void Close();

        /// <summary>
        /// Este metodo se encarga de guardar en base de datos
        /// </summary>
        /// <param name="profesion">una entidad de base de datos</param>
        /// <returns>un valor boolean true/false</returns>
        bool Create(profesiones profesion);
        bool Delete(profesiones profesion);

        /// <summary>
        /// Este metodo se encarga de editar un registro en la base de datos
        /// </summary>
        /// <param name="profesion">una entidad profesion de base de datos</param>
        /// <returns>un valor ture o false</returns>
        bool Edit(profesiones profesion);
        List<profesiones> GetAll();
        List<profesiones> GetAllOrderByName();
        profesiones GetById(int? id);
        profesiones GetByName(string name);
    }
}
