using CoreGameTemplate.Runtime.Controllers.CrossScene;
using CoreGameTemplate.Runtime.Views.CrossScene;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CoreGameTemplate.Runtime.Scopes.CrossScene
{
    public sealed class CurrencyScope : LifetimeScope
    {
        #region Fields
        [Header("Currency Scope Fields")]
        [SerializeField] private CurrencyView currencyView;
        #endregion
        
        #region Bindings
        protected override void Configure(IContainerBuilder builder)
        {
            ControllerBindings(builder);
            MediationBindings(builder);
        }
        private static void ControllerBindings(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<CurrencyDisplayController>().AsSelf();
            builder.RegisterEntryPoint<CurrencyButtonController>().AsSelf();
        }
        private void MediationBindings(IContainerBuilder builder)
        {
            builder.RegisterInstance(currencyView).AsSelf();
            
            builder.RegisterEntryPoint<CurrencyMediator>().AsSelf();
        }
        #endregion
    }
}