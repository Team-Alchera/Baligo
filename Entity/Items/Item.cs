using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Items
{
<<<<<<< HEAD
    public class Item
=======
    public abstract class Item
>>>>>>> ccc4b6ac56a8694eb82516740f8bbef6b282bbd0
    {
        public Vector2 Position;
        public string Name;
        public int Id;

        public abstract void Update(GameTime gmaTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
