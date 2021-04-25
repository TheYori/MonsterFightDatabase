using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace MonsterFightDatabase.Class
{
    static class Database
    {


        public static void UpdateInventory(int itemID) { }

        public static List<Item> GetInventoryItems()
        {

            List<Item> inventoryItem = new List<Item>();

            var connection = new SQLiteConnection("Data Source=staticData.db;Version=3;New=True");
            connection.Open();

            var cmd = new SQLiteCommand("SELECT * from iteminventory", connection);
            var dataSet = cmd.ExecuteReader();

            cmd = new SQLiteCommand("SELECT * from items", connection);
            var itemSet = cmd.ExecuteReader();

            while (dataSet.Read())
            {
                int itemId = dataSet.GetInt32(0);
                int amount = dataSet.GetInt32(1);

                while (itemSet.Read())
                {
                    int id = itemSet.GetInt32(0);
                    string Name = itemSet.GetString(1);
                    int price = itemSet.GetInt32(2);
                    int legal = itemSet.GetInt32(3);
                    int effectNumber = itemSet.GetInt32(4);

                    if(itemId == id) {
                        inventoryItem.Add(new Item(Name, amount, legal, effectNumber, id));
                        //Jeg har skifte price variablen ud med Amount variablen, så antal ad item ligger det samme sted som prisen.
                    }

                }

            }

            return inventoryItem;

        }


        public static List<Item> GetShopItems()
        {

            List<Item> result = new List<Item>();

            var connection = new SQLiteConnection("Data Source=staticData.db;Version=3;New=True");
            connection.Open();

            var cmd = new SQLiteCommand("SELECT * from items", connection);
            var dataSet = cmd.ExecuteReader();

            while (dataSet.Read())
            {
                int id = dataSet.GetInt32(0);
                string Name = dataSet.GetString(1);
                int price = dataSet.GetInt32(2);
                int legal = dataSet.GetInt32(3);
                int effectNumber = dataSet.GetInt32(4);


                result.Add(new Item(Name, price, legal, effectNumber, id));
            }

            return result;

        }
    }
}
