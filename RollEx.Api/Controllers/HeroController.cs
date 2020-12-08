using Microsoft.AspNetCore.Mvc;
using RollEx.Services;
using Microsoft.AspNetCore.Http;
using RollEx.Models;

namespace RollEx.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService heroService;

        public HeroController(IHeroService heroService)
        {
            this.heroService = heroService;
        }

        [Produces(typeof(Hero))]
        [HttpGet]
        public IActionResult Get(GenerateNamePreference generateNamePreference = GenerateNamePreference.Normal)
        {
            try
            {
                var aNewHero = heroService.GenerateHero(generateNamePreference);

                return Ok(aNewHero);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

        [Produces(typeof(Hero))]
        [Route("getbygender")]
        public IActionResult GetByGender(Gender gender, GenerateNamePreference generateNamePreference = GenerateNamePreference.Normal)
        {
            try
            {
                var aNewHero = heroService.GenerateHero(gender, generateNamePreference);

                return Ok(aNewHero);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            
        }

        [Produces(typeof(Hero))]
        [Route("getbyraceandgender")]
        public IActionResult GetByRaceAndGender(Race race, Gender gender, GenerateNamePreference generateNamePreference = GenerateNamePreference.Normal)
        {
            try
            {
                var aNewHero = heroService.GenerateHero(race, gender, generateNamePreference);

                return Ok(aNewHero);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }
    }
}
