using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using TowerDefence.Model;

namespace TowerDefence.Controller
{
    public class MainController
    {
        private Map CurrentLevelMap;
        void Initialize()
        {
            CurrentLevelMap = new Map(3,3,new []{new Point(0,0) },
                new []{new Point(2,2) });
            var entity = new AttackingEntity();
            entity.CurrentPosition = CurrentLevelMap.StartPositions[0];
            entity.GoToFinish(CurrentLevelMap);
            Thread.Sleep(2000);
            CurrentLevelMap.TowersPoints.Add(new Point(1,1));
        }
    }
}