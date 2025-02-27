using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TrainingDBase5ticg3.Infraestructura;
using TrainingDBase5ticg3.Models;

namespace TrainingDBase5ticg3.Services
{
    public class ProfesionesServices : IProfesionesServices
    {
        private readonly TestDbMensajeriaEntities db = null;

        public ProfesionesServices()
        {
            this.db = new TestDbMensajeriaEntities();
        }

        /// <summary>
        /// trae todos los registros de la tabla
        /// </summary>
        /// <returns></returns>
        public List<profesiones> GetAll()
        {
            return this.db.profesiones.ToList();
        }

        public List<profesiones> GetAllOrderByName()
        {
            return this.db.profesiones
                .OrderBy(o => o.strValor).ToList();
        }


        /// <summary>
        /// este metodo busca un solo registro por nombre
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public profesiones GetByName(string name) 
        {
            return this.db.profesiones
                .Where(p => p.strValor.Equals(name))
                .FirstOrDefault();
        }
        /// <summary>
        /// Este metodo se encarga de buscar por id
        /// </summary>
        /// <param name="id">el identificador de base de datos</param>
        /// <returns>una profesion</returns>
        public profesiones GetById(int? id)
        {
            return this.db
                .profesiones
                .SingleOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Este metodo se encarga de guardar en base de datos
        /// </summary>
        /// <param name="profesion">una entidad de base de datos</param>
        /// <returns>un valor boolean true/false</returns>
        public bool Create(profesiones profesion)
        {
            var transaccion =this.db.Database.BeginTransaction();
            this.db.profesiones.Add(profesion);
            this.db.SaveChanges();
            transaccion.Commit();
            return true;
        }

        /// <summary>
        /// Este metodo se encarga de editar un registro en la base de datos
        /// </summary>
        /// <param name="profesion">una entidad profesion de base de datos</param>
        /// <returns>un valor ture o false</returns>
        public bool Edit(profesiones profesion)
        {
            var transaccion = this.db.Database.BeginTransaction();
            db.Entry(profesion).State = EntityState.Modified;
            db.SaveChanges();
            transaccion.Commit();
            return true;
        }

        public bool Delete(profesiones profesion)
        {
            var transaccion = this.db.Database.BeginTransaction();
            db.profesiones.Remove(profesion);
            db.SaveChanges();
            transaccion.Commit();
            return true;
        }

        public void Close()
        {
            this.db.Dispose();
        }



    }
}