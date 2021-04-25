using Microsoft.Xna.Framework;
using MonsterFightDatabase.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Managers
{
    enum inventoryState{ItemState, PartState}

    public class InventoryManager : Manager
    {

        private inventoryState state = inventoryState.ItemState;
        private List<Item> items;
        private List<ItemCard> ItemCards;
        public List<int> ItemIDToUpdate;

        public bool UpdateIncomming { get; set; }
 
        public InventoryManager() : base()
        {
            items = new List<Item>();
            ItemCards = new List<ItemCard>();
            ItemIDToUpdate = new List<int>();

            GameObject backdrop = new GameObject();
            backdrop.Transform.Position = new Vector2(60, 128);
            SpriteRenderer renderer = new SpriteRenderer();
            renderer.SetSprite("Backdrops/InventoryBackdrop");
            backdrop.AddComponent(renderer);
            WindowObjects.Add(backdrop);

            GameObject inventoryScreen = new GameObject();
            inventoryScreen.Transform.Position = new Vector2(600, 200);
            SpriteRenderer invnetoryScreenRender = new SpriteRenderer();
            invnetoryScreenRender.SetSprite("INVENTORY/InventoryItemScreen");
            inventoryScreen.AddComponent(invnetoryScreenRender);
            WindowObjects.Add(inventoryScreen);

            GameObject inventoryItemButton = new GameObject();
            inventoryItemButton.Transform.Position = new Vector2(100, 200);
            SpriteRenderer ItemButtonRender = new SpriteRenderer();
            ItemButtonRender.SetSprite("INVENTORY/ItemButton");
            inventoryItemButton.AddComponent(ItemButtonRender);
            WindowObjects.Add(inventoryItemButton);

            GameObject inventoryPartButton = new GameObject();
            inventoryPartButton.Transform.Position = new Vector2(100, 400);
            SpriteRenderer partButtonRender = new SpriteRenderer();
            partButtonRender.SetSprite("INVENTORY/PartButton");
            inventoryPartButton.AddComponent(partButtonRender);
            WindowObjects.Add(inventoryPartButton);


            items = SetUpInventory();
            ItemCards = SetupItemIventoryCards(items);
        }


        public List<Item> SetUpInventory()
        {

            return Database.GetInventoryItems();
        }

        public List<ItemCard> SetupItemIventoryCards(List<Item> items)
        {

            List<SpriteRenderer> render = new List<SpriteRenderer>();
            List<GameObject> obj = new List<GameObject>();

            List<SpriteRenderer> buttonRender = new List<SpriteRenderer>();
            List<GameObject> buttonObj = new List<GameObject>();

            List<ItemCard> itemCardObj = new List<ItemCard>();

            List<ItemCard> result = new List<ItemCard>();

            for (var i = 0; i < items.Count; i++)
            {
                if (i < 3)
                {
                    render.Add(new SpriteRenderer());
                    buttonRender.Add(new SpriteRenderer());
                    obj.Add(new GameObject());
                    buttonObj.Add(new GameObject());

                    obj[i].Transform.Position = new Vector2(625, 225 + (i * 215));
                    buttonObj[i].Transform.Position = obj[i].Transform.Position + new Vector2(470, 110);
                    render[i].SetSprite("INVENTORY/InventoryItemCard");
                    buttonRender[i].SetSprite("INVENTORY/DropButton");
                    obj[i].AddComponent(render[i]);
                    buttonObj[i].AddComponent(buttonRender[i]);
                    itemCardObj.Add(new ItemCard(items[i], buttonObj[i], ItemCardType.Inventory));
                    obj[i].AddComponent(itemCardObj[i]);

                    WindowObjects.Add(obj[i]);
                    WindowObjects.Add(buttonObj[i]);

                    result.Add(itemCardObj[i]);
                }


            }

            return result;
        }


        public void InitInventory() {
            if(UpdateIncomming == true)
            {
                for(var i=0; i < ItemIDToUpdate.Count; i++)
                {
                    for(var y =0; y < items.Count; y++)
                    {
                        if (ItemIDToUpdate[i] == items[y].ItemId)
                        {
                            items[y].Price = Database.UpdateItemAmount(items[y].ItemId);
                            ItemIDToUpdate.RemoveAt(i);
                        } else
                        {
                            GameObject newItemCard = new GameObject();
                            GameObject newDropButton = new GameObject();
                            SpriteRenderer newItemRendere = new SpriteRenderer();
                            SpriteRenderer newDropButtonRendere = new SpriteRenderer();
                            ItemCard itemCardObj;

                            Item item;
                            newItemCard.Start();


                            newItemCard.Transform.Position = new Vector2(625, 225 + (ItemCards.Count * 215));
                            newDropButton.Transform.Position = newItemCard.Transform.Position + new Vector2(470, 110);
                      
                            newItemRendere.SetSprite("INVENTORY/InventoryItemCard");
                            newDropButtonRendere.SetSprite("INVENTORY/DropButton");
                            newItemCard.AddComponent(newItemRendere);
                            newDropButton.AddComponent(newDropButtonRendere);



                            item = Database.GetItemFromDatabase(ItemIDToUpdate[i]);
                            itemCardObj = new ItemCard(item, newDropButton,ItemCardType.Shop);
                            newItemCard.AddComponent(itemCardObj);

                            WindowObjects.Add(newItemCard);
                            WindowObjects.Add(newDropButton);

                            Database.AddItemToInventory(ItemIDToUpdate[i]);
                            ItemIDToUpdate.RemoveAt(i);
                        }
                    }

                }

                UpdateIncomming = false;
            }
        }
    }
}
