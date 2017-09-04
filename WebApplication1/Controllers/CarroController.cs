using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CarroController : Controller
    {
        // GET: Carro
        public ActionResult Index()
        {
            var model = _carros.OrderBy(m => m.Id);
            return View(model);
        }

        public ActionResult Edit(int Id) {

            var carro = _carros.Single(m => m.Id == Id);

            return View(carro);
        }

        [HttpPost]
        public ActionResult Edit(CarroModel carro) {

            _carros.Remove(_carros.Single(m => m.Id == carro.Id));

            _carros.Add(carro);

            return RedirectToAction("Index");
        }

        static List<CarroModel> _carros = new List<CarroModel> {
            new CarroModel {Id=1, Modelo="Gol",Ano = 1996,Placa="EYN-1609" },
            new CarroModel {Id=2, Modelo="Civic",Ano = 2016,Placa="GEN-1969" },
            new CarroModel {Id=3, Modelo="Uno",Ano = 1994,Placa="AEN-1597" },
            new CarroModel {Id=4, Modelo="Prisma",Ano = 2014,Placa="CUI-9856" }
        };
    }
}