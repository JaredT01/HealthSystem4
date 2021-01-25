using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystem4
{
    class Enemy : HealthSystem
    {
        public Enemy()
        {
            health = 100;
            name = "Monster";
            alive = true;

        }
        public void CheckEnemy() { 
        
        if(health <= 0)
            {
                State = "Dead";
                alive = false;
            }
        }
    }
}
