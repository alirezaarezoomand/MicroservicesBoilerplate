namespace Seedworks.Core.Domain
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; protected set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            var otherEntity = obj as Entity<TKey>;
            if (otherEntity == null) return false;
            return Id.Equals(otherEntity.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
