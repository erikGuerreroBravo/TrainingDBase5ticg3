using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingDBase5ticg3.Models;
using TrainingDBase5ticg3.ViewModels;

namespace TrainingDBase5ticg3.Infraestructura
{
    public interface IAuthServices
    {
        List<Roles> GetAllRoles();
        bool InsertUser(Usuarios usuarios);
        bool InsertUser(AuthVM authVM, int Roles);
        Usuarios Login(string userName, string password);
        bool UpdatePassword(string userName, string oldPassword, string newPassword);
    }
}
