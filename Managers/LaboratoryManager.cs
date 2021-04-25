using Microsoft.Xna.Framework;
using MonsterFightDatabase.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Managers
{
    public class LaboratoryManager : Manager
    {
        public LaboratoryManager() : base()
        {
            GameObject backdrop = new GameObject();
            backdrop.Transform.Position = new Vector2(60, 128);
            SpriteRenderer renderer = new SpriteRenderer();
            renderer.SetSprite("Backdrops/CreateBackdrop");
            backdrop.AddComponent(renderer);
            WindowObjects.Add(backdrop);

            GameObject labInventoryScreen = new GameObject();
            labInventoryScreen.Transform.Position = new Vector2(788, 142);
            SpriteRenderer labInvnetoryScreenRender = new SpriteRenderer();
            labInvnetoryScreenRender.SetSprite("LAB/LABInventoryScreen");
            labInventoryScreen.AddComponent(labInvnetoryScreenRender);
            WindowObjects.Add(labInventoryScreen);

            GameObject labInfoScreen = new GameObject();
            labInfoScreen.Transform.Position = new Vector2(93, 274);
            SpriteRenderer labInfoScreenRender = new SpriteRenderer();
            labInfoScreenRender.SetSprite("LAB/LABInfoScreen");
            labInfoScreen.AddComponent(labInfoScreenRender);
            WindowObjects.Add(labInfoScreen);

            GameObject newButton = new GameObject();
            newButton.Transform.Position = new Vector2(93, 150);
            SpriteRenderer newButtonRender = new SpriteRenderer();
            newButtonRender.SetSprite("LAB/NewButton");
            newButton.AddComponent(newButtonRender);
            WindowObjects.Add(newButton);

            GameObject modButton = new GameObject();
            modButton.Transform.Position = new Vector2(330, 150);
            SpriteRenderer modButtonRender = new SpriteRenderer();
            modButtonRender.SetSprite("LAB/ModButton");
            modButton.AddComponent(modButtonRender);
            WindowObjects.Add(modButton);

            GameObject saveButton = new GameObject();
            saveButton.Transform.Position = new Vector2(1040, 900);
            SpriteRenderer saveButtonRender = new SpriteRenderer();
            saveButtonRender.SetSprite("LAB/SaveButton");
            saveButton.AddComponent(saveButtonRender);
            WindowObjects.Add(saveButton);
        }
    }
}
