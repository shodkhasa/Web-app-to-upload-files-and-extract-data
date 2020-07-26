using Homework3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework3.Services
{
    public class CityService
    {
        private readonly AppDbContext _db;

        public CityService(AppDbContext db)
        {
            _db = db;
        }

        public List<CityData> GetCities()
        {
            return _db.CityDatas.OrderBy(n => n.Name).ToList();
        }

        public List<CityDailyCaseData> GetCitiesData()
        {
            return _db.CityDailyCaseDatas.OrderBy(n => n.Name).ToList();
        }

        public CityData GetCity(int id)
        {
            return _db.CityDatas.Where(e => e.Id == id).SingleOrDefault();
        }

        public List<CityDailyCaseData> GetCityData(string name)
        {

            var PrintCityData = (from e in _db.CityDailyCaseDatas where e.Name == name orderby e.Date select e).ToList();
            return PrintCityData;
        }

        public void SaveChanges() => _db.SaveChanges();

        public void AddCity(CityData c)
        {
            var TestCityNamesIfExist = (from e in _db.CityDatas where e.Name == c.Name select e).Count();
            if (TestCityNamesIfExist < 1)
            {
                _db.CityDatas.Add(c);
            }
            _db.SaveChanges();
        }

        public void AddCityData(CityDailyCaseData cd)
        {
            var TestCityDatasIfExist = (from e in _db.CityDailyCaseDatas where e.Date == cd.Date && e.Name == cd.Name select e).Count();
            if (TestCityDatasIfExist < 1)
            {
                _db.CityDailyCaseDatas.Add(cd);
            }
            else
            {
                Console.WriteLine("Data already exist for Date {0}", cd.Date.ToShortDateString());
            }
            _db.SaveChanges();
        }

    }
}
