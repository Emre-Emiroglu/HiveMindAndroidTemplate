using CoreGameTemplate.Runtime.Controllers.CrossScene;
using CoreGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CoreGameTemplate.Runtime.Handlers.CrossScene;
using CoreGameTemplate.Runtime.Models.CrossScene;
using CoreGameTemplate.Runtime.Signals.CrossScene;
using CoreGameTemplate.Runtime.Utilities.Extensions;
using CoreGameTemplate.Runtime.Views.CrossScene;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CoreGameTemplate.Runtime.Scopes.CrossScene
{
    public sealed class CrossSceneScope : LifetimeScope
    {
        #region Fields
        [Header("Cross Scene Scope Fields")]
        [SerializeField] private CrossSceneSettings crossSceneSettings;
        [SerializeField] private Settings settings;
        [SerializeField] private CurrencySettings currencySettings;
        [SerializeField] private LevelSettings levelSettings;
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
            builder.RegisterInstance(crossSceneSettings).AsSelf();
            builder.RegisterInstance(settings).AsSelf();
            builder.RegisterInstance(currencySettings).AsSelf();
            builder.RegisterInstance(levelSettings).AsSelf();
            
            builder.Register<CrossSceneModel>(Lifetime.Singleton).AsSelf();
            builder.Register<SettingsModel>(Lifetime.Singleton).AsSelf();
            builder.Register<CurrencyModel>(Lifetime.Singleton).AsSelf();
            builder.Register<LevelModel>(Lifetime.Singleton).AsSelf();
        }
        private static void ControllerBindings(IContainerBuilder builder)
        {
            builder.DeclareSignal<LoadSceneSignal>();
            builder.DeclareSignal<PlayAudioSignal>();
            builder.DeclareSignal<ChangeCurrencySignal>();
            builder.DeclareSignal<RefreshCurrencyVisualSignal>();
            builder.DeclareSignal<ChangeUIPanelSignal>();
            
            builder.RegisterEntryPoint<PlayAudioController>().AsSelf();
            builder.RegisterEntryPoint<AdjustSettingsController>().AsSelf();
        }
        private static void MediationBindings(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<AudioView>();
            
            builder.RegisterEntryPoint<AudioMediator>().AsSelf();
        }
        private static void HandlerBindings(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<CurrencyHandler>().AsSelf();
            builder.RegisterEntryPoint<SceneManagementHandler>().AsSelf();
        }
        #endregion
    }
}