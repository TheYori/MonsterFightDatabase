using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterFightDatabase.Class
{
    public class SponsorCard : Component 
    {

        private SpriteFont sponsorFont;

        public Sponsor sponsor;

        public SponsorCard(Sponsor sponsor) 
        {
            this.sponsor = sponsor;
            sponsorFont = GameManager.Instance.Content.Load<SpriteFont>("Font/BaseFont");
        }

        public override void Draw(SpriteBatch sprite)
        {
            sprite.DrawString(sponsorFont, "Sponsor: " + sponsor.Name, GameObject.Transform.Position + new Vector2(30, 30), Color.White);
            sprite.DrawString(sponsorFont, "Earnings: " + sponsor.Money, GameObject.Transform.Position + new Vector2(30, 80), Color.White);
            sprite.DrawString(sponsorFont, "Demand: " + sponsor.DemandNumber, GameObject.Transform.Position + new Vector2(30, 130), Color.White);

            base.Draw(sprite);
        }

        public override string ToString()
        {
            return "SponsorCard";
        }
    }
}
