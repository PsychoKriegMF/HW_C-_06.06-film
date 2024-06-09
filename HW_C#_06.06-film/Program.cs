namespace HW_C__06._06_film
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filmmanager = new FilmManager();

            filmmanager.AddFilm(new Film { Title = "Terminator", Genre = "Action", Director = "HZ", Year = 1800 });
            filmmanager.AddFilm(new Film { Title = "Zxcvbn", Genre = "nbvcxz", Director = "HwZ", Year = 2024 });
            filmmanager.AddFilm(new Film { Title = "Qwerty", Genre = "ytrewq", Director = "HZg", Year = 1697 });
            filmmanager.AddFilm(new Film { Title = "Terminator2", Genre = "Action", Director = "HZ", Year = 1802 });
            filmmanager.AddFilm(new Film { Title = "Zxcvbn2", Genre = "nbvcxz", Director = "HwZ", Year = 2026 });
            filmmanager.AddFilm(new Film { Title = "Qwerty2", Genre = "ytrewq", Director = "HZg", Year = 1699 });

            //Поиск фильмов
            Console.WriteLine("Фильмы от режисера HZ:");
            var HZdirector = filmmanager.FindFilmByDirector("HZ");
            foreach(var film in HZdirector)
            {
                Console.WriteLine($"{film.Title}, {film.Year}");
            }
            Console.WriteLine();
            Console.WriteLine("Поиск фильма терминатор:");
            var TerminatorFilm = filmmanager.FindFilmByTitle("Terminator");                  
            Console.WriteLine($"{TerminatorFilm.Genre}, {TerminatorFilm.Year}");
            Console.WriteLine();

            var ActionFilms = filmmanager.FindFilmByGenre("Action");
            Console.WriteLine("Фильмы в жанре action:");
            foreach(var film in ActionFilms)
            {
                Console.WriteLine($"{film.Title}, {film.Year}");
            }

            Console.WriteLine("Сохраняем в Json и Xml");
            string JsonPath = "file.json";
            string XmlPath = "file.xml";

            filmmanager.SaveToJson(JsonPath);
            filmmanager.SaveToXml(XmlPath);
            Console.WriteLine("Нажмите для продолжения...");
            Console.ReadKey();
            Console.Clear();

            ProgramContact program = new ProgramContact();
            program.Start();
            
        }
    }
}
