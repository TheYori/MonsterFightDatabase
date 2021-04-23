using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterFightDatabase.Class
{
    public class CustomMouse : Component
    {
        private bool hasBeenReleased = true;
        private bool isPressed = false;
        public override string ToString()
        {
            return "Mouse";
        }

        public override void Awake() 
        {
            Texture2D sprite = GameManager.Instance.Content.Load<Texture2D>("Ui/Mouse");
            Mouse.SetCursor(MouseCursor.FromTexture2D(sprite, 0, 0));
        }
        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle(
                       (int)(this.GameObject.Transform.Position.X),
                       (int)(this.GameObject.Transform.Position.Y),
                       1,
                       1
                   );
            }
        }
        public override void Update(GameTime gametime) 
        {
            MouseState state = Mouse.GetState();
            this.GameObject.Transform.Position = state.Position.ToVector2();
            if (hasBeenReleased && state.LeftButton == ButtonState.Pressed)
            {
                hasBeenReleased = false;
                isPressed = true;
                Console.WriteLine("mouse clicked");
                foreach (GameObject go in GameManager.Instance.gameObjects.Concat(GameManager.Instance.currentWindow.WindowObjects))
                {
                    if (go.GetComponent("SpriteRenderer") != null && go.GetComponent("Button") != null && (go.GetComponent("SpriteRenderer") as SpriteRenderer).CollisionBox.Intersects(this.CollisionBox))
                    {
                        (go.GetComponent("Button") as Button).action();
                        break;
                    }
                }
            }
            else if (state.LeftButton == ButtonState.Released)
            {
                hasBeenReleased = true;
            }
        }
        public override void Draw(SpriteBatch sprite) 
        {
        }
    }
}
