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

        /// <summary>
        /// compute victory points earn by one unit
        /// </summary>
        /// <returns>3 on desert, 2 on plain, 1 on volcano, 0 on swamp</returns>
        public int VictoryPoints(Unit u, ref Game myGame)
        {
            Coord c;
            if (myGame.Player1.UnitsList.ContainsKey(u)) { c = myGame.Player1.UnitsList[u]; }
            else { c = myGame.Player2.UnitsList[u]; }
            Tile t = myGame.Map.CasesJoueur[c];
            switch (t.GetType().ToString())
            {
                case "Desert": return 3;
                case "Plain": return 2;
                case "Volcano": return 1;
                case "Swamp": return 0;
                default: return 0;
            }
        }

        /// <summary>
        /// try to move the unit on the tile with coord
        /// </summary>
        /// <param name="u">unit to move</param>
        /// <param name="c">coord to move on</param>
        /// <returns>true if the unit can move on the tile, false if not</returns>
        public bool ActionMove(Unit u, Coord c, ref Game myGame)
        {
            
            throw new NotImplementedException();
        } 

        /// <summary>
        /// move the unit on the tile of the killed unit if no other units on this tile
        /// </summary>
        /// <param name="u">unit to move</param>
        /// <param name="c">move on those coord</param>
        public void MoveOverride(Unit u, KeyValuePair<Unit, Coord> d, ref Game myGame)
        {
            bool movement = true;
            IDictionary<Unit, Coord> list1;
            IDictionary<Unit, Coord> list2;
            if (myGame.Player1.UnitsList.Contains(d))
            {
                list1 = myGame.Player1.UnitsList;
                list2 = myGame.Player2.UnitsList;
            }
            else
            {
                list1 = myGame.Player2.UnitsList;
                list2 = myGame.Player1.UnitsList;
            }
            foreach (Unit t in list1.Keys)
            {
                if (list1[t].Equals(d.Value) & !t.Equals(d.Key)) { movement = false; }
            }
            if (movement) { list2[u] = d.Value; }
        }
    }
}
