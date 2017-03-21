namespace DeusVultOnline.Models
{
    public class Item
    {
        public Die AttackDie;
        //TODO
        public int AC { get; set; }

        public bool IsShield
        {
            get { return AC > 0; }
        }
    }
}