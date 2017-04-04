using System.Collections.Generic;
using System.Linq;
using DeusVultOnline.Characters;
using Newtonsoft.Json;

namespace DeusVultOnline.Models
{
    public struct UnitGroup
    {
        public UnitGroup(UnitType type, int amount)
        {
            Type = type;
            Amount = amount;
        }
        public UnitType Type;
        public int Amount;
    }

    public class Regiment100 : ArmyGroup
    {
        public Regiment100(List<UnitGroup> grouplist)
        {
            Units = new List<Unit>();
            foreach (var group in grouplist)
            {
                for (int i = 0; i < group.Amount; i++)
                {
                    Units.Add(new Unit(group.Type));
                }
            }
        }

        public int Moral
        {
            get { return Units.Sum(x => x.Moral)/Units.Count; }
        }

        public int Movement
        {
            get { return Units.Min(x => x.Movement); }
        }

        [JsonIgnore]
        public List<Unit> Units { get; set; }

        public int UnitCount => Units.Count;

        public Formation Fromation { get; set; }

        public override int GetMarshall()
        {
            return Leader.Marshall?.Total ?? 0;
        }

        public int MarshallBonus => GetBonus();
    }

    public class Regiment500 : ArmyGroup
    {
        public override int GetMarshall()
        {
            return (Leader.Marshall.Total - 8)/4;
        }
    }

    public class Regiment2000 : ArmyGroup
    {
        public override int GetMarshall()
        {
            return (Leader.Marshall.Total - 12) / 6;
        }
    }

    public class Regiment10000 : ArmyGroup
    {
        public override int GetMarshall()
        {
            return (Leader.Marshall.Total - 16) / 10;
        }
    }

    public abstract class ArmyGroup
    {
        public Character Leader;

        [JsonIgnore]
        public ArmyGroup Parent;
        public List<ArmyGroup> Childs;

        public int GetBonus()
        {
            if (Parent != null)
            {
                return Parent.GetBonus() + GetMarshall();
            }
            return Leader.Marshall?.Total ?? 0;
        }

        public abstract int GetMarshall();

        public void AddChild(ArmyGroup child)
        {
            if(Childs == null)
                Childs = new List<ArmyGroup>();
            Childs.Add(child);
            child.Parent = this;
        }

    }
}