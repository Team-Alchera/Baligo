using Baligo.Content.Fonts;
using Baligo.Entity.Characters.Players;
using Baligo.Graphics;
using Baligo.Input;
using Baligo.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.States
{
    public class MainGame : State
    {
        protected PlayerMain Player;

        public override void Init()
        {
            Player = new PlayerMain();
            Player.Init();
        }

        public override void Update(GameTime gameTime)
        {
            // Update current player class
            Player.CurrentPlayerClass.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                Fonts.Arial,
                "GAME\nPress Left Bottom to shoot\nWORK IN PROGRESS\n",
                new Vector2(BaligoEngine.Width / 2 - 150, BaligoEngine.Height / 2 - 20),
                Color.White);

            //Draw background
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 43; j++)
                {
                    if (i == 0)
                    {
                        Assets.WallBackground.Draw(spriteBatch, j * 32, i * 32);
                    }
                    else
                    {
                        if (j == 0 || j == 42)
                        {
                            Assets.WallBackground.Draw(spriteBatch, j * 32, i * 32);
                        }
                        else
                        {
                            Assets.GrassTypeOneBackground.Draw(spriteBatch, j * 32, i * 32);
                            /*if (i % 4 == 0 && j % 3 == 0)
                            {
                                Assets.GrassTypeTwoBackground.Draw(spriteBatch, j * 32, i * 32);
                            }
                            else
                            {
                                Assets.GrassTypeOneBackground.Draw(spriteBatch, j * 32, i * 32);
                            }*/
                        }
                    }
                    //trees
                    if ((i % 9 == 3) && (j % 13 >= 9))
                    {
                        Assets.GrassTypeTwoBackground.Draw(spriteBatch, j * 32, i * 32);
                        Assets.TreeBackground.Draw(spriteBatch, j * 32, i * 32);
                    }
                    else if ((i % 14 == 5 || i % 14 == 6) && (j % 17 == 3 || j % 17 == 4))
                    {
                        Assets.GrassTypeTwoBackground.Draw(spriteBatch, j * 32, i * 32);
                        Assets.TreeBackground.Draw(spriteBatch, j * 32, i * 32);
                    }
                    //lava
                    if ((i >= 18 && i <= 20) && (j >= 31 && j <= 33))
                    {
                        Assets.LavaBackground.Draw(spriteBatch, j * 32, i * 32);
                    }
                    else if ((i >= 4 && i <= 7) && (j >= 9 && j <= 12))
                    {
                        Assets.LavaBackground.Draw(spriteBatch, j * 32, i * 32);
                    }
                    //doors
                    if ((i == 1 && j == 0) || (i == 23 && j == 42))
                    {
                        Assets.ClosedDoor.Draw(spriteBatch, j * 32, i * 32);
                    }
                    //fountain
                    if ((i == 15 || i == 16) && (j == 10 || j == 11))
                    {
                        Assets.GrassTypeTwoBackground.Draw(spriteBatch, j * 32, i * 32);
                        Assets.Fountain.Draw(spriteBatch, j * 32, i * 32);
                    }
                    else if ((i >= 6 && i <= 7) && (j >= 30 && j <= 31))
                    {
                        Assets.GrassTypeTwoBackground.Draw(spriteBatch, j * 32, i * 32);
                        Assets.Fountain.Draw(spriteBatch, j * 32, i * 32);
                    }
                }
            }
            
            // Draw current player class
            Player.CurrentPlayerClass.Draw(spriteBatch);
        }
    }
}