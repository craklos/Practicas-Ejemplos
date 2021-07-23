using AppEjemplo.Data;
using AppEjemplo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rotativa.AspNetCore;

namespace AppEjemplo.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly CrudDbContext _context;
        public VehiculoController(CrudDbContext context)
        {
            _context = context;
        }
        //Metodos para consultar todos los datos
        public IActionResult Index()
        {
            IEnumerable<Vehiculo> listVehiculos = _context.Vehiculo;
            return View(listVehiculos);
        }
        //Metodos para Crear
        public IActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        public IActionResult Create(Vehiculo coche)
        {
            if (ModelState.IsValid)
            {
                _context.Vehiculo.Add(coche);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //Metodos para editar
        public IActionResult Edit(int? id)
        {
            TempData["ID"] = id;
            if (id == null || id==0)
            {
                return NotFound();
            }
            var vehiculo = _context.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return PartialView("Edit", vehiculo);
        }
        [HttpPost]
        public IActionResult Edit(Vehiculo coche)
        {
            if (ModelState.IsValid)
            {
                _context.Vehiculo.Update(coche);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //Metodos para borrar
        public IActionResult Delete()
        {
            return PartialView("Delete");
        }
        [HttpPost]
        public IActionResult Delete(int?  id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var vehiculo = _context.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            _context.Vehiculo.Remove(vehiculo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GeneratePDF(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var vehiculo = _context.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return new ViewAsPdf("GeneratePDF", vehiculo)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                FileName = "ReporteVehiculo.pdf"
                
            };
        }
    }
}
