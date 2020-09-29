using FluentValidation.Results;
using GerenciaJogos.ApplicationService.Dtos.Friend;
using GerenciaJogos.ApplicationService.Validation.FriendValidation;
using GerenciaJogos.Domain.Entities;
using GerenciaJogos.Infrastructure.Data.Interfaces.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaJogos.ApplicationService.Services
{
    public class FriendApplicationService
    {
        private readonly IFriendUnitOfWork _uow;
        private readonly FriendValidation _friendValidation;
        private readonly AccountApplicationService _accountApplicationService;

        public FriendApplicationService(
            IFriendUnitOfWork uow,
            FriendValidation friendValidation,
            AccountApplicationService accountApplicationService)
        {
            _uow = uow;
            _friendValidation = friendValidation;
            _accountApplicationService = accountApplicationService;
        }

        public async Task<ValidationResult> Create(FriendPostDto dto, string username)
        {
            var user = _accountApplicationService.GetByUsername(username);
            var friend = CreateMapper(dto, user.Id);
            var validationResult = await _friendValidation.CreateValidation.ValidateAsync(friend);

            if (!validationResult.IsValid)
                return validationResult;

            _uow.FriendRepository.Add(friend);
            await _uow.CommitAsync();
            return validationResult;
        }

        public async Task<ValidationResult> Update(FriendPutDto dto)
        {
            var friend = await _uow.FriendRepository.GetByIdAsync(dto.Id);
            friend = UpdateMapper(friend, dto);
            var validationResult = await _friendValidation.UpdateValidation.ValidateAsync(friend);

            if (!validationResult.IsValid)
                return validationResult;

            _uow.FriendRepository.Edit(friend);
            await _uow.CommitAsync();
            return validationResult;
        }

        public async Task<ValidationResult> Delete(Guid id)
        {
            var friend = await _uow.FriendRepository.GetByIdAsync(id);
            var validationResult = await _friendValidation.DeleteValidation.ValidateAsync(friend);

            if (!validationResult.IsValid)
                return validationResult;

            _uow.FriendRepository.Delete(friend);
            await _uow.CommitAsync();
            return validationResult;
        }

        public List<FriendListDto> GetAll(string username)
        {
            var user = _accountApplicationService.GetByUsername(username);
            var queryFriend = _uow.FriendRepository
                .GetAllReadOnly()
                .Where(x => x.IdUser == user.Id);
            
            var friends = queryFriend.Select(x => new FriendListDto
            {
                Id = x.Id,
                Name = x.Name,
                Nickname = x.Nickname,
                Whatsapp = x.Whatsapp
            }).OrderBy(x => x.Name)
            .ToList();

            return friends;
        }

        /* O mapeamento entre entidade e DTO pode ser automatizado por bibliotecas como AutoMapper,
         * porém, já ouvi várias opiniões positivas e negativas sobre o uso do AutoMapper. */
        private Friend CreateMapper(FriendPostDto dto, Guid idUser)
        {
            var friend = new Friend
            {
                IdUser = idUser,
                Name = dto.Name,
                Nickname = dto.Nickname,
                Whatsapp = dto.Whatsapp
            };

            return friend;
        }

        private Friend UpdateMapper(Friend friend, FriendPutDto dto)
        {
            friend.Name = dto.Name;
            friend.Nickname = dto.Nickname;
            friend.Whatsapp = dto.Whatsapp;

            return friend;
        }
    }
}
