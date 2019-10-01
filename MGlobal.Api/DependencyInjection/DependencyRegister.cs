using MGlobal.Core.Data.Services;
using MGlobal.Core.Domain.Contracts;
using MGlobal.Core.Factory;
using MGlobal.Core.Manager;
using Unity;

namespace MGlobal.Api.DependencyInjection
{
    public class DependencyRegister
    {
        public static void RegisterTypes(IUnityContainer diContainer)
        {
            diContainer.RegisterInstance<IHttpService>(new HttpService());
            diContainer.RegisterInstance<IEmployeeFactory>(new EmployeeFactory());
            diContainer.RegisterInstance<IEmployeeClientService>(new EmployeeClientService(diContainer.Resolve<IHttpService>()));
            diContainer.RegisterInstance<IEmployeeManager>(new EmployeeManager(diContainer.Resolve<IEmployeeClientService>(), diContainer.Resolve<IEmployeeFactory>()));
        }
    }
}
