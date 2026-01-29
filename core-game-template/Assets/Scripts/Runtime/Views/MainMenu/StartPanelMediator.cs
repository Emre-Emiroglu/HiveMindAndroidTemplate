using System;
using CoreGameTemplate.Runtime.Controllers.MainMenu;
using CoreGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using CoreGameTemplate.Runtime.Models.MainMenu;
using CoreGameTemplate.Runtime.Signals.CrossScene;
using ModelViewMediatorController.Runtime;
using VContainer.Unity;

namespace CoreGameTemplate.Runtime.Views.MainMenu
{
    public sealed class StartPanelMediator : Mediator<MainMenuModel, MainMenuSettings, StartPanelView>, IInitializable,
        IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus.Runtime.SignalBus _signalBus;
        private readonly StartPanelActivationController _startPanelActivationController;
        private readonly PlayButtonController _playButtonController;
        #endregion

        #region Constructor
        public StartPanelMediator(MainMenuModel model, StartPanelView view, SignalBus.Runtime.SignalBus signalBus,
            StartPanelActivationController startPanelActivationController,
            PlayButtonController playButtonController) : base(model, view)
        {
            _signalBus = signalBus;
            _startPanelActivationController = startPanelActivationController;
            _playButtonController = playButtonController;
        }
        #endregion

        #region Core
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);
                
                View.PlayButton.onClick.AddListener(OnPlayButtonClicked);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);
                
                View.PlayButton.onClick.RemoveListener(OnPlayButtonClicked);
            }
        }
        #endregion

        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) =>
            _startPanelActivationController.Execute(signal.UIPanelType);
        #endregion
        
        #region ButtonReceivers
        private void OnPlayButtonClicked() => _playButtonController.Execute();
        #endregion
    }
}