﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Peices
{
    public class Queen : ChessPiece
    {
        public override List<Vector2> getMoves(GameState state)
        {
            List<Vector2> results = new List<Vector2>();

            Vector2[] directions = new Vector2[] {
                new Vector2(0, 1), new Vector2(0, -1), new Vector2(1, 0), new Vector2(-1, 0),
                new Vector2(1, 1), new Vector2(-1, 1), new Vector2(1, -1), new Vector2(-1, -1)};

            for (int i = 0; i < directions.Length; i++)
            {
                int l = 1;
                Vector2 p = this.peicePosition + l * directions[i];
                bool canMoveTo = state.canMoveTo(p, this.peiceColor);

                while (canMoveTo)
                {
                    l++;

                    results.Add(p);

                    p = this.peicePosition + l * directions[i];
                    canMoveTo = state.canMoveTo(p, this.peiceColor) && !state.squareFilled(this.peicePosition + (l - 1) * directions[i]);
                }
            }

            return results;
        }

        public override List<Vector2> getControlledSquares(GameState state)
        {
            return getMoves(state);
        }

        public Queen(COLOR color) : base(color, TYPE.QUEEN)
        {
        }
    }
}
