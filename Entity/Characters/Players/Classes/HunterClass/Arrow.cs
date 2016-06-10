using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baligo.Content.Fonts;
using Baligo.Graphics;
using Baligo.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Baligo.Entity.Characters.Players.Classes.HunterClass
{
    public class Arrow
    {
        private const int Damage = 10;
        private const int Speed = 20;
        private Vector2 _position;
        private Vector2 _direction;
        private float _angle;

        private Vector2 _velocity;

        public Arrow(Vector2 position, Vector2 direction)
        {
            _position = position;
            _position.X += 16;
            _position.Y += 32;

            _direction = direction;

            _velocity = -(_position - _direction);
            _velocity.Normalize();

            // Calculate Angle

            Vector2 toCalcAngle = position - direction;
            _angle = (float) Math.Atan2(toCalcAngle.Y, toCalcAngle.X);
            
        }

        public void Update()
        {
            _position.X += _velocity.X * Speed;
            _position.Y += _velocity.Y * Speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Assets.PlayerHunterArrow.DrawWithRotation(spriteBatch, (int)_position.X, (int)_position.Y, _angle);
            
        }

        public double AngleFrom3PointsInDegrees(double x1, double y1,
            double x2, double y2,
            double x3, double y3)
        {
            double a = x2 - x1;
            double b = y2 - y1;
            double c = x3 - x2;
            double d = y3 - y2;

            double atanA = Math.Atan2(a, b);
            double atanB = Math.Atan2(c, d);

            return (atanA - atanB) * (-180 / Math.PI);
            // if Second line is counterclockwise from 1st line angle is 
            // positive, else negative
        }
    }
}
