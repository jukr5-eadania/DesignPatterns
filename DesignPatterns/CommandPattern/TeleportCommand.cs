using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CommandPattern
{
    public class TeleportCommand : ICommand
    {
        private Player player;
        private Vector2 velocity;

        public TeleportCommand(Player player, Vector2 velocity)
        {
            this.player = player;
            this.velocity = velocity;
        }

        public void Execute()
        {
            player.MoveByAddition(velocity);
        }

        public void Undo()
        {
            player.MoveByAddition(-velocity);
        }
    }
}
