using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// The different states the game may be in: X's Move, O's Move, X Wins, O Wins, or Draw.
    /// </summary>
    public enum GameState
    {
        X_Move,
        O_Move,
        X_Wins,
        O_Wins,
        Draw
    }
}
