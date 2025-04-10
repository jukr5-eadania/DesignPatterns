using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Player
    {
        private Texture2D sprite;
        private float speed;
        private Vector2 origin;
        private Transform transform = new();

        public Player(Vector2 position)
        {
            transform.Position = position;
            speed = 100;
        }

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Sprites\\fwd\\1fwd");
            origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            transform.Position = new Vector2(transform.Position.X, transform.Position.Y - (sprite.Height / 3));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, transform.Position, null, Color.White, transform.Rotation, origin, transform.Scale, SpriteEffects.None, 0);
        }

        public void Update(GameTime gametime)
        {
            
        }

        public void Move(Vector2 velocity)
        {
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            velocity *= speed;
            transform.Translate(velocity * GameWorld.Instance.DeltaTime);
        }

        public void MoveByAddition(Vector2 velocity)
        {
            transform.Translate(velocity);
        }
    }
}
