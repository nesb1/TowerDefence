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
            var map = new Map(4,4,new Point(0,0),new Point(3,3),1);
            var attackingEntity = new AttackingEntity();
            attackingEntity.GetCurrentPath(map);
            var towerPoint = new Point(1, 0);
            map.TowersPoints.Add(towerPoint);
            attackingEntity.OnTowersChange(map);
            Assert.False(attackingEntity.CurrentPath.Contains(towerPoint));
        }
    }
}