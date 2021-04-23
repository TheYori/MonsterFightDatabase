using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Class
{
    class ItemCard : Component
    {
        private Item item;
        private SpriteFont itemFont;
        private SpriteRenderer spriteRenderer;

        public ItemCard(Item item)
        {
            this.item = item;
        }

        public override void Awake()
        {
            spriteRenderer = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
        }

        public override void Start()
        {
            itemFont = GameManager.Instance.Content.Load<SpriteFont>("Font/BaseFont");
            spriteRenderer.Origin = new Vector2(0, 0);
        }

        public override void Draw(SpriteBatch sprite)
        {
            sprite.DrawString(itemFont, "Name: " + item.Name, GameObject.Transform.Position + new Vector2(30, 30), Color.White);
            sprite.DrawString(itemFont, "Price: " + item.Price, GameObject.Transform.Position + new Vector2(300, 30), Color.White);
            sprite.DrawString(itemFont, "Risk: " + item.Legal, GameObject.Transform.Position + new Vector2(30, 80), Color.White);
            sprite.DrawString(itemFont, "Effect: " + item.EffctNumber, GameObject.Transform.Position + new Vector2(400, 80), Color.White);
            base.Draw(sprite);
        }
        public override string ToString()
        {
            return "ItemCard";
        }
    }
}
