using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonsterFightDatabase.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Managers
{
    public class TeamManager : Manager
    {
        private enum ActiveTeamMenu { Team, Sponsor, empty }

        private ActiveTeamMenu activeTeamMenu = ActiveTeamMenu.Team;

        private List<GameObject> teamMenu = new List<GameObject>();

        private List<GameObject> sponsorMenu = new List<GameObject>();

        private List<Sponsor> sponsorList = new List<Sponsor>();
        
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
            teamManageButton.AddComponent(new Button(new Action(delegate() { CallTeamMenu(); })));
            WindowObjects.Add(teamManageButton);

            #region Buttons under Team Management
            //Heal Button - appear when Team Management button is pressed
            GameObject healButton = new GameObject();
            healButton.Transform.Position = new Vector2(150, 350);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/HealButton");
            healButton.AddComponent(renderer);
            teamMenu.Add(healButton);

            //Psychology button - appear when Team Management button is pressed
            GameObject psycheButton = new GameObject();
            psycheButton.Transform.Position = new Vector2(150, 525);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/PsykButton");
            psycheButton.AddComponent(renderer);
            teamMenu.Add(psycheButton);

            //Harvest Button - appear when Team Management button is pressed
            GameObject harvestButton = new GameObject();
            harvestButton.Transform.Position = new Vector2(150, 700);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/HarvestButton");
            harvestButton.AddComponent(renderer);
            teamMenu.Add(harvestButton);

            #endregion

            //Sponsor Button - Opens the sponsor mini menu
            GameObject sponsorButton = new GameObject();
            sponsorButton.Transform.Position = new Vector2(431, 200);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/SponserButton");
            sponsorButton.AddComponent(renderer);
            sponsorButton.AddComponent(new Button(new Action(delegate() { CallSponsorMenu(); })));
            WindowObjects.Add(sponsorButton);

            #region Buttons under Sponsor

            //Accept button - appear when Sponsor button is pressed
            GameObject acceptButton = new GameObject();
            acceptButton.Transform.Position = new Vector2(150, 350);
            renderer = new SpriteRenderer();
            renderer.SetSprite("TEAM/AcceptButton");
            acceptButton.AddComponent(renderer);
            sponsorMenu.Add(acceptButton);

            #endregion

            sponsorList = Database.GetSponsors();

            List<GameObject> sponserObj = new List<GameObject>();

            List<SponsorCard> cardObj = new List<SponsorCard>();

            for (var i = 0; i < sponsorList.Count; i++)
            {
                sponserObj.Add(new GameObject());
                sponserObj[i].Transform.Position = new Vector2(810, 200 +(i*100));

                cardObj.Add(new SponsorCard(sponsorList[i]));
                sponserObj[i].AddComponent(cardObj[i]);

                sponsorMenu.Add(sponserObj[i]);

            } 

        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
            if (activeTeamMenu == ActiveTeamMenu.Team)
            {
                foreach (GameObject obj in teamMenu)
                {
                    obj.Update(gametime);
                }
            }
            else if (activeTeamMenu == ActiveTeamMenu.Sponsor)
            {
                foreach (GameObject obj in sponsorMenu)
                {
                    obj.Update(gametime);
                }
            }
        }

        public override void Draw(SpriteBatch sprite)
        {
            base.Draw(sprite);

            if (activeTeamMenu == ActiveTeamMenu.Team)
            {
                foreach (GameObject obj in teamMenu)
                {
                    obj.Draw(sprite);
                }
            }
            else if(activeTeamMenu == ActiveTeamMenu.Sponsor)
            {
                foreach (GameObject obj in sponsorMenu)
                {
                   
                    obj.Draw(sprite);
                }
                
                
            }

            
        }

        public void CallTeamMenu()
        {
            activeTeamMenu = ActiveTeamMenu.Team;
        }

        public void CallSponsorMenu()
        {
            activeTeamMenu = ActiveTeamMenu.Sponsor;
        }



    }
}
