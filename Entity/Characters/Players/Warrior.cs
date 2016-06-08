using Baligo.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TexturePackerLoader;

namespace Baligo.Entity.Characters.Players
{
    
    public class Warrior : Player
    {
        public new Vector2 Position = new Vector2();
               
        private bool isAlive = true;

        public Warrior(int damage, int health)
        {
            this.Damage = damage;
            this.Health = health;
        }

        //Basic warrior Attack
        protected override void Attack()
        {
            // TODO: Implement collision detection for swing animation.
            // Идеята е да проверим когато анимацията стигна кадър номер 5
            //да се провери разстоянието от пиксели където меча замахва,
            //г-д 30-50 пиксела вдясно или вляво  от героя и да се 
            //пресмята атаката му спрямо бронята на опонента.
            
        }
        //Heal is not implemented by the warrior.
        protected override void Heal()
        {
            
        }
        //Is gonna cast spells maybe next course.
        protected override void CastSpell()
        {
            /*Тук можете да слагате идеи за видове магии
             * 
             * 
             */
            
        }


        public override void Init()
        {

            
        }

        /*TODO: This is the part to focus on!
         * 
         */
        public override void Update()
        {
            while (InputManager.AIsPressed)
            {
             // var spriteSheetLoader = new SpriteSheetLoader();
            } 
            Draw(
                new SpriteBatch(
                    new GraphicsDevice(
                        GraphicsAdapter
                        .DefaultAdapter, GraphicsProfile.HiDef, new PresentationParameters())));

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
          
        }
    }
}
