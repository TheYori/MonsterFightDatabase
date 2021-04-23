﻿using Microsoft.Xna.Framework;
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
            //Backdrop for the Team menu
            GameObject backdrop = new GameObject();
            backdrop.Transform.Position = new Vector2(60, 128);
            SpriteRenderer renderer = new SpriteRenderer();
            renderer.SetSprite("Backdrops/TeamBackdrop");
            backdrop.AddComponent(renderer);
            WindowObjects.Add(backdrop);

            //InfoScreen
            GameObject infoScreen = new GameObject();
            infoScreen.Transform.Position = new Vector2(800, 200);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/InfoScreen");
            infoScreen.AddComponent(renderer);
            WindowObjects.Add(infoScreen);

            //Team Management button
            GameObject teamManageButton = new GameObject();
            teamManageButton.Transform.Position = new Vector2(150, 200);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/TeamButton");
            teamManageButton.AddComponent(renderer);
            WindowObjects.Add(teamManageButton);

            //Heal Button
            GameObject healButton = new GameObject();
            healButton.Transform.Position = new Vector2(150, 350);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/HealButton");
            healButton.AddComponent(renderer);
            //WindowObjects.Add(healButton);

            //Psychology button
            GameObject psycheButton = new GameObject();
            psycheButton.Transform.Position = new Vector2(150, 525);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/PsykButton");
            psycheButton.AddComponent(renderer);
            //WindowObjects.Add(psycheButton);

            //HArvest Button
            GameObject harvestButton = new GameObject();
            harvestButton.Transform.Position = new Vector2(150, 700);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/HarvestButton");
            harvestButton.AddComponent(renderer);
            //WindowObjects.Add(harvestButton);

            //Sponsor Button
            GameObject sponsorButton = new GameObject();
            sponsorButton.Transform.Position = new Vector2(431, 200);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/SponserButton");
            sponsorButton.AddComponent(renderer);
            WindowObjects.Add(sponsorButton);
        }
    }
}
