﻿using DesignPatterns.ComponentPattern;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ComponentPattern
{
    public class SpriteRenderer : Component
    {
        public Vector2 Origin { get; set; }
        public Texture2D Sprite { get; set; }

        public SpriteRenderer(GameObject gameObject) : base(gameObject)
        {

        }

        public void SetSprite(string spriteName)
        {
            Sprite = GameWorld.Instance.Content.Load<Texture2D>(spriteName);
        }

        public override void Start()
        {
            Origin = new Vector2(Sprite.Width / 2, Sprite.Height / 2);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, gameObject.Transform.Position, null, Color.White, gameObject.Transform.Rotation, Origin, gameObject.Transform.Scale, SpriteEffects.None, 0);
        }
    }
}
