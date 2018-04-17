using System;

namespace SharedKernel
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastChanged { get; set; }

        public virtual bool Equals(Entity<TId> otherObject)
        {
            var entity = otherObject as Entity<TId>;
            if (entity != null)
            {
                return this.Equals(entity);
            }
            return base.Equals(otherObject);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
