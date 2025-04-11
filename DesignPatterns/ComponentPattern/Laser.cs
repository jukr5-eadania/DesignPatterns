using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ComponentPattern
{
    internal class Laser : Component
    {
        float speed;
        Vector2 velocity;

        public Laser(GameObject gameObject) : base(gameObject)
        {
            this.speed = 500;
            velocity = new(0, -1);
        }

        public override void Update()
        {
            gameObject.Transform.Translate(velocity * speed * GameWorld.Instance.DeltaTime);
            if (gameObject.Transform.Position.Y < 0)
            {
                GameWorld.Instance.Destroy(gameObject);
            }
        }
    }
}
