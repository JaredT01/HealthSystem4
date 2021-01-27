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
            health = 100;
            maxHealth = 100;
            maxShield = 100;
            name = "You";
            shield = 100;
            lives = 3;
            alive = true;
            hasShield = true;

        }
        public void CheckPlayer()
        {
            if (health <= 0)
            {
                if (lives > 0)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(name + " died. However, " + name + " had another life. Lucky.");
                    lives = lives - 1;
                    health = 100;
                    shield = 100;
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
        public void Reset()
        {
            health = 100;
            maxHealth = 100;
            name = "You";
            State = "Alive";
            shield = 100;
            lives = 3;
            alive = true;
            HasWon = false;
            Program.debugDamage = 0;
            Program.debugHeal = 0;
        }

        public void ShowStatsPlayer()
        {
            ShowStats();
            Console.WriteLine("Shield: " + shield);
            Console.WriteLine("Lives: " + lives);
        }
        public void Attack()
        {
            Console.WriteLine(Program.user.name + " attacked " + Program.enemy.name + "!");
            Program.enemy.TakeDamage(Program.debugDamage);
        }
        public void HeavyAttack()
        {
            Console.WriteLine(Program.user.name + " attacked with a Heavy Attack against " + Program.enemy.name + "!");
            Program.enemy.TakeDamage(Program.debugDamage*2);
        }



    }
}

