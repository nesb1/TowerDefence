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
        public int Health { get; set; }
        public Point CurrentPosition { get; set; }
        public Map map { get; set; }

        public AttackingEntity(Map map, MainController mainController)
        {
            CurrentController = mainController;
            this.map = map;
            CurrentPosition = map.StartPosition;
            GetCurrentPath();
            Health = 100;
        }

        public void GetCurrentPath()
        {
            CurrentPath = FindPaths(map, CurrentPosition).ToList();
        }

        public void GoToNextPoint()
        {
            if (CurrentPath.Count != 0)
            {
                CurrentPosition = CurrentPath[0];
                CurrentPath.RemoveAt(0);
            }

            if (CurrentPosition == map.FinishPosition)
                CurrentController.OnFinishReached();
        }

        public void OnTowersChange(Map map)
        {
            foreach (var tower in map.TowersPoints)
            {
                if (CurrentPath.Contains(tower.CurrentPoint))
                    GetCurrentPath();
                //не забить про удаление поинтов из листа, когда мы уже прошли эту клетку
            }
        }

        public void OnDamageTaken()
        {
            Health -= 20;
            if (Health <= 0)
                CurrentController.OnKilled(this);
        }
    }
}