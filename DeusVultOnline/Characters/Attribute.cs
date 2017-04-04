using MongoDB.Driver;

namespace DeusVultOnline.Characters
{
    public class Attribute
    {
        public int Base { get; set; }
        public int Gen { get; set; }
        public int Edu { get; set; }
        public int Faith { get; set; }
        public int Lifest { get; set; }
        public int Temp{ get; set; }
        public int Bonus { get; set; }
        public int Total => (Base + Gen + Edu + Faith + Lifest + Temp + Bonus);
    }

}