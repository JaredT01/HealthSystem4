using System;

namespace HealthSystem4
{
    class Enemy : HealthSystem
    {
        public Enemy()
        {
            SetHealth(150);
            maxHealth = 150;
            SetMaxShield(50);
            SetShield(GetMaxShield());
            name = "Bal, the Dark Lord";
            alive = true;
            hasTitle = true;
            hasShield = true;
            hasLives = true;
            SetLives(3);
            maxLives = 3;

        }
        
        public void CheckEnemy() {
            if (hasLives == true)
            {
                if (GetHealth() <= 0)
                {
                    if (GetLives() > 0)
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(name + " died. However, " + name + " had another life. Lucky.");
                        SetLives(GetLives() - 1);
                        SetHealth(maxHealth);
                        SetShield(maxShield);
                        Console.ReadKey(true);
                        State = "Alive";
                    }
                    else
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
            }
            else {
                if (GetHealth() <= 0)
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
        }
        public void Attack()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine(Program.user.GetName() + " took a hit from " + name);
            Program.user.TakeDamage(Program.debugDamage);
        }
        public void HeavyAttack()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine(Program.user.GetName() + " took a powerful hit from " + name);
            Program.user.TakeDamage(Program.debugDamage*2);
        }
    }
}
