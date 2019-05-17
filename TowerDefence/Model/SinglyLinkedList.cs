using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TowerDefence.Model
{
    public class SinglyLinkedList
    {
        public readonly Point Value;
        public readonly SinglyLinkedList Previous;
        public readonly int Length;

        public SinglyLinkedList(Point value, SinglyLinkedList previous = null)
        {
            Value = value;
            Previous = previous;
            Length = previous?.Length + 1 ?? 1;
        }

        public List<Point> ToList()
        {
            var result = new List<Point>();
            if (Length == 0) return result;
            result.Add(Value);
            var prevItem = Previous;
            while (prevItem!=null)
            {
                result.Add(prevItem.Value);
                prevItem = prevItem.Previous;
            }
            result.Reverse();
            result.RemoveAt(0);
            return result;
        }
    }
}
