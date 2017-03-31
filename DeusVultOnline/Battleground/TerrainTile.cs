using DeusVultOnline.Models;

namespace DeusVultOnline.Battleground
{
    public enum TerrainType
    {
        Plain, 
        Hill,
        Mountain
    }

    public class TerrainTile
    {
        public TerrainType Type { get; set; }
        public Position Pos { get; set; }

        public Regiment100 Regiment { get; set; }

        public TerrainTile(TerrainType type, Position pos)
        {
            Type = type;
            Pos = pos;
            Regiment = null;
        }
        
    }
}