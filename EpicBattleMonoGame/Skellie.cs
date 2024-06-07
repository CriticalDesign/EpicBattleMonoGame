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
    internal class Skellie : Minion
    {
        //Constructor - Skellies don't have armour, set it to 0
        public Skellie(int health, Texture2D currentSprite, SpriteFont currentFont, float x, float y) : base(health, 0, currentSprite, currentFont, x, y)
        {
            
        }

        //skellies take half damage - because they are skellies
        public override void TakeDamage(int damage)
        {
            if (damage > 2)
            {
                _health -= damage / 2;
            }
            else
            {
                _health -= damage;
            }
        }

        //Skelles do 2-8 damage by default
        public override int DealDamage()
        {
            Random rng = new Random();
            return rng.Next(2, 8);
        }

        //Skellie special.
        public int SkellieRattle()
        {
            Console.WriteLine("**spooky rattling**");
            Random rng = new Random();
            return rng.Next(7, 15);
        }

        public override string ToString()
        {
            return "Skellie[" + base.ToString() + "]";
        }
    }
}
