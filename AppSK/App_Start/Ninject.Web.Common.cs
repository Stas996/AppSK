[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AppSK.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(AppSK.App_Start.NinjectWebCommon), "Stop")]

namespace AppSK.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using AppSK.BLL.Core;
    using AppSK.BLL.Services;
    using AppSK.DAL.Context;
    using AppSK.DAL.Repositories;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<ApplicationDbContext>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>)).InRequestScope();
            kernel.Bind<IProjectsService>().To<ProjectsService>().InRequestScope();
            kernel.Bind<IMarksService>().To<MarksService>().InRequestScope();
            kernel.Bind<IManagersService>().To<ManagersService>().InRequestScope();
            kernel.Bind<IExpertsService>().To<ExpertsService>().InRequestScope();
            kernel.Bind<IStocksService>().To<StocksService>().InRequestScope();
            kernel.Bind<IPortfolioService>().To<PortfolioService>().InRequestScope();
        }        
    }
}