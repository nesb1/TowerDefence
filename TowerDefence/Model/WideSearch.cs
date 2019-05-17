using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Model
{
    public class WideSearch
    {
        public static SinglyLinkedList FindPaths(Map map, Point start)
        {
            var exit = map.FinishPosition;
            var firstPoint = new SinglyLinkedList(start);
            var visited = new HashSet<Point>();
            var queue = new Queue<SinglyLinkedList>();
            queue.Enqueue(firstPoint);
            while (queue.Count != 0)
            {
                var linkedListFromQueue = queue.Dequeue();
                var point = linkedListFromQueue.Value;
                if (point.X < 0 || point.X >= map.MapCell.GetLength(0) || point.Y < 0 ||
                    point.Y >= map.MapCell.GetLength(1) || map.IsTowerHere(point)) continue;
                visited.Add(new Point {X = point.X, Y = point.Y});
                for (var dy = -1; dy <= 1; dy++)
                for (var dx = -1; dx <= 1; dx++)
                {
                    var newPoint = new Point {X = point.X + dx, Y = point.Y + dy};
                    if (visited.Contains(newPoint)) continue;
                    if (dx != 0 && dy != 0) continue;
                    visited.Add(newPoint);
                    var newSinglyLinkedList =
                        new SinglyLinkedList(newPoint, linkedListFromQueue);
                    if (newPoint == exit)
                        return newSinglyLinkedList;
                    queue.Enqueue(newSinglyLinkedList);
                }
            }

            return null;
        }
    }
}