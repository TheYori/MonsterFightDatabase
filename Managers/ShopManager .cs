using Microsoft.Xna.Framework;
using MonsterFightDatabase.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Managers
{
    public class ShopManager : Manager
    {

        private List<Item> items;
        private List<GameObject> ItemCards;

        public ShopManager() : base()
        {
            items = new List<Item>();
            ItemCards = new List<GameObject>();

            GameObject backdrop = new GameObject();
            backdrop.Transform.Position = new Vector2(60, 128);
            SpriteRenderer renderer = new SpriteRenderer();
            renderer.SetSprite("Backdrops/ShopBackdrop");
            backdrop.AddComponent(renderer);
            WindowObjects.Add(backdrop);

            GameObject SelectScreen = new GameObject();
            SelectScreen.Transform.Position = new Vector2(100,200);
            SpriteRenderer screenRender = new SpriteRenderer();
            screenRender.SetSprite("SHOP/ShopTypeScreen");
            SelectScreen.AddComponent(screenRender);
            WindowObjects.Add(SelectScreen);


            GameObject ShopScreen = new GameObject();
            ShopScreen.Transform.Position = new Vector2(600, 200);
            SpriteRenderer shopRender = new SpriteRenderer();
            shopRender.SetSprite("SHOP/ShopItemScreen");
            ShopScreen.AddComponent(shopRender);
            WindowObjects.Add(ShopScreen);

            items = SetupItems();
            ItemCards=SetupCards(items);

        }

        public List<Item> SetupItems()
        {

            return Database.GetInventoryItems();
        }

        public List<GameObject> SetupCards(List<Item> items) {

            List<SpriteRenderer> render = new List<SpriteRenderer>();
            List<GameObject> obj = new List<GameObject>();

            List<SpriteRenderer> buttonRender = new List<SpriteRenderer>();
            List<GameObject> buttonObj = new List<GameObject>();

            List<GameObject> result = new List<GameObject>();
            
            

            for (var i = 0; i < items.Count; i++)
            {
                if(i < 3)
                {
                    render.Add(new SpriteRenderer());
                    buttonRender.Add(new SpriteRenderer());
                    obj.Add(new GameObject());
                    buttonObj.Add(new GameObject());

                    obj[i].Transform.Position = new Vector2(625, 225 + (i * 215));
                    buttonObj[i].Transform.Position = obj[i].Transform.Position + new Vector2(520, 110);
                    render[i].SetSprite("SHOP/ShopItemCard");
                    buttonRender[i].SetSprite("SHOP/BuyButton");
                    obj[i].AddComponent(render[i]);
                    buttonObj[i].AddComponent(buttonRender[i]);
                    obj[i].AddComponent(new ItemCard(items[i], buttonObj[i], ItemCardType.Shop));

                    WindowObjects.Add(obj[i]);
                    WindowObjects.Add(buttonObj[i]);

                    result.Add(obj[i]);
                }
     

            }

            return result;
        }

        public void removeFromShop(GameObject item, GameObject button)
        {
            for(var i = 0; i < WindowObjects.Count; i++)
            {
                if(WindowObjects[i] == item)
                {
                    WindowObjects.RemoveAt(i);
                }
            }

            for (var i = 0; i < WindowObjects.Count; i++)
            {
                if (WindowObjects[i] == button)
                {
                    WindowObjects.RemoveAt(i);
                }
            }

        }


    }
}
