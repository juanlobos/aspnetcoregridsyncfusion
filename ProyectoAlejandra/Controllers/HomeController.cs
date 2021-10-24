using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoAlejandra.Data;
using ProyectoAlejandra.Models;
using Syncfusion.EJ2.Base;

namespace ProyectoAlejandra.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MvcPersonaContext _context;


        public HomeController(ILogger<HomeController> logger, MvcPersonaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var lista = _context.Persona.ToList();
            ViewBag.data = lista.ToArray();
            return View();
        }

        [HttpPost]
        public IActionResult Comprobar(string producto,string cantidad)
        {
            return Json(new { result = "1" });
        }

        [HttpPost]
        public ActionResult Insert(Persona value, string idcodigo)
        {
            string hagoloquequiero = idcodigo;//este seria el id de cabecera, puedo hacer lo que quiera con el
            _context.Persona.Add(value);//inserto el registro en la base de datos
            _context.SaveChanges();
            return new JsonResult(value);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        public ActionResult Update(Persona value)
        {
            var ord = value;
            ////////////////////////////////
            //aca va logica para actualizar



            //Persona val = Persona.GetAllRecords().Where(or => or.Id == ord.Id).FirstOrDefault();
            //val.Id = ord.Id;
            //val.Fecha = ord.Fecha;
            //val.Jubilado = ord.Jubilado;
            //val.Nombre = ord.Nombre;
            //val.Rut = ord.Rut;

            return new JsonResult(value);
        }



        public ActionResult Delete(Persona value)
        {
            ////////aca va logica para eliminar

            //Persona.GetAllRecords().Remove(Persona.GetAllRecords().Where(or => or.Id == int.Parse(value.key.ToString())).FirstOrDefault());
            return new JsonResult(value);
        }

   
    }
}
