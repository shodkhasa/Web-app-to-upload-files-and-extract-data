using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework3.Models;
using Homework3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Homework3.Controllers
{
    public class ChartController : Controller
    {
        private readonly CityService _cityService;
        public ChartController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            
            ViewBag.CityPop = _cityService.GetCity(id);
            string name = ViewBag.CityPop.Name;
            ViewBag.Dates = _cityService.GetCityData(name).Select(e => e.Date.Day);
            ViewBag.Cases = _cityService.GetCityData(name).Select(e => e.Cases);
            ViewBag.Test = _cityService.GetCityData(name).Select(e => e.Test);
            ViewBag.Death = _cityService.GetCityData(name).Select(e => e.Death);
            ViewBag.CityListData = 
                _cityService
                .GetCityData(name)
                .Select(e => e) //(e.Date, e.Cases, e.Death, e.Test)
                .ToList();

            ViewBag.CityList =
                _cityService
                .GetCities()
                .Where(e => e.Id != id)
                .Select(e => new SelectListItem
                {
                    Text = e.Name,
                    Value = e.Id.ToString()
                })
                .ToList();

            var model = new CityData();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CityData c)
        {
            return RedirectToAction("Index", "Chart", new { id = c.Id });
        }
    }
}
