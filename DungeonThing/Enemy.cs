using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading;

namespace DungeonThing
{
    class Enemy
    {
        public float health = 50;
        public float damage = 5;

        public void AttackPlayer(Player playerref)
        {
            Console.Clear();
            Console.WriteLine(string.Format("\nBeast Stats:\nHealth: {0}\nDamage: {1}\n", health, damage));
            Console.WriteLine(string.Format("\nPlayer Stats:\nHealth: {0}\nDamage: {1}\n", playerref.health, playerref.damage));
            Console.WriteLine("The Beast Attacks!");
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
            Console.Clear();
            playerref.health -= damage;
            Console.WriteLine(string.Format("It Deals {0} Damage, The Players Health Is Now {1}", damage, playerref.health));
            Thread.Sleep(1000);
            
        }
    }
}
