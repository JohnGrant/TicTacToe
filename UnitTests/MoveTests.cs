using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Engine;

namespace UnitTests
{
    [TestClass]
    public class MoveTests
    {
        [TestMethod]
        public void Can_Create_Move()
        {
            var move = new Move(Players.X, 1);
            Assert.IsNotNull(move);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Given_InvalidPosition_ThrowException()
        {
            var move = new Move(Players.X, 0);
        }
    }
}
