using GerenciaJogos.ApplicationService.Dtos.Account;
using GerenciaJogos.ApplicationService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaJogos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountApplicationService _app;

        public AccountController(AccountApplicationService app)
        {
            _app = app;
        }

        /// <summary>
        /// Serviço para autenticar o usuário
        /// </summary>
        /// <param name="dto">Dados do login, username e password</param>
        /// <returns>Dados do Usuário e o Token</returns>
        /// <response code="202">Login realizado com sucesso.</response>
        /// <response code="400">Erro na validação do Serviço.</response>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AccountLoginDto), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login(AccountLoginDto dto)
        {
            var accountUserGetDto = _app.Login(dto);

            if (accountUserGetDto == null)
                return BadRequest("Usuário ou senha inválido.");

            return Accepted(accountUserGetDto);
        }

        /// <summary>
        /// Serviço para criar usuário
        /// </summary>
        /// <param name="dto">Dados do usuário, username, password e role</param>
        /// <returns></returns>
        /// <response code="204">Cadastro realizado com sucesso.</response>
        /// <response code="400">Erro na validação do Serviço.</response>
        [HttpPost]
        [Route("user/create")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AccountUserPostDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(AccountUserPostDto dto)
        {
            var validationResult = await _app.CreateUser(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            
            return NoContent();
        }
    }
}