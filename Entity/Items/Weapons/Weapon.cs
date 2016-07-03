using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Baligo.Entity.Items.Weapons
{
    public abstract class Weapon: Item
    { 
        public Vector2 Direction { get; set; }
        public float Angle { get; set; }
        public Vector2 Velocity { get; set; }
        public bool IsActive { get; set; }
        public int Timer { get; set; }
        public bool IsEnemyArrow { get; set; }
    }
}
