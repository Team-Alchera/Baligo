using System.Collections.Generic;
using Baligo.Content.Fonts;
using Baligo.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Console
{
    static class BaligoConsole
    {
        public static List<Message> Messages;

        public static void Init()
        {
            Messages = new List<Message>();
            Messages.Add(new Message("Initializing game!", Color.Magenta));
            Messages.Add(new Message("Initializing console!", Color.Magenta));
            BaligoConsole.WriteLine("=======", Color.Yellow);
        }

        public static void WriteLine(string message, Color color)
        {
            Messages.Add(new Message(message, color));
            if (Messages.Count > 36)
            {
                Messages.RemoveAt(0);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.ConsoleTile.Texture,
                new Vector2(0, 0),
                new Rectangle(0, 0, 400, 768),
                Color.White);

            int position = 5;
            foreach (var message in Messages)
            {
                if (message.StringMessage == "=======")
                {
                    spriteBatch.DrawString(
                        Fonts.Console,
                        message.StringMessage,
                        new Vector2(20, position),
                        message.Color);
                }
                else
                {
                    spriteBatch.DrawString(
                        Fonts.Console,
                        ">",
                        new Vector2(20, position),
                        Color.White);
                    spriteBatch.DrawString(
                        Fonts.Console,
                        message.StringMessage,
                        new Vector2(40, position),
                        message.Color);
                }
                


                position += 21;
            }
        }
    }

    class Message
    {
        public Color Color;
        public string StringMessage;

        public Message(string _m, Color _c)
        {
            StringMessage = _m;
            Color = _c;
        }
    }
}
