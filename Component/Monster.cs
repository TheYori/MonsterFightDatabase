using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Class
{
    class Monster : Component
    {

        public override void Awake()
        {
            //GameObject.Transform.Position = new Vector2(GameManager.Instance.GraphicsDevice.Viewport.Width / 2, GameManager.Instance.GraphicsDevice.Viewport.Height);
        }

        public override void Start()
        {
            
        }

        public override string ToString()
        {
            return "Monster";
        }
    }
}
