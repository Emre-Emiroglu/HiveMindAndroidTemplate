using CoreGameTemplate.Runtime.Controllers.Bootstrap;
using CoreGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;
using CoreGameTemplate.Runtime.Handlers.Bootstrap;
using CoreGameTemplate.Runtime.Models.Bootstrap;
using CoreGameTemplate.Runtime.Signals.Bootstrap;
using CoreGameTemplate.Runtime.Utilities.Extensions;
using CoreGameTemplate.Runtime.Views.Bootstrap;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CoreGameTemplate.Runtime.Scopes.Bootstrap
{
    public sealed class BootstrapScope : LifetimeScope
    {
        #region Fields
        [Header("Bootstrap Scope Fields")]
        [SerializeField] private BootstrapSettings bootstrapSettings;
        #endregion
        
        #region Bindings
        protected override void Configure(IContainerBuilder builder)
        {
            ModelBindings(builder);
            ControllerBindings(builder);
            MediationBindings(builder);
            HandlerBindings(builder);
        }
        private void ModelBindings(IContainerBuilder builder)
        {
            builder.RegisterInstance(bootstrapSettings).AsSelf();

            builder.Register<BootstrapModel>(Lifetime.Singleton).AsSelf();
        }
        private static void ControllerBindings(IContainerBuilder builder)
        {
            builder.DeclareSignal<InitializeBootstrapSignal>();
            
            builder.RegisterEntryPoint<LogoImageController>().AsSelf();
            builder.RegisterEntryPoint<LogoPanelActivationController>().AsSelf();
            builder.RegisterEntryPoint<LogoTweenController>().AsSelf();
        }
        private static void MediationBindings(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<LogoHolderPanelView>().AsSelf();
            builder.RegisterEntryPoint<LogoHolderPanelMediator>().AsSelf();
        }
        private static void HandlerBindings(IContainerBuilder builder) =>
            builder.RegisterEntryPoint<BootstrapHandler>().AsSelf();
        #endregion

        #region Cycle
        private void Start() => Container.Resolve<SignalBus.Runtime.SignalBus>().Fire(new InitializeBootstrapSignal());
        #endregion
    }
}