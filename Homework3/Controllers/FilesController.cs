using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Homework3.Models;
using Homework3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework3.Controllers
{
    public class FilesController : Controller
    {
        private readonly CityService _cityService;

        public FilesController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file, DateTime dateTime)
        {
            
            using var reader = new StreamReader(file.OpenReadStream());
            var lines = new List<string>();
            string line;
            while ((line = reader.ReadLine()) != null)
                lines.Add(line);

            String dt = dateTime.ToShortDateString();

            foreach (var l in lines)
            {
                if (l.StartsWith("\"\"")) continue;

                string[] words = l.Split(',');

                CityData TempCityData = new CityData
                {
                    Name = words[1].Substring(1, words[1].Length - 2),
                    Pop = int.Parse(words[11])
                };

                _cityService.AddCity(TempCityData);

                CityDailyCaseData TempCityDailyCaseData = new CityDailyCaseData
                {
                    Name = words[1].Substring(1, words[1].Length - 2),
                    Cases = int.Parse(words[2]),
                    Death = int.Parse(words[5]),
                    Test = int.Parse(words[8]),
                    Date = dateTime
                };

                _cityService.AddCityData(TempCityDailyCaseData);
            }

            ViewBag.dateTime = dt;
            return View("Display", lines);
        }
    }
}
