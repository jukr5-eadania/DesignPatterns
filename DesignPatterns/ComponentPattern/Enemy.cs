using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ComponentPattern
{
    public class Enemy : Component
    {
        private float speed = 10;
        private Vector2 velocity;

        public Enemy(GameObject gameObject, float speed) : base(gameObject)
        {
            velocity = new Vector2(0, 1);
            this.speed = speed;
        }

        public override void Start()
        {
            SetRandomPositionOutsideOfScreen();
        }

        public void SetRandomPositionOutsideOfScreen()
        {
            Random rnd = new();
            float xRandomCoord = rnd.Next(0, GameWorld.Instance.Width);
            float yCoordOutsideScreen = -((SpriteRenderer)gameObject.getComponent<SpriteRenderer>()).Sprite.Height / 2;
            gameObject.Transform.Position = new Vector2(xRandomCoord, yCoordOutsideScreen);
        }

        public override void Update()
        {
            Move();
            if (GameWorld.Instance.Height < gameObject.Transform.Position.Y - 50)
            {
                SetRandomPositionOutsideOfScreen();
            }
        }

        private void Move()
        {
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            gameObject.Transform.Translate(velocity*speed*GameWorld.Instance.DeltaTime);
        }
    }
}
