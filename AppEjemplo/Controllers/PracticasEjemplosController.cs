using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ChoETL;
using System.Text;

namespace AppEjemplo.Controllers
{
    public class PracticasEjemplosController : Controller
    {
        private IWebHostEnvironment Environment;
        public PracticasEjemplosController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

        public IActionResult Bootstrap()
        {
            return View();
        }
        public IActionResult Charts()
        {
            return View();
        }
        public IActionResult DataTable()
        {
            return View();
        }
        public IActionResult Qrcode()
        {
            return View();
        }
        public IActionResult Sweetalert()
        {
            return View();
        }
        public IActionResult Importcsv()
        {
            return View();
        }
        public IActionResult ConvertCSV()
        {
            return View();
            //if (button == "btnSubir")
            //{
            //    TempData["buttonVal"] = "Boton Presionado";
            //}
            //return RedirectToAction("Importcsv");
        }
        [HttpPost]
        public IActionResult Importcsv(IFormFile fileCSV)
        {
            if (fileCSV != null)
            {

                string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(fileCSV.FileName);
                string filePath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    fileCSV.CopyTo(stream);
                }
                string csvData = System.IO.File.ReadAllText(filePath);
                DataTable dt = new DataTable();
                //StringBuilder sb = new StringBuilder();
                //using (var p = ChoCSVReader.LoadText(csvData)
                //    .WithFirstLineHeader()
                //    )
                //{
                //    using (var w = new ChoJSONWriter(sb))
                //        w.Write(p);
                //}
                bool firstRow = true;
                foreach (string row in csvData.Split('\n'))
                {
                       if (!string.IsNullOrEmpty(row))
                       {
                            if (firstRow)
                            {
                                foreach (string cell in row.Split(','))
                                {
                                    dt.Columns.Add(cell.Trim());
                                }
                                firstRow = false;
                            }
                            else
                            {
                                dt.Rows.Add();
                                int i = 0;
                                foreach (string cell in row.Split(new char[] { ',' }))
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = cell.Trim();
                                    i++;
                                }
                            }
                       }
                }
                return View(dt);
            }

            return View();
        }
    }
}
