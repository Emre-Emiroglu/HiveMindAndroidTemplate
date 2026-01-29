using CoreGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CoreGameTemplate.Runtime.Enums.CrossScene;
using CoreGameTemplate.Runtime.Models.Game;
using CoreGameTemplate.Runtime.Signals.CrossScene;
using CoreGameTemplate.Runtime.Signals.Game;
using CoreGameTemplate.Runtime.Views.Game;
using ModelViewMediatorController.Runtime;

namespace CoreGameTemplate.Runtime.Controllers.Game
{
    public sealed class FailButtonController : Controller<GameModel, GameSettings, InGamePanelView>
    {
        #region ReadonlyFields
        private readonly SignalBus.Runtime.SignalBus _signalBus;
        #endregion
        
        #region Constructor
        public FailButtonController(GameModel model, InGamePanelView view, SignalBus.Runtime.SignalBus signalBus) :
            base(model, view) => _signalBus = signalBus;
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            _signalBus.Fire(new GameOverSignal(false));
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}