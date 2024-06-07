using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EpicBattleMonoGame
{
    internal class Minion
    {

        //Minions default class
        protected int _health;
        protected int _armour;

        protected Texture2D _currentSprite;
        protected SpriteFont _currentFont;
        protected float _x, _y;

        protected Color _currentColor;

        //Constructor
        public Minion(int health, int armour, Texture2D currentSprite, SpriteFont currentFont, float x, float y)
        {
            if (health <= 0 || health > 35)
                health = 35;
            _health = health;

            if (armour < 0 || armour > 5)
                armour = 3;
            _armour = armour;

            _currentSprite = currentSprite;
            _currentFont = currentFont;
            _x = x;
            _y = y;

            _currentColor = Color.White;
        }

        public int GetHealth() { return _health; }
        public int GetArmour() { return _armour; }

        public Rectangle GetBounds() { return new Rectangle((int)_x, (int)_y, _currentSprite.Width, _currentSprite.Height); }

        //armour reduces damage
        public virtual void TakeDamage(int damage) { _health -= (damage - _armour); }

        //default damage is 5
        public virtual int DealDamage() { return 5; }

        //is the minion dead?
        public bool isDead() { return _health <= 0; }

        public void Update(GameTime gameTime) 
        {
            if (GetBounds().Contains(Mouse.GetState().Position))
            {
                _currentColor = Color.DarkGray;

                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    TakeDamage(1);
            }
            else
                _currentColor = Color.White;

        
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_currentSprite, new Vector2(_x, _y), _currentColor);

            string healthString = "Health:" + _health;
            float healthStringWidth = _currentFont.MeasureString(healthString).X;
            spriteBatch.DrawString(_currentFont, healthString + "", new Vector2(_x + _currentSprite.Width / 2 - healthStringWidth / 2, _y - 25), Color.White);
            spriteBatch.End();
        }

        public override string ToString()
        {
            return "Minion[" + _health + "," + _armour + "]";
        }
    }
}
