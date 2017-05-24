namespace HackatonBot.Dal.Repository.Library
{
   using System.Collections.Generic;
   using System.Linq;
   using Entity.Library;
   using NHibernate.Criterion;
   using NHibernate.Util;

   public class AmdarisBookRepository : Repository<AmdarisBook>
   {
      #region Public members

      public AmdarisBook GetBookByName(string bookName)
      {
         return _session.QueryOver<AmdarisBook>()
                        .Where(x => x.Name == bookName).SingleOrDefault();
      }

      public IList<AmdarisBook> GetBooks()
      {
         return _session.QueryOver<AmdarisBook>().List();
      }

      public IList<AmdarisBook> GetBooks(IList<string> filters)
      {
         if (!EnumerableExtensions.Any(filters))
            return GetBooks();
         BookCategory bookCategory = null;
         IEnumerable<AmdarisBook> q1 = _session.QueryOver<AmdarisBook>()
                                               .JoinAlias(x => x.BookCategories, () => bookCategory)
                                               .Where(()=>bookCategory.Name
                                                                 .IsIn(filters.ToArray()))
                                               .Future();
         IEnumerable<AmdarisBook> q2 =
            _session.QueryOver<AmdarisBook>()
                    .Where(Restrictions.Or(
                       Restrictions.In("Name", filters.ToArray()),
                       Restrictions.In("Author", filters.ToArray())))
                    .Future();

         return q1.Union(q2).ToList();
      }

      public IList<AmdarisBook> GetBooksByCategoryName(string categoryName)
      {
         BookCategory bookCategory = null;
         return _session.QueryOver<AmdarisBook>()
                        .JoinAlias(x => x.BookCategories, () => bookCategory)
                        .Where(() => bookCategory.Name == categoryName)
                        .List();
      }

      #endregion
   }
}