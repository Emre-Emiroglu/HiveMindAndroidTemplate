using CoreGameTemplate.Runtime.Interfaces;
using UnityEngine;

namespace CoreGameTemplate.Runtime.Temp
{
    public abstract class MonoSignalListener : MonoBehaviour, ISignalListenable
    {
        #region Fields
        protected SignalBus.Runtime.SignalBus SignalBus;
        #endregion

        #region PostConstruct
        protected virtual void PostConstruct(SignalBus.Runtime.SignalBus signalBus) => SignalBus = signalBus;
        #endregion

        #region Core
        public virtual void Initialize() => SetSubscriptions(true);
        public virtual void Dispose() => SetSubscriptions(false);
        protected abstract void SetSubscriptions(bool isSubscribed);
        #endregion
    }
}