using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.Content.Fonts;
using Baligo.Entity.Characters.Enemies;
using Baligo.Entity.Characters.Players;
using Baligo.Entity.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Main
{
    class StoryLine
    {
        public StoryLine(Level level)
        {
            this.Story = level.Story;
        }

        public StoryLine(Enemy enemy)
        {
            this.Story = enemy.Story;
        }

        public StoryLine(Player player)
        {
            this.Story = player.Story;
        }

        public string Story { get; set; }

        public void DisplayBaligoStoryLine()
        {
        }
    }
}