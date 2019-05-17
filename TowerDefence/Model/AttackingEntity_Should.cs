using System.Drawing;
using System.Threading;
using NUnit.Framework;

namespace TowerDefence.Model
{
    [TestFixture]
    public class AttackingEntity_Should
    {
        [Test]
        public void EntityGoToFinishReactOnEditTower()
        {
            var  map = new Map(3,3,new []{new Point( 0,0)},new []{new Point(1,1) });
            var ae = new AttackingEntity {CurrentPosition = map.StartPositions[0]};
            ae.GoToFinish(map);
            map.TowersPoints.Add(new Point(1,0));
            Assert.False(true);
        }
    }
}