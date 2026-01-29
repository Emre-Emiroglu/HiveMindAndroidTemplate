using CoreGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CoreGameTemplate.Runtime.Enums.CrossScene;
using CoreGameTemplate.Runtime.Models.CrossScene;
using CoreGameTemplate.Runtime.Models.Game;
using CoreGameTemplate.Runtime.Utilities.Extensions;
using CoreGameTemplate.Runtime.Views.Game;
using ModelViewMediatorController.Runtime;

namespace CoreGameTemplate.Runtime.Controllers.Game
{
    public sealed class InGamePanelActivationController : Controller<GameModel, GameSettings, InGamePanelView>
    {
        #region ReadonlyFields
        private readonly LevelModel _levelModel;
        #endregion
        
        #region Constructor
        public InGamePanelActivationController(GameModel model, InGamePanelView view, LevelModel levelModel) :
            base(model, view) => _levelModel = levelModel;
        #endregion
        
        #region Executes
        public override void Execute(params object[] parameters)
        {
            UIPanelTypes uiPanelType = (UIPanelTypes) parameters[0];
            
            bool isShow = uiPanelType == View.UIPanelVo.UIPanelType;
            
            View.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(isShow);
            
            if (isShow)
                SetLevelText();
        }
        private void SetLevelText()
        {
            int levelNumber = _levelModel.LevelPersistentData.CurrentLevelIndex + 1;
            
            View.LevelText.SetText($"Level {levelNumber}");
        }
        #endregion
    }
}