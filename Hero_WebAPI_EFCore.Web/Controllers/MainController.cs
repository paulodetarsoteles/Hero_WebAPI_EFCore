using Hero_WebAPI_EFCore.Web.Models;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hero_WebAPI_EFCore.Web.Controllers
{
    [ApiController]
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
                    return Ok("Message: Nenhum modelo cadastrado.");

                return Ok(models);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
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
                    return Ok("Message: Nenhum modelo encontrado.");

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
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
                    return Ok("Message: Nenhum modelo encontrado.");

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpPost("CreateHero")]
        public IActionResult CreateHero([FromBody] HeroViewModel model)
        {
            try
            {
                if (model is null || !ModelState.IsValid)
                    return BadRequest("Erro: Modelo enviado está inválido.");

                model.UpdateDate = DateTime.Now;

                if (!_heroService.Insert(model))
                    throw new Exception("Erro ao salvar modelo.");

                return Ok("Message: Modelo cadastrado.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpPut("UpdateHero")]
        public IActionResult UpdateHero([FromBody] HeroViewModel model)
        {
            try
            {
                if (model is null || !ModelState.IsValid)
                    return BadRequest("Erro: Modelo enviado está inválido.");

                model.UpdateDate = DateTime.Now;

                if (!_heroService.Update(model))
                    throw new Exception("Erro ao salvar modelo.");

                return Ok("Message: Modelo atualizado.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpDelete("DeleteHero/{id}")]
        public IActionResult DeleteHero(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Erro: Código ID enviado é inválido.");

                if (!_heroService.Delete(id))
                    throw new Exception("Erro ao excluir modelo.");

                return Ok("Message: Modelo excluído.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        #endregion

        #region Movies

        [HttpGet("GetMovies")]
        public IActionResult GetMovies()
        {
            try
            {
                List<MovieViewModel> models = _movieService.Get();

                if (models is null || models.Count == 0)
                    return Ok("Message: Nenhum modelo cadastrado.");

                return Ok(models);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpGet("GetMovieById/{id}")]
        public IActionResult GetMovieById(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest("Erro: Código ID enviado é inválido.");

                MovieViewModel model = _movieService.GetById(id);

                if (model is null)
                    return Ok("Message: Nenhum modelo encontrado.");

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpGet("GetMovieByName/{movieName}")]
        public IActionResult GetMovieByName(string movieName)
        {
            try
            {
                if (string.IsNullOrEmpty(movieName))
                    return BadRequest("Erro: Nome enviado para a consulta é inválido.");

                MovieViewModel model = _movieService.GetByName(movieName);

                if (model is null)
                    return Ok("Message: Nenhum modelo encontrado.");

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpPost("CreateMovie")]
        public IActionResult CreateMovie([FromBody] MovieViewModel model)
        {
            try
            {
                if (model is null || !ModelState.IsValid)
                    return BadRequest("Erro: Modelo enviado está inválido.");

                if (!_movieService.Insert(model))
                    throw new Exception("Erro ao salvar modelo.");

                return Ok("Message: Modelo cadastrado.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie([FromBody] MovieViewModel model)
        {
            try
            {
                if (model is null || !ModelState.IsValid)
                    return BadRequest("Erro: Modelo enviado está inválido.");

                if (!_movieService.Update(model))
                    throw new Exception("Erro ao salvar modelo.");

                return Ok("Message: Modelo atualizado.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpDelete("DeleteMovie/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Erro: Código ID enviado é inválido.");

                if (!_movieService.Delete(id))
                    throw new Exception("Erro ao excluir modelo.");

                return Ok("Message: Modelo excluído.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        #endregion

        #region Secrets

        [HttpGet("GetSecrets")]
        public IActionResult GetSecrets()
        {
            try
            {
                List<SecretViewModel> models = _secretService.Get();

                if (models is null || models.Count == 0)
                    return this.StatusCode(StatusCodes.Status200OK, $"Message: Nenhum modelo cadastrado.");

                return this.StatusCode(StatusCodes.Status200OK, models);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpGet("GetSecretById/{id}")]
        public IActionResult GetSecretById(int id)
        {
            try
            {
                if (id == 0)
                    return this.StatusCode(StatusCodes.Status400BadRequest, "Erro: Código ID enviado é inválido.");

                SecretViewModel model = _secretService.GetById(id);

                if (model is null)
                    return this.StatusCode(StatusCodes.Status200OK, $"Message: Nenhum modelo encontrado.");

                return this.StatusCode(StatusCodes.Status200OK, model);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpGet("GetSecretByName/{secretName}")]
        public IActionResult GetSecretByName(string secretName)
        {
            try
            {
                if (string.IsNullOrEmpty(secretName))
                    return StatusCode(StatusCodes.Status400BadRequest, "Erro: Nome enviado para a consulta é inválido.");

                SecretViewModel model = _secretService.GetByName(secretName);

                if (model is null)
                    return StatusCode(StatusCodes.Status200OK, $"Message: Nenhum modelo encontrado.");

                return StatusCode(StatusCodes.Status200OK, model);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpPost("CreateSecret")]
        public IActionResult CreateSecret(SecretViewModel secretViewModel)
        {
            try
            {
                if (secretViewModel is null || !ModelState.IsValid)
                    return StatusCode(400, "Erro: Modelo enviado está inválido.");

                if (!_secretService.Insert(secretViewModel))
                    throw new Exception("Erro ao salvar modelo.");

                return StatusCode(StatusCodes.Status200OK, $"Message: Modelo cadastrado.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpPut("UpdateSecret")]
        public IActionResult UpdateSecret([FromBody] SecretViewModel model)
        {
            try
            {
                if (model is null || !ModelState.IsValid)
                    return BadRequest("Erro: Modelo enviado está inválido.");

                if (!_secretService.Update(model))
                    throw new Exception("Erro ao salvar modelo.");

                return Ok("Message: Modelo atualizado.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpDelete("DeleteSecret/{id}")]
        public IActionResult DeleteSecret(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Erro: Código ID enviado é inválido.");

                if (!_secretService.Delete(id))
                    throw new Exception("Erro ao excluir identidade secreta.");

                return Ok("Message: Modelo excluído.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        #endregion

        #region Weapons

        [HttpGet("GetWeapons")]
        public IActionResult GetWeapons()
        {
            try
            {
                List<WeaponViewModel> models = _weaponService.Get();

                if (models is null || models.Count == 0)
                    return Ok("Message: Nenhum modelo cadastrado.");

                return Ok(models);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpGet("GetWeaponById/{id}")]
        public IActionResult GetWeaponById(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest("Erro: Código ID enviado é inválido.");

                WeaponViewModel model = _weaponService.GetById(id);

                if (model is null)
                    return Ok("Message: Nenhum modelo encontrado.");

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpGet("GetWeaponByName/{weaponName}")]
        public IActionResult GetWeaponByName(string weaponName)
        {
            try
            {
                if (string.IsNullOrEmpty(weaponName))
                    return BadRequest("Erro: Nome enviado para a consulta é inválido.");

                WeaponViewModel model = _weaponService.GetByName(weaponName);

                if (model is null)
                    return Ok("Message: Nenhum modelo encontrado.");

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpPost("CreateWeapon")]
        public IActionResult CreateWeapon([FromBody] WeaponViewModel model)
        {
            try
            {
                if (model is null || !ModelState.IsValid)
                    return BadRequest("Erro: Modelo enviado está inválido.");

                bool result = _weaponService.Insert(model);

                if (!result)
                    throw new Exception("Erro ao salvar modelo.");

                return Ok("Message: Modelo cadastrado.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpPut("UpdateWeapon")]
        public IActionResult UpdateWeapon([FromBody] WeaponViewModel model)
        {
            try
            {
                if (model is null || !ModelState.IsValid)
                    return BadRequest("Erro: Modelo enviado está inválido.");

                bool result = _weaponService.Update(model);

                if (!result)
                    throw new Exception("Erro ao salvar modelo.");

                return Ok("Message: Modelo atualizado.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        [HttpDelete("DeleteWeapon/{id}")]
        public IActionResult DeleteWeapon(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Erro: Código ID enviado é inválido.");

                if (!_weaponService.Delete(id))
                    throw new Exception("Erro ao excluir arma.");

                return Ok("Message: Modelo excluído.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e.Message}");
            }
        }

        #endregion
    }
}
