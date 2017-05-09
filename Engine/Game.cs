using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// This is the game engine class which tracks the state of play. 
    /// </summary>
    public class Game
    {
        public GameState GameState { get; private set; }

        private IList<Move> Moves { get; } = new List<Move>();

        /// <summary>
        /// Used to make a move in the game
        /// </summary>
        /// <param name="move">The move to make in the game.</param>
        /// <returns>The result of the move containing validity of move, errror message, and game status.</returns>
        public MoveResult MakeMove(Move move)
        {
            var message = IsValidMove(move);
            if (!string.IsNullOrWhiteSpace(message))
            {
                return new MoveResult(false, message, GameState);
            }

            Moves.Add(new Move(move.Player, move.Position));

            UpdateGameState();
            return new MoveResult(true, message, GameState);
        }

        private void UpdateGameState()
        {
            var x = Moves.Where(s => s.Player == Players.X).Select(s => s.Position);
            var o = Moves.Where(s => s.Player == Players.O).Select(s => s.Position);
            bool isVictoryForX = false;
            bool isVictoryForO = false;

            foreach (var combo in Wins.Combos)
            {
                // check if a win combination is a subset of each players' moves
                //
                isVictoryForX = !combo.Except(x).Any();
                isVictoryForO = !combo.Except(o).Any();

                if (isVictoryForX || isVictoryForO)
                    break;
            }

            if (isVictoryForX)
                GameState = GameState.X_Wins;
            else if (isVictoryForO)
                GameState = GameState.O_Wins;
            else if (Moves.Count == 9 && !isVictoryForO && !isVictoryForX)
                GameState = GameState.Draw;
            else if (GameState == GameState.X_Move)
                GameState = GameState.O_Move;
            else if (GameState == GameState.O_Move)
                GameState = GameState.X_Move;
        }

        public IList<Move> GetAllMoves()
        {
            var moves = new List<Move>();
            moves.AddRange(Moves);
            return moves;
        }

        private string IsValidMove(Move move)
        {
            if (GameState == GameState.Draw
                || GameState == GameState.X_Wins
                || GameState == GameState.O_Wins)
            {
                return $"Game is over: {this.GameState.ToString()}";
            }

            if (Moves.Count == 0 && move.Player == Players.O)
                return "Player X must move first.";

            if (this.GameState == GameState.X_Move && move.Player == Players.O)
                return "Player X must move.";

            if (this.GameState == GameState.O_Move && move.Player == Players.X)
                return "Player O must move.";

            if (Moves.Any(s => s.Position == move.Position))
                return "Position is unavailable.";

            return "";
        }
    }
}
