namespace HackatonBot.Dal.Map
{
   using Entity.Library;

   public class AmdarisBookMap : EntityMap<AmdarisBook>
   {
      #region Public members

      public AmdarisBookMap()
      {
         Map(x => x.Name).Not.Nullable().Unique();
         Map(x => x.Author).Not.Nullable();
         Map(x => x.BookStatus).Not.Nullable();
         Map(x => x.ReadBy).Nullable();
         HasManyToMany(x => x.BookCategories).Cascade.SaveUpdate();
      }

      #endregion
   }
}