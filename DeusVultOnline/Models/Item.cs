namespace DeusVultOnline.Models
{
    public class Item
    {
        public string Name { get; set; }
        public ItemType ItemType;
        public float Quality;
        public Die AttackDie;
        //TODO
        public int MeleeAC { get; set; }
        public int RangedAC { get; set; }
        public int BombardAC { get; set; }

        public int WeaponLength { get; set; }
        public int Range { get; set; }

        public int Cost { get; set; }

        public bool IsShield => MeleeAC > 0;
    }

    public enum ItemType
    {
        Sword,
        Spear,
        Bow,
        Shield,
        Dagger,
        Greatwsord,
        Axe,
        Warhammer,
        Mace,
        Crossbow,
        LightAmour,
        MediumArmour,
        HeavyArmour,
        Wand,
        Staff
    }
}