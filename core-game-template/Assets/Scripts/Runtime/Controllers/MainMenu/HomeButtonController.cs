using CoreGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using CoreGameTemplate.Runtime.Enums.CrossScene;
using CoreGameTemplate.Runtime.Models.MainMenu;
using CoreGameTemplate.Runtime.Signals.CrossScene;
using CoreGameTemplate.Runtime.Views.MainMenu;
using ModelViewMediatorController.Runtime;

namespace CoreGameTemplate.Runtime.Controllers.MainMenu
{
    public sealed class HomeButtonController : Controller<MainMenuModel, MainMenuSettings, ShopPanelView>
    {
        #region ReadonlyFields
        private readonly SignalBus.Runtime.SignalBus _signalBus;
        #endregion
        
        #region Constructor
        public HomeButtonController(MainMenuModel model, ShopPanelView view, SignalBus.Runtime.SignalBus signalBus) :
            base(model, view) => _signalBus = signalBus;
        #endregion
        
        #region Executes
        public override void Execute(params object[] parameters)
        {
            _signalBus.Fire(new ChangeUIPanelSignal(UIPanelTypes.StartPanel));
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}