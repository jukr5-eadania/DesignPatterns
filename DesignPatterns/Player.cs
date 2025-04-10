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
        private Vector2 position;
        private Vector2 origin;

        public Player(Vector2 position)
        {
            this.position = position;
            speed = 100;
        }

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Sprites\\fwd\\1fwd");
            origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            position.Y -= sprite.Height / 3;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, origin, 1, SpriteEffects.None, 0);
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
            position += velocity * GameWorld.DeltaTime;
        }
    }
}
