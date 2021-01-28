using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystem4
{
    abstract class HealthSystem
    {
        private int health;
        protected int maxShield;
        protected int maxHealth;
        private int shield;
        private int lives;
        protected string name;
        protected bool alive = true;
        protected bool hasShield = false;
        protected string State = "Alive";
        protected bool HasWon = false;
        protected bool hasTitle = false;
        protected bool hasLives = false;
        protected int maxLives = 3;


        public void SetHasShield(bool DesiredHasShield)
        {
            hasShield = DesiredHasShield;
        }
        public void SetHasLives(bool DesiredHasLives)
        {
            hasLives = DesiredHasLives;
        }
        public void SetAlive(bool DesiredAlive)
        {
            alive = DesiredAlive;
        }
        public bool GetAlive()
        {
            return alive;
        }
        public void SetVictory(bool victory)
        {
            HasWon = victory;
        }
        public bool GetVictory()
        {
            return HasWon;
        }
        public void SetLives(int DesiredLives)
        {
            lives = DesiredLives;
        }
        public int GetLives()
        {

            return lives;
        }
        public void SetName(string DesiredName)
        {
           name = DesiredName;
        }
        public string GetName()
        {

            return name;
        }
        public void SetHealth(int DesiredHealth)
        {
            health = DesiredHealth;
        }

        public int GetHealth()
        {
            
            return health;
        }
        public void SetShield(int DesiredShield)
        {
            shield = DesiredShield;
        }

        public int GetShield()
        {

            return shield;
        }
        public void SetMaxHealth(int DesiredMaxHealth)
        {
            maxHealth = DesiredMaxHealth;
        }

        public int GetMaxHealth()
        {

            return maxHealth;
        }
        public void SetMaxShield(int DesiredMaxShield)
        {
            maxShield = DesiredMaxShield;
        }

        public int GetMaxShield()
        {

            return maxShield;
        }
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
                    if (hasTitle == true)
                    {
                        Console.WriteLine(name + ", took " + OriginalDamage + " points of damage!");
                    }
                    else
                    {
                        Console.WriteLine(name + " took " + OriginalDamage + " points of damage!");
                    }
                    
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
                    if(damage > health)
                    {
                        OriginalDamage = health;
                    }
                    health = health - damage;
                    if (hasTitle == true)
                    {
                        Console.WriteLine(name + ", took " + OriginalDamage + " points of damage!");
                    }
                    else
                    {
                        Console.WriteLine(name + " took " + OriginalDamage + " points of damage!");
                    }
                    
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
            if(hasShield == true)
            {
                Console.WriteLine("Shield: " + shield);
            }
            if(hasLives == true)
            {
                Console.WriteLine("Lives: " + lives);
            }
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
                        if (hasTitle == true)
                        {
                            Console.WriteLine(name + ", healed for " + Healed + " health.");
                        }
                        else
                        {
                            Console.WriteLine(name + " healed for " + Healed + " health.");
                        }

                    }
                    else
                    {
                        health = health + heal;
                        Console.WriteLine("--------------------------------");
                        if (hasTitle == true)
                    {
                            Console.WriteLine(name + ", healed for " + heal + " health.");
                        }
                    else
                    {
                            Console.WriteLine(name + " healed for " + heal + " health.");
                        }
                        
                        Console.ReadKey(true);
                    }
                }
            }
            else
            {
                Console.WriteLine("--------------------------------");
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
                    Console.WriteLine("You cannot regenerate negative numbers! Please increase to a positive integer");

                }
            }
            else
            {
                Console.WriteLine(name + " does not have a shield and therefore cannot regenerate a shield.");
            }
        }

        public void Reset()
        {
            health = maxHealth;
            if(hasShield == true)
            {
                shield = maxShield;
            }
            if(hasLives == true)
            {
                lives = maxLives;
            }
            State = "Alive";
            alive = true;
            HasWon = false;
            Program.debugDamage = 0;
            Program.debugHeal = 0;
        }


    }
}
