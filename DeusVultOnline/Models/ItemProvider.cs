namespace DeusVultOnline.Models
{
    public class ItemProvider
    {
        public Item[] Weapons =
        {
            new Item
            {
                Name = "Bad Sword",
                ItemType = ItemType.Sword,
                AttackDie = new Die(1, 6),
                WeaponLength = 2,
                Cost = 0
            },
            new Item
            {
                Name = "Sword",
                ItemType = ItemType.Sword,
                AttackDie = new Die(1, 8),
                WeaponLength = 2,
                Cost = 2,
                Quality = 1
            },
            new Item
            {
                Name = "Good Sword",
                ItemType = ItemType.Sword,
                AttackDie = new Die(1, 10),
                WeaponLength = 2,
                Cost = 5,
                Quality = 2
            },
            new Item
            {
                Name = "Bad Dagger",
                ItemType = ItemType.Dagger,
                AttackDie = new Die(1, 10),
                WeaponLength = 0,
                Cost = 0
            },
            new Item
            {
                Name = "Dagger",
                ItemType = ItemType.Dagger,
                AttackDie = new Die(1, 12),
                WeaponLength = 0,
                Cost = 2,
                Quality = 1
            },
            new Item
            {
                Name = "Good Dagger",
                ItemType = ItemType.Dagger,
                AttackDie = new Die(2, 6),
                WeaponLength = 0,
                Cost = 5,
                Quality = 2
            },
            new Item
            {
                Name = "Bad Shield",
                ItemType = ItemType.Shield,
                MeleeAC = 2,
                RangedAC = 1,
                BombardAC = 2,
                Cost = 0
            },
            new Item
            {
                Name = "Shield",
                ItemType = ItemType.Shield,
                MeleeAC = 2,
                RangedAC = 2,
                BombardAC = 4,
                Cost = 2
            },
            new Item
            {
                Name = "Good Shield",
                ItemType = ItemType.Shield,
                MeleeAC = 2,
                RangedAC = 3,
                BombardAC = 6,
                Cost = 5
            },
            new Item
            {
                Name = "Light Armor",
                ItemType = ItemType.Shield,
                MeleeAC = 2,
                RangedAC = 1,
                BombardAC = 2,
                Cost = 0
            }
        };
    }
}