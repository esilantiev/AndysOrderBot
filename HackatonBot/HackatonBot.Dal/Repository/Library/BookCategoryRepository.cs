namespace HackatonBot.Dal.Repository.Library
{
   using Entity.Library;

   public class BookCategoryRepository : Repository<BookCategory>
   {
      #region Public members

      public BookCategory FindBookCategoryByName(string categoryName)
      {
         return _session.QueryOver<BookCategory>()
                        .Where(x => x.Name == categoryName)
                        .SingleOrDefault();
      }

      #endregion
   }
}