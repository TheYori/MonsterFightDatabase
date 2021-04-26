using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace MonsterFightDatabase.Class
{
    static class MonsterDatabase
    {
        private static string connectionString = "Data Source=DynamicData.db;Version=3;";
        static public void Create()
        {
            using (SQLiteConnection c = new SQLiteConnection(connectionString))
            {
                string cmds = "CREATE TABLE IF NOT EXISTS Monster (monster_id INTEGER NOT NULL PRIMARY KEY, mood INTEGER DEFAULT 0, moral INTEGER DEFAULT 0); ";
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(cmds, c))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        static public void NewMonster()
        { 
            using (SQLiteConnection c = new SQLiteConnection(connectionString))
            {
                string cmds = "INSERT INTO people ( mood, moral) VALUES(0, 0); ";
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(cmds, c))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        static public List<Monster> getMonsters()
        {
            using (SQLiteConnection c = new SQLiteConnection(connectionString))
            {
                List<Monster> final = new List<Monster>();
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT monster_id from Monster", c))
                {
                    using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                    {
                        while (dataSet.Read())
                        {
                            final.Add(new Monster(dataSet.GetInt32(0)));
                        }
                    }
                }
                return final;
            }
        }

    }
}
