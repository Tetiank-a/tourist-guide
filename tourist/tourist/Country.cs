using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tourist
{
    class Country
    {
        public string Name;
        public List<Tour> tours = new List<Tour>();
        public Country(string name)
        {
            Name = name;
        }
        public void add(Tour tour)
        {
            tours.Add(tour);
        }
    }
}
