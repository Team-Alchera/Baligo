using Baligo.Entity.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters
{
    public class Player : ICharacter
    {
        

        public void Init()
        {
            
        }

        public void Update()
        {

        }

        public Vector2 Position { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public bool IsAlive { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
