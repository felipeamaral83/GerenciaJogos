using GerenciaJogos.ApplicationService.Dtos.BorrowedGame;
using GerenciaJogos.ApplicationService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaJogos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowedGameController : ControllerBase
    {
        private readonly BorrowedGameApplicationService _app;

        public BorrowedGameController(BorrowedGameApplicationService app)
        {
            _app = app;
        }

        /// <summary>
        /// Serviço para realizar empréstimo de um jogo para um amigo.
        /// </summary>
        /// <param name="dto">Dados para emprestar.</param>
        /// <returns></returns>
        /// <response code="204">Empréstimo realizado com sucesso.</response>
        /// <response code="400">Erro na validação do Serviço.</response>
        /// <response code="403">Usuário não possui a função (role) admin.</response>
        [HttpPost]
        [Route("lend")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(BorrowedGamePostDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Lend(BorrowedGamePostDto dto)
        {
            var validationResult = await _app.Lend(dto, User.Identity.Name);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            return NoContent();
        }

        /// <summary>
        /// Serviço para realizar a devolução de um jogo.
        /// </summary>
        /// <param name="id">Identificador do empréstimo.</param>
        /// <returns></returns>
        /// <response code="204">Devolução realizada com sucesso.</response>
        /// <response code="400">Erro na validação do Serviço.</response>
        /// <response code="403">Usuário não possui a função (role) admin.</response>
        [HttpPut]
        [Route("giveback/{id}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GiveBack(Guid id)
        {
            var validationResult = await _app.GiveBack(id);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            return NoContent();
        }
    }
}