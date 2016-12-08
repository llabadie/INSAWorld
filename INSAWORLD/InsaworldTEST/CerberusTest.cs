﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;
using System.Linq;

namespace InsaworldTEST
{
    [TestClass()]
    public class CerberusTest
    {
        Player p;
        Game g;

        [TestInitialize()]
        public void Setup()
        {
            p = new Player("Michel", 1, 6);
            Player temp = new Player("Jean", 2, 6);
            g = new Game(ref p, ref temp);
            g.Initialize(0);
        }

        /// <summary>
        /// test Cerberus constructor
        /// </summary>
        [TestMethod()]
        public void TestCerberus()
        {
            Assert.IsInstanceOfType(p.RacePlay, typeof(Cerberus));
            Assert.IsNotNull(p.RacePlay.Life);
        }

        /// <summary>
        /// test if a wrong race is choose, an exception is risen
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(BadRaceException))]
        public void TestCerberusFail()
        {
            Player trash = new Player("Batman", 5, 6);
        }

        /// <summary>
        /// test if a unit is moved by the ActionMove method
        /// </summary>
        [TestMethod()]
        public void TestActionMove()
        {
            var u = p.UnitsList.First();
            Coord changed = new Coord(u.C.X + 1, u.C.Y);
            p.RacePlay.ActionMove(u, changed, ref g);
            Coord n = p.UnitsList.First().C;
            Assert.AreEqual(changed, n);
        }

        /// <summary>
        /// test if when the unit is asked to move too far, it returns false
        /// </summary>
        [TestMethod()]
        //[ExpectedException(typeof(OutOfBoundException))]
        public void TestActionMoveFail()
        {
            var u = p.UnitsList.First();
            Coord changed = new Coord(u.C.X + 10, u.C.Y + 10);
            bool test = p.RacePlay.ActionMove(u, changed, ref g);
            Assert.IsFalse(test);
            
        }

        /// <summary>
        /// test if at the beginning of the game players have points
        /// test if when a player have no more units, he has no point and lost
        /// </summary>
        [TestMethod()]
        public void TestVictoryPoints()
        {
            Unit v = p.UnitsList.First();
            if (g.Map.CasesJoueur[v.C].getType().Equals("plain")) Assert.AreEqual(p.RacePlay.VictoryPoints(v, ref g), 0);
            else Assert.AreNotEqual(p.RacePlay.VictoryPoints(v, ref g), 0);


        }

        /// <summary>
        /// test if the unit can move with this method
        /// </summary>
        [TestMethod()]
        public void TestTryMove()
        {
            Unit u = p.UnitsList.First();
            Coord temp = new Coord(u.C.X + 1, u.C.Y);
            Assert.IsTrue(p.RacePlay.TryMove(u, temp, ref g));

            u.MovePoints = 0;
            Assert.IsFalse(p.RacePlay.TryMove(u, temp, ref g));
        }

        /// <summary>
        /// test if a unit with no life points can't move 
        /// </summary>
        [TestMethod()]
        public void TestNoMoreMoves()
        {
            Unit u = p.UnitsList.First();
            u.MovePoints = 0;
            GameMap m = g.Map;
            Assert.IsTrue(p.RacePlay.NoMoreMoves(u, ref m));
        }
    }
}
