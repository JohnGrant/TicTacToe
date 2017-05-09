using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    /// <summary>
    /// The model for a move in the game. 
    /// Assumes board positions are numbered 1-9 starting in the top left corner, proceeding right, and ending in the bottom right corner of the board.
    /// </summary>
    public class Move
    {
        public Players Player { get; }
        public byte Position { get; }

        //
        public Move(Players player, byte position)
        {
            if (position < 1 || position > 9)
                throw new ArgumentException("Position must be between 1 and 9 inclusive", nameof(position));

            Player = player;
            Position = position;
        }
    }
}
