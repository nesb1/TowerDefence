using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using TowerDefence.Controller;

namespace TowerDefence.Model
{
    public class Cursor
    {
        public static Map TryChangeCursorPosition(Map map, Keys keyCode, MainController mainController)
        {
            var mapCell = map.MapCell;
            var currentPosition = map.Cursor;
            
            switch (keyCode)
            {
                case Keys.Down:
                    if (currentPosition.Y+1<mapCell.GetLength(1))
                        map.Cursor = new Point(currentPosition.X,currentPosition.Y+1);
                    break;
                case Keys.Up:
                    if (currentPosition.Y-1>=0)
                        map.Cursor = new Point(currentPosition.X,currentPosition.Y-1);
                    break;
                case Keys.Left:
                    if (currentPosition.X-1>=0)
                        map.Cursor = new Point(currentPosition.X-1,currentPosition.Y);
                    break;
                case Keys.Right:
                    if (currentPosition.X+1<mapCell.GetLength(0))
                        map.Cursor = new Point(currentPosition.X+1,currentPosition.Y);
                    break;
                case Keys.Enter:
                    if (!map.TowersPoints.Contains(new TowerEntity(currentPosition)))
                    {
                        
                        mainController.TryToBuildTower(currentPosition);
                       
                        
                    }

                    break;
            }
            return map;
        } 
    }
}