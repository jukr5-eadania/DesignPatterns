using Microsoft.Xna.Framework;
using System;
using DesignPatterns.Strategy;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ComponentPattern
{
    public class Enemy : Component
    {
        private IMovementStrategy movementStrategy;

        public Enemy(GameObject gameObject, IMovementStrategy movementStrategy) : base(gameObject)
        {
            this.movementStrategy = movementStrategy;
        }

        public override void Update()
        {
            movementStrategy.Move();
        }
    }
}
