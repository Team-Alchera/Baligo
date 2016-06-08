using System;
using Baligo.Entity.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Items
{
    public class Item : ICollectable
    {
        public int HealthPoints { get; set; }
        public int DamagePoints { get; set; }
        public int ManaPoints { get; set; }

        // Default will be true
        public virtual bool IsItemCollected()
        {
            return true;
        }

        public virtual void Init()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
