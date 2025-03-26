using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingDBase5ticg3.Infraestructura;
using TrainingDBase5ticg3.Models;

namespace TrainingDBase5ticg3.Services
{
	public class BigrafiaServices: IBigrafiaServices
    {
        private readonly TestDbMensajeriaEntities db = null;

        public BigrafiaServices()
        {
            this.db = new TestDbMensajeriaEntities();
        }

        public bool InsertBiografia(string bio, int IdPersona)
        {
            bool result = false;
            var transaccion = this.db.Database.BeginTransaction();
            try
            {
                Biografia biografia = new Biografia {FechaRegistro= DateTime.UtcNow, StrValor=bio,IdPersona= IdPersona };
                this.db.Biografia.Add(biografia);
                this.db.SaveChanges();
                transaccion.Commit();
                return result;
            }
            catch (Exception)
            {
                return result;              
            }
        }

    }
}