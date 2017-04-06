namespace DeusVultOnline.Characters
{
    public class Religion
    {
        public enum God
        {
            Jaboku,
            Jakobu,
            Seiren,
            Bachus,
            Groht
        }
        public int Level { get; set; }
        public string Rank { get; set; }
        public int SpellLevel { get; set; }
    }
}