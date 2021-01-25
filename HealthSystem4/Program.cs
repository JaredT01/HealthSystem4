using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HealthSystem4
{
    class Program
    {

       public static Player user = new Player();
        public static Enemy enemy = new Enemy();
        public static int debugDamage = 0;
        public static int debugHeal = 0;
        static void Main(string[] args)
        {
            for (int x = 0; x < 1;)
            {
                if (user.alive == true)
                {
                    GameLoop();
                }
                else
                {
                    Console.WriteLine("Do you wish to run this again? Y/N");
                    string answer = Console.ReadLine();
                    if (answer == "y")
                    {
                        user.Reset();
                    }
                    else if (answer == "Y")
                    {
                        user.Reset();

                    }
                    else if (answer == "n")
                    {
                        x = 1;
                    }
                    else if (answer == "N")
                    {
                        x = 1;
                    }
                    else
                    {
                        Console.Clear();
                    }

                }

            }

        }
        static void GameLoop()
        {
            //Increases Damage and Heal to showcase the Health System
            debugDamage = debugDamage + 25;
            debugHeal = debugHeal + 5;

            //Display Stats and handle equiping gear
            Console.Clear();
            user.ShowStatsPlayer();
            enemy.ShowStats();
            Console.ReadKey(true);
            Console.Clear();

            //Taking Damage
            user.ShowStatsPlayer();
            enemy.ShowStats();
            if(enemy.alive == true)
            {
                AttackChoice();
            }
            else
            {
                Console.WriteLine("--------------------------------");
                user.TakeDamage(debugDamage);
            }
            Console.ReadKey(true);
            Console.Clear();

            //Checking the player to see if they died from the TakeDamage()
            user.ShowStatsPlayer();
            enemy.ShowStats();
            user.CheckPlayer();
            enemy.CheckEnemy();

            //Healing and Regenerating an alive player. Will be skipped if the player died
            if (user.alive == true)
            {
                Console.Clear();
                user.ShowStatsPlayer();
                enemy.ShowStats();
                user.Heal(debugHeal);
                if (enemy.alive == true)
                {
                    enemy.Heal(debugHeal);
                }
                Console.Clear();
                user.ShowStatsPlayer();
                enemy.ShowStats();
                user.Regenerate(debugHeal);
            }
        }
       static void AttackChoice()
        {
            for (int x = 0; x < 1;)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Choose your attack:");
                Console.WriteLine("1) Fast Attack");
                Console.WriteLine("2) Heavy Attack");
                Console.WriteLine("--------------------------------");
                string answer = Console.ReadLine();
                Random rand = new Random();
                int FoeAI = rand.Next(1, 2);
                if (answer == "1")
                {
                    
                    user.Attack();
                    if(FoeAI == 1)
                    {
                        enemy.Attack();
                    }
                    else
                    {
                        enemy.HeavyAttack();
                    }
                    x = 1;

                }
                else if (answer == "2")
                {
                    if (FoeAI == 1)
                    {
                        enemy.Attack();
                    }
                    else
                    {
                        enemy.HeavyAttack();
                    }
                    user.HeavyAttack();
                    x = 1;
                }
                else
                {
                    Console.Clear();
                    user.ShowStatsPlayer();
                    enemy.ShowStats();
                }
            }
        }
    }
}

