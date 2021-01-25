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
        public int maxShield;
        public int maxHealth;
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
                            OriginalDamage = health;
                            health = 0;
                        }
                        else
                        {
                            health = health - damage;
                        }

                    }
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
                    if (health <= 0)
                    {
                        State = "Dead";
                        health = 0;
                    }
                }
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
                if (health >= maxHealth)
                {
                    health = maxHealth;
                }
                else
                {
                    if (health + heal > maxHealth)
                    {
                        int Healed = maxHealth - health;
                        health = maxHealth;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(name + " healed for " + Healed + " health.");

                    }
                    else
                    {
                        health = health + heal;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(name + " healed for " + heal + " health.");
                        Console.ReadKey(true);
                    }
                }
            }
            else
            {
                Console.WriteLine("You cannot heal negative numbers! Please increase to a positive integer");

            }
        }
        public void Regenerate(int regen)
        {
            if (hasShield == true)
            {
                if (regen > 0)
                {
                    if (shield + regen > 100)
                    {

                    }
                    else
                    {
                        shield = shield + regen;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(name + " regenerated for " + regen + " shield points.");
                        Console.ReadKey(true);

                    }
                }
                else
                {
                    Console.WriteLine("You cannot heal negative numbers! Please increase to a positive integer");

                }
            }
            else
            {
                Console.WriteLine(name + " does not have a shield and therefore cannot regenerate a shield.");
            }
        }


    }
}
