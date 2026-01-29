using CoreGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;
using CoreGameTemplate.Runtime.Models.Bootstrap;
using CoreGameTemplate.Runtime.Views.Bootstrap;
using ModelViewMediatorController.Runtime;

namespace CoreGameTemplate.Runtime.Controllers.Bootstrap
{
    public sealed class LogoImageController : Controller<BootstrapModel, BootstrapSettings, LogoHolderPanelView>
    {
        #region Constructor
        public LogoImageController(BootstrapModel model, LogoHolderPanelView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            View.LogoImage.sprite = Model.Settings.LogoSprite;
            View.LogoImage.preserveAspect = true;
        }
        #endregion
    }
}