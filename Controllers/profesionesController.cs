using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingDBase5ticg3.Infraestructura;
using TrainingDBase5ticg3.Mapping;
using TrainingDBase5ticg3.Models;
using TrainingDBase5ticg3.Services;
using TrainingDBase5ticg3.ViewModels;

namespace TrainingDBase5ticg3.Controllers
{
    public class profesionesController : Controller
    {
        
        private readonly IProfesionesServices
            services = null;

        public profesionesController() 
        {
            services = new 
                ProfesionesServices();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var resultado = services.GetAll();
            return View(resultado);
        }

        // GET: profesiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profesiones profesiones =services.GetById(id);
            
            if (profesiones == null)
            {
                return HttpNotFound();
            }
            return View(profesiones);
        }

        #region Metodo Create

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: profesiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "strValor,strDescripcion")]TrainingDBase5ticg3.ViewModels.ProfesionesVM profesionesVM)
        {
            if (ModelState.IsValid)
            {
               profesiones profesiones = new profesiones();
               AutoMapper.Mapper.Map(profesionesVM, profesiones);
               this.services.Create(profesiones);
               return RedirectToAction("Index");
            }

            return View(profesionesVM);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Crear([Bind(Include = "strValor,strDescripcion")] TrainingDBase5ticg3.ViewModels.ProfesionesVM profesionesVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    profesiones profesiones = new profesiones();
                    AutoMapper.Mapper.Map(profesionesVM, profesiones);
                    this.services.Create(profesiones);
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = ex.Message });
                }
            }

            return Json(new { success = false, message = "Datos inválidos." });
        }

        #endregion


        // GET: profesiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            profesiones profesiones = services.GetById(id);
            List<TrainingDBase5ticg3.ViewModels.ProfesionesVM> profesionesVMs = new List<TrainingDBase5ticg3.ViewModels.ProfesionesVM>();
            Mapper.Map(profesiones,profesionesVMs);

            if (profesiones == null)
            {
                return HttpNotFound();
            }
            return View(profesionesVMs);
        }

        // POST: profesiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,strValor,strDescripcion")]TrainingDBase5ticg3.ViewModels.ProfesionesVM profesionesVM)
        {
            if (ModelState.IsValid)
            {
                profesiones profesiones = new profesiones();
                AutoMapper.Mapper.Map(profesionesVM, profesiones);
                this.services.Edit(profesiones);
                return RedirectToAction("Index");
            }
            return View(profesionesVM);
        }

        // GET: profesiones/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profesiones profesiones = services.GetById(id);
            TrainingDBase5ticg3.ViewModels.ProfesionesVM profesionesVMs = new TrainingDBase5ticg3.ViewModels.ProfesionesVM();
            Mapper.Map(profesiones, profesionesVMs);

            if (profesiones == null)
            {
                return HttpNotFound();
            }
            return View(profesionesVMs);
        }

        // POST: profesiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            profesiones profesiones = services.GetById(id);
            this.services.Delete(profesiones);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.services.Close();
            }
            base.Dispose(disposing);
        }
    }
}
