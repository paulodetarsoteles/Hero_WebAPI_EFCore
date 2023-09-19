using Hero_WebAPI_EFCore.Web.Models;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hero_WebAPI_EFCore.Web.Controllers
{
    [Route("api/[controller]")]
    public class MainController : ControllerBase
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

        [HttpGet("GetHeroes")]
        public IActionResult GetHeroes()
        {
            try
            {
                List<HeroViewModel> models = _heroService.Get();

                if (models is null || models.Count == 0)
                    return this.StatusCode(StatusCodes.Status200OK, $"Message: Nenhum modelo cadastrado.");

                return this.StatusCode(StatusCodes.Status200OK, models);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpGet("GetHeroById/{id}")]
        public IActionResult GetHeroById(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest("Erro: Código ID enviado é inválido.");

                HeroViewModel model = _heroService.GetById(id);

                if (model is null)
                    return this.StatusCode(StatusCodes.Status200OK, $"Message: Nenhum modelo encontrado.");

                return this.StatusCode(StatusCodes.Status200OK, model);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpGet("GetHeroByName/{heroName}")]
        public IActionResult GetHeroByName(string heroName)
        {
            try
            {
                if (string.IsNullOrEmpty(heroName))
                    return BadRequest("Erro: Nome enviado para a consulta é inválido.");

                HeroViewModel model = _heroService.GetByName(heroName);

                if (model is null)
                    return this.StatusCode(StatusCodes.Status200OK, $"Message: Nenhum modelo encontrado.");

                return this.StatusCode(StatusCodes.Status200OK, model);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpPost]
        [Route("CreateHero")]
        public IActionResult CreateHero([FromBody] HeroViewModel model)
        {
            try
            {
                if (model is null || !ModelState.IsValid)
                    return BadRequest("Erro: Modelo enviado está inválido.");

                model.UpdateDate = DateTime.Now;

                bool result = _heroService.Insert(model);

                if (!result)
                    throw new Exception("Erro ao salvar modelo.");

                return this.StatusCode(StatusCodes.Status200OK, $"Message: Modelo cadastrado.");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
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
