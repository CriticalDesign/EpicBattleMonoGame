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
    internal class Slime : Minion
    {
        private bool _hasSplit;
        private int _originalHealth;

        public Slime(int health, bool hasSplit, Texture2D currentSprite, SpriteFont currentFont, float x, float y) : base(health, 0, currentSprite, currentFont, x, y)
        {
            _hasSplit = hasSplit;
            _originalHealth = base.GetHealth();
        }

        public bool HasSplit() { return _hasSplit; }

        public bool ShouldSplit() { 
            Console.WriteLine("original health: " + _originalHealth + ", current health: " + base.GetHealth() + ", should split " + ((_originalHealth / 2) >= base.GetHealth()));
            return (_originalHealth / 2) >= base.GetHealth();  
        }

        public override int DealDamage()
        {
            if (_hasSplit)
                return base.DealDamage() / 2;
            else
                return base.DealDamage();
        }

        public int SlimeBounce()
        {
            Console.WriteLine("**BOING!**");
            if (_hasSplit)
                return base.DealDamage();
            return
                base.DealDamage() * 2;
        }

        public override string ToString()
        {
            if(_hasSplit)
                return "SplitSlime[" + base.ToString() + ", split?: " + _hasSplit + "]";
            else
                return "Slime[" + base.ToString() + ", split?: " + _hasSplit + "]";
        }



    }
}
