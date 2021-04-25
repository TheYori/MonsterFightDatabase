using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Class
{
    class ItemCard : Component
    {
        public Item item;
        private SpriteFont itemFont;
        private SpriteRenderer spriteRenderer;
        private ItemCardType cardType;

        public GameObject BuyButton { get; set; }
        public ItemCard(Item item, GameObject button, ItemCardType type)
        {

            this.item = item;
            BuyButton = button;
            cardType = type;
        }

        public override void Awake()
        {
            spriteRenderer = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
            BuyButton.AddComponent(new Button(new Action(delegate () { BuyObject(); })));
        }

        public override void Start()
        {
            itemFont = GameManager.Instance.Content.Load<SpriteFont>("Font/BaseFont");
            spriteRenderer.Origin = new Vector2(0, 0);

                         
        }

        public override void Draw(SpriteBatch sprite)
        {
            sprite.DrawString(itemFont, "Name: " + item.Name, GameObject.Transform.Position + new Vector2(30, 30), Color.White);
            sprite.DrawString(itemFont, "Risk: " + item.Legal +"%", GameObject.Transform.Position + new Vector2(30, 80), Color.White);
            sprite.DrawString(itemFont, "Effect: " + item.EffctNumber, GameObject.Transform.Position + new Vector2(30, 130), Color.White);

            if(cardType == ItemCardType.Shop)
            {
                sprite.DrawString(itemFont, "Price: " + item.Price, GameObject.Transform.Position + new Vector2(450, 30), Color.White);
            }

            if (cardType == ItemCardType.Inventory)
            {
                sprite.DrawString(itemFont, "Amount: " + item.Price, GameObject.Transform.Position + new Vector2(450, 30), Color.White);
            }



            base.Draw(sprite);
        }
        public override string ToString()
        {
            return "ItemCard";
        }

        public void BuyObject()
        {

            GameManager.Instance.shopManager.removeFromShop(GameObject, BuyButton);


        }


    }
}
