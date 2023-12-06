
//Not Needed

namespace CS233_ASPnet_TicTacToe_JohnMoreau.Models
{
    public class TicTacToeSession
    {

        private const string GameKey = "game";

        private ISession session { get; set; }

        public TicTacToeSession(ISession session) => this.session = session;


        public void SetGame(TicTacToe game)
        {
            session.SetObject(GameKey, game);
        }

        public TicTacToe GetGame() => session.GetObject<TicTacToe>(GameKey) ?? new TicTacToe();

        public void NewGame() => SetGame(new TicTacToe());

    }
}
