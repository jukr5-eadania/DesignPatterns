using DesignPatterns.ComponentPattern;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy
{
    internal class DiagonalMovement : IMovementStrategy
    {
        private float speed = 10;
        private Vector2 velocity;
        private GameObject gameObject;

        public DiagonalMovement(GameObject gameObject, float speed)
        {
            this.gameObject = gameObject;
            this.speed = speed;
            RespawnAndSetNewPosition();
        }

        public void Move()
        {
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            gameObject.Transform.Translate(velocity * speed * GameWorld.Instance.DeltaTime);

            if (gameObject.Transform.Position.Y - 50 > GameWorld.Instance.Height ||
                gameObject.Transform.Position.X + 50 < 0 ||
                gameObject.Transform.Position.X - 50 > GameWorld.Instance.Width)
            {
                RespawnAndSetNewPosition();
            }
        }

        public void RespawnAndSetNewPosition()
        {
            Random rnd = new();
            float randomY = (float)rnd.NextDouble();

            float randomX = (float)(rnd.NextDouble() * 2f) - 1f;
            velocity = new(randomX, randomY);

            float xRandomCoord = rnd.Next(0, GameWorld.Instance.Width);
            float yCoordOutsideScreen = -((SpriteRenderer)gameObject.getComponent<SpriteRenderer>()).Sprite.Height / 2;
            gameObject.Transform.Position = new Vector2(xRandomCoord, yCoordOutsideScreen);
        }
    }
}
