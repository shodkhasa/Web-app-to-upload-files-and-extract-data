using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework3.Models
{
    public class CityData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pop { get; set; }

        public override string ToString()
        {
            return $"{Name}\t{Pop}";
        }
    }

    public class CityDailyCaseData
    {
        public int Id { get; set; }
        public int Death { get; set; }
        public string Name { get; set; }
        public int Cases { get; set; }
        public int Test { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{Date}\t{Test}\t{Cases}\t{Death}";
        }
    }
}
