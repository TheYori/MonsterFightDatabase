using Microsoft.Xna.Framework;
using MonsterFightDatabase.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Managers
{
    public class ShopManager : Manager
    {
        private List<ItemCard> itemCards;
        private List<Item> items;


        public ShopManager() : base()
        {
            items = new List<Item>();
            itemCards = new List<ItemCard>();

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
            SetupCards(items);

        }

        public List<Item> SetupItems()
        {
            List<Item> result = new List<Item>();

            result.Add(new Item("test", 1000, 60, 70));
            result.Add(new Item("test2", 2000, 50, 80));
            result.Add(new Item("test3", 3000, 40, 90));
            return result;
        }

        public void SetupCards(List<Item> items) {

            List<SpriteRenderer> render = new List<SpriteRenderer>();
            List<GameObject> obj = new List<GameObject>();




            for (var i = 0; i < items.Count; i++)
            {
                render.Add(new SpriteRenderer());
                obj.Add(new GameObject());
                obj[i].Transform.Position = new Vector2(625, 225 +( i* 215));
                render[i].SetSprite("SHOP/ShopItemCard");
                obj[i].AddComponent(render[i]);
                obj[i].AddComponent(new ItemCard(items[i]));

                WindowObjects.Add(obj[i]);
            }

   


        }
    }
}
