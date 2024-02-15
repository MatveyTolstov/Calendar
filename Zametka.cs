using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Календарь
{
    class Zametka
    {
        public string name;
        public string opisanie;
        public DateTime date;

        public Zametka(string name, string opisanie, DateTime date)
        {
            this.name = name;
            this.opisanie = opisanie;
            this.date = date;
        }
    }
}
