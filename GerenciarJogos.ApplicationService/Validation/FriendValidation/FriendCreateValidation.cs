using FluentValidation;
using GerenciaJogos.Domain.Entities;

namespace GerenciaJogos.ApplicationService.Validation.FriendValidation
{
    public class FriendCreateValidation : BaseValidation<Friend>
    {
        public FriendCreateValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(RequiredField("Nome"))
                .MaximumLength(100).WithMessage(InvalidSizeField("Nome", 100));

            RuleFor(x => x.Nickname)
                .MaximumLength(50).WithMessage(InvalidSizeField("Apelido", 50));

            RuleFor(x => x.Whatsapp)
                .MaximumLength(11).WithMessage(InvalidSizeField("Whatsapp", 11));
        }
    }
}
