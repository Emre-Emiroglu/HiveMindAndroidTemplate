using CoreGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CoreGameTemplate.Runtime.Enums.CrossScene;
using CoreGameTemplate.Runtime.Models.CrossScene;
using CoreGameTemplate.Runtime.Signals.CrossScene;
using CoreGameTemplate.Runtime.Views.CrossScene;
using ModelViewMediatorController.Runtime;

namespace CoreGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class MainButtonController : Controller<SettingsModel, Settings, SettingsView>
    {
        #region ReadonylFields
        private readonly SignalBus.Runtime.SignalBus _signalBus;
        private readonly SettingsVerticalGroupController _settingsVerticalGroupController;
        #endregion
        
        #region Constructor
        public MainButtonController(SettingsModel model, SettingsView view, SignalBus.Runtime.SignalBus signalBus,
            SettingsVerticalGroupController settingsVerticalGroupController) : base(model, view)
        {
            _signalBus = signalBus;
            _settingsVerticalGroupController = settingsVerticalGroupController;
        }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            _settingsVerticalGroupController.Execute(!_settingsVerticalGroupController.IsVerticalGroupActive);

            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}