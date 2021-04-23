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

            //Sponsor Button
            GameObject sponsorButton = new GameObject();
            sponsorButton.Transform.Position = new Vector2(450, 200);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/SponserButton");
            sponsorButton.AddComponent(renderer);
            WindowObjects.Add(sponsorButton);
        }
    }
}
