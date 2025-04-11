using DesignPatterns.ComponentPattern;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy
{
    public class TopToBottomMovement : IMovementStrategy
    {
        private float speed = 10;
        private Vector2 velocity;
        private GameObject gameObject;

        public TopToBottomMovement(GameObject gameObject, float speed, Vector2 velocity)
        {
            this.gameObject = gameObject;
            this.speed = speed;
            this.velocity = velocity;
            RespawnAndSetNewPosition();
        }

        public void Move()
        {
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            gameObject.Transform.Translate(velocity * speed * GameWorld.Instance.DeltaTime);

            if (GameWorld.Instance.Height < gameObject.Transform.Position.Y - 50)
            {
                RespawnAndSetNewPosition();
            }
        }

        public void RespawnAndSetNewPosition()
        {
            Random rnd = new();
            float xRandomCoord = rnd.Next(0, GameWorld.Instance.Width);
            float yCoordOutsideScreen = -((SpriteRenderer)gameObject.getComponent<SpriteRenderer>()).Sprite.Height / 2;
            gameObject.Transform.Position = new Vector2(xRandomCoord, yCoordOutsideScreen);
        }
    }
}
