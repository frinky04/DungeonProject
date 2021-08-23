using System;
using System.Numerics;
using System.Threading;

namespace DungeonThing
{
    class Player
    {
        public float health = 100;
        public float damage = 25;
        public float defense = 2;
        public Vector2 position = new Vector2(0, 0);
        Random rnd = new Random();

        public void PlayerTurn()
        {
            Console.Clear();
            Console.WriteLine("Player Move:");
            Console.WriteLine("");
            Console.WriteLine(string.Format("Current Position: X{0}, Y{1}", position.X, position.Y));
            Console.WriteLine(string.Format("Health: {0}\nDamage: {1}\nDefense: {2}", health, damage, defense));
            Console.WriteLine("");
            Console.WriteLine("W = Y + 1\nS = Y - 1\nD = X + 1\nA = X - 1");
            ConsoleKeyInfo move = Console.ReadKey();
            Console.WriteLine("");
            if (move.Key == ConsoleKey.W)
            {
                PlayerMove(new Vector2(0, 1));
            }

            else if (move.Key == ConsoleKey.S)
            {
                PlayerMove(new Vector2(0, -1));
            }

            else if (move.Key == ConsoleKey.D)
            {
                PlayerMove(new Vector2(1, 0));
            }

            else if (move.Key == ConsoleKey.A)
            {
                PlayerMove(new Vector2(-1, 0));
            }

            Thread.Sleep(500);

        }

        public void PlayerMove(Vector2 add)
        {
            position = position + add;
            if (rnd.Next(0, 2) == 1)
            {
                Console.Clear();
                Enemy enemy1 = new Enemy();
                Console.WriteLine("The Player Moves... But Somethings Wrong...");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("...");
                Thread.Sleep(2000);
                Console.Clear();
                AttackLoop(enemy1);
            }

        }
        public void AttackLoop(Enemy enemyref)
        {
            Console.WriteLine("The Player Is Attacked By A Beast!");
            while (enemyref.health >= 1 && health >= 0)
            {
                enemyref.AttackPlayer(this);

                Console.WriteLine(string.Format("\nBeast Stats:\nHealth: {0}\nDamage: {1}\n", enemyref.health, enemyref.damage));
                Console.WriteLine(string.Format("\nPlayer Stats:\nHealth: {0}\nDamage: {1}\n", health, damage));
                Console.WriteLine("");
                Console.WriteLine("Attacks:\nQ : Normal Attack - 75% Damage - 100% Hit Chance - 1 Attack\nE : Heavy Attack - 200% Damage - 50% Hit Chance - 1 Attack\nX : Chain Attack - 100% Damage - 50% Hit Chance - 2 Attacks");
                Console.WriteLine("");
                ConsoleKeyInfo attack = Console.ReadKey();
                Console.Clear();
                Console.WriteLine("");
                if (attack.Key == ConsoleKey.Q)
                {
                    PlayerAttack(0, enemyref);
                }

                else if (attack.Key == ConsoleKey.E)
                {
                    PlayerAttack(1, enemyref);
                }

                else if (attack.Key == ConsoleKey.X)
                {
                    PlayerAttack(2, enemyref);
                }



            }

        }

        public void PlayerAttack(int attacktype, Enemy enemyref)
        {
            if (attacktype == 0)
            {
                Console.WriteLine("The Player Normal Attacks!");
                enemyref.health -= damage * 0.75f;
                Console.WriteLine(string.Format("The Player Hits, It Deals {0} Damage\n\nThe Beasts Health Is Now {1}", damage, enemyref.health));
            }

            else if (attacktype == 1)
            {
                Console.WriteLine("The Player Heavy Attacks!");
                if (rnd.Next(0, 2) == 1)
                {
                    enemyref.health -= damage * 2f;
                    Console.WriteLine(string.Format("The Player Hits, It Deals {0} Damage\n\nThe Beasts Health Is Now {1}", damage * 2f, enemyref.health));
                }
                else
                {
                    Console.WriteLine("The Player Misses His Attack!");
                }

            }

            else if (attacktype == 2)
            {
                Console.WriteLine("The Player Chain Attacks!");
                if (rnd.Next(0, 2) == 1)
                {
                    enemyref.health -= damage * 1f;
                    Console.WriteLine(string.Format("The Player Hits The First Hit, It Deals {0} Damage\n\nThe Beasts Health Is Now {1}", damage * 1f, enemyref.health));
                }
                else
                {
                    Console.WriteLine("The Player Misses His First Attack!");
                }

                if (rnd.Next(0, 2) == 1)
                {
                    enemyref.health -= damage * 1f;
                    Console.WriteLine(string.Format("The Player Hits The Second Hit, It Deals {0} Damage\n\nThe Beasts Health Is Now {1}", damage * 1f, enemyref.health));
                }
                else
                {
                    Console.WriteLine("The Player Misses His Last Attack!");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
            Console.WriteLine("");
        }

    }
}
