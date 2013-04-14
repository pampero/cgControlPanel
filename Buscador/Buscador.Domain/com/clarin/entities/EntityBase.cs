using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buscador.Domain.com.clarin.entities
{
    public class EntityBase<TEntity> where TEntity : EntityBase<TEntity>
    {
        //private int? oldHashCode;

        public virtual int Id { get; set; }

        public virtual bool Equals(EntityBase<TEntity> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Id, Id);
        }

        //Commente por ahora el GetHashCode ver si se usa
        /*public override int GetHashCode()
         {
             // Once we have a hash code we'll never change it
             if (oldHashCode.HasValue)
                 return oldHashCode.Value;
             var thisIsTransient = Equals(Guid, Guid.Empty);
             // When this instance is transient, we use the base GetHashCode()
             // and remember it, so an instance can NEVER change its hash code.
             if (thisIsTransient)
             {
                 oldHashCode = base.GetHashCode();
                 return oldHashCode.Value;
             }
             return Guid.GetHashCode();
         }*/


        /* public override bool Equals(object obj)
          {
              if (this == obj) return true;
              TEntity other = obj as TEntity;
              if (other == null) return false;
              return !(Guid == other.Guid); 
          }*/


        public override bool Equals(object obj)
        {
            var other = obj as TEntity;

            if (other == null)
                return false;
            //handle the case of comparing two NEW objects
            var otherIsTransient = Equals(other.Id, 0);
            var thisIsTransient = Equals(Id, 0);

            if (otherIsTransient && thisIsTransient)
                return ReferenceEquals(other, this);
            return other.Id.Equals(Id);

        }
    }
}
