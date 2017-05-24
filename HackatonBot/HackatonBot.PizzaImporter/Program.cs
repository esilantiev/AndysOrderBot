
namespace HackatonBot.PizzaImporter
{
    using Dal.Entity;
    using Dal.Repository;

    internal class Program
    {
        #region Non-public static members

      private static void Main(string[] args)
      {
         var pizza = new Pizza("Rancho", 10, "2344");
         var repository = new PizzaRepository();
         repository.SaveOrUpdate(pizza);
      }

        #endregion
    }
}