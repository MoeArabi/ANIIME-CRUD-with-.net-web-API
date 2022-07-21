using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANIIME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    { private static  List<ANIME> Animes=new List<ANIME>
    { 
                new ANIME {Id = 1, Name="OnePiece",MCName="Luffy",seasons=20 },
                new ANIME {Id = 2, Name="Naruto Shippuden",MCName="Naruto",seasons=15 }
            };
        [HttpGet]
        public async Task<ActionResult<List<ANIME>>> Get()
        { 
        return Ok(Animes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ANIME>>> Get(int id)
        {  var anime= Animes.Find( H=>H.Id==id);
            if (anime == null)
                return BadRequest("Anime not found.");
            return Ok(anime);
        }

        [HttpPost]
        public async Task<ActionResult<List<ANIME>>> Addanime(ANIME anime)
        {
            Animes.Add(anime);
           

            return Ok(Animes);
        }

        [HttpPut]
        public async Task<ActionResult<List<ANIME>>> UpdateHero(ANIME request)
        {
            var anime = Animes.Find(H => H.Id == request.Id);
            if (anime == null)
                return BadRequest("Hero not found.");

            anime.Name = request.Name;
            anime.MCName = request.MCName;
            anime.seasons = request.seasons;
           

            return Ok(Animes);
        }
        [HttpDelete("{id}")]
            public async Task<ActionResult<List<ANIME>>> Delete(int id)
        {
            var anime = Animes.Find(H => H.Id == id);
            if (anime == null)
                return BadRequest("Anime not found.");
            Animes.Remove(anime);
            return Ok(anime);
        }
    }
}
