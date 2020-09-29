using GerenciaJogos.ApplicationService.Dtos.Friend;
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
    public class FriendController : ControllerBase
    {
        private readonly FriendApplicationService _app;

        public FriendController(FriendApplicationService app)
        {
            _app = app;
        }

        /// <summary>
        /// Serviço para criar um amigo.
        /// </summary>
        /// <param name="dto">Dados para cadastro.</param>
        /// <returns></returns>
        /// <response code="204">Cadastro realizado com sucesso.</response>
        /// <response code="400">Erro na validação do Serviço.</response>
        /// <response code="403">Usuário não possui a função (role) admin.</response>
        [HttpPost]
        [Route("")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(FriendPostDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create(FriendPostDto dto)
        {
            var validationResult = await _app.Create(dto, User.Identity.Name);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            return NoContent();
        }

        /// <summary>
        /// Serviço para atualizar um amigo.
        /// </summary>
        /// <param name="dto">Dados para atualizar.</param>
        /// <returns></returns>
        /// <response code="204">Cadastro atualizado com sucesso.</response>
        /// <response code="400">Erro na validação do Serviço.</response>
        /// <response code="403">Usuário não possui a função (role) admin.</response>
        [HttpPut]
        [Route("")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(FriendPutDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Update(FriendPutDto dto)
        {
            var validationResult = await _app.Update(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            return NoContent();
        }

        /// <summary>
        /// Serviço para excluir um amigo.
        /// </summary>
        /// <param name="id">Identificador do amigo.</param>
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
        /// Serviço para obter todos os amigos do usuário logado.
        /// </summary>
        /// <returns>Lista de dados de amigo.</returns>
        /// <response code="200">Amigos listados com sucesso.</response>
        /// <response code="403">Usuário não possui a função (role) admin.</response>
        [HttpGet]
        [Route("all")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(FriendListDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetAll()
        {
            var dto = _app.GetAll(User.Identity.Name);
            return Ok(dto);
        }
    }
}