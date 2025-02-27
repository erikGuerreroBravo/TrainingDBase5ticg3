using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingDBase5ticg3.Infraestructura;
using TrainingDBase5ticg3.Models;

namespace TrainingDBase5ticg3.Services
{
    public class PersonasServices: IPersonasServices
    {
        private readonly TestDbMensajeriaEntities db = null;
        public PersonasServices() 
        {
            this.db = new TestDbMensajeriaEntities();
        }

        /// <summary>
        /// Este metodo consulta a todas las personas
        /// </summary>
        /// <returns>una lista de personas</returns>
        public List<personas> GetAll()
        {
            return this.db.personas.ToList();
        }

        public personas GetById(int? id)
        {
            return this.db.personas.Find(id);
        }

        public List<personas> GetByName(string name)
        {
            return this.db.personas
                .Where(p=> p.Nombre.StartsWith(name)).ToList(); 
        }
        /// <summary>
        /// insercion de la entidad persona
        /// </summary>
        /// <param name="personas"></param>
        /// <returns></returns>
        public bool Crear(personas personas)
        {
            bool respuesta = false;
            try
            {
                var transaccion = this.db.Database.BeginTransaction();
                this.db.personas.Add(personas);
                this.db.SaveChanges();
                transaccion.Commit();
                respuesta = true;
                return respuesta;
            }
            catch (Exception ex)
            {
                return respuesta;
                
            }
        }

    }
}