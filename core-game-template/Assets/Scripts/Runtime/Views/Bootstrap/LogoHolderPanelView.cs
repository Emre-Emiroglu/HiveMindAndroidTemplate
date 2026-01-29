using CoreGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using ModelViewMediatorController.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace CoreGameTemplate.Runtime.Views.Bootstrap
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class LogoHolderPanelView : View
    {
        #region Fields
        [Header("Bootstrap Panel View Fields")]
        [SerializeField] private UIPanelVo uiPanelVo;
        [SerializeField] private Image logoImage;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => uiPanelVo;
        public Image LogoImage => logoImage;
        #endregion
    }
}
