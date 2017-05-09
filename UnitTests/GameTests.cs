using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Engine;

namespace UnitTests
{
    [TestClass]
    public class GameTests
    {
        IList<Move> XWinsData = new List<Move>()
        {
            new Move(Players.X, 1),
            new Move(Players.O, 7),
            new Move(Players.X, 2),
            new Move(Players.O, 8),
            new Move(Players.X, 3),
        };

        IList<Move> OWinsData = new List<Move>()
        {
            new Move(Players.X, 1),
            new Move(Players.O, 3),
            new Move(Players.X, 4),
            new Move(Players.O, 7),
            new Move(Players.X, 6),
            new Move(Players.O, 5),
        };

        IList<Move> DrawData = new List<Move>()
        {
            new Move(Players.X,1),
            new Move(Players.O,2),
            new Move(Players.X,9),
            new Move(Players.O,5),
            new Move(Players.X,4),
            new Move(Players.O,7),
            new Move(Players.X,3),
            new Move(Players.O,6),
            new Move(Players.X,8)
        };

        [TestMethod]
        public void Can_Create_Game()
        {
            var game = new Game();
            Assert.IsNotNull(game);
        }

        [TestMethod]
        public void Given_New_Game_X_Moves()
        {
            var game = new Game();
            Assert.AreEqual(GameState.X_Move, game.GameState);
        }

        [TestMethod]
        public void Can_Make_Move()
        {
            var game = new Game();
            var move = new Move(Players.X, 1);
            game.MakeMove(move);

            Assert.AreEqual(game.GetAllMoves().Count, 1);
        }

        [TestMethod]
        public void Given_FirstMoveO_InvalidResult()
        {
            var game = new Game();
            var move = new Move(Players.O, 1);
            var result = game.MakeMove(move);
            Assert.AreEqual(false, result.IsValid);
            Assert.AreEqual("Player X must move first.", result.Message);
        }

        [TestMethod]
        public void Given_PlayerXMove_State_Updated()
        {
            var game = new Game();
            var move = new Move(Players.X, 1);
            var result = game.MakeMove(move);
            Assert.AreEqual(GameState.O_Move, result.GameState);
        }

        [TestMethod]
        public void Given_PlayerOMove_State_Updated()
        {
            var game = new Game();
            var move = new Move(Players.X, 1);
            game.MakeMove(move);
            move = new Move(Players.O, 2);
            var result = game.MakeMove(move);
            Assert.AreEqual(GameState.X_Move, result.GameState);
        }

        [TestMethod]
        public void Given_UnavailableMove_NotValidResult()
        {
            var game = new Game();
            var move = new Move(Players.X, 1);
            game.MakeMove(move);
            move = new Move(Players.O, 1);
            var result = game.MakeMove(move);
            Assert.AreEqual(false, result.IsValid);
            Assert.AreEqual("Position is unavailable.", result.Message);
        }

        [TestMethod]
        public void Given_DoubleMoves_NotValidResult()
        {
            var game = new Game();
            var move = new Move(Players.X, 1);
            var result = game.MakeMove(move);
            Assert.AreEqual(true, result.IsValid);
            Assert.AreEqual(GameState.O_Move, result.GameState);
            move = new Move(Players.X, 2);
            result = game.MakeMove(move);
            Assert.AreEqual(false, result.IsValid);
            Assert.AreEqual("Player O must move.", result.Message);
        }

        [TestMethod]
        public void X_Wins()
        {
            MoveResult result = null;
            var game = new Game();
            foreach(var move in XWinsData)
            {
                result = game.MakeMove(move);
                Assert.IsTrue(result.IsValid);
                Assert.AreEqual("", result.Message);
            }

            Assert.AreEqual(GameState.X_Wins, result.GameState);
        }

        [TestMethod]
        public void O_Wins()
        {
            MoveResult result = null;
            var game = new Game();
            foreach(var move in OWinsData)
            {
                result = game.MakeMove(move);
                Assert.IsTrue(result.IsValid);
                Assert.AreEqual("", result.Message);
            }
            Assert.AreEqual(GameState.O_Wins, result.GameState);
        }

        [TestMethod]
        public void Draw()
        {
            MoveResult result = null;
            var game = new Game();
            foreach (var move in DrawData)
            {
                result = game.MakeMove(move);
                Assert.IsTrue(result.IsValid);
                Assert.AreEqual("", result.Message);
            }
            Assert.AreEqual(GameState.Draw, result.GameState);
        }
    }

}
