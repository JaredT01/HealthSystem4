using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystem4
{
    class Player : HealthSystem
    {
        public Player()
        {
            SetHealth(100);
            maxHealth = 100;
            maxShield = 100;
            name = "You";
            SetShield(100);
            SetLives(3);
            alive = true;
            hasShield = true;

        }
        public void CheckPlayer()
        {
            if (GetHealth() <= 0)
            {
                if (GetLives() > 0)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(name + " died. However, " + name + " had another life. Lucky.");
                    SetLives(GetLives() - 1);
                    SetHealth(maxHealth);
                    SetShield(100);
                    Console.ReadKey(true);
                    State = "Alive";
                    Program.debugHeal = 5;
                    Program.debugDamage = 25;
                }
                else
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(name + " died... permenantly.");
                    alive = false;
                    Console.ReadKey(true);
                }
            }

        }

        public new void ShowStats()
        {
            base.ShowStats();
            Console.WriteLine("Shield: " + GetShield());
            Console.WriteLine("Lives: " + GetLives());
        }
        public void Attack()
        {
            Console.WriteLine(Program.user.name + " attacked " + Program.enemy.GetName() + "!");
            Program.enemy.TakeDamage(Program.debugDamage);
        }
        public void HeavyAttack()
        {
            Console.WriteLine(Program.user.name + " attacked with a Heavy Attack against " + Program.enemy.GetName() + "!");
            Program.enemy.TakeDamage(Program.debugDamage*2);
        }



    }
}

