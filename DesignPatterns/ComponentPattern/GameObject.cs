using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ComponentPattern
{
    public class GameObject
    {
        public Transform Transform { get; set; } = new();
        private List<Component> components = new();
        public string Tag { get; set; }

        public T AddComponent<T>(params object[] additionalParameters) where T : Component
        {
            Type componentType = typeof(T);
            try
            {
                // Opret en instans ved hjælp af den fundne konstruktør og leverede parametre
                object[] allParameters = new object[1 + additionalParameters.Length];
                allParameters[0] = this;
                Array.Copy(additionalParameters, 0, allParameters, 1, additionalParameters.Length);

                T component = (T)Activator.CreateInstance(componentType, allParameters);
                components.Add(component);
                return component;
            }
            catch (Exception)
            {
                // Håndter tilfælde, hvor der ikke er en passende konstruktør
                throw new InvalidOperationException($"Klassen {componentType.Name} har ikke en " +
                    "konstruktør, der matcher de leverede parametre.");
            }
        }

        public Component getComponent<T>() where T : Component
        {
            return components.Find(x => x.GetType() == typeof(T));
        }

        public void Awake()
        {
            foreach (var component in components)
            {
                component.Awake();
            }
        }

        public void Start()
        {
            foreach (var component in components)
            {
                component.Start();
            }
        }

        public void Update()
        {
            foreach (var component in components)
            {
                component.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var component in components)
            {
                component.Draw(spriteBatch);
            }
        }
    }
}
