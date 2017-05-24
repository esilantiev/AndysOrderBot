namespace HackatonBot.Dal.Entity.Library
{
   using System;

   public class BookCategory : Entity
   {
      #region Public members

      public virtual string Name { get; protected set; }

      public BookCategory(string name)
      {
         if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(nameof(name));

         Name = name;
      }

      #endregion

      #region Non-public members

      protected BookCategory()
      {
      }

      #endregion
   }
}