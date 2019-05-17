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
            CurrentLevelMap = new Map(3,3,new Point(0,0),
                new Point(2,2),1);
            var entity = new AttackingEntity();
            entity.CurrentPosition = CurrentLevelMap.StartPosition;
            /*entity.GoToFinish(CurrentLevelMap);*/
            
            CurrentLevelMap.TowersPoints.Add(new Point(1,1));
        }

        public void OnFinishReached(AttackingEntity entity)
        {
            CurrentLevelMap.Lives--;
            //notify view
            //delete from currents entities
        }
    }
}