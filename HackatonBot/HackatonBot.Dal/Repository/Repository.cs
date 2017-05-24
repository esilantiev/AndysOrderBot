namespace HackatonBot.Dal.Repository
{
   using Entity;
   using Nhibernate;
   using NHibernate;

   public abstract class Repository<TEntity> where TEntity : Entity
   {
      #region Public members

      public void SaveOrUpdate(TEntity entity)
      {
         using (ITransaction transaction = _session.BeginTransaction())
         {
            _session.SaveOrUpdate(entity);
            transaction.Commit();
         }
      }

      public TEntity Get(TEntity entity)
      {
         return _session.Get<TEntity>(entity);
      }

      public void RegenerateSession()
      {
         _session = SessionGenerator.Instance.GetSession();
      }

      #endregion

      #region Non-public members

      protected ISession _session = SessionGenerator.Instance.GetSession();

      #endregion
   }
}