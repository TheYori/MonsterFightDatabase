using Microsoft.Xna.Framework;
using MonsterFightDatabase.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Managers
{
    public class TeamManager : Manager
    {

        // TODO:
        // 1.
        // Make "Team Management" and "Sponsor" button.

        //2.
        // When pressing the "Team Management" button, Heal, psyche and harvest...
        // buttons should appear.
        // Then Do the same with the "Sponsor" button.

        // 3.
        // Next step: Make the newly appeared sprites buttons

        //4.
        //Give them a random function, to make sure they work.
        // pressing the "Accept" button under "Sponsor", should make it green.
        // BONUS: The "Accept" button turn back normal after 1 - 2 seconds.


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

            //Team Management button - Opens the team management mini menu
            GameObject teamManageButton = new GameObject();
            teamManageButton.Transform.Position = new Vector2(150, 200);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/TeamButton");
            teamManageButton.AddComponent(renderer);
            WindowObjects.Add(teamManageButton);

            //Heal Button - appear when Team Management button is pressed
            GameObject healButton = new GameObject();
            healButton.Transform.Position = new Vector2(150, 350);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/HealButton");
            healButton.AddComponent(renderer);
            //WindowObjects.Add(healButton);

            //Psychology button - appear when Team Management button is pressed
            GameObject psycheButton = new GameObject();
            psycheButton.Transform.Position = new Vector2(150, 525);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/PsykButton");
            psycheButton.AddComponent(renderer);
            //WindowObjects.Add(psycheButton);

            //Harvest Button - appear when Team Management button is pressed
            GameObject harvestButton = new GameObject();
            harvestButton.Transform.Position = new Vector2(150, 700);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/HarvestButton");
            harvestButton.AddComponent(renderer);
            //WindowObjects.Add(harvestButton);

            //Sponsor Button - Opens the sponsor mini menu
            GameObject sponsorButton = new GameObject();
            sponsorButton.Transform.Position = new Vector2(431, 200);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/SponserButton");
            sponsorButton.AddComponent(renderer);
            WindowObjects.Add(sponsorButton);

            //BUTTON COMMENTED OUT UNTIL SPONSOR BUTTON WORKS

            //Accept button - appear when Sponsor button is pressed
            //GameObject acceptButton = new GameObject();
            //acceptButton.Transform.Position = new Vector2(150, 350);
            //renderer = new SpriteRenderer();
            //renderer.SetSprite("TEAM/SponserButton");
            //acceptButton.AddComponent(renderer);
            //WindowObjects.Add(acceptButton);

        }
    }
}
