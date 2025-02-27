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
using TrainingDBase5ticg3.Models;
using TrainingDBase5ticg3.Services;
using TrainingDBase5ticg3.ViewModels;

namespace TrainingDBase5ticg3.Controllers
{
    public class PersonasController : Controller
    {
        private TestDbMensajeriaEntities db = new TestDbMensajeriaEntities();

        private readonly IPersonasServices services = null;
        private readonly IProfesionesServices profesionesServices = null;

        public PersonasController()
        {
            services = new PersonasServices();
            profesionesServices= new ProfesionesServices(); 
        }

        // GET: Personas
        public ActionResult Index()
        {
            List<personas> personas = services.GetAll();
            var personasVM = new List<PersonasVM>();
            personasVM =Mapper
                .Map<List<personas>,List<PersonasVM>>(personas);
            return View(personasVM);
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personas persona = services.GetById(id);
            PersonasVM personasVM = new PersonasVM();
            personasVM=AutoMapper.Mapper
                .Map<PersonasVM>(persona);
            if (personasVM == null)
            {
                return HttpNotFound();
            }
            return View(personasVM);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.Profesiones = new 
                SelectList(profesionesServices.GetAllOrderByName(), 
                "Id", "strValor");
            return View();
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,ApellidoPaterno,ApellidoMaterno,Edad,TelefonoVM,DireccionVM,Profesiones")]PersonasVM personasVM,int Profesiones)
        
        {
            if (ModelState.IsValid)
            {
                List<ProfesionesPersonaVM> profesionesPersonas = new List<ProfesionesPersonaVM>();
                profesionesPersonas.Add(new ProfesionesPersonaVM() {
                    IdProfesiones=Profesiones,
                    PersonasVM = personasVM,
                   
                });
                personasVM.ProfesionesPersonaVM = profesionesPersonas;

                personas persona = new personas();
                direcciones direcciones = new direcciones();
                telefonos telefonos= new telefonos();
                profesionesPersonas profesionesPersona = new profesionesPersonas();
                persona.direcciones = direcciones;
                persona.telefonos = telefonos;
                persona.profesionesPersonas.Add(profesionesPersona);
                persona=Mapper.Map<personas>(personasVM);
                services.Crear(persona);
                return RedirectToAction("Create");
            }

            return View(personasVM);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personas persona = services.GetById(id);
            PersonasVM personasVM = new PersonasVM();
            personasVM = AutoMapper.Mapper
                .Map<PersonasVM>(persona);
            if (personasVM == null)
            {
                return HttpNotFound();
            }
            return View(personasVM);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,ApellidoPaterno,ApellidoMaterno,Edad,IdDireccion,IdTelefono")] PersonasVM personasVM)
        {
            if (ModelState.IsValid)
            {
               // db.Entry(personasVM).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personasVM);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personas persona = services.GetById(id);
            PersonasVM personasVM = new PersonasVM();
            personasVM = AutoMapper.Mapper
                .Map<PersonasVM>(persona);
            if (personasVM == null)
            {
                return HttpNotFound();
            }
            return View(personasVM);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            personas persona = services.GetById(id);
            PersonasVM personasVM = new PersonasVM();
            personasVM = AutoMapper.Mapper
                .Map<PersonasVM>(persona);
            
            //db.PersonasVMs.Remove(personasVM);
            //db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
