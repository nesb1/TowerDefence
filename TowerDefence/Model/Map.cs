using System;
using System.Collections.Generic;
using System.Drawing;

namespace TowerDefence.Model
{
    public class Map
    {
        public Map(int height, int width, Point startPosition , Point finishPosition,int lives)
        {
            MapCell = new Point[height,width];
            StartPosition = startPosition;
            FinishPosition = finishPosition;
            TowersPoints = new List<Point>();
            Lives = lives;
        }
        
        
        public int Lives { get; set; }
        public List<Point> TowersPoints { get; }
        public Point[,] MapCell { get;  }
        public Point StartPosition { get;  }
        public Point FinishPosition { get; }

        public bool IsTowerHere(Point point)
        {
            return TowersPoints.Contains(point);
        }
        
    }
}