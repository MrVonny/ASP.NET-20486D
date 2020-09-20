﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ButterfliesShop.Models;
using ButterfliesShop.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ButterfliesShop.Controllers
{
    public class ButterflyController : Controller
    {
        private IDataService _data;
        private IHostingEnvironment _environment;
        private IButterfliesQuantityService _butterfliesQuantityService;

        public ButterflyController(IDataService data, IHostingEnvironment environment, IButterfliesQuantityService butterfliesQuantityService)
        {
            _data = data;
            _environment = environment;
            _butterfliesQuantityService = butterfliesQuantityService;
            InitializeButterfliesData();
        }

        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.Butterflies = _data.ButterfliesList;
            return View(indexViewModel);
        }

        private void InitializeButterfliesData()
        {
            if (_data.ButterfliesList == null)
            {
                List<Butterfly> butterflies = _data.ButterfliesInitializeData();
                foreach (var butterfly in butterflies)
                {
                    _butterfliesQuantityService.AddButterfliesQuantityData(butterfly);
                }
            }
        }

        public IActionResult GetImage(int id)
        {
            Butterfly requestedButterfly = _data.GetButterflyById(id);
            if (requestedButterfly != null)
            {
                return null;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Butterfly butterfly)
        {
            var lastButterfly = _data.ButterfliesList.LastOrDefault();
            if (butterfly.PhotoAvatar != null && butterfly.PhotoAvatar.Length > 0)
            {
                butterfly.ImageMimeType = butterfly.PhotoAvatar.ContentType;
                butterfly.ImageName = Path.GetFileName(butterfly.PhotoAvatar.FileName);
                butterfly.Id = lastButterfly.Id + 1;
                _butterfliesQuantityService.AddButterfliesQuantityData(butterfly);
                using(MemoryStream memoryStream = new MemoryStream())
                {
                    butterfly.PhotoAvatar.CopyTo(memoryStream);
                    butterfly.PhotoFile = memoryStream.ToArray();
                }
                _data.AddButterfly(butterfly);
                return RedirectToAction("Index");
            }
            return View(butterfly);
        }
    }
}