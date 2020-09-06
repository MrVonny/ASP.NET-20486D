using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnimalMVC.Models;

namespace AnimalMVC.Controllers
{
    public class AnimalController : Controller
    {
        private IData tempData;
        public AnimalController(IData data)
        {
            tempData = data;
        }
        public IActionResult Index()
        {
            List<Animal> animals = tempData.AnimalsInitializeData();
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.Animals = animals;
            return View(indexViewModel);
        }

        public IActionResult Details(int? id)
        {
            var model = tempData.GetAnimalById(id);
            if (model == null) return NotFound();
            return View(model);
        }
    }
}