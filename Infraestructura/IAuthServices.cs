using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingDBase5ticg3.Models;

namespace TrainingDBase5ticg3.Infraestructura
{
    public interface IAuthServices
    {
        Usuarios Login(string userName, string password);
    }
}
