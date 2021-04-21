using Microsoft.Xna.Framework;
using MonsterFightDatabase.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Managers
{
    public class TeamManager : Manager
    {
        public TeamManager() : base()
        {
            GameObject backdrop = new GameObject();
            backdrop.Transform.Position = new Vector2(0, 0);
            SpriteRenderer renderer = new SpriteRenderer();
            renderer.SetSprite("Backdrops/TeamBackdrop");
            backdrop.AddComponent(renderer);
            WindowObjects.Add(backdrop);
        }
    }
}
