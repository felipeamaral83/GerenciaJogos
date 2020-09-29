using GerenciaJogos.ApplicationService.Dtos.Game;
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
    public class GameController : ControllerBase
    {
        private readonly GameApplicationService _app;

        public GameController(GameApplicationService app)
        {
            _app = app;
        }

        /// <summary>
        /// Serviço para criar um jogo.
        /// </summary>
        /// <param name="dto">Dados para cadastro.</param>
        /// <returns></returns>
        /// <response code="204">Cadastro realizado com sucesso.</response>
        /// <response code="400">Erro na validação do Serviço.</response>
        /// <response code="403">Usuário não possui a função (role) admin.</response>
        [HttpPost]
        [Route("")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(GamePostDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create(GamePostDto dto)
        {
            var validationResult = await _app.Create(dto, User.Identity.Name);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            return NoContent();
        }

        /// <summary>
        /// Serviço para atualizar um jogo.
        /// </summary>
        /// <param name="dto">Dados para atualizar.</param>
        /// <returns></returns>
        /// <response code="204">Cadastro atualizado com sucesso.</response>
        /// <response code="400">Erro na validação do Serviço.</response>
        /// <response code="403">Usuário não possui a função (role) admin.</response>
        [HttpPut]
        [Route("")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(GamePutDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Update(GamePutDto dto)
        {
            var validationResult = await _app.Update(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            return NoContent();
        }

        /// <summary>
        /// Serviço para excluir um jogo.
        /// </summary>
        /// <param name="id">Identificador do jogo.</param>
        /// <returns></returns>
        /// <response code="204">Cadastro excluído com sucesso.</response>
        /// <response code="400">Erro na validação do Serviço.</response>
        /// <response code="403">Usuário não possui a função (role) admin.</response>
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var validationResult = await _app.Delete(id);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            return NoContent();
        }

        /// <summary>
        /// Serviço para obter todos os jogos do usuário logado.
        /// </summary>
        /// <returns>Lista de dados de jogo.</returns>
        /// <response code="200">Jogos listados com sucesso.</response>
        /// <response code="403">Usuário não possui a função (role) admin.</response>
        [HttpGet]
        [Route("all")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(GameListDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetAll()
        {
            var dto = _app.GetAll(User.Identity.Name);
            return Ok(dto);
        }

        /// <summary>
        /// Serviço para obter todos os jogos emprestados ou não e pra quem foi emprestado do usuário logado.
        /// </summary>
        /// <returns>Lista de dados de jogo e para quem está emprestado caso esteja.</returns>
        /// <response code="200">Jogos listados com sucesso.</response>
        /// <response code="403">Usuário não possui a função (role) admin.</response>
        [HttpGet]
        [Route("mygames")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(GameListDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetMyGames()
        {
            var dto = _app.GetMyGames(User.Identity.Name);
            return Ok(dto);
        }

        /// <summary>
        /// Serviço para listar todos os jogos disponíveis de algum amigo.
        /// </summary>
        /// <param name="idUser">Identificado do usuário.</param>
        /// <returns>Lista de dados de jogo.</returns>
        /// <response code="200">Jogos listados com sucesso.</response>
        /// <response code="403">Usuário não possui as funções (roles) admin ou guest.</response>
        [HttpGet]
        [Route("gamesavailable/{idUser}")]
        [Authorize(Roles = "admin,guest")]
        [ProducesResponseType(typeof(GameListDto), StatusCodes.Status200OK)]
        public IActionResult GetGamesAvailable(Guid idUser)
        {
            var dto = _app.GetGamesAvailable(idUser);
            return Ok(dto);
        }
    }
}