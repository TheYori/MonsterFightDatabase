using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonsterFightDatabase;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Class
{
    public class SpriteRenderer : Component
    {

        public Texture2D Sprite { get; set; }

        public Vector2 Origin { get; set; }

        public void SetSprite(string spriteName)
        {
            Sprite = GameManager.Instance.Content.Load<Texture2D>(spriteName);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, GameObject.Transform.Position, null, Color.White, 0, Origin, 1, SpriteEffects.None, 0);
        }

        public override string ToString()
        {
            return "SpriteRenderer";
        }

    }
}
