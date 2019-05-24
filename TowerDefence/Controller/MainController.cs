using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using NUnit.Framework.Constraints;
using TowerDefence.Model;
using Cursor = TowerDefence.Model.Cursor;

namespace TowerDefence.Controller
{
    public class MainController
    {
        public Map CurrentMap { get; set; }
        private AttackingEntity AttackingEntity;
        private int tickCount;
        public int Gold = 180;
        public bool isGameEnd;
        public int Lives = 1;
        private int TanksCount = 5;
        public int level = 1;
        private int levelSpeed = 32;
        

        public MainController()
        {
            CurrentMap = new Map(15, 15, new Point(0, 0),
                new Point(10, 10), 1, new Point(0, 0));
            
            AttackingEntity = new AttackingEntity(CurrentMap, this);
            CurrentMap.EntitiesPoints.Add(AttackingEntity);
        }

        public void OnKeyDown(Keys keyCode)
        {
            CurrentMap = Cursor.TryChangeCursorPosition(CurrentMap, keyCode,this);
        }

        public void OnFinishReached()
        {
            if ( Lives== 0)
            {
                
                isGameEnd = true;
                return;
            }

            Lives--;
        }
        

        public Map OnTick()
        {
            if (tickCount % levelSpeed == 0 && tickCount > 0 && TanksCount > 0)
            {
                
                CurrentMap.EntitiesPoints.Add(new AttackingEntity(CurrentMap, this));
                TanksCount--;
            }

            if (tickCount % levelSpeed == 0)
            {
                foreach (var ae in CurrentMap.EntitiesPoints)
                {
                    ae.GoToNextPoint();
                }
            }
            if (tickCount%50 ==0)
                Attack();

            tickCount++;
            return CurrentMap;
        }

        private void Attack()
        {
            foreach (var tower in CurrentMap.TowersPoints)
            {
                tower.Attack(CurrentMap);
            }
        }

        public void OnKilled(AttackingEntity attackingEntity)
        {
            CurrentMap.EntitiesPoints.Remove(attackingEntity);
            Gold += 5;
            if (TanksCount == 0)
            {
                level++;
                if (levelSpeed >=6)
                    levelSpeed -= 5;
                TanksCount = level * 10;
            }
        }

        public void TryToBuildTower(Point currentPosition)
        {
            if (Gold < 20) return;
            Gold -= 20;
            CurrentMap.TowersPoints.Add(new TowerEntity(currentPosition));
            foreach (var entity in CurrentMap.EntitiesPoints)
            {
                entity.OnTowersChange(CurrentMap);
            }
        }
    }
}