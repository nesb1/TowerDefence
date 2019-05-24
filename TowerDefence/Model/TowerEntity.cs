using System.Drawing;
using System.Linq;

namespace TowerDefence.Model
{
    public class TowerEntity
    {
        public Point CurrentPoint { get; set; }

        public TowerEntity (Point currentPoint)
        {
            CurrentPoint = currentPoint;
        }
        public void Attack(Map map)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    var dPoint = new Point(CurrentPoint.X+i,CurrentPoint.Y+j);
                    if (i==j)continue;
                    var points = map.IsAttackingEntityHere(dPoint);
                    if (!points.Any()) continue;
                    foreach (var attackingEntity in points)
                    {
                        attackingEntity.OnDamageTaken();
                    }

                }
            }
        }
    }
}