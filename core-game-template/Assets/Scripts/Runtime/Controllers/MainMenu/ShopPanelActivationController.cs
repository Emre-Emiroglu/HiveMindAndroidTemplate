using CoreGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using CoreGameTemplate.Runtime.Enums.CrossScene;
using CoreGameTemplate.Runtime.Models.MainMenu;
using CoreGameTemplate.Runtime.Utilities.Extensions;
using CoreGameTemplate.Runtime.Views.MainMenu;
using ModelViewMediatorController.Runtime;

namespace CoreGameTemplate.Runtime.Controllers.MainMenu
{
    public sealed class ShopPanelActivationController : Controller<MainMenuModel, MainMenuSettings, ShopPanelView>
    {
        #region Constructor
        public ShopPanelActivationController(MainMenuModel model, ShopPanelView view) : base(model, view) { }
        #endregion
        
        #region Executes
        public override void Execute(params object[] parameters)
        {
            UIPanelTypes uiPanelType = (UIPanelTypes) parameters[0];

            View.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(uiPanelType == View.UIPanelVo.UIPanelType);
        }
        #endregion
    }
}