namespace GerenciaJogos.ApplicationService.Validation.GameValidation
{
    public class GameValidation
    {
        public GameValidation(
            GameCreateValidation createValidation,
            GameUpdateValidation updateValidation,
            GameDeleteValidation deleteValidation)
        {
            CreateValidation = createValidation;
            UpdateValidation = updateValidation;
            DeleteValidation = deleteValidation;
        }

        public GameCreateValidation CreateValidation { get; }
        public GameUpdateValidation UpdateValidation { get; }
        public GameDeleteValidation DeleteValidation { get; }
    }
}
