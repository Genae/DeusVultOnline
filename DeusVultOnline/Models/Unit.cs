using System.Collections.Generic;

namespace DeusVultOnline.Models
{
    public class Unit
    {
        public Unit(){ } //bad fix for Character class error

        public Unit(UnitType unitType)
        {
            Health = 10;
            Experience = 0;
            Moral = 1;
            Movement = 1;

            UnitType = unitType;
        }

        public int Health { get; set; }
        public int Experience { get; set; }
        public int Moral { get; set; }

        public int Movement { get; set; }
        public int MeleeAC { get; set; }
        public int RangedAC { get; set; }
        public int BombardAC { get; set; }
        public int Attack { get; set; }

        public List<Modifier> Modifiers;

        public UnitType UnitType;

        public int GetDamage(int vsAC)
        {
            var atk = Attack;
            return atk - vsAC;
        }
    }

    public class UnitType
    {
        public UnitType(Inventory inventory, int frontwidth)
        {
            Inventory = inventory;
            FrontWidth = frontwidth;
        }
        public int FrontWidth { get; set; } = 1; //Space occupied on Front: default 1
        public Inventory Inventory;
    }
}