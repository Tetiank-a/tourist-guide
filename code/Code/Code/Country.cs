using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    [Serializable]
    public class Country
    {
        public string Name { get; set; }
        public int key { get; set; }
        public Country(string name, int k)
        {
            Name = name;
            key = k;
        }
    }
}
