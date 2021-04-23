using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace MonsterFightDatabase.Class
{
    static class Database
    {
    

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
