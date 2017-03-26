using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DeusVultOnline.Models
{
    public class Regiment : ArmyGroup
    {
        public int Moral
        {
            get { return Units.Sum(x => x.Moral)/Units.Count; }
        }

        [JsonIgnore]
        public List<Unit> Units { get; set; } = new List<Unit>();

        public int UnitCount => Units.Count;
        public Formation Fromation { get; set; }

        public override int GetMarshall()
        {
            return Leader?.Marshall??0;
        }

        public int MarshallBonus => GetBonus();
    }

    public class Regiment500 : ArmyGroup
    {
        public override int GetMarshall()
        {
            return (Leader.Marshall - 8)/4;
        }
    }

    public class Regiment2000 : ArmyGroup
    {
        public override int GetMarshall()
        {
            return (Leader.Marshall - 12) / 6;
        }
    }

    public class Regiment10000 : ArmyGroup
    {
        public override int GetMarshall()
        {
            return (Leader.Marshall - 16) / 10;
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
            return Leader?.Marshall??0;
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