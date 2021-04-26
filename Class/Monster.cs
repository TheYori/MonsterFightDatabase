using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace MonsterFightDatabase.Class
{
    public class Monster
    {
        private int id;
        private static string connectionDynamicString = "Data Source=DynamicData.db;Version=3;";
        private static string connectionStaticString = "Data Source=staticData.db;Version=3;";
        public int Id { get { return id; } }
        public int Mood
        {
            get
            {
                using (SQLiteConnection c = new SQLiteConnection(connectionDynamicString))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT mood from Monster WHERE monster_id = " + Id, c))
                    {
                        using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                        {
                            if (dataSet.Read())
                            {
                                return dataSet.GetInt32(0);
                            }
                            return 0;
                        }
                    }
                }
            }
            set
            {
                using (SQLiteConnection c = new SQLiteConnection(connectionDynamicString))
                {
                    string cmds = "UPDATE Monster SET mood = "+value+" WHERE id = "+Id;
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(cmds, c))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public int Moral
        {
            get
            {
                using (SQLiteConnection c = new SQLiteConnection(connectionDynamicString))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT moral from Monster WHERE monster_id = " + Id, c))
                    {
                        using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                        {
                            if (dataSet.Read())
                            {
                                return dataSet.GetInt32(0);
                            }
                            return 0;
                        }
                    }
                }
            }
            set
            {
                using (SQLiteConnection c = new SQLiteConnection(connectionDynamicString))
                {
                    string cmds = "UPDATE Monster SET moral = " + value + " WHERE id = " + Id;
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(cmds, c))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public int Strength
        {
            get
            {
                using (SQLiteConnection c = new SQLiteConnection(connectionStaticString))
                {
                    int total = 0;
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT strength from Tail WHERE monster_id = " + Id, c))
                    {
                        using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                        {
                            while (dataSet.Read())
                            {
                                total += dataSet.GetInt32(0);
                            }
                        }
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT strength from Arms WHERE monster_id = " + Id, c))
                    {
                        using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                        {
                            while (dataSet.Read())
                            {
                                total += dataSet.GetInt32(0);
                            }
                        }
                    }
                    return total;
                }
            }
        }
        public int Agility
        {
            get
            {
                using (SQLiteConnection c = new SQLiteConnection(connectionStaticString))
                {
                    int total = 0;
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT agillity from Tail WHERE monster_id = " + Id, c))
                    {
                        using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                        {
                            while (dataSet.Read())
                            {
                                total += dataSet.GetInt32(0);
                            }
                        }
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT agillity from Legs WHERE monster_id = " + Id, c))
                    {
                        using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                        {
                            while (dataSet.Read())
                            {
                                total += dataSet.GetInt32(0);
                            }
                        }
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT agillity from Head WHERE monster_id = " + Id, c))
                    {
                        using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                        {
                            while (dataSet.Read())
                            {
                                total += dataSet.GetInt32(0);
                            }
                        }
                    }
                    return total;
                }
            }
        }
        public int Speed
        {
            get
            {
                using (SQLiteConnection c = new SQLiteConnection(connectionStaticString))
                {
                    int total = 0;
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT speed from Arms WHERE monster_id = " + Id, c))
                    {
                        using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                        {
                            while (dataSet.Read())
                            {
                                total += dataSet.GetInt32(0);
                            }
                        }
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT speed from Legs WHERE monster_id = " + Id, c))
                    {
                        using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                        {
                            while (dataSet.Read())
                            {
                                total += dataSet.GetInt32(0);
                            }
                        }
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT speed from Wings WHERE monster_id = " + Id, c))
                    {
                        using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                        {
                            while (dataSet.Read())
                            {
                                total += dataSet.GetInt32(0);
                            }
                        }
                    }
                    return total;
                }
            }
        }
        public int Defence
        {
            get
            {
                using (SQLiteConnection c = new SQLiteConnection(connectionStaticString))
                {
                    int total = 0;
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT defence from Body WHERE monster_id = " + Id, c))
                    {
                        using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                        {
                            while (dataSet.Read())
                            {
                                total += dataSet.GetInt32(0);
                            }
                        }
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT defence from Head WHERE monster_id = " + Id, c))
                    {
                        using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                        {
                            while (dataSet.Read())
                            {
                                total += dataSet.GetInt32(0);
                            }
                        }
                    }
                    return total;
                }
            }
        }
        public int Health
        {
            get
            {
                using (SQLiteConnection c = new SQLiteConnection(connectionStaticString))
                {
                    int total = 0;
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT health from Body WHERE monster_id = " + Id, c))
                    {
                        using (SQLiteDataReader dataSet = cmd.ExecuteReader())
                        {
                            while (dataSet.Read())
                            {
                                total += dataSet.GetInt32(0);
                            }
                        }
                    }
                    return total;
                }
            }
        }

        public Monster(int id)
        {
            this.id = id;
        }
    }
}
