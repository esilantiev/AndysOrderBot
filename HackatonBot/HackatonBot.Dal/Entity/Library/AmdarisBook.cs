namespace HackatonBot.Dal.Entity.Library
{
   using System;
   using System.Collections.Generic;

   public enum BookStatus
   {
      Undefined = 0,
      Free = 1,
      Read = 2
   }

   public class AmdarisBook : Entity
   {
      #region Public members

      public virtual IList<BookCategory> BookCategories => _bookCategories;

      public virtual string ReadBy { get; protected set; }
      public virtual BookStatus BookStatus { get; protected set; }
      public virtual string Author { get; protected set; }
      public virtual string Name { get; protected set; }

      public AmdarisBook(string author, string name)
      {
         if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException(nameof(author));
         if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(nameof(name));

         Author = author;
         Name = name;
         BookStatus = BookStatus.Free;
      }

      public virtual void Borrow(string readBy)
      {
         ReadBy = readBy;
         BookStatus = BookStatus.Read;
      }

      public virtual void Return()
      {
         ReadBy = null;
         BookStatus = BookStatus.Free;
      }

      public virtual void AssignCategory(BookCategory category)
      {
         _bookCategories.Add(category);
      }

      public override string ToString()
      {
         return $"*{Name}* - '{Author}' " + (BookStatus == BookStatus.Free ? "is available" : "read by " + ReadBy);
      }

      #endregion

      #region Non-public members

      private readonly IList<BookCategory> _bookCategories = new List<BookCategory>();

      protected AmdarisBook()
      {
      }

      #endregion
   }
}