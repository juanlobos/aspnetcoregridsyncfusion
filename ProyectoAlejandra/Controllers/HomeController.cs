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

        public IActionResult UrlDatasource([FromBody] DataManagerRequest dm)
        {
            //var order = Persona.GetAllRecords();
            var order = _context.Persona.ToList();//aca traes la data de la base de datos o puedes inicializar una lista vacia
            IEnumerable DataSource = order;

            DataOperations operation = new DataOperations();
            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = operation.PerformSearching(DataSource, dm.Search);  //Search
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = operation.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<Persona>().Count();
            if (dm.Skip != 0)
            {
                DataSource = operation.PerformSkip(DataSource, dm.Skip);   //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = operation.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? new JsonResult(new { result = DataSource, count = count }) : new JsonResult(DataSource);
        }


        //public ActionResult Insert([FromBody] CRUDAction<Persona> value,string cadena)
        //{
        //    //Persona.GetAllRecords().Insert(0, value.value);
        //    _context.Persona.Add(value.value);//inserto el registro en la base de datos
        //    _context.SaveChanges();
        //    return new JsonResult(value.value);
        //}



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

        public class CRUDAction<T> where T : class
        {
            public string action { get; set; }

            public string table { get; set; }

            public string keyColumn { get; set; }

            public object key { get; set; }

            public T value { get; set; }

            public List<T> added { get; set; }

            public List<T> changed { get; set; }

            public List<T> deleted { get; set; }

            public IDictionary<string, object> @params { get; set; }
        }

    }
}
