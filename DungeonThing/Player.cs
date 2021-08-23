using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace DungeonThing
{
    class Player
    {
        public float health = 100;
        public Vector2 position = new Vector2(0, 0);

        public void PlayerTurn()
        {
            Console.Clear();
            Console.WriteLine("Player Move:");
            Console.WriteLine("");
            Console.WriteLine(string.Format("Current Position: X{0}, Y{1}", position.X, position.Y));
        }

    }
}
