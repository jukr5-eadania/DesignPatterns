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

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Sprites\\fwd\\1fwd");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, Vector2.Zero, Color.White);
        }
    }
}
