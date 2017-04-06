using System.Collections.Generic;

namespace DeusVultOnline.Characters
{
    public class ReligionProvider
    {
        public Religion[] Religions =
        {
            new Religion
            {
                God = "Jaboku",
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
