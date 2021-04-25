using MonsterFightDatabase.Component.MonsterParts;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace MonsterFightDatabase.Class
{
    public class MonsterPartDatabase<T> where T : MonsterPart
    {
        private static Dictionary<string, MonsterPartDatabase<T>> instance = new Dictionary<string, MonsterPartDatabase<T>>();
        private string connectionString = "Data Source=staticData.db;Version=3;";
        public static MonsterPartDatabase<T> Instance
        {
            get
            {
                if (instance.ContainsKey(typeof(T).Name))
                {
                    return instance[typeof(T).Name];
                }
                else
                {
                    MonsterPartDatabase<T> newDatabase = new MonsterPartDatabase<T>();
                    instance.Add(typeof(T).Name, newDatabase);
                    return instance[typeof(T).Name];
                }
                
            }
        }

        public MonsterPart getPartByPartId(int id)
        {
            using (SQLiteConnection c = new SQLiteConnection(connectionString))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * from " + typeof(T).Name + " WHERE monsterpart_id = " + id, c))
                {
                    using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                    {
                        if (dataSet.Read())
                        {
                            int monsterId = dataSet.GetInt32(0);
                            int partId = dataSet.GetInt32(1);
                            string name = dataSet.GetString(2);
                            string rank = dataSet.GetString(3);
                            string alligment = dataSet.GetString(4);
                            int price = dataSet.GetInt32(5);
                            int statOne = dataSet.GetInt32(6);
                            int statTwo = dataSet.GetInt32(7);
                            switch (typeof(T).Name)
                            {
                                case "Tail":
                                    return new Tail(monsterId, partId, name, rank, alligment, price, statOne, statTwo);
                                case "Arms":
                                    return new Arms(monsterId, partId, name, rank, alligment, price, statOne, statTwo);
                                case "Legs":
                                    return new Legs(monsterId, partId, name, rank, alligment, price, statOne, statTwo);
                                case "wings":
                                    return new Wings(monsterId, partId, name, rank, alligment, price, statOne, statTwo);
                                case "body":
                                    return new Body(monsterId, partId, name, rank, alligment, price, statOne, statTwo);
                                case "head":
                                    return new Head(monsterId, partId, name, rank, alligment, price, statOne, statTwo);
                                default:
                                    throw new Exception("ObjectDatabase can only handle the MonsterPart objects at the moment");
                            }
                        }
                        return null;
                    }
                }
            }
        }
        public MonsterPart getPartByMonsterId(int id)
        {
            using (SQLiteConnection c = new SQLiteConnection(connectionString))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * from " + typeof(T).Name + " WHERE monster_id = " + id, c))
                {
                    using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                    {
                        if (dataSet.Read())
                        {
                            int monsterId = dataSet.GetInt32(0);
                            int partId = dataSet.GetInt32(1);
                            string name = dataSet.GetString(2);
                            string rank = dataSet.GetString(3);
                            string alligment = dataSet.GetString(4);
                            int price = dataSet.GetInt32(5);
                            int statOne = dataSet.GetInt32(6);
                            int statTwo = dataSet.GetInt32(7);
                            switch (typeof(T).Name)
                            {
                                case "Tail":
                                    return new Tail(monsterId, partId, name, rank, alligment, price, statOne, statTwo);
                                case "Arms":
                                    return new Arms(monsterId, partId, name, rank, alligment, price, statOne, statTwo);
                                case "Legs":
                                    return new Legs(monsterId, partId, name, rank, alligment, price, statOne, statTwo);
                                case "wings":
                                    return new Wings(monsterId, partId, name, rank, alligment, price, statOne, statTwo);
                                case "body":
                                    return new Body(monsterId, partId, name, rank, alligment, price, statOne, statTwo);
                                case "head":
                                    return new Head(monsterId, partId, name, rank, alligment, price, statOne, statTwo);
                                default:
                                    throw new Exception("ObjectDatabase can only handle the MonsterPart objects at the moment");
                            }
                        }
                        return null;
                    }
                }
            }
        }
    }
}
