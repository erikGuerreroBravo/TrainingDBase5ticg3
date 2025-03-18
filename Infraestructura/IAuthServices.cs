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
        List<Roles> GetAllRoles();
        Usuarios Login(string userName, string password);
        bool UpdatePassword(string userName, string oldPassword, string newPassword);
    }
}
