using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonsterFightDatabase.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Managers
{
    public abstract class Manager
    {
        protected List<GameObject> WindowObjects { get; set; }

        public Manager()
        {
            WindowObjects = new List<GameObject>();
        }

        public virtual void Update(GameTime gametime)
        {
            foreach (GameObject gameObj in WindowObjects)
            {
                gameObj.Update(gametime);
            }
        }
        public virtual void Draw(SpriteBatch sprite) 
        {
            foreach (GameObject gameObj in WindowObjects)
            {
                gameObj.Draw(sprite);
            }
        }
    }
}
