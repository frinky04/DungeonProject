using System;
using System.Numerics;

namespace DungeonThing
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            while (player.health >= 1)
            {
                player.PlayerTurn();
            }

        }
    }
}
