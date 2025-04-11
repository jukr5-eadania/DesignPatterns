using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using DesignPatterns.ComponentPattern;
using DesignPatterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct3D9;
using System.Reflection.Metadata;

namespace DesignPatterns
{
    public class Player : Component
    {
        private float speed;
        private bool canShoot = true;
        private float shootTimer = 1;
        private float timeSinceLastShot;

        public Player(GameObject gameObject) : base(gameObject)
        {

        }

        public override void Start()
        {
            SpriteRenderer sr = gameObject.getComponent<SpriteRenderer>() as SpriteRenderer;
            sr.SetSprite("Sprites\\fwd\\1fwd");
            gameObject.Transform.Position = new Vector2(GameWorld.Instance.Width / 2, GameWorld.Instance.Height - sr.Sprite.Height / 3);
            speed = 100;
        }

        public void Move(Vector2 velocity)
        {
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            velocity *= speed;
            gameObject.Transform.Translate(velocity * GameWorld.Instance.DeltaTime);
        }

        public void MoveByAddition(Vector2 velocity)
        {
            gameObject.Transform.Translate(velocity);
        }

        public void Shoot()
        {
            if (canShoot)
            {
                canShoot = false;
                timeSinceLastShot = 0;
                GameObject laserGo = LaserFactory.Instance.Create();
                laserGo.Transform.Position = gameObject.Transform.Position;
                GameWorld.Instance.instantiate(laserGo);
            }
        }

        public override void Update()
        {
            timeSinceLastShot += GameWorld.Instance.DeltaTime;
            if (timeSinceLastShot > shootTimer)
            {
                canShoot = true;
            }
        }
    }
}
