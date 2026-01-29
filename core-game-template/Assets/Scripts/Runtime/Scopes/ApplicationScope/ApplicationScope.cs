using CoreGameTemplate.Runtime.Data.ScriptableObjects.Application;
using CoreGameTemplate.Runtime.Handlers.Application;
using CoreGameTemplate.Runtime.Models.Application;
using CoreGameTemplate.Runtime.Signals.Application;
using CoreGameTemplate.Runtime.Utilities.Extensions;
using PersistentData.Runtime;
using Pool.Runtime;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CoreGameTemplate.Runtime.Scopes.ApplicationScope
{
    public sealed class ApplicationScope : LifetimeScope
    {
        #region Fields
        [Header("Application Scope Fields")]
        [SerializeField] private ApplicationSettings applicationSettings;
        [SerializeField] private PoolConfig poolConfig;
        #endregion
        
        #region Bindings
        protected override void Configure(IContainerBuilder builder)
        {
            ServiceBindings(builder);
            ModelBindings(builder);
            ControllerBindings(builder);
            HandlerBindings(builder);
        }
        private void ServiceBindings(IContainerBuilder builder)
        {
            PersistentDataServiceUtilities.Initialize();
            
            builder.RegisterSignalBus();
            builder.RegisterPoolService(poolConfig);
        }
        private void ModelBindings(IContainerBuilder builder)
        {
            builder.RegisterInstance(applicationSettings).AsSelf();
            
            builder.Register<ApplicationModel>(Lifetime.Singleton).AsSelf();
        }
        private static void ControllerBindings(IContainerBuilder builder)
        {
            builder.DeclareSignal<InitializeApplicationSignal>();
            builder.DeclareSignal<QuitApplicationSignal>();
        }
        private static void HandlerBindings(IContainerBuilder builder) =>
            builder.RegisterEntryPoint<ApplicationHandler>().AsSelf();
        #endregion

        #region Cycle
        private void Start() =>
            Container.Resolve<SignalBus.Runtime.SignalBus>().Fire(new InitializeApplicationSignal());
        #endregion
    }
}