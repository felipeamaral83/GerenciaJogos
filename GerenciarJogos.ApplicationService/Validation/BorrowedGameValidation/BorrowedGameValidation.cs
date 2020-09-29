namespace GerenciaJogos.ApplicationService.Validation.BorrowedGameValidation
{
    public class BorrowedGameValidation
    {
        public BorrowedGameValidation(
            BorrowedGameLendValidation borrowedGameLendValidation,
            BorrowedGameGiveBackValidation borrowedGameGiveBackValidation)
        {
            LendValidation = borrowedGameLendValidation;
            GiveBackValidation = borrowedGameGiveBackValidation;
        }

        public BorrowedGameLendValidation LendValidation { get; }
        public BorrowedGameGiveBackValidation GiveBackValidation { get; }
    }
}
