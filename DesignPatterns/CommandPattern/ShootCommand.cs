using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CommandPattern
{
    public class ShootCommand : ICommand
    {
        Player player;

        public ShootCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.Shoot();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
