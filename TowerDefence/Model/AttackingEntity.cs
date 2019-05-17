using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using TowerDefence.Controller;
using static TowerDefence.Model.WideSearch;


namespace TowerDefence.Model
{
    public class AttackingEntity
    {
        public MainController CurrentController { get; set; }
        public List<Point> CurrentPath { get; private set; }
        public int Speed { get; }
        public Point CurrentPosition { get; set; }

        public void GetCurrentPath(Map map)
        {
            CurrentPath = FindPaths(map, CurrentPosition).ToList();
        }

        public void GoToFinish(Map map)
        {
            foreach (var point in CurrentPath)
            {
                Thread.Sleep(1000);
                CurrentPosition = point;
                //notify view
                if (point == map.FinishPosition) CurrentController.OnFinishReached(this);

                //Когда построили новую башню уведомить сущность
                //если новый поиск в ширину дал такой же результат, то ничего не менять,
                // иначе запускать другой маршрут

            }
        }

        public void OnTowersChange(Map map)
        {
            foreach (var point in map.TowersPoints)
            {
                if (CurrentPath.Contains(point))
                    GetCurrentPath(map);
                //не забить про удаление поинтов из листа, когда мы уже прошли эту клетку
            }
        }

        
    }
}