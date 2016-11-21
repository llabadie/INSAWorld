﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using INSAWORLD;

namespace InsaworldTEST
{
    [TestClass]
    public class CentaursTest
    {

        Player p;

        [TestInitialize()]
        public void Initialize()
        {
            p = new Player("Michel", 0, 6);
        }

        [TestMethod]
        public void TestCentaurs()
        {
            Assert.IsInstanceOfType(p.RacePlay, typeof(Centaurs));
            Assert.IsNotNull(p.RacePlay.Life);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRaceException))]
        public void TestCentaursFail()
        {
            Player trash = new Player("Batman", 5, 6);
        }

        [TestMethod]
        public void TestActionMove()
        {
            System.Collections.Generic.IEnumerator<Unit> uList = p.UnitsList.Keys.GetEnumerator();
            Unit u = uList.Current;
            Coord c;
            p.UnitsList.TryGetValue(u, out c);
            Coord changed = new Coord(c.X + 1, c.Y + 1);
            p.RacePlay.ActionMove(u, changed);
            Coord n;
            p.UnitsList.TryGetValue(u, out n);
            Assert.AreEqual(changed, n);
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfBoundException))]
        public void TestActionMoveFail()
        {
            System.Collections.Generic.IEnumerator<Unit> uList = p.UnitsList.Keys.GetEnumerator();
            Unit u = uList.Current;
            Coord c;
            p.UnitsList.TryGetValue(u, out c);
            Coord changed = new Coord(c.X + 10, c.Y + 10);
            p.RacePlay.ActionMove(u, changed);
        }

        [TestMethod]
        public void TestVictoryPoints()
        {
            Assert.IsTrue(p.UnitsList != null & p.RacePlay.VictoryPoints() > 0);
            p.UnitsList.Clear();
            Assert.IsTrue(p.RacePlay.VictoryPoints() == 0);
        }
    }
}
