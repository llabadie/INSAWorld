﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSAWORLD
{
    public class Cyclops : Race
    {
        /// <summary>
        /// units' statistics of this race
        /// </summary>
        private int attack;
        private int defense;
        private int life;
        private int move;
        private const string type = "Cyclops";

        public Cyclops()
        {
            attack = 4;
            defense = 6;
            life = 12;
            move = 3;
        }

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        public int Life
        {
            get { return life; }
            set { life = value; }
        }

        public int Move
        {
            get { return move; }
            set { move = value; }
        }

        public string Type
        {
            get { return type; }
        }

        /// <summary>
        /// compute victory points earn by one unit
        /// </summary>
        /// <param name="u">target unit</param>
        /// <param name="myGame">reference to the game (to access game objects)</param>
        /// <returns>3 on desert, 2 on plain, 1 on volcano, 0 on swamp</returns>
        public int VictoryPoints(Unit u, ref Game myGame)
        {
            Tile t = myGame.Map.CasesJoueur[u.C];
            switch (t.getType())
            {
                case "desert": return 3;
                case "plain": return 2;
                case "volcano": return 1;
                case "swamp": return 0;
                default: return 0;
            }
        }

        /// <summary>
        /// try to move the unit on the tile with coord
        /// </summary>
        /// <param name="u">unit to move</param>
        /// <param name="c">coord to move on</param>
        /// <param name="myGame">reference to the game (to access game objects)</param>
        /// <returns>true if the unit can move on the tile, false if not</returns>
        public void ActionMove(Unit u, Coord c, ref Game myGame)
        {
            Player defender = null;
            if (myGame.Player1.RacePlay.Equals(u.Race)) defender = myGame.Player2;
            else defender = myGame.Player1;
            foreach (Unit unit in defender.UnitsList)
            {
                if (unit.C.Equals(c)) return;
            }
            u.C = c;
            u.MovePoints--;
        }

        /// <summary>
        /// move the unit on the tile of the killed unit if no other units on this tile
        /// </summary>
        /// <param name="u">unit to move</param>
        /// <param name="d">unit killed and his coord</param>
        /// <param name="map">reference to the map</param>
        public bool TryMove(Unit u, Coord c, ref Game myGame)
        {
            if (u.C.Equals(c) || (Math.Abs(u.C.X - c.X) + Math.Abs(u.C.Y - c.Y)) > 1 || u.MovePoints < 1)
            {
                return false;
            }

            return true;
        } 

        /// <summary>
        /// verifies if a unit can still move or if it has no move points remaining
        /// </summary>
        /// <param name="u">target unit</param>
        /// <param name="map">reference to the map</param>
        /// <returns>true if the unit can't move, false if if do</returns>
        public bool NoMoreMoves(Unit u, ref GameMap map)
        {
            return u.MovePoints == 0;
        }

        public bool Equals(Cyclops c)
        {
            return c.Type.Equals(type);
        }
        public static bool operator ==(Cyclops c, Cyclops c2)
        {
            return c.Equals(c2);
        }

        public static bool operator !=(Cyclops c, Cyclops c2)
        {
            return !c.Equals(c2);
        }
        public bool Equals(Race c)
        {
            return c.Type.Equals(type);
        }
    }
}
