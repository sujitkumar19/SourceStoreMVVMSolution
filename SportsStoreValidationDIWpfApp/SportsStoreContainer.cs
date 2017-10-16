using Microsoft.Practices.Unity;
using SportsStoreDomainLibrary2.Abstract;
using SportsStoreDomainLibrary2.Concrete;

namespace SportsStoreValidationDIWpfApp
{
    class SportsStoreContainer
    {
        private static UnityContainer _UnityContainer;

        static SportsStoreContainer() {
            _UnityContainer = new UnityContainer();
            AddBindings();
        }

        public static UnityContainer Container { get { return _UnityContainer; } }

        public static void AddBindings() {
            //ContainerControlledLifetimeManager this create singleton object
            _UnityContainer.RegisterType<iProductRepository, FfProductRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
