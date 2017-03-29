using DeusVultOnline.Models;

namespace DeusVultOnline.Battleground
{
    public enum TerrainType
    {
        Plain, 
        Hill,
        Mountain,
        Default
    }

    public class TerrainTile
    {
        public TerrainType Type { get; set; }

        public Regiment100 Regiment { get; set; }

        public TerrainTile(TerrainType type)
        {
            Type = type;
            Regiment = null;
        }
        
    }
}