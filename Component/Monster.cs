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
            SpriteRenderer sr = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
            sr.SetSprite("TestPicture");
            sr.Origin = new Vector2(sr.Sprite.Width / 2, (sr.Sprite.Height / 2) + 70);
        }

        public override string ToString()
        {
            return "Monster";
        }
    }
}
