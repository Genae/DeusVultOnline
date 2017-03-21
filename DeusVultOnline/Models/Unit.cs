using System.Collections.Generic;

namespace DeusVultOnline.Models
{
    public class Unit
    {
        public int Health { get; set; }
        public int Experience { get; set; }
        public int MeleeAC { get; set; }
        public int RangedAC { get; set; }
        public int BombardAC { get; set; }
        public int Attack { get; set; }
        public int FrontWidth { get; set; } = 1; //Space occupied on Front: default 1

        public int Moral { get; set; }

        public List<Modifier> Modifiers;

        public Inventory Inventory;

        public int GetDamage(int vsAC)
        {
            var atk = Attack;
            return atk - vsAC;
        }

    }
}