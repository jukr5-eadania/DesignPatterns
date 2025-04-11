using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ComponentPattern
{
    public class Component : ICloneable
    {
        public GameObject gameObject { get; private set; }

        public Component(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public virtual void Awake()
        {

        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        public virtual object Clone()
        {
            Component clone = (Component)MemberwiseClone();
            return clone;
        }

        public void SetNewGameObject(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }
}
