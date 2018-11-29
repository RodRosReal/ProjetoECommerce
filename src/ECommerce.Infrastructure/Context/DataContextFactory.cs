using ECommerce.Infrastructure.Context.DataContextStorage;
using ECommerce.Infrastructure.Diagram;

namespace ECommerce.Infrastructure.Context
{
    public static class DataContextFactory
    {
        public static void Clear()
        {
            var dataContextStorageContainer = DataContextStorageFactory<PrincipalDbContextContainer>.CreateStorageContainer();
            dataContextStorageContainer.Clear();
        }

        public static PrincipalDbContextContainer GetDataContext()
        {
            var dataContextStorageContainer = DataContextStorageFactory<PrincipalDbContextContainer>.CreateStorageContainer();
            var contactManagerContext = dataContextStorageContainer.GetDataContext();
            if (contactManagerContext == null)
            {
                contactManagerContext = new PrincipalDbContextContainer();
                dataContextStorageContainer.Store(contactManagerContext);
            }
            return contactManagerContext;
        }
    }
}
