using System;
using CoreGameTemplate.Runtime.Controllers.Game;
using CoreGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CoreGameTemplate.Runtime.Models.Game;
using CoreGameTemplate.Runtime.Signals.CrossScene;
using ModelViewMediatorController.Runtime;
using VContainer.Unity;

namespace CoreGameTemplate.Runtime.Views.Game
{
    public sealed class TutorialPanelMediator : Mediator<TutorialModel, TutorialSettings, TutorialPanelView>,
        IInitializable, IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus.Runtime.SignalBus _signalBus;
        private readonly TutorialPanelActivationController _tutorialPanelActivationController;
        private readonly TutorialCloseButtonController _tutorialCloseButtonController;
        #endregion
        
        #region Constructor
        public TutorialPanelMediator(TutorialModel model, TutorialPanelView view, SignalBus.Runtime.SignalBus signalBus,
            TutorialPanelActivationController tutorialPanelActivationController,
            TutorialCloseButtonController tutorialCloseButtonController) : base(model, view)
        {
            _signalBus = signalBus;
            _tutorialPanelActivationController = tutorialPanelActivationController;
            _tutorialCloseButtonController = tutorialCloseButtonController;
        }
        #endregion

        #region Core
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.CloseButton.onClick.AddListener(OnCloseButtonClicked);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.CloseButton.onClick.RemoveListener(OnCloseButtonClicked);
            }
        }
        #endregion

        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) =>
            _tutorialPanelActivationController.Execute(signal.UIPanelType);
        #endregion

        #region ButtonReceivers
        private void OnCloseButtonClicked() => _tutorialCloseButtonController.Execute();
        #endregion
    }
}