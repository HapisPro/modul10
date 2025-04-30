using Microsoft.AspNetCore.Mvc;
using modul10_1030223000069.Models;

namespace modul10_1030223000069.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<string> daftarPemain1 = new List<string>
        {
            new string ("Tim Robbins"),
            new string ("Morgan Freeman"),
            new string ("Bob Gunton")
        };

        private static List<string> daftarPemain2 = new List<string>
        {
            new string ("Marlon Brando"),
            new string ("Al Pacino"),
            new string ("James Caan")
        };

        private static List<string> daftarPemain3 = new List<string>
        {
            new string ("Christian Bale"),
            new string ("Heath Ledger"),
            new string ("Aaron Eckhart")
        };

        private static List<Movie> daftarMovie = new List<Movie>
        {
            new Movie { 
                Title = "The Shawshank Redemption", 
                Director = "Frank Darabont", 
                Stars = daftarPemain1, 
                Description = "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion." 
            },

            new Movie {
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Stars = daftarPemain2,
                Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
            },

            new Movie {
                Title = "The Dark Knight",
                Director = "Christoper Nolan",
                Stars = daftarPemain3,
                Description = "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness."
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovie()
        {
            return Ok(daftarMovie);
        }

        [HttpGet("{index}")]
        public ActionResult<Movie> GetMovieByIndex(int index)
        {
            if (index < 0 || index >= daftarMovie.Count)
            {
                return NotFound("Movie tidak ditemukan");
            }
            return Ok(daftarMovie[index]);
        }

        [HttpPost]
        public ActionResult<Movie> PostMovie(Movie movie)
        {
            daftarMovie.Add(movie);
            return CreatedAtAction(nameof(GetMovieByIndex), new { index = daftarMovie.Count - 1 }, movie);
        }

        [HttpDelete]
        public IActionResult DeleteMovie(int index)
        {
            if (index < 0 || index >= daftarMovie.Count)
            {
                return NotFound("Movie tidak ditemukan untuk dihapus");
            }

            daftarMovie.RemoveAt(index);
            return NoContent();
        }
    }
}
