namespace HackatonBot.Dal.Map
{
   using Entity;

   public class PizzaMap : EntityMap<Pizza>
   {
      #region Public members

      public PizzaMap()
      {
         Map(x => x.Name).Not.Nullable();
         Map(x => x.ExternalId).Not.Nullable();
         Map(x => x.Price).Not.Nullable();
      }

      #endregion
   }
}