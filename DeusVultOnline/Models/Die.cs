using System;

namespace DeusVultOnline.Models
{
    public class Die
    {
        public int Sides;
        public int Amount;

        public Die(int amount, int sides)
        {
            Amount = amount;
            Sides = sides;
        }

        public int Roll(bool exploding)
        {
            var rand = new Random();
            var sum = 0;
            for (var i = 0; i < Amount; i++)
            {
                if (exploding)
                {
                    sum += RollExploding(Sides, rand);
                }
                else
                {
                    sum += rand.Next(1, Sides);
                }
            }
            return sum;
        }

        private int RollExploding(int max, Random rand)
        {
            var roll = rand.Next(1, max);
            if (roll != max)
                return roll;
            return RollExploding(max, rand) + max-1;
        }
    }
}