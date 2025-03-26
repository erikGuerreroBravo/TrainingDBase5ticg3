using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingDBase5ticg3.Infraestructura;
using TrainingDBase5ticg3.Models;

namespace TrainingDBase5ticg3.Services
{
	public class SkillsServices: ISkillsServices
    {
        private readonly TestDbMensajeriaEntities db = null;
        
        public SkillsServices()
        {
            this.db = new TestDbMensajeriaEntities();
        }
        public bool InsertAllSkill(string[] skills,int IdUser) 
        {
            bool result = false;
            var transaccion = this.db.Database.BeginTransaction();
            try
            {                
                foreach (var a in skills)
                {
                    Skills skill = new Skills { StrValor = a, IdPersona=IdUser };
                    this.db.Skills.Add(skill);
                }
                this.db.SaveChanges();
                transaccion.Commit();
                result = true;
                return result;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                return result;
            }
        }


    }
}