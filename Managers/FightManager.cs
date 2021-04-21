using Microsoft.Xna.Framework;
using MonsterFightDatabase.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Managers
{
    public class FightManager : Manager
    {
        public FightManager() : base()
        {
            GameObject backdrop = new GameObject();
            backdrop.Transform.Position = new Vector2(60, 128);
            SpriteRenderer renderer = new SpriteRenderer();
            renderer.SetSprite("Backdrops/FightBackdrop");
            backdrop.AddComponent(renderer);
            WindowObjects.Add(backdrop);
        }
    }
}
