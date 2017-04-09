using System.Collections.Generic;

namespace DeusVultOnline.Characters
{
    public class ReligionProvider
    {
        public static Religion[] Religions =
        {
            new Religion
            {
                God = "Jaboku",
                Faith  = new Dictionary<int, Dictionary<string, int>>
                {
                    {1, new Dictionary<string, int> { { "Marshal", 1}, {"Attack", 1} } },
                    {2, new Dictionary<string, int> { { "Marshal", 2}, { "Attack", 1}, {"Health", 3}, { "Technique", 1} } },
                    {3, new Dictionary<string, int> { { "Marshal", 3}, { "Attack", 2}, {"Health", 3}, { "Technique", 2}, {"Armor", 1} } },
                    {4, new Dictionary<string, int> { { "Marshal", 5}, { "Attack", 3}, {"Health", 6}, { "Technique", 3}, {"Armor", 2} } },
                    {5, new Dictionary<string, int> { { "Marshal", 7}, { "Attack", 4}, {"Health", 12}, { "Technique", 5}, {"Armor", 3} } },
                    {6, new Dictionary<string, int> { { "Marshal", 10}, { "Attack", 6}, {"Health", 15}, { "Technique", 7}, {"Armor", 4} } },
                }
            },
            new Religion
            {
                God = "Seiren",
                RankName = new Dictionary<int, string>
                {
                    {1, "Novice" },
                    {2, "Monk" },
                    {3, "High Monk" },
                }
            },
            new Religion
            {
                God = "Bachus"
            },
            new Religion
            {
                God = "Grohk"
            }
        };
    }
}
