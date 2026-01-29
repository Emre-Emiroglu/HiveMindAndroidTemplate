using CoreGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CoreGameTemplate.Runtime.Models.CrossScene;
using CoreGameTemplate.Runtime.Views.CrossScene;
using ModelViewMediatorController.Runtime;

namespace CoreGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class SettingsVerticalGroupController : Controller<SettingsModel, Settings, SettingsView>
    {
        #region Properities
        public bool IsVerticalGroupActive { get; private set; }
        #endregion
        
        #region Constructor
        public SettingsVerticalGroupController(SettingsModel model, SettingsView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            bool isActive = (bool) parameters[0];
            
            IsVerticalGroupActive = isActive;
            View.VerticalGroup.SetActive(IsVerticalGroupActive);
        }
        #endregion
    }
}