namespace HackatonBot.BookBot.Services
{
   using System.Collections.Generic;
   using Dal.Entity.Library;
   using Dal.Repository.Library;

   public class BookService
   {
      #region Public members
      

      public IList<AmdarisBook> GetBooks(IList<string> filters)
      {
         IList<AmdarisBook> books = bookRepository.GetBooks(filters);
         return books;
      }
      

      public void Update(AmdarisBook book)
      {
         bookRepository.SaveOrUpdate(book);
      }

      #endregion

      #region Non-public members

      private readonly AmdarisBookRepository bookRepository = new AmdarisBookRepository();

      #endregion
   }
}