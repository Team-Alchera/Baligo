using Microsoft.Xna.Framework;

namespace Baligo.Graphics
{
    public class Animation
    {
        private Rectangle _sourceRectangle;

        private readonly int _rowOfAnimation;
        private readonly int _totalCols;

        private float _elapsedTime;
        private int _frames;
        private readonly int _speed;

        public Animation(int speed, int row, int totalCols)
        {
            this._speed = speed;

            this._rowOfAnimation = row;
            this._totalCols = totalCols;

            this._frames = 0;
        }

        public void Update(GameTime gameTime)
        {
            _elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_elapsedTime >= _speed)
            {
                if (_frames == _totalCols - 1)
                {
                    _frames = 0;
                }
                else
                {
                    _frames++;
                }
                _elapsedTime = 0;
            }

            _sourceRectangle = new Rectangle(64 * _frames , 64 * _rowOfAnimation, 64, 64);
        }

        public Rectangle GetBoundsForFrame()
        {
            return _sourceRectangle;
        }
    }
}
