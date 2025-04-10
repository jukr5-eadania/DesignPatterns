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

        public T AddComponent<T>() where T : Component
        {
            Type componentType = typeof(T);
            var constructors = componentType.GetConstructors();
            var constructor = constructors.FirstOrDefault(c =>
            {
                var parameters = c.GetParameters();
                return parameters.Length == 1 && parameters[0].ParameterType == typeof(GameObject);
            });
            if (constructor != null)
            {
                T component = (T)Activator.CreateInstance(componentType, this);
                components.Add(component);
                return component;
            }
            else
            {
                throw new InvalidOperationException($"Klassen {componentType.Name} skal have en konstructor med et parameter af typen GameObject.");
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
