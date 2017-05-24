namespace HackatonBot.Dal.Entity
{
   using System;

   public abstract class Entity
   {
      #region Public static members

      public static bool operator ==(Entity left, Entity right)
      {
         if (ReferenceEquals(left, right))
            return true;
         if (ReferenceEquals(left, null))
            return false;

         //We could simply return left.Equals(right) here, but to avoid us having to setup Equals(null) for all strict mocks when 
         //  involved in (<entity> == null) checks, we return immediately here so Equals(null) is never called in that case.
         if (ReferenceEquals(right, null))
            return false;
         return left.Equals(right);
      }

      public static bool operator !=(Entity left, Entity right)
      {
         return !(left == right);
      }

      #endregion

      #region Public members

      public virtual long Id { get; protected set; }


      public virtual long Version { get; protected set; }

      public virtual bool Equals(Entity other)
      {
         if (ReferenceEquals(other, null))
            return false;
         if (ReferenceEquals(other, this))
            return true;

         var thisId = Id;
         var otherId = other.Id;

         //If both objects aren't transient and ids are same, they are equal only if the type are the same
         if (!IsTransient(this) && !IsTransient(other) && Equals(thisId, otherId))
         {
            var thisType = GetUnproxiedType();
            var otherType = other.GetUnproxiedType();
            //If they are same type they are equal since Ids are identicay for non-transient objects.
            //  If using incompatible types, e.g. using Equals(DerivedB, DerivedA), IsAssignableFrom will return false.
            return thisType.IsAssignableFrom(otherType) ||
                   otherType.IsAssignableFrom(thisType);
         }
         return false;
      }

      #endregion

      #region Non-public static members

      private static bool IsTransient(Entity entity)
      {
         return entity != null && Equals(entity.Id, default(long));
      }

      #endregion

      #region Non-public members

      protected virtual Type GetUnproxiedType()
      {
         return GetType();
      }

      #endregion
   }
}