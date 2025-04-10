using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using DesignPatterns.ComponentPattern;
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
    }
}
