using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CommandPattern
{
    public class MoveCommand : ICommand
    {
        private Vector2 velocity;
        private Player player;

        public MoveCommand(Player player, Vector2 velocity)
        {
            this.velocity = velocity;
            this.player = player;
        }

        public void Execute()
        {
            player.Move(velocity);
        }
    }
}
