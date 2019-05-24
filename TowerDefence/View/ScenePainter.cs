using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using TowerDefence.Model;
using TowerDefence.Properties;

namespace TowerDefence
{
    public class ScenePainter
    {
        public SizeF Size => new SizeF(currentMap.MapCell.GetLength(0), currentMap.MapCell.GetLength(1));
        public Size LevelSize => new Size(currentMap.MapCell.GetLength(0), currentMap.MapCell.GetLength(1));

        private readonly Dictionary<Map, Point[]> paths;
        public Map currentMap { get; set; }
        private int mainIteration;
        private Bitmap mapImage;
        

        private Point? lastMouseClick;
        private IEnumerable<List<Point>> pathsToChests;

        public ScenePainter(Map[] maps)
        {
			
            currentMap = maps[0];
            mainIteration = 0;
            CreateMap();
        }

		

        public void Paint(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawLevel(g);
			
        }

        private void DrawLevel(Graphics graphics)
        {
            graphics.DrawImage(mapImage, new Rectangle(0, 0, LevelSize.Width, LevelSize.Height));
            foreach (var chest in currentMap.TowersPoints)
                graphics.DrawImage(Resources.tank_bullet3, new Rectangle(chest.CurrentPoint.X, chest.CurrentPoint.Y, 1, 1));
            graphics.DrawImage(Resources.tank_explosion1, new Rectangle(currentMap.Cursor.X,currentMap.Cursor.Y,1,1));
            for (var i = 0 ; i < currentMap.EntitiesPoints.Count; i++)
            {
                var entity = currentMap.EntitiesPoints[i];
                if (i%3==0)
                    graphics.DrawImage(Resources.tanks_tankGreen4, new Rectangle(entity.CurrentPosition.X,entity.CurrentPosition.Y,1,1));
                graphics.DrawImage(i % 3 == 1 ? Resources.tanks_tankDesert4 : Resources.tanks_tankGrey4,
                    new Rectangle(entity.CurrentPosition.X, entity.CurrentPosition.Y, 1, 1));
            }
            graphics.DrawImage(Resources.tanks_crateArmor,new Rectangle(currentMap.FinishPosition.X,currentMap.FinishPosition.Y,1,1) );
        }

		

        private void CreateMap()
        {
            var cellWidth = Resources.Grass.Width;
            var cellHeight = Resources.Grass.Height;
            mapImage = new Bitmap(LevelSize.Width * cellWidth, LevelSize.Height * cellHeight);
            using (var graphics = Graphics.FromImage(mapImage))
            {
                for (var x = 0; x < currentMap.MapCell.GetLength(0); x++)
                {
                    for (var y = 0; y < currentMap.MapCell.GetLength(1); y++)
                    {
                        var image = Resources.Grass;
                        graphics.DrawImage(image, new Rectangle(x * cellWidth, y * cellHeight, cellWidth, cellHeight));
                    }
                }
            }
            
        }
    }
}