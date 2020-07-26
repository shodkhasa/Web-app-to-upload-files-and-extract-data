using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework3.Models;
using Homework3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Homework3.Controllers
{
    public class CityController : Controller
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult List()
        {
            ViewBag.CityList =  
                _cityService
                .GetCities()
                .Select(e=> new SelectListItem
                {
                    Text = e.Name,
                    Value = e.Id.ToString()
                })
                .ToList();
            var model = new CityData();
            return View(model);
        }

        [HttpPost]
        public IActionResult List(CityData c)
        {
            return RedirectToAction("Index", "Chart", new {id = c.Id});
        }

        public IActionResult Search(string SearchString)
        {
            var searchData = 
                _cityService
                .GetCitiesData()
                .Where(e => e.Name.ToLower().Contains(SearchString)).Distinct()
                .OrderBy(e => e.Name)
                .GroupBy(e => e.Date)
                .ToList();

            var FirstData = searchData.First();
            var fd = FirstData.ElementAt(0);

            ViewBag.searchString = SearchString;
            return View(searchData);
        }

        public IActionResult CityList()
        {
            return View(_cityService.GetCities());
        }
    }
}
