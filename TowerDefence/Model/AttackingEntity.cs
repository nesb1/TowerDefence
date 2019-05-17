using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace TowerDefence.Model
{
    public class AttackingEntity
    {
        public int Speed { get; }
        public Point CurrentPosition { get; set; }

        public void GoToFinish(Map map)
        {
            var visited = new HashSet<Point>();
            var stack = new Stack<Point>();
            stack.Push(CurrentPosition);
            visited.Add(CurrentPosition);
            while (stack.Count != 0)
            {
                var element = stack.Pop();
                if (element.X < 0 || element.X >= map.MapCell.GetLength(0) || element.Y < 0 ||
                    element.Y >= map.MapCell.GetLength(1) || map.IsTowerHere(element) || visited.Contains(element)) continue;
                visited.Add(element);
                for (var dy = -1; dy <= 1; dy++)
                for (var dx = -1; dx <= 1; dx++)
                {
                    var newPoint = new Point {X = element.X + dx, Y = element.Y + dy};
                    if (visited.Contains(newPoint)) continue;
                    if (dx != 0 && dy != 0) continue;
                    visited.Add(newPoint);
                    if (dx != 0 && dy != 0) continue;
                    stack.Push(new Point {X = element.X + dx, Y = element.Y + dy});
                }
                
                map.TowersPoints.Add(new Point(1,0));
            }
        }
    }
}