using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_C__06._06_film
{
    public class Film : IFilm
    {
        public string Title {  get; set; }
        public string Director { get; set; }
        public int Year {  get; set; }
        public string Genre {  get; set; }
    }
}
