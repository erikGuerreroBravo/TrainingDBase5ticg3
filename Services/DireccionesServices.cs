using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingDBase5ticg3.Infraestructura;
using TrainingDBase5ticg3.Models;

namespace TrainingDBase5ticg3.Services
{
    public class DireccionesServices: IDireccionesServices
    {
        private readonly TestDbMensajeriaEntities db = null;

        public DireccionesServices()
        {
            this.db= new TestDbMensajeriaEntities();
        }
        //1.- consultar

        public direcciones Get(int? id)
        {
            return this.db.direcciones
                .SingleOrDefault(p=> p.Id==id);  
        }

        public List<direcciones> GetAll() 
        {
            return this.db.direcciones.ToList();
        }

        public List<direcciones> GetByName(string name) 
        {
            return this
                .db.direcciones
                .Where(p=> p.Calle.StartsWith(name))
                .ToList();
        }


    }
}