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
        public static int DebugMode = 0; // 0 = Didn't choose, 1 = Yes, 2 = No
        static void Main(string[] args)
        {
            for (int x = 0; x < 1;)
            {
                if (DebugMode == 0)
                {
                    Console.WriteLine("Do you wish to run this in debug mode? Y/N");
                    string answer = Console.ReadLine();
                    if (answer == "y")
                    {
                        DebugMode = 1;
                        Debug();
                        x++;
                    }
                    else if (answer == "Y")
                    {
                        DebugMode = 1;
                        Debug();
                        x++;
                    }
                    else if (answer == "n")
                    {
                        DebugMode = 2;
                    }
                    else if (answer == "N")
                    {
                        DebugMode = 2;
                    }
                    else
                    {
                        Console.Clear();
                    }
                } else if(DebugMode == 1)
                {

                } else if(DebugMode == 2) {
                    if (user.HasWon == true)
                    {
                        Console.WriteLine("Congrats! " + user.name + " took down the Dark Lord and won!");
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
                    
                    else if (user.alive == true)
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
                user.HasWon = true;
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

        static void Debug()
        {
            Console.Clear();
            user.ShowStatsPlayer();
            enemy.ShowStats();
            Console.ReadKey();
            user.TakeDamage(10);
            enemy.TakeDamage(10);
            Console.ReadKey();
            Console.Clear();
            user.ShowStatsPlayer();
            enemy.ShowStats();
            user.Regenerate(10);
            enemy.Heal(10);
            Console.ReadKey();
            Console.Clear();
            user.ShowStatsPlayer();
            enemy.ShowStats();
            user.TakeDamage(110);
            enemy.TakeDamage(110);
            Console.ReadKey();
            Console.Clear();
            user.ShowStatsPlayer();
            enemy.ShowStats();
            user.Heal(10);
            enemy.Heal(10);
            Console.ReadKey();
            Console.Clear();
            user.ShowStatsPlayer();
            enemy.ShowStats();
            user.TakeDamage(-110);
            enemy.TakeDamage(-110);
            Console.ReadKey();
            Console.Clear();
            user.ShowStatsPlayer();
            enemy.ShowStats();
            user.Heal(-10);
            enemy.Heal(-10);
            Console.ReadKey();
            Console.Clear();
            user.ShowStatsPlayer();
            enemy.ShowStats();
            user.TakeDamage(999);
            enemy.TakeDamage(999);
            Console.ReadKey();
            Console.Clear();
            user.ShowStatsPlayer();
            enemy.ShowStats();
            user.CheckPlayer();
            enemy.CheckEnemy();
            Console.ReadKey();
            Console.Clear();
            user.ShowStatsPlayer();
            user.TakeDamage(150);
            Console.ReadKey();
            Console.Clear();
            user.ShowStatsPlayer();
            user.Regenerate(150);
            user.Heal(150);
            Console.ReadKey();
            Console.Clear();
            user.ShowStatsPlayer();
            user.TakeDamage(999);
            Console.ReadKey();
            Console.Clear();
            user.ShowStatsPlayer();
            user.CheckPlayer();
            Console.ReadKey();
            Console.Clear();
            user.ShowStatsPlayer();
            user.TakeDamage(999);
            Console.ReadKey();
            Console.Clear();
            user.ShowStatsPlayer();
            user.CheckPlayer();
            Console.ReadKey();
            Console.Clear();
            user.ShowStatsPlayer();
            user.TakeDamage(999);
            Console.ReadKey();
            Console.Clear();
            user.ShowStatsPlayer();
            user.CheckPlayer();
            Console.ReadKey();
            Console.WriteLine("Debug Mode has ended. We have tested the following: ");
            Console.WriteLine("-Damage Spill over");
            Console.WriteLine("-No over healing or over regeneration");
            Console.WriteLine("-No taking damage over your max health/shield");
            Console.WriteLine("-Healing/Regeneration with negative integers");
            Console.WriteLine("-Negative Integers with Damage");
            Console.WriteLine("-Using the player's lives");
            Console.WriteLine(" ");
            Console.WriteLine("Exit the program by pressing a button.");
            Console.ReadKey();
        }
    }
}

