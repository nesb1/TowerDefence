using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TowerDefence.Model
{
    public class Map
    {
        public Map(int height, int width, Point startPosition , Point finishPosition,int lives, Point cursor)
        {
            MapCell = new Point[height,width];
            StartPosition = startPosition;
            FinishPosition = finishPosition;
            TowersPoints = new List<TowerEntity>();
            Cursor = cursor;
            EntitiesPoints = new List<AttackingEntity>();
        }
        public List<AttackingEntity> EntitiesPoints { get; set; }
        public Point Cursor { get; set; }
        public List<TowerEntity> TowersPoints { get; set; }
        public Point[,] MapCell { get;  }
        public Point StartPosition { get;  }
        public Point FinishPosition { get; }

        public List<AttackingEntity> IsAttackingEntityHere(Point point)
        {
            return EntitiesPoints.Where(r => r.CurrentPosition == point).ToList();

        }
        public bool IsTowerHere(Point point)
        {
            return TowersPoints
                .Any(s => s.CurrentPoint == point);
            
        }
        
    }
}