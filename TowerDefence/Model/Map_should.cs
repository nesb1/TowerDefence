using System.Drawing;
using NUnit.Framework;

namespace TowerDefence.Model
{
    [TestFixture]
    public class Map_should
    {
        private Map map;
        private Point point;
        private TowerEntity te;

        [SetUp]
        public void initialize()
        {
            point = new Point(1,0);
            map = new Map(1,1,new Point( 0,0),new Point(1,1),1,new Point(0,0));
            te = new TowerEntity (point);
        }
        [Test]
        public void CorrectIfTowerHere()
        {
            map.TowersPoints.Add(te);
            Assert.True(map.IsTowerHere(point));
            map.TowersPoints.RemoveAt(0);
        }

        [Test]
        public void InCorrectIfTowerNotHere()
        {
            map.TowersPoints.Add(te);
            Assert.False(map.IsTowerHere(new Point(0,1)));
            map.TowersPoints.RemoveAt(0);
        }
    }
}