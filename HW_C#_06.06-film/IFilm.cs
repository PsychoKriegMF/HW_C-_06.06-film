using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_C__06._06_film
{
    public interface IFilm
    {
        string Title {  get; }
        int Year {  get; }
        string Director {  get; }
        string Genre {  get; }
    }
}
