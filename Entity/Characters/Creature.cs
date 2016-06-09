using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters
{
    public abstract class Creature
    {
        public Vector2 Position;
        public int Health;
        public int Armor;
        public int Damage;
        public int Speed;
        public bool IsAlive;
        
        public abstract void Update(GameTime gmaTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
