using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Interfaces
{
    public interface ICollectable
    {
        int HealthPoints { get; set; }
        int DamagePoints { get; set; }
        int ManaPoints { get; set; }

        bool IsItemCollected();

        // Methods
        void Update();
        void Draw(SpriteBatch spriteBatch);
        void Init();
    }
}
