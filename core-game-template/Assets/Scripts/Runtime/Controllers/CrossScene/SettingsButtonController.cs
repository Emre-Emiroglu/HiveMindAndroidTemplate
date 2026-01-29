using CoreGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CoreGameTemplate.Runtime.Enums.CrossScene;
using CoreGameTemplate.Runtime.Models.CrossScene;
using CoreGameTemplate.Runtime.Signals.CrossScene;
using CoreGameTemplate.Runtime.Views.CrossScene;
using ModelViewMediatorController.Runtime;

namespace CoreGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class SettingsButtonController : Controller<SettingsModel, Settings, SettingsView>
    {
        #region ReadonylFields
        private readonly SignalBus.Runtime.SignalBus _signalBus;
        private readonly SettingsButtonVisualController _settingsButtonVisualController;
        #endregion
        
        #region Constructor
        public SettingsButtonController(SettingsModel model, SettingsView view, SignalBus.Runtime.SignalBus signalBus,
            SettingsButtonVisualController settingsButtonVisualController) : base(model, view)
        {
            _signalBus = signalBus;
            _settingsButtonVisualController = settingsButtonVisualController;
        }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            SettingsTypes settingsType = (SettingsTypes) parameters[0];
            
            switch (settingsType)
            {
                case SettingsTypes.Music:
                    Model.SetMusic(!Model.SettingsPersistentData.IsMusicMuted);
                    break;
                case SettingsTypes.Sound:
                    Model.SetSound(!Model.SettingsPersistentData.IsSoundMuted);
                    break;
                case SettingsTypes.Haptic:
                    Model.SetHaptic(!Model.SettingsPersistentData.IsHapticMuted);
                    break;
            }
            
            _settingsButtonVisualController.Execute(settingsType);

            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}