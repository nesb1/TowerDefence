using System.Drawing;
using NUnit.Framework;

namespace TowerDefence.Model
{
    [TestFixture]
    public class Map_should
    {
        private Map map;
        private Point point;
        [SetUp]
        public void initialize()
        {
            map = new Map(1,1,new Point( 0,0),new Point(1,1),1);
            point = new Point(1, 0);
        }
        [Test]
        public void CorrectIfTowerHere()
        {
            map.TowersPoints.Add(point);
            Assert.True(map.IsTowerHere(point));
            map.TowersPoints.RemoveAt(0);
        }

        [Test]
        public void InCorrectIfTowerNotHere()
        {
            map.TowersPoints.Add(point);
            Assert.False(map.IsTowerHere(new Point(0,1)));
            map.TowersPoints.RemoveAt(0);
        }
    }
}