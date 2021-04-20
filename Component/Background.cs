using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Class
{
    class Background : Component
    {

        private SpriteRenderer spriteRenderer;

        public override void Awake()
        {
            GameObject.Transform.Position = new Vector2(0, 0);
            spriteRenderer = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
        }

        public override void Start()
        {
            spriteRenderer.SetSprite("");
            spriteRenderer.Origin = new Vector2(0, 0);
        }

        public override string ToString()
        {
            return "Background";
        }
    }
}
