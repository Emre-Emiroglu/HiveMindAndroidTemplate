using CoreGameTemplate.Runtime.Controllers.MainMenu;
using CoreGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using CoreGameTemplate.Runtime.Handlers.MainMenu;
using CoreGameTemplate.Runtime.Models.MainMenu;
using CoreGameTemplate.Runtime.Signals.MainMenu;
using CoreGameTemplate.Runtime.Utilities.Extensions;
using CoreGameTemplate.Runtime.Views.MainMenu;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CoreGameTemplate.Runtime.Scopes.MainMenu
{
    public sealed class MainMenuScope : LifetimeScope
    {
        #region Fields
        [Header("Main Menu Scope Fields")]
        [SerializeField] private MainMenuSettings mainMenuSettings;
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
            builder.RegisterInstance(mainMenuSettings).AsSelf();

            builder.Register<MainMenuModel>(Lifetime.Singleton).AsSelf();
        }
        private void ControllerBindings(IContainerBuilder builder)
        {
            builder.DeclareSignal<InitializeMainMenuSignal>();
            
            builder.RegisterEntryPoint<StartPanelActivationController>().AsSelf();
            builder.RegisterEntryPoint<PlayButtonController>().AsSelf();
            builder.RegisterEntryPoint<ShopPanelActivationController>().AsSelf();
            builder.RegisterEntryPoint<HomeButtonController>().AsSelf();
        }
        private void MediationBindings(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<StartPanelView>().AsSelf();
            builder.RegisterComponentInHierarchy<ShopPanelView>().AsSelf();
            
            builder.RegisterEntryPoint<StartPanelMediator>().AsSelf();
            builder.RegisterEntryPoint<ShopPanelMediator>().AsSelf();
        }
        private void HandlerBindings(IContainerBuilder builder) =>
            builder.RegisterEntryPoint<MainMenuHandler>().AsSelf();
        #endregion

        #region Cycle
        private void Start() => Container.Resolve<SignalBus.Runtime.SignalBus>().Fire(new InitializeMainMenuSignal());
        #endregion
    }
}