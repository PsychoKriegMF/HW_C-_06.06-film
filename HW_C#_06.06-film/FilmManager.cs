using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace HW_C__06._06_film
{
    public class FilmManager 
    {
        public List<IFilm> films = new List<IFilm>();
        public void AddFilm(IFilm film)
        {
            films.Add(film);
        }
        public void RemoveFilm(string title)
        {
            var film = films.FirstOrDefault(f => f.Title == title);
            if(film != null)
            {
                films.Remove(film);
            }
            else
            {
                throw new KeyNotFoundException("Фильм не найден.");
            }
        }
        public IFilm FindFilmByTitle(string title)
        {
            var film = films.FirstOrDefault(f => f.Title == title);
            if(film == null)
            {
                throw new KeyNotFoundException("Фильм не найден.");
            }
            return film;
        }
        public IEnumerable<IFilm> FindFilmByDirector(string director)
        {
            return films.Where(f => f.Director == director);
        }
        public IEnumerable<IFilm> FindFilmByGenre(string genre)
        {
            return films.Where(f => f.Genre == genre);
        }
        public IEnumerable<IFilm> SortFilmByDate(int min, int max)
        {
            return films.Where(f => f.Year >= min && f.Year <= max);
        }
        public void SaveToJson(string path)
        {
            string json = JsonConvert.SerializeObject(films);
            File.WriteAllText(path, json);
        }
        public void LoadFromJson(string path)
        {
            string json = File.ReadAllText(path);
            films = JsonConvert.DeserializeObject<List<IFilm>>(json);
        }
        public void SaveToXml(string filePath)
        {
            var serialize = new XmlSerializer(typeof(List<Film>));
            using(var stream = new FileStream(filePath,FileMode.Create))
            {
                serialize.Serialize(stream,films.Cast<Film>().ToList());
            }
        }
        public void LoadFromXml(string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<Film>));
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                films = ((List<Film>)serializer.Deserialize(stream)).Cast<IFilm>().ToList();
            }
        }
    }
}
