using UnityEngine;

namespace CoreGameTemplate.Runtime.Data.ScriptableObjects.Application
{
    [CreateAssetMenu(fileName = "ApplicationSettings", menuName = "CoreGameTemplate/Application/ApplicationSettings")]
    public sealed class ApplicationSettings : ScriptableObject
    {
        #region Fields
        [Header("Application Settings Fields")]
        [Range(30, 240)] [SerializeField] private int maxFrameRate;
        [SerializeField] private bool runInBackground;
        #endregion

        #region Getters
        public int MaxFrameRate => maxFrameRate;
        public bool RunInBackground => runInBackground;
        #endregion
    }
}
