using System;
using Baligo.Entity.Interfaces;

namespace Baligo.Entity.Items
{
    public class Item : ICollectable
    {
        public int HealthPoints { get; set; }
        public int DamagePoints { get; set; }
        public int ManaPoints { get; set; }

        public virtual bool IsItemCollected()
        {
            throw new NotImplementedException();
        }
    }
}
