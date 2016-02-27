using System;
using System.Collections.Generic;

namespace Core.General
{
    public abstract class Entity<TId>: IEquatable<Entity<TId>>
    {    
        public TId Id { get; }

        protected Entity(TId id)
        {
            if (Equals(id, default(TId)))
            {
                throw new ArgumentException("The ID cannot be the type's default value.", nameof(id));
            }
            Id = id;
        }


        public bool Equals(Entity<TId> other)
        {            
            if (ReferenceEquals(other, null)) return false;
            return ReferenceEquals(this, other) || Id.Equals(other.Id);
            //if (GetType() != other.GetType()) return false;
            //if (EqualityComparer<TId>.Default.Equals(Id, default(TId)) ||
            //    EqualityComparer<TId>.Default.Equals(other.Id, default(TId))) return false;
        }

        public override bool Equals(object other)
        {
            return Equals(other as Entity<TId>);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        public static bool operator ==(Entity<TId> a, Entity<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.Equals(b);
        }

        public static bool operator !=(Entity<TId> a, Entity<TId> b)
        {
            return !(a == b);
        }
    }
}
