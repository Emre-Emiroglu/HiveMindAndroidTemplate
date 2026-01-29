using CoreGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;
using CoreGameTemplate.Runtime.Models.Bootstrap;
using CoreGameTemplate.Runtime.Utilities.Extensions;
using CoreGameTemplate.Runtime.Views.Bootstrap;
using ModelViewMediatorController.Runtime;

namespace CoreGameTemplate.Runtime.Controllers.Bootstrap
{
    public sealed class
        LogoPanelActivationController : Controller<BootstrapModel, BootstrapSettings, LogoHolderPanelView>
    {
        #region Constructor
        public LogoPanelActivationController(BootstrapModel model, LogoHolderPanelView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters) =>
            View.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(true);
        #endregion
    }
}