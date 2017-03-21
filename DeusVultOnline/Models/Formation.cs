using System.Collections.Generic;
using System.Linq;

namespace DeusVultOnline.Models
{
    public abstract class Formation
    {
        public string Name { get; set; }
        public int FrontWidth { get; set; }
        public List<Modifier> Modifiers;

        protected Formation(string name, int frontwidth, List<Modifier> modifiers)
        {
            Name = name;
            FrontWidth = frontwidth;
            Modifiers = modifiers;
        }

        public abstract bool IsValid(Regiment reg);
    }

    public class TurtleFormation : Formation
    {
        public TurtleFormation() : base("Turtle", 20, null)
        {
        }

        public override bool IsValid(Regiment reg)
        {
            return reg.Units.Count(u => u.Inventory.SecondaryWeapon.IsShield) > reg.Units.Count * 0.8 && reg.Units.Count > 50;
        }
    }
}