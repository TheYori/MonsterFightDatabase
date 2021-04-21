﻿using Microsoft.Xna.Framework;
using MonsterFightDatabase.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Managers
{
    public class InventoryManager : Manager
    {
        public InventoryManager() : base()
        {
            GameObject backdrop = new GameObject();
            backdrop.Transform.Position = new Vector2(0, 0);
            SpriteRenderer renderer = new SpriteRenderer();
            renderer.SetSprite("Backdrops/InventoryBackdrop");
            backdrop.AddComponent(renderer);
            WindowObjects.Add(backdrop);
        }
    }
}
