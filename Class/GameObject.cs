using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Class
{
    public class GameObject
    {
        public Transform Transform { get; set; }
      
        public string Tag { get; set; }

        private Dictionary<string, Component> components = new Dictionary<string, Component>();

        public GameObject()
        {
            Transform = new Transform();
        }


        public void AddComponent(Component component)
        {
            components.Add(component.ToString(), component);
            component.GameObject = this;
        }

        public Component GetComponent(string component)
        {
            if(components.ContainsKey(component))
            {
                return components[component];
            }
            return null;
        }

        public void Awake()
        {
            foreach (Component component in components.Values)
            {
                component.Awake();
            }
        }

        public void Start()
        {
            foreach (Component component in components.Values)
            {
                component.Start();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Component component in components.Values)
            {
                if (component.IsEnabled)
                {
                    component.Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component component in components.Values)
            {
                if (component.IsEnabled)
                {
                    component.Draw(spriteBatch);
                }
            }
        }

    }
}
