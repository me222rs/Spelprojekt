using SpaceShooter.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter.Model
{
    class Collision
    {
        List<EnemyView> enemyList;
        List<Destroyer> destroyerList;
        List<MeteorView> meteorList;


        public Collision(List<EnemyView> enemyList, List<Destroyer> destroyerList, List<MeteorView> meteorList) {
            this.enemyList = enemyList;
            this.destroyerList = destroyerList;
            this.meteorList = meteorList;
        }

        public List<EnemyView> CheckEnemyCollision(List<EnemyView> enemyList) {
            this.enemyList = enemyList;



            return this.enemyList;
        }
    }
}
