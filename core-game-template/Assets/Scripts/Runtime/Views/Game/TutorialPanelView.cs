using CoreGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using ModelViewMediatorController.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace CoreGameTemplate.Runtime.Views.Game
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class TutorialPanelView : View
    {
        #region Fields
        [Header("Tutorial Panel View Fields")]
        [SerializeField] private UIPanelVo uiPanelVo;
        [SerializeField] private Button closeButton;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => uiPanelVo;
        public Button CloseButton => closeButton;
        #endregion
    }
}