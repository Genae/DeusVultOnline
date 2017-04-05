using System.Collections.Generic;
using DeusVultOnline.Battleground;
using DeusVultOnline.Models;
using NUnit.Framework;

namespace DeusVultOnline.Tests
{
    [TestFixture]
    public class BattlefieldTests
    {
        [Test]
        public void TestUnitsCanCalculateWalkableTiles()
        {
            //arrange
            var battlefield = new Battlefield(50);

            var tile = battlefield.BattlefieldTiles[0, 0];
            var ulist = new List<UnitGroup>();
            ulist.Add(new UnitGroup(new UnitType(new Inventory(), 1), 100));
            tile.Regiment = new Regiment100(ulist);


            var tile2 = battlefield.BattlefieldTiles[0, 1];
            var ulist2 = new List<UnitGroup>();
            ulist2.Add(new UnitGroup(new UnitType(new Inventory(), 1), 100));
            tile2.Regiment = new Regiment100(ulist2);

            //act
            var list = battlefield.GetPositionsInRange(tile);
            var list2 = battlefield.GetPositionsInRange(tile2);

            //assert
            Assert.AreEqual(list.Count, 2);
            Assert.AreEqual(list2.Count, 4);
        }
    }
}
