using DesignPatterns.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public class LaserFactory : GameObjectFactory
    {
        private static LaserFactory instance;
        public static LaserFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new();
                }
                return instance;
            }
        }

        GameObject protoType;

        public LaserFactory()
        {
            protoType = new();
            SpriteRenderer sr = protoType.AddComponent<SpriteRenderer>();
            sr.SetSprite("Sprites\\laserRed04");
            protoType.AddComponent<Laser>();
        }

        public override GameObject Create()
        {
            return (GameObject)protoType.Clone();
        }
    }
}
