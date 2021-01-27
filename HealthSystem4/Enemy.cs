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
            health = 300;
            maxHealth = 300;
            name = "Bal, the Dark Lord";
            alive = true;
            hasTitle = true;

        }
        public void Reset()
        {
            health = 300;
            maxHealth = 300;
            name = "Bal, the Dark Lord";
            State = "Alive";
            alive = true;
        }
        public void CheckEnemy() { 
        
        if(health <= 0)
            {
                if (hasTitle == true)
                {
                    Console.WriteLine(name + ", has died!");
                }
                else
                {
                    Console.WriteLine(name + " has died!");
                }
                State = "Dead";
                alive = false;
            }
        }
        public void Attack()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine(Program.user.name + " took a hit from " + name);
            Program.user.TakeDamage(Program.debugDamage);
        }
        public void HeavyAttack()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine(Program.user.name + " took a powerful hit from " + name);
            Program.user.TakeDamage(Program.debugDamage*2);
        }
    }
}
