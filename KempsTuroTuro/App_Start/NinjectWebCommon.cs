using KempsTuroTuro.DAL;
using KempsTuroTuro.Interface;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(KempsTuroTuro.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(KempsTuroTuro.NinjectWebCommon), "Stop")]

namespace KempsTuroTuro
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

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
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<IDatabaseFactory>().To<DatabaseFactory>().InRequestScope();
                /*
                kernel.Bind<ICharterRepository>().To<CharterRepository>().InRequestScope();
                kernel.Bind<ICharterAttachmentRepository>().To<CharterAttachmentRepository>().InRequestScope();
                kernel.Bind<ICharterFundingRepository>().To<CharterFundingRepository>().InRequestScope();
                kernel.Bind<ICostAllocationRepository>().To<CostAllocationRepository>().InRequestScope();
                kernel.Bind<ICategorizationRepository>().To<CategorizationRepository>().InRequestScope();
                kernel.Bind<IFelStageRepository>().To<FelStageRepository>().InRequestScope();
                kernel.Bind<IFundingTypeRepository>().To<FundingTypeRepository>().InRequestScope();
                kernel.Bind<IHardSoftRepository>().To<HardSoftRepository>().InRequestScope();
                kernel.Bind<IIntangibleRepository>().To<IntangibleRepository>().InRequestScope();
                kernel.Bind<IProjectRepository>().To<ProjectRepository>().InRequestScope();
                kernel.Bind<IRefreshGrowRepository>().To<RefreshGrowRepository>().InRequestScope();
                kernel.Bind<ITangibleRepository>().To<TangibleRepository>().InRequestScope();
                kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
                kernel.Bind<ICharterStateWorkflowRepository>().To<CharterStateWorkflowRepository>().InRequestScope();
                kernel.Bind<IWbsCodeRepository>().To<WbsCodeRepository>().InRequestScope();
                kernel.Bind<IStateTypeRepository>().To<StateTypeRepository>().InRequestScope();
                kernel.Bind<IStatusLookupRepository>().To<StatusLookupRepository>().InRequestScope();
                kernel.Bind<IStateStatusRepository>().To<StateStatusRepository>().InRequestScope();
                kernel.Bind<IStateWorkflowRepository>().To<StateWorkflowRepository>().InRequestScope();
                kernel.Bind<ICharterCommentRepository>().To<CharterCommentRepository>().InRequestScope();
                kernel.Bind<IEmailConditionRepository>().To<EmailConditionRepository>().InRequestScope();
                kernel.Bind<IEmailTemplateRepository>().To<EmailTemplateRepository>().InRequestScope();
                kernel.Bind<IChangeStateRules>().To<ChangeStateRules>().InRequestScope();

                kernel.Bind<ICharterService>().To<CharterService>().InRequestScope();
                kernel.Bind<IProjectService>().To<ProjectService>().InRequestScope();
                kernel.Bind<IUserService>().To<UserService>().InRequestScope();
                kernel.Bind<IAttachmentService>().To<AttachmentService>().InRequestScope();
                kernel.Bind<IFundingService>().To<FundingService>().InRequestScope();
                kernel.Bind<ITangibleService>().To<TangibleService>().InRequestScope();
                kernel.Bind<IIntangibleService>().To<IntangibleService>().InRequestScope();
                kernel.Bind<ICharterStateWorkflowService>().To<CharterStateWorkflowService>().InRequestScope();
                kernel.Bind<IWbsCodeService>().To<WbsCodeService>().InRequestScope();
                kernel.Bind<IEmailTemplateService>().To<EmailTemplateService>().InRequestScope();
                kernel.Bind<ICategorizationService>().To<CategorizationService>().InRequestScope();
                kernel.Bind<IFinishCharterService>().To<FinishCharterService>().InRequestScope();
                kernel.Bind<ICharterCreateMapper>().To<CharterCreateMapper>().InRequestScope();
                kernel.Bind<ICharterUpdateMapper>().To<CharterUpdateMapper>().InRequestScope();
                kernel.Bind<ICharterDisplayMapper>().To<CharterDisplayMapper>().InRequestScope();
                kernel.Bind<ICharterDetailsMapper>().To<CharterDetailsMapper>().InRequestScope();
                kernel.Bind<ITangibleCreateMapper>().To<TangibleCreateMapper>().InRequestScope();
                kernel.Bind<IIntangibleCreateMapper>().To<IntangibleCreateMapper>().InRequestScope();
                kernel.Bind<ICharterFundingCreateMapper>().To<CharterFundingCreateMapper>().InRequestScope();
                kernel.Bind<IAttachmentCreateMapper>().To<AttachmentCreateMapper>().InRequestScope();
                kernel.Bind<IProjectCreateMapper>().To<ProjectCreateMapper>().InRequestScope();
                kernel.Bind<IWbsCodeCreateMapper>().To<WbsCodeCreateMapper>().InRequestScope();

                kernel.Bind<IAttachmentUpdateMapper>().To<AttachmentUpdateMapper>().InRequestScope();
                kernel.Bind<ICharterFundingUpdateMapper>().To<CharterFundingUpdateMapper>().InRequestScope();
                kernel.Bind<IIntangibleUpdateMapper>().To<IntangibleUpdateMapper>().InRequestScope();
                kernel.Bind<ITangibleUpdateMapper>().To<TangibleUpdateMapper>().InRequestScope();
                kernel.Bind<IWbsCodeUpdateMapper>().To<WbsCodeUpdateMapper>().InRequestScope();

                kernel.Bind<ICharterPopulate>().To<CharterPopulate>().InRequestScope();
                kernel.Bind<ICharterRules>().To<CharterRules>().InRequestScope();

                kernel.Bind<IExpenseRepository>().To<ExpenseRepository>().InRequestScope();
                */
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }        
    }
}
