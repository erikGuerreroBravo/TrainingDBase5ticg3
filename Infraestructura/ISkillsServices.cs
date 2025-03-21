using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingDBase5ticg3.Infraestructura
{
    public interface ISkillsServices
    {
        
        bool InsertAllSkill(string[] skills, int IdUser);
    }
}
