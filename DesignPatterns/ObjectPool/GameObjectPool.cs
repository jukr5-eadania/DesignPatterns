using DesignPatterns.ComponentPattern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ObjectPool
{
    public abstract class GameObjectPool
    {
        private List<GameObject> activeObjects = new();
        private Stack<GameObject> inactiveObjects = new();

        public GameObject GetGameObject()
        {
            GameObject go;
            if (inactiveObjects.Count == 0)
            {
                Debug.WriteLine("Created new gameobject");
                go = Create();
            }
            else
            {
                Debug.WriteLine("Got go from pool");
                go = inactiveObjects.Pop();
            }
            activeObjects.Add(go);
            return go;
        }

        public void ReleaseObject(GameObject gameObject)
        {
            activeObjects.Remove(gameObject);
            inactiveObjects.Push(gameObject);
            CleanUp(gameObject);

            Debug.WriteLine("Pooled gameobject");
            GameWorld.Instance.Destroy(gameObject);
        }

        protected abstract GameObject Create();

        protected abstract void CleanUp(GameObject gameObject);
    }
}
