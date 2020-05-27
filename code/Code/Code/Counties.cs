using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    [Serializable]
    public class Countries
    {
        public List<Country> countries { private set; get; }
        public Countries()
        {
            countries = new List<Country>();
        }
        public void Add_new(Country temp)
        {
            countries.Add(temp);
        }
        public Country this[int i]
        {
            set { if (i<countries.Count)  countries[i] = value; }
            get { if (i < countries.Count) return countries[i]; else return null; }
        }
    }
}
