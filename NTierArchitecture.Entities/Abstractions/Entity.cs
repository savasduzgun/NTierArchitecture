namespace NTierArchitecture.Entities.Abstractions
{
    internal abstract class Entity
    {
        public Guid Id { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
