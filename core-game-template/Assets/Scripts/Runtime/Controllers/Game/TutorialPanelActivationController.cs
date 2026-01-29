using CoreGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CoreGameTemplate.Runtime.Enums.CrossScene;
using CoreGameTemplate.Runtime.Models.Game;
using CoreGameTemplate.Runtime.Utilities.Extensions;
using CoreGameTemplate.Runtime.Views.Game;
using ModelViewMediatorController.Runtime;

namespace CoreGameTemplate.Runtime.Controllers.Game
{
    public sealed class
        TutorialPanelActivationController : Controller<TutorialModel, TutorialSettings, TutorialPanelView>
    {
        #region Constructor
        public TutorialPanelActivationController(TutorialModel model, TutorialPanelView view) : base(model, view) { }
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