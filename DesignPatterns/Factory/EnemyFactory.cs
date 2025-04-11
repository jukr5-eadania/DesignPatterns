using DesignPatterns.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public enum EnemyType { SLOW, FAST }
    public class EnemyFactory : GameObjectFactory
    {
        private static EnemyFactory instance;
        public static EnemyFactory Instance
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

        public override GameObject Create()
        {
            GameObject enemyGo = new();
            SpriteRenderer enemySpriteRenderer = enemyGo.AddComponent<SpriteRenderer>();
            enemyGo.AddComponent<Enemy>();
            enemySpriteRenderer.SetSprite("Sprites\\enemyBlue\\enemyBlue1");
            return enemyGo;
        }

        public GameObject CreateEnemy(EnemyType enemyType)
        {
            GameObject enemyGo = new();
            SpriteRenderer enemySpriteRenderer = enemyGo.AddComponent<SpriteRenderer>();
            switch (enemyType)
            {
                case EnemyType.SLOW:
                    enemyGo.AddComponent<Enemy>(50);
                    enemySpriteRenderer.SetSprite("Sprites\\enemyBlue\\enemyBlue1");
                    break;
                case EnemyType.FAST:
                    enemyGo.AddComponent<Enemy>(100);
                    enemySpriteRenderer.SetSprite("Sprites\\enemyGreen\\enemyGreen1");
                    break;
                default:
                    break;
            }
            return enemyGo;
        }
    }
}
