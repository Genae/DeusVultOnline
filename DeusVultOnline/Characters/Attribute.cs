using MongoDB.Driver;

namespace DeusVultOnline.Characters
{
    public class Attribute
    {
        //Attribute Modifiers
        public int Base { get; set; }
        public int Gen { get; set; }
        public int Edu { get; set; }
        public int Faith { get; set; }
        public int Lifest { get; set; }
        public int Temp{ get; set; }
        public int Bonus { get; set; }
        //CombatAttribute Madifiers
        public int Skill { get; set; }
        public int Equip { get; set; }
        //Total values
        public int Total => (Base + Gen + Edu + Faith + Lifest + Temp + Bonus + Skill);
    }

}