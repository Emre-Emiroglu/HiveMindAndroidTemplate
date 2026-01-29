using System;
using System.Linq;
using CoreGameTemplate.Runtime.Controllers.CrossScene;
using CoreGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CoreGameTemplate.Runtime.Enums.CrossScene;
using CoreGameTemplate.Runtime.Models.CrossScene;
using CoreGameTemplate.Runtime.Signals.CrossScene;
using ModelViewMediatorController.Runtime;
using VContainer.Unity;

namespace CoreGameTemplate.Runtime.Views.CrossScene
{
    public sealed class CurrencyMediator : Mediator<CurrencyModel, CurrencySettings, CurrencyView>, IInitializable,
        IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus.Runtime.SignalBus _signalBus;
        private readonly CurrencyDisplayController _currencyDisplayController;
        private readonly CurrencyButtonController _currencyButtonController;
        #endregion

        #region Constructor
        public CurrencyMediator(CurrencyModel model, CurrencyView view, SignalBus.Runtime.SignalBus signalBus,
            CurrencyDisplayController currencyDisplayController,
            CurrencyButtonController currencyButtonController) : base(model, view)
        {
            _signalBus = signalBus;
            _currencyDisplayController = currencyDisplayController;
            _currencyButtonController = currencyButtonController;
        }
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();

            _currencyDisplayController.Execute(CurrencyTypes.Coin, true);
        }
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<RefreshCurrencyVisualSignal>(OnRefreshCurrencyVisualSignal);
                
                View.CurrencyButtons.Values.ToList().ForEach(x => x.onClick.AddListener(OnButtonClicked));
            }
            else
            {
                _signalBus.Unsubscribe<RefreshCurrencyVisualSignal>(OnRefreshCurrencyVisualSignal);
                
                View.CurrencyButtons.Values.ToList().ForEach(x => x.onClick.RemoveAllListeners());
            }
        }
        #endregion

        #region SignalReceivers
        private void OnRefreshCurrencyVisualSignal(RefreshCurrencyVisualSignal signal) =>
            _currencyDisplayController.Execute(signal.CurrencyType, false);
        #endregion

        #region ButtonReceivers
        private void OnButtonClicked() => _currencyButtonController.Execute();
        #endregion
    }
}