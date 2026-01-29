using System;
using AYellowpaper.SerializedCollections;
using CoreGameTemplate.Runtime.Enums.CrossScene;
using ModelViewMediatorController.Runtime;
using UnityEngine;

namespace CoreGameTemplate.Runtime.Views.CrossScene
{
    public sealed class AudioView : View
    {
        #region Actions
        public event Action StartAction;
        #endregion
        
        #region Fields
        [Header("Audio View Fields")]
        [SerializeField] private SerializedDictionary<AudioTypes, AudioSource> audioSources;
        #endregion

        #region Getters
        public SerializedDictionary<AudioTypes, AudioSource> AudioSources => audioSources;
        #endregion

        #region Core
        private void Start() => StartAction?.Invoke();
        #endregion
    }
}