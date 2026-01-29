using System;
using CoreGameTemplate.Runtime.Controllers.Game;
using CoreGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CoreGameTemplate.Runtime.Models.Game;
using CoreGameTemplate.Runtime.Signals.CrossScene;
using ModelViewMediatorController.Runtime;
using VContainer.Unity;

namespace CoreGameTemplate.Runtime.Views.Game
{
    public sealed class InGamePanelMediator : Mediator<GameModel, GameSettings, InGamePanelView>, IInitializable,
        IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus.Runtime.SignalBus _signalBus;
        private readonly InGamePanelActivationController _inGamePanelActivationController;
        private readonly WinButtonController _winButtonController;
        private readonly FailButtonController _failButtonController;
        private readonly AddCurrencyButtonController _addCurrencyButtonController;
        #endregion

        #region Constructor
        public InGamePanelMediator(GameModel model, InGamePanelView view, SignalBus.Runtime.SignalBus signalBus,
            InGamePanelActivationController inGamePanelActivationController,
            WinButtonController winButtonController,
            FailButtonController failButtonController,
            AddCurrencyButtonController addCurrencyButtonController) : base(model, view)
        {
            _signalBus = signalBus;
            _inGamePanelActivationController = inGamePanelActivationController;
            _winButtonController = winButtonController;
            _failButtonController = failButtonController;
            _addCurrencyButtonController = addCurrencyButtonController;
        }

        #endregion

        #region Core
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.WinButton.onClick.AddListener(OnWinButtonClicked);
                View.FailButton.onClick.AddListener(OnFailButtonClicked);
                View.AddCurrencyButton.onClick.AddListener(OnAddCurrencyButtonClicked);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.WinButton.onClick.RemoveListener(OnWinButtonClicked);
                View.FailButton.onClick.RemoveListener(OnFailButtonClicked);
                View.AddCurrencyButton.onClick.RemoveListener(OnAddCurrencyButtonClicked);
            }
        }
        #endregion
        
        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) =>
            _inGamePanelActivationController.Execute(signal.UIPanelType);
        #endregion

        #region ButtonReceivers
        private void OnWinButtonClicked() => _winButtonController.Execute();
        private void OnFailButtonClicked() => _failButtonController.Execute();
        private void OnAddCurrencyButtonClicked() => _addCurrencyButtonController.Execute();
        #endregion
    }
}