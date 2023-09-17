using Hero_WebAPI_EFCore.Web.Models;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Hero_WebAPI_EFCore.Web.Controllers
{
    [Route("api/[controller]")]
    public class MainController : Controller
    {
        private readonly IHeroService _heroService;
        private readonly IMovieService _movieService;
        private readonly ISecretService _secretService;
        private readonly IWeaponService _weaponService;

        public MainController(IHeroService heroService, IMovieService movieService, ISecretService secretService, IWeaponService weaponService)
        {
            _heroService = heroService;
            _movieService = movieService;
            _secretService = secretService;
            _weaponService = weaponService;
        }

        public IActionResult Index()
        {
            return Ok("API Running...");
        }

        #region Heroes

        [HttpPost]
        public IActionResult CreateHero(HeroViewModel model)
        {
            try
            {
                if (model is null)
                    return BadRequest("Modelo enviado está nulo.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                bool result = _heroService.Insert(model);

                if (!result)
                    throw new Exception("Erro ao salvar modelo."); 

                return CreatedAtAction(MethodBase.GetCurrentMethod().ToString(), $"Id: {model.HeroId}", model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion

        #region Movies
        #endregion

        #region Secrets
        #endregion

        #region Weapons
        #endregion
    }
}
