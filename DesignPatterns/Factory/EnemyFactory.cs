using DesignPatterns.ComponentPattern;
using DesignPatterns.Strategy;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public enum EnemyType { SLOW, FAST, MULTIPLE }
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
                    enemySpriteRenderer.SetSprite("Sprites\\enemyBlue\\enemyBlue1");
                    enemyGo.AddComponent<Enemy>(new TopToBottomMovement(enemyGo, 50f, new Vector2(0,1)));
                    break;
                case EnemyType.FAST:
                    enemySpriteRenderer.SetSprite("Sprites\\enemyGreen\\enemyGreen2");
                    enemyGo.AddComponent<Enemy>(new DiagonalMovement(enemyGo, 100f));
                    break;
                case EnemyType.MULTIPLE:
                    enemySpriteRenderer.SetSprite("Sprites\\enemyRed\\enemyRed3");
                    enemyGo.AddComponent<Enemy>(new MultipleMovement(new List<IMovementStrategy> { 
                        new TopToBottomMovement(enemyGo, 50f, new Vector2(0, 1)), 
                        new DiagonalMovement(enemyGo, 100f) 
                    }));
                    break;
                default:
                    break;
            }
            return enemyGo;
        }
    }
}
