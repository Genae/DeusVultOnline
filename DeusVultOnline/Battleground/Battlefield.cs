using System;
using System.Collections.Generic;

namespace DeusVultOnline.Battleground
{
    public class Battlefield
    {
        public int Size;
        public TerrainTile[,] BattlefieldTiles; 

        public Battlefield(int size)
        {
            Size = size;
            InitTerrain();
        }

        private void InitTerrain() //Init to TerrainType.Plain
        {
            BattlefieldTiles = new TerrainTile[Size, Size];

            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    BattlefieldTiles[x, y] = new TerrainTile(TerrainType.Plain, new Position(x, y));
                }
            }
        }

        public List<TerrainTile> GetPositionsInRange(TerrainTile tile) 
        {
            var list = new List<TerrainTile>();
            var movement = BattlefieldTiles[tile.Pos.X, tile.Pos.Y].Regiment.Movement;
            var pos = tile.Pos;
            for (int x = pos.X - movement; x <= pos.X + movement; x++)
            {
                for (int y = pos.Y - movement; y <= pos.Y + movement; y++)
                {
                    if(IsPositionEmpty(new Position(x, y)))
                    {
                        list.Add(BattlefieldTiles[x, y]);
                    }
                }
            }
            return list;
        }

        private bool IsPositionEmpty(Position pos)
        {
            if (IsPositionInBattlefield(pos))
            {
                if (BattlefieldTiles[pos.X, pos.Y].Regiment == null)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsPositionInBattlefield(Position pos)
        {
            if (pos.X >= 0 && pos.X < Size && pos.Y >= 0 && pos.Y < Size) return true;
            return false;
        }
        

    }
}