using System.Collections.Generic;

namespace DeusVultOnline.Characters
{
    public class Religion
    {
        public string God { get; set; }

        public Dictionary<int, string> RankName = new Dictionary<int, string>
        {
            {1, "Follower"},
            {2, "Servant"},
            {3, "Priest"},
            {4, "High Priest"},
            {5, "Apostel"},
            {6, "Prophet"}
        };

        public Dictionary<int, int> SpellLevel = new Dictionary<int, int>
        {
            {1, 0},
            {2, 0},
            {3, 1},
            {4, 2},
            {5, 3},
            {6, 4}
        };

        public Dictionary<int, Dictionary<string, int>> Faith = new Dictionary<int, Dictionary<string, int>>();

        //TODO Faith Attributes
    }
}