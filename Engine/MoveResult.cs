using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// The result for a game move.
    /// </summary>
    public class MoveResult
    {
        /// <summary>
        /// Was the requested move valid.
        /// </summary>
        public bool IsValid { get; private set; }
        /// <summary>
        /// If the move was NOT valid message will contain the reason why.
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// The state of the game after the requested move
        /// </summary>
        public GameState GameState { get; private set; }

        public MoveResult(bool isValid, string message, GameState gameState)
        {
            IsValid = isValid;
            Message = message;
            GameState = gameState;
        }
    }
}
