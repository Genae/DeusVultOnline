using System.Collections.Generic;

namespace DeusVultOnline.Characters
{
    public class Religion
    {
        public string God { get; set; }

        public Dictionary<int, string> RankName = new Dictionary<int, string>
        {
            {1, "Servant"},
            {2, "Priest"},
            {3, "High Priest"}
        };

        public Dictionary<int, int> SpellLevel = new Dictionary<int, int>
        {
            {1, 0},
            {2, 0},
            {3, 1},
            {4, 1}
        };

        public Dictionary<int, Dictionary<string, int>> Faith = new Dictionary<int, Dictionary<string, int>>
        {
            {1, new Dictionary<string, int> { { "Combat", 1}, {"Strength", 4} } },
            {2, new Dictionary<string, int> { { "Combat", 1}, {"Strength", 4}, {"Armor", 1} } }
        };

        //TODO Faith Attributes
    }
}