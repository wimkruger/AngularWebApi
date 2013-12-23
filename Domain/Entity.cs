using System;
namespace Domain
{
    public abstract class Entity
    {
        public virtual int Id { get; set; }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Entity);
        }

        public virtual bool Equals(Entity other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (!IsTransient(this) && !IsTransient(other) && Id == other.Id)
            {
                var otherType = other.GetUnproxiedType();
                var thisType = this.GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                    otherType.IsAssignableFrom(thisType);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id == 0 ? base.GetHashCode() : Id.GetHashCode();
        }

        private static bool IsTransient(Entity obj)
        {
            return obj != null && obj.Id == 0;
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }
    }
}