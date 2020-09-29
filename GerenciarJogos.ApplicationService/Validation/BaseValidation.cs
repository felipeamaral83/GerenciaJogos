using FluentValidation;

namespace GerenciaJogos.ApplicationService.Validation
{
    public abstract class BaseValidation<T> : AbstractValidator<T>
    {
        protected string RequiredField(string field) => $"O campo {field} é obrigatório.";
        protected string InvalidSizeField(string field, int size) => $"O campo {field} deve possuir no máximo {size} caracteres.";
    }
}
