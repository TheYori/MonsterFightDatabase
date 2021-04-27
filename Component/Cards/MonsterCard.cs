using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Class
{
    public class MonsterCard : Component
    {
        public Monster monster;
        private SpriteFont monsterFont;

        public MonsterCard(Monster monster)
        {
            this.monster = monster;
            monsterFont = GameManager.Instance.Content.Load<SpriteFont>("Font/BaseFont");
        }
        public override void Draw(SpriteBatch sprite)
        {
            sprite.DrawString(monsterFont, "Name: " + monster.Id, GameObject.Transform.Position + new Vector2(30, 30), Color.White);
            sprite.DrawString(monsterFont, "Mood: " + monster.Mood, GameObject.Transform.Position + new Vector2(30, 80), Color.White);
            sprite.DrawString(monsterFont, "Moral: " + monster.Moral, GameObject.Transform.Position + new Vector2(30, 130), Color.White);

            base.Draw(sprite);
        }
        public override string ToString()
        {
            return "MonsterCard";
        }
        public void SelectMonster()
        {
        }
    }
}
