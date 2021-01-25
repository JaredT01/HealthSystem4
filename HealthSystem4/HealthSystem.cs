using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystem4
{
    abstract class HealthSystem
    {
        public int health;
        public int shield;
        public int lives;
        public string name;
        public bool alive = true;
        public bool hasShield = false;
        public string State = "Alive";


        public void TakeDamage(int damage)
        {
            int OriginalDamage = damage;
            if (hasShield == true)
            {
                if (damage > 0)
                {
                    if (shield > 0)
                    {
                        if (damage > shield)
                        {
                            if (damage > shield + health)
                            {
                                OriginalDamage = shield + health;
                            }
                            damage = damage - shield;
                            shield = 0;
                            health = health - damage;
                        }
                        else
                        {
                            shield = shield - damage;
                        }

                    }
                    else
                    {
                        shield = 0;
                        if (damage > health)
                        {
                            health = 0;
                            OriginalDamage = health;
                        }
                        else
                        {
                            health = health - damage;
                        }

                    }
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(name + " took " + OriginalDamage + " points of damage!");
                    if (health < 0)
                    {
                        health = 0;
                    }

                }
                else
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Damage is not a positive integer and therefore does not work.");
                }

            }
            else
            {
                if (damage < 0)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Damage is not a positive integer and therefore does not work.");
                }
                else
                {
                    health = health - damage;
                    Console.WriteLine(name + " took " + OriginalDamage + " points of damage!");
                    if (health < 0)
                    {
                        health = 0;
                    }
                }
            }
            if(health <= 0)
            {
                State = "Dead";
            }
        }
        public void ShowStats()
        {
            Console.WriteLine("--------------" + name + "------------------");
            Console.WriteLine("Health: " + health);
            Console.WriteLine("State: " + State);
        }

        public void Heal(int heal)
        {
            if (heal > 0)
            {
                if (health + heal > 100)
                {

                }
                else
                {
                    health = health + heal;
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(name + " healed for " + heal + " health.");
                    Console.ReadKey(true);
                }
            }
            else
            {
                Console.WriteLine("You cannot heal negative numbers! Please increase to a positive integer");

            }
        }
        

    }
}
