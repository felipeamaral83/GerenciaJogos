namespace GerenciaJogos.ApplicationService.Validation.AccountValidation
{
    public class AccountValidation
    {
        public AccountValidation(AccountCreateValidation createValidation)
        {
            CreateValidation = createValidation;
        }

        public AccountCreateValidation CreateValidation { get; }
    }
}
