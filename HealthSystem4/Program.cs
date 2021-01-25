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
                        enemy.Reset();
                    }
                    else if (answer == "Y")
                    {
                        user.Reset();
                        enemy.Reset();

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
            user.CheckPlayer();
            enemy.CheckEnemy();
            Console.ReadKey(true);
            Console.Clear();

        }
       static void AttackChoice()
        {
            for (int x = 0; x < 1;)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Choose your move:");
                Console.WriteLine("1) Fast Attack");
                Console.WriteLine("2) Heavy Attack");
                Console.WriteLine("3) Heal");
                Console.WriteLine("4) Regenerate");
                Console.WriteLine("--------------------------------");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    
                    user.Attack();
                    FoeAI();
                    x = 1;

                }
                else if (answer == "2")
                {
                    FoeAI();
                    user.HeavyAttack();
                    x = 1;
                }else if(answer == "3")
                {
                    if(user.health == user.maxHealth)
                    {
                        Console.WriteLine("You can't heal past your max health which is: " + user.maxHealth);
                        Console.ReadKey(true);
                        Console.Clear();
                        user.ShowStatsPlayer();
                        enemy.ShowStats();
                    }
                    else { user.Heal(debugHeal); FoeAI(); x = 1; }
                }
                else if (answer == "4")
                {
                    if (user.shield == user.maxShield)
                    {
                        Console.WriteLine("You can't regen past your max shield which is: " + user.maxShield);
                        Console.ReadKey(true);
                        Console.Clear();
                        user.ShowStatsPlayer();
                        enemy.ShowStats();
                    }
                    else { user.Regenerate(debugHeal); FoeAI(); x = 1; }
                }
                else
                {
                    Console.Clear();
                    user.ShowStatsPlayer();
                    enemy.ShowStats();
                }
            }
        }
        static void FoeAI()
        {
                Random rand = new Random();
                int FoeAI = rand.Next(1, 2);
            if (FoeAI == 1)
            {
                enemy.Attack();
            }
            else
            {
                enemy.HeavyAttack();
            }
        }
    }
}

