using Autofac;
using AutomationFramework.PageObjects;
using AutomationFramework.PageObjects.PageParts;
using AutomationFramework.PageServices;
using OpenQA.Selenium;

namespace AutomationFramework.Utils
{
    static class ObjectFactory
    {
        private static IContainer _container;
        
        static ObjectFactory()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CloudGoogleCalculatorPage>()
                .As<ICloudGoogleCalculatorPage>().InstancePerDependency();

            builder.RegisterType<CalculatorPart>()
                .As<ICalculatorPart>().UsingConstructor(typeof(string), typeof(IWebDriver)).InstancePerDependency();

            builder.RegisterType<InstancesArea>()
                .As<IInstancesArea>().UsingConstructor(typeof(string), typeof(IWebDriver)).InstancePerDependency();

            builder.RegisterType<SoleTenantNodesArea>()
                .As<ISoleTenantNodesArea>().UsingConstructor(typeof(string), typeof(IWebDriver)).InstancePerDependency();

            builder.RegisterType<CalculatorService>()
                .As<ICalculatorService>().InstancePerDependency();

            builder.Register<IWebDriver>(context => BrowserFactory.Instance).InstancePerDependency();
            _container = builder.Build();

        }

        public static T Get<T>(params object[] args)
        {
            var constructorArguments = args.Select(x => new TypedParameter(x.GetType(), x));
            return _container.Resolve<T>(constructorArguments);
        }

    }
}