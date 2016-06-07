using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Interfaces
{
    public interface ICharacter
    {
        // Position
        Vector2 Position { get; set; }

        // Stats
        int Health { get; set; }
        int Damage { get; set; }

        // Status
        bool IsAlive { get; set; }

        // Methods
        void Draw(SpriteBatch spriteBatch);
        void Update();
        void Init();
    }
}
