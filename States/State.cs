namespace Baligo.State
{
    public abstract class State
    {
        public abstract void Update();

        public abstract void Draw();

        public abstract void Init();
    }
}