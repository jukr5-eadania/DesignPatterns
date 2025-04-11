using DesignPatterns.ComponentPattern;
using DesignPatterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ObjectPool
{
    public class EnemyGameObjectPool : GameObjectPool
    {
        private static EnemyGameObjectPool instance;
        public static EnemyGameObjectPool Instance
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

        protected override void CleanUp(GameObject gameObject)
        {
            
        }

        protected override GameObject Create()
        {
            Random rnd = new();
            return EnemyFactory.Instance.CreateEnemy((EnemyType)rnd.Next(0,3));
        }
    }
}
