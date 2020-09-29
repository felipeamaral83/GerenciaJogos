namespace GerenciaJogos.ApplicationService.Validation.FriendValidation
{
    public class FriendValidation
    {
        public FriendValidation(
            FriendCreateValidation createValidation,
            FriendUpdateValidation updateValidation,
            FriendDeleteValidation deleteValidation)
        {
            CreateValidation = createValidation;
            UpdateValidation = updateValidation;
            DeleteValidation = deleteValidation;
        }

        public FriendCreateValidation CreateValidation { get; }
        public FriendUpdateValidation UpdateValidation { get; }
        public FriendDeleteValidation DeleteValidation { get; }
    }
}
