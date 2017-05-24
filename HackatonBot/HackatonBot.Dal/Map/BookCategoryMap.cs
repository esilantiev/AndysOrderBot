namespace HackatonBot.Dal.Map
{
   using Entity.Library;

   public class BookCategoryMap : EntityMap<BookCategory>
   {
      #region Public members

      public BookCategoryMap()
      {
         Map(x => x.Name).Not.Nullable().Unique();
      }

      #endregion
   }
}