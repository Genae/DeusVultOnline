using System;
using System.Collections.Generic;

namespace DeusVultOnline.Battleground
{
    public class Battlefield
    {
        public int Size;
        private TerrainTile[,] _battlefieldTiles; 

        public Battlefield(int size)
        {
            Size = size;
            InitTerrain();
        }

        private void InitTerrain() //Init to TerrainType.Plain
        {
            _battlefieldTiles = new TerrainTile[Size, Size];

            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    _battlefieldTiles[x, y] = new TerrainTile(TerrainType.Plain);
                }
            }
        }

        private bool IsPositionEmpty(Position pos)
        {
            if (IsPositionInBattlefield(pos))
            {
                if (_battlefieldTiles[pos.X, pos.Y].Regiment != null)
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