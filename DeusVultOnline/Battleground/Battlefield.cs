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
                    _battlefieldTiles[x, y] = new TerrainTile(TerrainType.Plain, new Position(x, y));
                }
            }
        }

        private List<TerrainTile> GetPositionsInRange(TerrainTile tile) //List of TerrainTiles or List of Positions? dunno whats better
        {
            var list = new List<TerrainTile>();
            var movement = _battlefieldTiles[tile.Pos.X, tile.Pos.Y].Regiment.Movement;
            var pos = tile.Pos;
            for (int x = pos.X - movement; x < pos.X + movement; x++)
            {
                for (int y = pos.Y - movement; y < pos.Y + movement; y++)
                {
                    if(IsPositionEmpty(new Position(x, y)))
                    {
                        list.Add(_battlefieldTiles[x, y]);
                    }
                }
            }
            return list;
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