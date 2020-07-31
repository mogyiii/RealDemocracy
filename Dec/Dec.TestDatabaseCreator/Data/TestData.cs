using NHibernate;
using System;
using Dec.Shared.Interfaces.DomainModel.Entity;

namespace Dec.TestDatabaseCreator.Data
{
    static partial class TestData
    {
        internal static ISession session;

        internal static void InsertEntity(IEntity entity)
        {
            if (session == null)
                throw new InvalidOperationException("Session must be provided!");

            session.Save(entity);
            Console.WriteLine($"INSERTED {entity.ToString()} ({entity.Id})");
        }
    }
}
