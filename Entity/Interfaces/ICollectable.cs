namespace Baligo.Entity.Interfaces
{
    public interface ICollectable
    {
        int HealthPoints { get; set; }
        int DamagePoints { get; set; }
        int ManaPoints { get; set; }

        bool IsItemCollected();
    }
}
