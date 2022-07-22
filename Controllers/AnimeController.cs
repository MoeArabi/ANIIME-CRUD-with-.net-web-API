
using AnimeInternship.API.Models;

using Microsoft.AspNetCore.Mvc;

namespace AnimeInternship.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {

        private static List<Anime> AnimeList = new()
         {
             new(1, "OnePiece", "Luffy", 20 ),
             new(2, "Naruto Shippuden", "Naruto", 15)
         };

        [HttpGet]
        public async Task<ActionResult<List<Anime>>> Get()
            => Ok(AnimeList);

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Anime>>> GetById(int id)
        {
            //You're trying to find an anime not a hero so u do a=> a. not H
            var anime = AnimeList.Find(a => a.Id == id);
            if (anime == null)
                return BadRequest("Anime not found.");
            return Ok(anime);
        }

        [HttpPost]
        public async Task<ActionResult<List<Anime>>> AddAnime(Anime anime)
        {
            AnimeList.Add(anime);
            return Ok(AnimeList);  
        }

        [HttpPut]
        public async Task<ActionResult<List<Anime>>> UpdateHero(Anime request)
        {
            //same like above?
            var anime = AnimeList.Find(a => a.Id == request.Id);
            if (anime == null)
                return BadRequest("Hero not found.");
            anime.Update(request.Name, request.MCName, request.Seasons);
            return Ok(AnimeList);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Anime>>> Delete(int id)
        {
            var anime = AnimeList.Find(a => a.Id == id);
            if (anime == null)
                return BadRequest("Anime not found.");
            AnimeList.Remove(anime);
            return Ok(anime);
        }
    }
}
