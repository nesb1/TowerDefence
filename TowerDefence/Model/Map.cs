using System;
using System.Collections.Generic;
using System.Drawing;

namespace TowerDefence.Model
{
    public class Map
    {
        public Map(int height, int width, Point[] startPositions , Point[] finishPositions)
        {
            MapCell = new Point[height,width];
            StartPositions = startPositions;
            FinishPositions = finishPositions;
            TowersPoints = new List<Point>();
        }

        public List<Point> TowersPoints { get; }
        public Point[,] MapCell { get;  }
        public Point[] StartPositions { get;  }
        public Point[] FinishPositions { get; }

        public bool IsTowerHere(Point point)
        {
            return TowersPoints.Contains(point);
        }
        
    }
}