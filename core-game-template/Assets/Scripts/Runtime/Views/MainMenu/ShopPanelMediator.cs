using System;
using CoreGameTemplate.Runtime.Controllers.MainMenu;
using CoreGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using CoreGameTemplate.Runtime.Models.MainMenu;
using CoreGameTemplate.Runtime.Signals.CrossScene;
using ModelViewMediatorController.Runtime;
using VContainer.Unity;

namespace CoreGameTemplate.Runtime.Views.MainMenu
{
    public sealed class ShopPanelMediator : Mediator<MainMenuModel, MainMenuSettings, ShopPanelView>, IInitializable,
        IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus.Runtime.SignalBus _signalBus;
        private readonly ShopPanelActivationController _shopPanelActivationController;
        private readonly HomeButtonController _homeButtonController;
        #endregion
        
        #region Constructor
        public ShopPanelMediator(MainMenuModel model, ShopPanelView view, SignalBus.Runtime.SignalBus signalBus,
            ShopPanelActivationController shopPanelActivationController,
            HomeButtonController homeButtonController) : base(model, view)
        {
            _signalBus = signalBus;
            _shopPanelActivationController = shopPanelActivationController;
            _homeButtonController = homeButtonController;
        }
        #endregion
        
        #region Core
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.HomeButton.onClick.AddListener(OnHomeButtonClicked);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.HomeButton.onClick.RemoveListener(OnHomeButtonClicked);
            }
        }
        #endregion
        
        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) =>
            _shopPanelActivationController.Execute(signal.UIPanelType);
        #endregion

        #region ButtonReceivers
        private void OnHomeButtonClicked() => _homeButtonController.Execute();
        #endregion
    }
}